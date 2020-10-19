Imports System.Text.RegularExpressions
Public Class Form1
    Public http, http2 As Object
    Public U1, UrlList(), First, SAML0, SAML1, Shost, MainH, LType, SName As String
    Dim nowVersion As String
    Dim sortColumn As Integer = -1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nowVersion = "2.06.0" '버전 가운데는 두자리로!
        lrnType.Text = "학습중"
        LType = "LRN"
        Try
            CheckUpdate(nowVersion)
            SCodeBox.Text = My.Settings.SchCode
            IDBox.Text = My.Settings.ID
            IDSaveBox.Checked = My.Settings.IDSave
            Shost = "hoc30" '임시방편

            StatusList.Enabled = False
            ClassList.Enabled = False
            startNokori.Enabled = False
            lrnType.Enabled = False
            openSender.Enabled = False

            http = CreateObject("WinHttp.WinHttpRequest.5.1")
            http.Open("GET", "https://ebssw.kr/sso/loginView.do?loginType=onlineClass")
            'http.Send("c=LI&SAMLRequest=PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz48c2FtbDJwOkF1dGhuUmVxdWVzdCAgICB4bWxuczpzYW1sMnA9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpwcm90b2NvbCIgICAgICAgIElEPSJob2MyNC5lYnNzdy5rci0xNTg2OTY0MDcxNjUxIiAgICAgICAgVmVyc2lvbj0iMi4wIiAgICAgICAgSXNzdWVJbnN0YW50PSIyMDIwLTA0LTE1VDE1OjIxOjExLjY1MVoiICAgICAgICBBc3NlcnRpb25Db25zdW1lclNlcnZpY2VVUkw9Imh0dHBzOi8vaG9jMjQuZWJzc3cua3Ivc3NvIiAgICAgICAgRGVzdGluYXRpb249Imh0dHBzOi8vc3NvLmVicy5jby5rci9pZHAvcHJvZmlsZS9TQU1MMi9QT1NULVJlZGlyZWN0L1NTTyI+PHNhbWwyOklzc3VlciB4bWxuczpzYW1sMj0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOmFzc2VydGlvbiI+aG9jMjQuZWJzc3cua3I8L3NhbWwyOklzc3Vlcj48L3NhbWwycDpBdXRoblJlcXVlc3Q+&j_returnurl=https%3A%2F%2Fhoc.ebssw.kr%2FonlineClass%2Freqst%2FonlineClassReqstInfoView.do&j_loginurl=https%3A%2F%2Fhoc24.ebssw.kr%2Fsso%2FloginView.do&hmpgId=&userSeCode=&loginType=onlineClass")
            http.Send()
            http.WaitForResponse()

            First = System.Text.Encoding.UTF8.GetString(http.ResponseBody)
            SAML0 = Split(Split(First, "name=""SAMLRequest")(1), "/>")(0)
            SAML1 = Split(Split(SAML0, "value=""")(1), """")(0) 'SAMLRequest 추출
        Catch ex As Exception
            MsgBox("인터넷 또는 서버가 불안정합니다." & vbCrLf & "프로그램을 재실행해주시기 바랍니다.", MsgBoxStyle.Exclamation, "알림")
            Enable_Control(False)
            Me.Close()
        End Try
    End Sub
    Private Sub IDSaving() '아이디 저장 여부
        If My.Settings.IDSave = True Then
            My.Settings.ID = IDBox.Text
            My.Settings.Save()
        Else
            My.Settings.ID = ""
            My.Settings.Save()
        End If
    End Sub
    Private Sub Login()
        Shost = My.Settings.SchHost '학교 호스트(서버 네임)
        MainH = Regex.Replace(Shost, "\d", "") '학교 메인호스트 추출 
        'MsgBox(MainH) '호스트추출 Test
        Call Enable_Control(False)
        Call IDSaving()
        My.Settings.SchCode = SCodeBox.Text
        My.Settings.Save()
        Dim Temp As String

        If IDBox.Text.Trim() = "" Or PWBox.Text.Trim() = "" Then
            MsgBox("아이디와 비밀번호를 입력하세요.", MsgBoxStyle.Exclamation, "로그인 오류")
            Call Enable_Control(True)
            PWBox.Text = ""
            IDBox.Focus()
        ElseIf SCodeBox.Text.Trim() = "" Then
            MsgBox("학교코드를 검색하세요.", MsgBoxStyle.Exclamation, "로그인 오류")
            Call Enable_Control(True)
            PWBox.Text = ""
            SCodeBox.Focus()
        Else
            '로그인 시도
            Me.Cursor = Cursors.WaitCursor '로딩 커서
            ' MsgBox("Shost: " & Shost & vbCrLf & "MainH: " & MainH)
            http.Open("POST", "https://" & Shost & ".ebssw.kr/sso")
            http.SetRequestHeader("Referer", "https://" & MainH & ".ebssw.kr/sso/loginView.do?loginType=onlineClass")
            http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
            http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
            http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
            http.SetRequestHeader("Host", MainH & ".ebssw.kr")
            http.Send("c=LI&SAMLRequest=" & SAML1 & "&j_returnurl=https%3A%2F%2F" & MainH & ".ebssw.kr%2FonlineClass%2Freqst%2FonlineClassReqstInfoView.do&j_loginurl=https%3A%2F%2F" & MainH & ".ebssw.kr%2Fsso%2FloginView.do&j_logintype=&localLoginUrl=&hmpgId=&userSeCode=&loginType=onlineClass" & "&j_username=" & IDBox.Text & "&j_password=" & PWBox.Text)
            'http.Send("c=LI&SAMLRequest=PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz48c2FtbDJwOkF1dGhuUmVxdWVzdCAgICB4bWxuczpzYW1sMnA9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpwcm90b2NvbCIgICAgICAgIElEPSJob2MuZWJzc3cua3ItMTU4NjYyNTQ3MTMwNyIgICAgICAgIFZlcnNpb249IjIuMCIgICAgICAgIElzc3VlSW5zdGFudD0iMjAyMC0wNC0xMVQxNzoxNzo1MS4zMDdaIiAgICAgICAgQXNzZXJ0aW9uQ29uc3VtZXJTZXJ2aWNlVVJMPSJodHRwczovL2hvYy5lYnNzdy5rci9zc28iICAgICAgICBEZXN0aW5hdGlvbj0iaHR0cHM6Ly9zc28uZWJzLmNvLmtyL2lkcC9wcm9maWxlL1NBTUwyL1BPU1QtUmVkaXJlY3QvU1NPIj48c2FtbDI6SXNzdWVyIHhtbG5zOnNhbWwyPSJ1cm46b2FzaXM6bmFtZXM6dGM6U0FNTDoyLjA6YXNzZXJ0aW9uIj5ob2MuZWJzc3cua3I8L3NhbWwyOklzc3Vlcj48L3NhbWwycDpBdXRoblJlcXVlc3Q%2B&j_returnurl=https%3A%2F%2Fhoc.ebssw.kr%2FonlineClass%2Freqst%2FonlineClassReqstInfoView.do&j_loginurl=https%3A%2F%2Fhoc.ebssw.kr%2Fsso%2FloginView.do&j_logintype=&localLoginUrl=&hmpgId=&userSeCode=&loginType=onlineClass" & "&j_username=" & IDBox.Text & "&j_password=" & PWBox.Text)
            http.WaitForResponse(1000)

            '학교 페이지 접속
            http.Open("GET", "https://" & Shost & ".ebssw.kr/onlineClass/search/onlineClassSearchView.do?schulCcode=" & SCodeBox.Text)
            http.Send()
            http.WaitForResponse()

            Temp = http.ResponseText

            If InStr(Temp, IDBox.Text) Then
                MsgBox("로그인에 성공하였습니다.", MsgBoxStyle.Exclamation, "환영합니다!")
                SName = Split(Split(Temp, "user_name fl"">")(1), "님")(0)
                StatusList.Enabled = True
                ClassList.Enabled = True
                startNokori.Enabled = True
                lrnType.Enabled = True
                lrnType.Text = "학습중"
                Call CallClassList()

            ElseIf InStr(Temp, "로그인을 해주세요.") Then
                MsgBox("아이디 또는 비밀번호 오류.", MsgBoxStyle.Exclamation, "로그인 오류")
                Call Enable_Control(True)
                PWBox.Focus()
            Else
                MsgBox("로그인 시도 실패", MsgBoxStyle.Exclamation, "로그인 오류")
                Call Enable_Control(True)
                IDBox.Focus()
            End If
        End If
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀
    End Sub
    Public Sub LoginCheck()
        Dim Temp As String
        Try
            http.Open("GET", "https://" & Shost & ".ebssw.kr/onlineClass/search/onlineClassSearchView.do?schulCcode=" & SCodeBox.Text)
            http.Send()
            http.WaitForResponse()
        Catch ex As IndexOutOfRangeException
            MsgBox("로그인 세션이 만료되어 재로그인을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
            ClassSearch.Close()
            Call Login()
        Catch ex2 As System.Runtime.InteropServices.COMException
            MsgBox("서버와의 연결을 실패했습니다.", MsgBoxStyle.Exclamation, "알림")
            ClassSearch.Close()
            startNokori.Enabled = True
        Catch ex3 As Exception
            MsgBox(ex3.ToString, MsgBoxStyle.Exclamation, "에러")
            ClassSearch.Close()
        End Try

        Temp = http.ResponseText
        If InStr(Temp, IDBox.Text) Then
            '넘어가욧!
        Else
            MsgBox("로그인 세션이 만료되어 재로그인을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
            ClassSearch.Close()
            Call Login()
        End If
    End Sub
    Private Sub Enable_Control(bool As Boolean)
        IDBox.Enabled = bool
        PWBox.Enabled = bool
        LoginBtn.Enabled = bool
        SCodeBox.Enabled = bool
        SCodeFind.Enabled = bool
        IDSaveBox.Enabled = bool
    End Sub
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Call Login()
    End Sub
    Private Sub PWBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PWBox.KeyDown
        If e.KeyCode = Keys.Return Then
            LoginBtn_Click(sender, New System.EventArgs())
        End If
    End Sub
    Private Sub CallClassList()
        '클래스 리스트 조회
        Dim html, Cut, Cname(), CUrl() As String
        ClassList.Items.Clear() '리스트뷰 초기화
        U1 = "" '클래스 URL 초기화

        http.Open("GET", "https://" & Shost & ".ebssw.kr/onlineClass/reqst/onlineClassReqstInfoView.do")
        http.Send()
        http.WaitForResponse()
        html = System.Text.Encoding.UTF8.GetString(http.ResponseBody)

        Cut = Split(Split(html, "가입한 클래스")(1), "데이터 없을 때 : s")(0)

        Try
            Cname = Split(Cut, "<li>")
            CUrl = Split(Cut, "<li>")
            For i = 1 To UBound(Cname)
                Cname(i) = Split(Split(Cname(i), "] ")(1), "<i class")(0)
                CUrl(i) = Split(Split(CUrl(i), "https://")(1), """")(0)

                Dim CListDesu As New ListViewItem(Cname(i), i - 1)
                ClassList.Items.AddRange(New ListViewItem() {CListDesu}) '제목
                CListDesu.SubItems.Add(CUrl(i)) '주소
                U1 = U1 & "|" & CUrl(i)
                Application.DoEvents()
            Next i
            Call CallNokori() '자동 새로고침
        Catch ex As Exception
            MsgBox("불러오는 중 오류가 발생했습니다." & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub lrnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lrnType.SelectedIndexChanged
        Call DateDialog.ControlEnable(True)
        Try
            If lrnType.Text = "학습중" Then
                LType = "LRN"
                StatusList.Size = New Size(742, 456)
                EnrollPanel.Visible = False
                DateDialog.Close()
                DateHeader.Text = "학습 시작일"
                Call CallNokori()
            ElseIf lrnType.Text = "학습완료" Then
                LType = "COMPT"
                StatusList.Size = New Size(742, 456)
                DateDialog.RadioWeek.Checked = True '기본값 (일주일)
                DateDialog.Show() '범위 설정 오픈
                EnrollPanel.Visible = False
                DateHeader.Text = "학습 시작일"
                'Call CallNokori()
            ElseIf lrnType.Text = "미수강중" Then
                StatusList.Size = New Size(742, 417)
                EnrollPanel.Visible = True
                DateDialog.RadioMonth.Checked = True '기본값 (최근 한 달)
                DateDialog.Show() '범위 설정 오픈
                DateHeader.Text = "강좌 작성일"
                'Call CallNotEnrolled()
            Else
                lrnType.Text = "학습중"
                LType = "LRN"
                StatusList.Size = New Size(742, 456)
            End If
        Catch ex As IndexOutOfRangeException
            MsgBox("로그인 세션이 만료되어 재로그인을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
            Call Login()
        Catch ex2 As System.Runtime.InteropServices.COMException
            MsgBox("서버와의 연결을 실패했습니다.", MsgBoxStyle.Exclamation, "알림")
            startNokori.Enabled = True
        Catch ex3 As Exception
            MsgBox(ex3.ToString, MsgBoxStyle.Exclamation, "에러")
        End Try
    End Sub
    Private Sub ClassList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ClassList.MouseDoubleClick
        '클래스 리스트 더블클릭시
        With Me.ClassList
            For i = 0 To .Items.Count - 1
                If .Items(i).Selected = True Then
                    System.Diagnostics.Process.Start("https://" & .Items(i).SubItems(1).Text) '브라우저로 열기
                End If
            Next
        End With
    End Sub
    Private Sub StatusList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles StatusList.MouseDoubleClick
        Call EnrollCourse("one")
    End Sub
    Dim iCount As Integer
    Private Sub EnrollBtn_Click(sender As Object, e As EventArgs) Handles EnrollBtn.Click
        iCount = 0
        For I = 0 To StatusList.Items.Count - 1
            If StatusList.Items(I).Checked = True Then
                iCount = iCount + 1
            End If
        Next
        If iCount = 0 Then
            MsgBox("선택한 항목이 없습니다.", MsgBoxStyle.Exclamation, "알림")
        Else
            Call EnrollCourse("two")
        End If
    End Sub
    Public Sub EnrollCourse(count As String) '수강신청 구문 one:1개 two:2개이상
        Dim i, CountNum As Integer
        Dim NowUrl, MyUrl, alctcrSn, stepSn, hmpgOperSn, totalURL, msg, Cname As String
        CountNum = 0 '카운팅 초기화
        With Me.StatusList
            For i = 0 To .Items.Count - 1
                Cname = .Items(i).SubItems(1).Text '강의 이름
                NowUrl = .Items(i).SubItems(4).Text '주소
                MyUrl = .Items(i).SubItems(5).Text '게시판 아이디
                alctcrSn = .Items(i).SubItems(6).Text
                stepSn = .Items(i).SubItems(7).Text
                hmpgOperSn = .Items(i).SubItems(8).Text
                totalURL = NowUrl & "/hmpg/hmpgLctrumView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn & "&stepSn=" & stepSn

                If count = "one" Then
                    If .Items(i).Selected = True Then
                        If lrnType.Text = "미수강중" Then
                            msg = MsgBox(""" " & Cname & " """ & vbCrLf & "해당 강의를 신청하시겠습니까?", vbYesNo, "수강신청")
                            If msg = vbYes Then
                                StatusList.Enabled = False '리스트뷰 비활성화
                                Try
                                    http.Open("POST", "https://" & Shost & ".ebssw.kr/lrnng/alctcr/alctcrAtnlcAt.do")
                                    http.SetRequestHeader("Referer", NowUrl & "/hmpg/hmpgAlctcrDetailView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn)
                                    http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                                    http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                                    http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                                    http.SetRequestHeader("Host", Shost & ".ebssw.kr")
                                    http.Send("alctcrSn=" & alctcrSn & "&alctcrTy=1")
                                    http.WaitForResponse()

                                    http.Open("POST", NowUrl & "/lrnng/alctcr/alctcrAtnlcSave.do")
                                    http.SetRequestHeader("Referer", NowUrl & "/hmpg/hmpgAlctcrDetailView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn)
                                    http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                                    http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                                    http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                                    http.SetRequestHeader("Host", Shost & ".ebssw.kr")
                                    http.Send("alctcrSn=" & alctcrSn & "&stepSn=" & stepSn & "&hmpgOperSn=" & hmpgOperSn & "&crtfcUseAt=0&athriCrtfcInfo=&athriCrtecAt=")
                                    http.WaitForResponse()

                                    MsgBox("수강신청에 성공하였습니다.", MsgBoxStyle.Exclamation, "알림")
                                    MsgBox("새로고침을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
                                    Call CallNotEnrolled() '새로고침
                                    '.Items(i).Remove() '임시로 아이템 제거
                                Catch ex As Exception
                                    MsgBox("오류가 발생했습니다." & vbCrLf & ex.ToString)
                                End Try
                                StatusList.Enabled = True '리스트뷰 활성화
                            End If
                        Else
                            System.Diagnostics.Process.Start(totalURL) '브라우저로 열기
                        End If
                    End If
                ElseIf count = "two" Then 'two
                    If .Items(i).Checked = True Then
                        If lrnType.Text = "미수강중" Then
                            msg = MsgBox(""" " & Cname & " """ & vbCrLf & "해당 강의를 신청하시겠습니까?", vbYesNo, "수강신청")
                            If msg = vbYes Then
                                StatusList.Enabled = False '리스트뷰 비활성화
                                Try
                                    http.Open("POST", "https://" & Shost & ".ebssw.kr/lrnng/alctcr/alctcrAtnlcAt.do")
                                    http.SetRequestHeader("Referer", NowUrl & "/hmpg/hmpgAlctcrDetailView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn)
                                    http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                                    http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                                    http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                                    http.SetRequestHeader("Host", Shost & ".ebssw.kr")
                                    http.Send("alctcrSn=" & alctcrSn & "&alctcrTy=1")
                                    http.WaitForResponse()

                                    http.Open("POST", NowUrl & "/lrnng/alctcr/alctcrAtnlcSave.do")
                                    http.SetRequestHeader("Referer", NowUrl & "/hmpg/hmpgAlctcrDetailView.do?menuSn=" & MyUrl & "&alctcrSn=" & alctcrSn)
                                    http.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                                    http.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36")
                                    http.SetRequestHeader("Accept-Language", "ko-KR,ko;q=0.9,en-US;q=0.8,en;q=0.7,ja;q=0.6")
                                    http.SetRequestHeader("Host", Shost & ".ebssw.kr")
                                    http.Send("alctcrSn=" & alctcrSn & "&stepSn=" & stepSn & "&hmpgOperSn=" & hmpgOperSn & "&crtfcUseAt=0&athriCrtfcInfo=&athriCrtecAt=")
                                    http.WaitForResponse()

                                    '.Items(i).Remove() '임시로 아이템 제거
                                    CountNum = CountNum + 1
                                    If CountNum = iCount Then
                                        MsgBox(CountNum & "개의 수강신청을 성공하였습니다.", MsgBoxStyle.Exclamation, "알림")
                                        MsgBox("새로고침을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
                                        Call CallNotEnrolled() '새로고침
                                    End If
                                Catch ex As Exception
                                    MsgBox("오류가 발생했습니다." & vbCrLf & ex.ToString)
                                End Try
                                StatusList.Enabled = True '리스트뷰 활성화
                                'If i = .Items.Count - 1 Then
                                '    MsgBox("새로고침을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
                                '    Call CallNotEnrolled() '새로고침
                                'End If
                            End If
                        End If
                    End If
                End If
            Next

            'For i = 0 To .Items.Count - 1
            '    If .Items(i).Checked = True Or .Items(i).Checked = True Then
            '        .Items(i).Remove() '임시로 아이템 제거
            '    End If
            'Next
        End With
    End Sub
    Public Sub CallNokori()
        '진행중인 강의와 진도율 조회
        Dim html, html2, MyUrl, Cutting, Lcount, NowUrl, ClassName, Ltotal, ComCount As String
        Dim Lname(), Lend(), Lcontext(), Ldate(), alctcrSn(), stepSn(), hmpgOperSn() As String

        startNokori.Enabled = False '새로고침 비활성화
        lrnType.Enabled = False '콤보박스 비활성화
        openSender.Enabled = False '연동 버튼 비활성화
        StatusList.Enabled = False '리스트뷰 비활성화
        StatusList.CheckBoxes = False '리스트뷰 체크박스 비활성화
        UrlList = Split(U1, "|") 'URL을 리스트로 정렬
        StatusList.Items.Clear() '리스트 초기화
        EnrollPanel.Visible = False '수강신청 버튼 비활성화
        ComCount = 0 '100% 카운트 초기화
        Me.Cursor = Cursors.WaitCursor '로딩 커서

        For i = 1 To UBound(UrlList)
            NowUrl = "https://" & UrlList(i) '클래스 URL
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
                    Dim strPer As String = Int32.Parse(Math.Truncate(totalPer).ToString()) & "%"

                    ' MsgBox(strPer)
                    'class="end" 개수 검출 -> 강의 개수 강좌구성 : 1개 강의

                    If strPer = "100%" Then '100%인데 학습중으로 뜰때
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
                        CListDesu.SubItems.Add(NowUrl) '기본주소
                        CListDesu.SubItems.Add(MyUrl) '마이페이지 주소값
                        CListDesu.SubItems.Add(alctcrSn(i2))
                        CListDesu.SubItems.Add(stepSn(i2))
                        CListDesu.SubItems.Add(hmpgOperSn(i2))
                    ElseIf lrnType.Text = "학습완료" Then
                        If DateDialog.StartDate.Value <= Ldate(i2) And DateDialog.EndDate.Value >= Ldate(i2) Then
                            Dim CListDesu As New ListViewItem(ClassName, i2 - 1) '과목 제목
                            StatusList.Items.AddRange(New ListViewItem() {CListDesu})
                            CListDesu.SubItems.Add(Lname(i2)) '진도 이름
                            CListDesu.SubItems.Add(strPer) '진도율
                            CListDesu.SubItems.Add(Ldate(i2)) '날짜
                            CListDesu.SubItems.Add(NowUrl) '기본주소
                            CListDesu.SubItems.Add(MyUrl) '마이페이지 주소값
                            CListDesu.SubItems.Add(alctcrSn(i2))
                            CListDesu.SubItems.Add(stepSn(i2))
                            CListDesu.SubItems.Add(hmpgOperSn(i2))
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
        startNokori.Enabled = True '새로고침 버튼 활성화
        lrnType.Enabled = True '콤보박스 활성화
        openSender.Enabled = True '연동 버튼 활성화
        StatusList.Enabled = True '리스트뷰 활성화
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀
        If LType = "LRN" And ComCount <> 0 Then
            MsgBox(ComCount & "개의 강의가 학습완료 처리되었습니다." & vbCrLf & "새로고침을 시도합니다!")
            Call CallNokori() '새로고침
        End If
    End Sub

    Private Sub GoClass_Click(sender As Object, e As EventArgs) Handles GoClass.Click
        If SCodeBox.Text.Trim() = "" Then
            MsgBox("학교코드를 검색하세요.", MsgBoxStyle.Exclamation, "알림")
        Else
            System.Diagnostics.Process.Start("https://" & Shost & ".ebssw.kr/onlineClass/search/onlineClassSearchView.do?schulCcode=" & SCodeBox.Text) '클래스 열기
        End If
    End Sub

    Private Sub openSender_Click(sender As Object, e As EventArgs) Handles openSender.Click
        ClassSearch.Show()
    End Sub

    Public Sub CallNotEnrolled() '미수강중 목록 불러오기
        Dim NowUrl, html, menuSn, ClassName, hmpgOperSn, Cutting, Cut2, newLname, urlpage, Ldate As String
        Dim Lurl(), MyUrl(), alctcrSn(), stepSn() As String
        startNokori.Enabled = False '새로고침 비활성화
        openSender.Enabled = False '연동 버튼 비활성화
        lrnType.Enabled = False '콤보박스 비활성화
        StatusList.Enabled = False '리스트뷰 비활성화
        StatusList.CheckBoxes = True '리스트뷰 체크박스 활성화
        StatusList.Items.Clear() '리스트 초기화
        EnrollBtn.Enabled = False '수강신청 버튼 아직 못누르게
        EnrollPanel.Visible = True '수강신청 버튼 활성화
        Me.Cursor = Cursors.WaitCursor '로딩 커서

        Call LoginCheck()

        For i = 1 To UBound(UrlList)
            NowUrl = "https://" & UrlList(i) '클래스 URL
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

                        If DateDialog.StartDate.Value <= Ldate And DateDialog.EndDate.Value >= Ldate Then
                            Dim NotEnrollList As New ListViewItem(ClassName, i2 - 1) '과목 제목
                            StatusList.Items.AddRange(New ListViewItem() {NotEnrollList})
                            NotEnrollList.SubItems.Add(newLname) '강의(진도) 이름
                            NotEnrollList.SubItems.Add("미수강중") '미수강 표시
                            NotEnrollList.SubItems.Add(Ldate) '날짜 표시
                            'NotEnrollList.SubItems.Add("https://" & Shost & ".ebssw.kr" & Lurl(i2)) '강의 주소
                            NotEnrollList.SubItems.Add(NowUrl)
                            NotEnrollList.SubItems.Add(MyUrl(i2))
                            NotEnrollList.SubItems.Add(alctcrSn(i2))
                            NotEnrollList.SubItems.Add(stepSn(i2))
                            NotEnrollList.SubItems.Add(hmpgOperSn)
                            Application.DoEvents() '렉방지
                        End If
                    End If
                    Application.DoEvents() '렉방지
                End If

            Next i2
            Application.DoEvents() '렉방지
        Next i
        startNokori.Enabled = True '새로고침 버튼 활성화
        lrnType.Enabled = True '콤보박스 활성화 
        StatusList.Enabled = True '리스트뷰 활성화
        EnrollPanel.Enabled = True '수강신청 버튼 활성화
        EnrollBtn.Enabled = True '수강신청 버튼 활성화
        openSender.Enabled = True '연동 버튼 활성화
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀
    End Sub
    Private Sub IDSaveBox_CheckedChanged(sender As Object, e As EventArgs) Handles IDSaveBox.CheckedChanged
        '아이디저장 체크시 상태저장 ㄱㄱ
        My.Settings.IDSave = IDSaveBox.Checked
        My.Settings.Save()
        Call IDSaving()
    End Sub
    Private Sub SCodeFind_Click(sender As Object, e As EventArgs) Handles SCodeFind.Click
        SearchCode.Show() '학교검색 폼 실행
        'System.Diagnostics.Process.Start("https://github.com/devITae/EBSOCProgressViewer#11-%ED%95%99%EA%B5%90%EC%BD%94%EB%93%9C-%EC%B0%BE%EA%B8%B0")
    End Sub
    Private Sub startNokori_Click(sender As Object, e As EventArgs) Handles startNokori.Click
        '새로고침 버튼 클릭 시
        Call LoginCheck() '로그인 상태 확인
        Try
            If lrnType.Text = "학습중" Then
                LType = "LRN"
                Call CallNokori()
                DateDialog.Close()
            ElseIf lrnType.Text = "학습완료" Then
                LType = "COMPT"
                DateDialog.Show()
                'Call CallNokori()
            ElseIf lrnType.Text = "미수강중" Then
                DateDialog.Show()
                'Call CallNotEnrolled()
            Else
                lrnType.Text = "학습중"
                LType = "LRN"
                DateDialog.Close()
            End If
        Catch ex As IndexOutOfRangeException
            MsgBox("로그인 세션이 만료되어 재로그인을 시도합니다.", MsgBoxStyle.Exclamation, "알림")
            Call Login()
        Catch ex2 As System.Runtime.InteropServices.COMException
            MsgBox("서버와의 연결을 실패했습니다.", MsgBoxStyle.Exclamation, "알림")
            startNokori.Enabled = True
        Catch ex3 As Exception
            MsgBox(ex3.ToString, MsgBoxStyle.Exclamation, "에러")
        End Try
    End Sub
    Private Sub StatusList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles StatusList.ColumnClick
        '현재 열이 이전에 클릭한 열이 아닌 경우
        If e.Column <> sortColumn Then
            '정렬 열을 새 열로 설정.
            sortColumn = e.Column
            '오름차순 정렬로 기본 설정
            Me.StatusList.Sorting = SortOrder.Ascending
        Else
            '정렬 순서를 바꿈
            If StatusList.Sorting = SortOrder.Ascending Then
                Me.StatusList.Sorting = SortOrder.Descending
            Else
                Me.StatusList.Sorting = SortOrder.Ascending
            End If
        End If

        'ListViewItemSorter 속성을 새로운 ListViewSort 개체로 설정
        Me.StatusList.ListViewItemSorter = New ListViewSort(e.Column, StatusList.Sorting)
        '수동으로 정렬하기 위한 정렬 방법을 호출
        StatusList.Sort()
    End Sub
    'Private Sub ClassList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ClassList.ColumnClick
    '    '리스트뷰에서 제목열 클릭 시 정렬
    '    If ClassList.Columns(e.Column).ListView.Sorting = SortOrder.Descending Then
    '        ClassList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending
    '    ElseIf StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending Then
    '        ClassList.Columns(e.Column).ListView.Sorting = SortOrder.Descending
    '    Else
    '        ClassList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending
    '    End If
    'End Sub
    Public Sub CheckUpdate(nowVer As String)
        '업데이트 확인
        Dim HTML, lastest, upLink, IU, notice As String

        http2 = CreateObject("WinHttp.WinHttpRequest.5.1")
        http2.Open("GET", "https://raw.githubusercontent.com/devITae/EBSOCProgressViewer/master/img/version")
        http2.Send()
        http2.WaitForResponse()

        HTML = System.Text.Encoding.UTF8.GetString(http2.ResponseBody)
        lastest = Split(Split(HTML, "Lastest(v")(1), ")")(0)
        upLink = Split(Split(HTML, "UpdateLink(")(1), ")")(0)

        If lastest = nowVer Then
            '최신버전
            If InStr(HTML, "공지사항있음") Then
                notice = Split(Split(HTML, "NotiMent(")(1), ")")(0)
                MsgBox(notice, MsgBoxStyle.Exclamation, "공지사항")
            End If
        ElseIf lastest > nowVersion Then
            '업데이트 알림
            IU = MsgBox("정상적인 사용을 위해 업데이트를 권장합니다!" & vbCrLf & "지금 업데이트 하시겠습니까?", vbYesNo, "업데이트 알림")
            If IU = vbYes Then
                System.Diagnostics.Process.Start(upLink)
            Else
                '흠흠
            End If
        Else
            '지금 버전이 최신보다 클 때
            MsgBox("개발중인 테스트 버전 입니다." & vbCrLf & "최신: " & lastest & " / 현재: " & nowVer, MsgBoxStyle.Exclamation, "Welcome! Beta Tester.")
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/devITae/EBSOCProgressViewer") '깃허브 이동
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/devITae/EBSOCProgressViewer/releases/") '깃허브 이동
    End Sub
End Class
