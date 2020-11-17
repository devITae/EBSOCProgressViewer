Public Class ClassSearch
    Dim server_addr, Shost, LType As String
    Dim http As Object
    Private Sub ClassSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True '항상 위
        http = Form1.http
        ProgressBar1.Style = ProgressBarStyle.Blocks
        server_addr = "https://paran.be/oc"
        Me.StartDate.Value = DateTime.Today.AddDays(-30) '-30일
        Me.EndDate.Value = DateTime.Today 'Today
        gbox.Text = My.Settings.gCode
        cbox.Text = My.Settings.cCode
        nbox.Text = My.Settings.nCode
        Label6.Visible = False
        lrnType.Text = "학습중"
        LType = "LRN"
        Shost = My.Settings.SchHost
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If gbox.Text.Trim() = "" Or cbox.Text.Trim() = "" Or nbox.Text.Trim() = "" Then
            MsgBox("학번을 입력하여주세요.", MsgBoxStyle.Exclamation, "알림")
        Else
            My.Settings.gCode = gbox.Text
            My.Settings.cCode = cbox.Text
            My.Settings.nCode = nbox.Text
            My.Settings.Save()

            Dim httpes As Object
            httpes = CreateObject("WinHttp.WinHttpRequest.5.1")
            Dim shtml, result_name As String

            httpes.Open("GET", server_addr & "/class_search.php?school=" & Form1.SCodeBox.Text & "&grade=" & gbox.Text & "&class=" & cbox.Text)
            httpes.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            httpes.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
            httpes.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
            httpes.Send()
            httpes.WaitForResponse()
            Application.DoEvents()
            shtml = System.Text.Encoding.UTF8.GetString(httpes.ResponseBody)

            If InStr(shtml, Form1.SCodeBox.Text) Then
                result_name = Split(Split(shtml, "이름(")(1), ")")(0)
                Label5.Text = gbox.Text & "학년 " & cbox.Text & "반" & vbCrLf & "담임: " & result_name
                Label5.Visible = True  '반, 담임정보

                Me.Cursor = Cursors.WaitCursor '로딩 커서
                Label6.Text = "최근 한 달간의 기록을 불러오는 중입니다.." & vbCrLf & "강의의 양에 따라 시간이 오래걸릴 수 있습니다."
                Label6.Visible = True
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Button1.Enabled = False
                gbox.Enabled = False
                cbox.Enabled = False
                nbox.Enabled = False

                Call Me.CallNokori()
                Application.DoEvents()

                Call uploadData()
                Me.Close()
                MsgBox("전송이 완료되었습니다.", MsgBoxStyle.Exclamation, "알림")
            Else
                MsgBox("등록된 사용자가 아닙니다.", MsgBoxStyle.Exclamation, "알림")
                'MsgBox(server_addr & "/class_search.php?school=" & Form1.SCodeBox.Text & "&grade=" & gbox.Text & "&class=" & cbox.Text)
                'MsgBox(shtml)
            End If
        End If
    End Sub

    Public Sub uploadData()
        Dim className, courseName, status, co_date As String
        Do Until Me.StatusList.Items.Count + Me.ErrorList.Items.Count = 0
            With Me.StatusList
                For i = 0 To .Items.Count - 1
                    'If status <> "100" Then '진도율이 100이 아닐때
                    'If .Items(i).Selected = True Then 'Test
                    className = .Items(i).SubItems(0).Text.Trim() '클래스명
                    courseName = .Items(i).SubItems(1).Text.Trim() '강의명
                    status = .Items(i).SubItems(2).Text '진도율
                    co_date = Replace(.Items(i).SubItems(3).Text, ".", "-") '날짜

                    Dim http3 As Object
                    http3 = CreateObject("WinHttp.WinHttpRequest.5.1")

                    'Console.WriteLine(vbCrLf & "name=" & Form1.SName & "&ebs_id=" & Form1.IDBox.Text & "&class_name=" & className & "&course_name=" & courseName & "&status=" & status & "&co_date=" & co_date)
                    Try
                        http3.Open("POST", server_addr & "/upload.php")
                        http3.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                        http3.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                        http3.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                        http3.Send("name=" & Form1.SName & "&ebs_id=" & Form1.IDBox.Text & "&s_grade=" & gbox.Text & "&s_class=" & cbox.Text & "&s_num=" & nbox.Text & "&class_name=" & className & "&course_name=" & courseName & "&status=" & status & "&co_date=" & co_date)
                        http3.WaitForResponse(1000)
                        Application.DoEvents()
                    Catch
                        Dim CListDesu As New ListViewItem(className, i - 1) '과목 제목
                        Me.ErrorList.Items.AddRange(New ListViewItem() {CListDesu})
                        CListDesu.SubItems.Add(courseName) '진도 이름
                        CListDesu.SubItems.Add(status) '진도율
                        CListDesu.SubItems.Add(co_date) '날짜
                        Application.DoEvents()
                    End Try
                Next i
                Me.StatusList.Clear()
                If Me.ErrorList.Items(0).SubItems(0).Text = "error" Then
                    Me.ErrorList.Items(0).Remove()
                End If
            End With

            With Me.ErrorList
                For i = 0 To .Items.Count - 1
                    className = .Items(i).SubItems(0).Text.Trim() '클래스명
                    courseName = .Items(i).SubItems(1).Text.Trim() '강의명
                    status = .Items(i).SubItems(2).Text '진도율
                    co_date = Replace(.Items(i).SubItems(3).Text, ".", "-") '날짜

                    Dim http3 As Object
                    http3 = CreateObject("WinHttp.WinHttpRequest.5.1")

                    'Console.WriteLine(vbCrLf & "name=" & Form1.SName & "&ebs_id=" & Form1.IDBox.Text & "&s_grade=" & gbox.Text & "&s_class=" & cbox.Text & "&s_num=" & nbox.Text &"&class_name=" & className & "&course_name=" & courseName & "&status=" & status & "&co_date=" & co_date)
                    Try
                        http3.Open("POST", server_addr & "/upload.php")
                        http3.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                        http3.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                        http3.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                        http3.Send("name=" & Form1.SName & "&ebs_id=" & Form1.IDBox.Text & "&s_grade=" & gbox.Text & "&s_class=" & cbox.Text & "&s_num=" & nbox.Text & "&class_name=" & className & "&course_name=" & courseName & "&status=" & status & "&co_date=" & co_date)
                        http3.WaitForResponse(1000)
                        Application.DoEvents()
                    Catch
                        Dim CListDesu As New ListViewItem(className, i - 1) '과목 제목
                        Me.StatusList.Items.AddRange(New ListViewItem() {CListDesu})
                        CListDesu.SubItems.Add(courseName) '진도 이름
                        CListDesu.SubItems.Add(status) '진도율
                        CListDesu.SubItems.Add(co_date) '날짜
                        Application.DoEvents()
                    End Try
                Next i
                Me.ErrorList.Clear()
            End With
        Loop
    End Sub
    Public Sub CallNokori()
        '진행중인 강의와 진도율 조회

        Dim html, html2, MyUrl, Cutting, Lcount, NowUrl, ClassName, Ltotal, ComCount As String
        Dim Lname(), Lend(), Lcontext(), Ldate(), alctcrSn(), stepSn(), hmpgOperSn() As String

        'StatusList.Enabled = False '리스트뷰 비활성화
        StatusList.CheckBoxes = False '리스트뷰 체크박스 비활성화
        Form1.UrlList = Split(Form1.U1, "|") 'URL을 리스트로 정렬
        'StatusList.Items.Clear() '리스트 초기화

        ComCount = 0 '100% 카운트 초기화
        Me.Cursor = Cursors.WaitCursor '로딩 커서

        Call Form1.LoginCheck()

        For i = 1 To UBound(Form1.UrlList)
            NowUrl = "https://" & Form1.UrlList(i) '클래스 URL
            http.Open("GET", NowUrl)
            http.Send()
            http.WaitForResponse()
            html = System.Text.Encoding.UTF8.GetString(http.ResponseBody)
            ClassName = Split(Split(html, "logo txt_grey"">")(1), "</a>")(0) '클래스 이름 추출
            MyUrl = Split(Split(html, "mypageView.do?menuSn=")(1), """")(0) '마이페이지 게시판넘버 추출

            http.Open("POST", NowUrl & "/hmpg/mypageLrnTabView.do?lrnType=" & LType) '마이페이지 LRN:학습중 / COMPT:학습완료
            http.SetRequestHeader("Referer", NowUrl & "/hmpg/mypageView.do?menuSn=" & MyUrl)
            http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
            http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
            http.SetRequestHeader("Host", Shost & ".ebssw.kr")
            http.Send("menuSn=" & MyUrl)
            http.WaitForResponse()
            html2 = System.Text.Encoding.UTF8.GetString(http.ResponseBody)
            'Console.WriteLine("<------------------------>" & vbCrLf & html2)

            Cutting = Split(html2, "list al")(1) '리스트 부분 컷

            If InStr(Cutting, "강좌가 없습니다.") Then
                '넘어가욧!
            Else
                'Console.WriteLine(Cutting) 

                'for문에서 i가 추가되면 새롭게 string을 찾음
                Lname = Split(Cutting, "tit bold") '강의 제목 검출용
                Lcontext = Split(Cutting, "tit bold") '목차 검출용
                Ldate = Split(Cutting, "tit bold") '날짜 검출용
                alctcrSn = Split(Cutting, "class=""info""") '강의 주소 검출용 1
                stepSn = Split(Cutting, "class=""info""") '강의 주소 검출용2
                hmpgOperSn = Split(Cutting, "class=""info""") '강의 주소 검출용3

                For i2 = 1 To UBound(Lname)
                    Lname(i2) = Split(Split(Lname(i2), "tit_txt"">")(1), "</span>")(0).Replace(vbTab, "") '강의 제목
                    Lcontext(i2) = Split(Split(Lcontext(i2), "class=""way""")(1), "</div>")(0) '목차 부분만 따오기
                    Ldate(i2) = Split(Split(Ldate(i2), "학습 시작일 : ")(1), "</li>")(0) '날짜 부분만 따오기
                    alctcrSn(i2) = Split(Split(alctcrSn(i2), "showLctrumView('")(1), "',")(0) 'alctcrSn 값
                    stepSn(i2) = Split(Split(stepSn(i2), alctcrSn(i2) & "', '")(1), "',")(0) 'stepSn 값
                    hmpgOperSn(i2) = Split(Split(hmpgOperSn(i2), stepSn(i2) & "', '")(1), "',")(0) 'hmpgOperSn 값

                    Lend = Split(Lcontext(i2), "<a href") 'a 부분 반복 ㄱㄱ

                    'Console.WriteLine("<------------------------>" & vbCrLf & Lcontext(i2)) '강의 당 목차 파싱 출력

                    Lcount = 0 '카운트 초기화 
                    For i4 = 1 To UBound(Lend) 'end 검출
                        Lend(i4) = Split(Split(Lend(i4), "class=")(1), ">")(0) '강의 목차 추출
                        If InStr(Lend(i4), "end") Then 'class="end">
                            Lcount = Lcount + 1 '완료 카운트 계산
                        End If
                    Next i4
                    Ltotal = UBound(Lend)
                    'Application.DoEvents()
                    'Console.WriteLine("<--" & Lname(i2) & ": " & Lcount & "/" & UBound(Lend))
                    Dim totalPer As Double = Lcount / Ltotal * 100
                    Dim strPer As String = Int32.Parse(Math.Truncate(totalPer).ToString()) '& "%"

                    ' MsgBox(strPer)
                    'class="end" 개수 검출 -> 강의 개수 강좌구성 : 1개 강의

                    If strPer = "100" Then '100%인데 학습중으로 뜰때
                        http.Open("GET", NowUrl & "/hmpg/hmpgLctrumView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn(i2) & "&stepSn=" & stepSn(i2))
                        '/클래스네임/hmpg/hmpgLctrumView.do?menuSn="& MyUrl & "&alctcrSn=값&stepSn=값  -> 목차페이지 주소
                        http.Send()
                        http.WaitForResponse()
                        ComCount = ComCount + 1 '100%인 항목 카운트
                    End If

                    If lrnType.Text = "학습중" Then
                        Dim CListDesu As New ListViewItem(ClassName, i2 - 1) '과목 제목
                        StatusList.Items.AddRange(New ListViewItem() {CListDesu})
                        CListDesu.SubItems.Add(Lname(i2)) '진도 이름
                        CListDesu.SubItems.Add(strPer) '진도율
                        CListDesu.SubItems.Add(Ldate(i2)) '날짜
                        'CListDesu.SubItems.Add(NowUrl) '기본주소
                        'CListDesu.SubItems.Add("학습중") '
                    ElseIf lrnType.Text = "학습완료" Then
                        If Me.StartDate.Value <= Ldate(i2) And Me.EndDate.Value >= Ldate(i2) Then
                            Dim CListDesu As New ListViewItem(ClassName, i2 - 1) '과목 제목
                            StatusList.Items.AddRange(New ListViewItem() {CListDesu})
                            CListDesu.SubItems.Add(Lname(i2)) '진도 이름
                            CListDesu.SubItems.Add(strPer) '진도율
                            CListDesu.SubItems.Add(Ldate(i2)) '날짜
                            'CListDesu.SubItems.Add(NowUrl) '기본주소
                            'CListDesu.SubItems.Add("학습완료") '상태
                        End If
                    End If
                    'CListDesu.SubItems.Add(NowUrl & "/hmpg/hmpgLctrumView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn(i2) & "&stepSn=" & stepSn(i2)) '주소
                    Application.DoEvents() '렉 방지
                    Lcount = 0 '카운트 초기화 
                Next i2
            End If
            Application.DoEvents() '렉방지
        Next i
        '로딩완료 이후
        lrnType.Enabled = True '콤보박스 활성화
        StatusList.Enabled = True '리스트뷰 활성화
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀

        If lrnType.Text = "학습중" Then
            lrnType.Text = "학습완료"
            LType = "COMPT"
            Call Me.CallNokori()
        ElseIf lrnType.Text = "학습완료" Then
            lrnType.Text = "미수강중"
            Call Me.CallNotEnrolled()
        End If

    End Sub
    Public Sub CallNotEnrolled() '미수강중 목록 불러오기

        Dim NowUrl, html, menuSn, ClassName, hmpgOperSn, Cutting, Cut2, newLname, urlpage, Ldate As String
        Dim Lurl(), MyUrl(), alctcrSn(), stepSn() As String
        lrnType.Enabled = False '콤보박스 비활성화
        'StatusList.Enabled = False '리스트뷰 비활성화
        'StatusList.CheckBoxes = True '리스트뷰 체크박스 활성화
        'StatusList.Items.Clear() '리스트 초기화
        Me.Cursor = Cursors.WaitCursor '로딩 커서

        Call Form1.LoginCheck()

        For i = 1 To UBound(Form1.UrlList)
            NowUrl = "https://" & Form1.UrlList(i) '클래스 URL
            http.Open("GET", NowUrl)
            http.Send()
            http.WaitForResponse()
            html = System.Text.Encoding.UTF8.GetString(http.ResponseBody)
            menuSn = Split(Split(html, "hmpgAlctcrListView.do?menuSn=")(1), """")(0) '강의 목록 주소

            http.Open("GET", NowUrl & "/hmpg/hmpgAlctcrListView.do?menuSn=" & menuSn)
            http.Send()
            http.WaitForResponse()
            html = System.Text.Encoding.UTF8.GetString(http.ResponseBody)

            ClassName = Split(Split(html, "logo txt_grey"">")(1), "</a>")(0) '클래스 이름 추출
            hmpgOperSn = Split(Split(html, "fncHmpgVisitLogInsert(""")(1), """")(0) '클래스 이름 추출

            Cutting = Split(html, "learning_list")(1) '리스트 부분 컷
            'Lname = Split(Cutting, "tit bold") '강의 제목 검출용
            Lurl = Split(Cutting, "<li class=""clearfix"">") '강의주소 검출용
            MyUrl = Split(Cutting, "<li class=""clearfix"">") '강의주소 검출용
            alctcrSn = Split(Cutting, "<li class=""clearfix"">") '강의주소 검출용
            stepSn = Split(Cutting, "<li class=""clearfix"">") '강의주소 검출용

            For i2 = 1 To UBound(Lurl)
                'Lname(i2) = Split(Split(Lname(i2), """>")(1), "</p>")(0).Replace(vbTab, "") '강의 제목
                Lurl(i2) = Split(Split(Lurl(i2), "<a href=""")(1), """ class=")(0) '주소 부분만 따오기
                If InStr(Cutting, "등록된 강좌가 없습니다.") Then
                    '으앙 넘어가요ㅠㅠ
                Else
                    MyUrl(i2) = Split(Split(Lurl(i2), "menuSn=")(1), "&")(0) '마이페이지 메뉴 아이디
                    'Console.WriteLine(MyUrl(i2) & vbCrLf & "---")
                    alctcrSn(i2) = Split(Lurl(i2), "&alctcrSn=")(1) 'alctcrSn 값

                    http.Open("GET", "https://" & Shost & ".ebssw.kr" & Lurl(i2))
                    http.Send()
                    http.WaitForResponse()
                    urlpage = System.Text.Encoding.UTF8.GetString(http.ResponseBody)

                    If InStr(urlpage, "btn_enrol") Then
                        stepSn(i2) = Split(Split(urlpage, "name=""stepSn"" value=""")(1), """")(0) 'stepSn 값
                        'Console.WriteLine("<------------------------>" & vbCrLf & "https://" & Shost & ".ebssw.kr" & Lurl(i2))

                        Cut2 = Split(urlpage, "og:title")(1)
                        newLname = Split(Split(Cut2, "content=""")(1), """ />")(0) '강의 제목 따오기

                        Ldate = Split(Split(urlpage, "강좌 작성일</span>")(1), "</li>")(0) '날짜 추출

                        If Me.StartDate.Value <= Ldate And Me.EndDate.Value >= Ldate Then
                            Dim NotEnrollList As New ListViewItem(ClassName, i2 - 1) '과목 제목
                            Me.StatusList.Items.AddRange(New ListViewItem() {NotEnrollList})
                            NotEnrollList.SubItems.Add(newLname) '강의(진도) 이름
                            NotEnrollList.SubItems.Add("200") '미수강 표시
                            NotEnrollList.SubItems.Add(Ldate) '날짜 표시
                            'NotEnrollList.SubItems.Add("https://" & Shost & ".ebssw.kr" & Lurl(i2)) '강의 주소

                            Application.DoEvents() '렉방지
                        End If
                    End If
                    Application.DoEvents() '렉방지
                End If

            Next i2
            Application.DoEvents() '렉방지
        Next i

        lrnType.Enabled = True '콤보박스 활성화 
        StatusList.Enabled = True '리스트뷰 활성화
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀
        'Call LoadForm.uploadData()
    End Sub
    Private Sub gbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gbox.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub cbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbox.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub nbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles nbox.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub
End Class