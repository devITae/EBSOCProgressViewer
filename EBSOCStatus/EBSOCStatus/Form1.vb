Imports System.Text.RegularExpressions
Public Class Form1
    Public http, http2 As Object
    Public U1, UrlList(), First, SAML0, SAML1, Shost, MainH, LType As String
    Dim nowVersion As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nowVersion = "2.01.0" '버전 가운데는 두자리로!
        lrnType.Text = "학습중"
        LType = "LRN"
        CheckUpdate(nowVersion)
        SCodeBox.Text = My.Settings.SchCode
        IDBox.Text = My.Settings.ID
        IDSaveBox.Checked = My.Settings.IDSave
        Shost = "hoc30" '임시방편

        StatusList.Enabled = False
        ClassList.Enabled = False
        startNokori.Enabled = False
        lrnType.Enabled = False

        http = CreateObject("WinHttp.WinHttpRequest.5.1")
        http.Open("GET", "https://ebssw.kr/sso/loginView.do?loginType=onlineClass")
        'http.Send("c=LI&SAMLRequest=PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz48c2FtbDJwOkF1dGhuUmVxdWVzdCAgICB4bWxuczpzYW1sMnA9InVybjpvYXNpczpuYW1lczp0YzpTQU1MOjIuMDpwcm90b2NvbCIgICAgICAgIElEPSJob2MyNC5lYnNzdy5rci0xNTg2OTY0MDcxNjUxIiAgICAgICAgVmVyc2lvbj0iMi4wIiAgICAgICAgSXNzdWVJbnN0YW50PSIyMDIwLTA0LTE1VDE1OjIxOjExLjY1MVoiICAgICAgICBBc3NlcnRpb25Db25zdW1lclNlcnZpY2VVUkw9Imh0dHBzOi8vaG9jMjQuZWJzc3cua3Ivc3NvIiAgICAgICAgRGVzdGluYXRpb249Imh0dHBzOi8vc3NvLmVicy5jby5rci9pZHAvcHJvZmlsZS9TQU1MMi9QT1NULVJlZGlyZWN0L1NTTyI+PHNhbWwyOklzc3VlciB4bWxuczpzYW1sMj0idXJuOm9hc2lzOm5hbWVzOnRjOlNBTUw6Mi4wOmFzc2VydGlvbiI+aG9jMjQuZWJzc3cua3I8L3NhbWwyOklzc3Vlcj48L3NhbWwycDpBdXRoblJlcXVlc3Q+&j_returnurl=https%3A%2F%2Fhoc.ebssw.kr%2FonlineClass%2Freqst%2FonlineClassReqstInfoView.do&j_loginurl=https%3A%2F%2Fhoc24.ebssw.kr%2Fsso%2FloginView.do&hmpgId=&userSeCode=&loginType=onlineClass")
        http.Send()
        http.WaitForResponse()

        First = System.Text.Encoding.UTF8.GetString(http.ResponseBody)
        SAML0 = Split(Split(First, "name=""SAMLRequest")(1), "/>")(0)
        SAML1 = Split(Split(SAML0, "value=""")(1), """")(0) 'SAMLRequest 추출
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
            MsgBox("학교코드를 입력하세요.", MsgBoxStyle.Exclamation, "로그인 오류")
            Call Enable_Control(True)
            PWBox.Text = ""
            SCodeBox.Focus()
        Else
            '로그인 시도
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
                StatusList.Enabled = True
                ClassList.Enabled = True
                startNokori.Enabled = True
                lrnType.Enabled = True
                lrnType.Text = "학습중"
                Call CallClassList()
            ElseIf InStr(Temp, "로그인을 해주세요.") Then
                MsgBox("아이디 또는 비밀번호 오류.", MsgBoxStyle.Exclamation, "로그인 오류")
                Call Enable_Control(True)
                IDBox.Focus()
            Else
                MsgBox("로그인 시도 실패", MsgBoxStyle.Exclamation, "로그인 오류")
                Call Enable_Control(True)
                IDBox.Focus()
            End If
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
            MsgBox("불러오는 중 오류가 발생했습니다.")
        End Try
    End Sub

    Private Sub lrnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lrnType.SelectedIndexChanged
        If lrnType.Text = "학습중" Then
            LType = "LRN"
            Call CallNokori()
        ElseIf lrnType.Text = "학습완료" Then
            LType = "COMPT"
            Call CallNokori()
        Else
            lrnType.Text = "학습중"
            LType = "LRN"
        End If
    End Sub

    Private Sub CallNokori()
        '진행중인 강의와 진도율 조회
        Dim html, html2, MyUrl, Cutting, Lname(), NowUrl, ClassName, Lend(), Ltotal, Lcontext() As String
        Dim Lcount, Ltot As String

        startNokori.Enabled = False '새로고침 비활성화
        lrnType.Enabled = False '콤보박스 비활성화
        UrlList = Split(U1, "|") 'URL을 리스트로 정렬
        StatusList.Items.Clear() '리스트 초기화

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
            Cutting = Split(html2, "list al")(1)

            If InStr(Cutting, "강좌가 없습니다.") Then
                '넘어가욧!
            Else
                'Console.WriteLine(Cutting) 
                Lname = Split(Cutting, "tit bold") 'for문에서 i가 추가되면 새롭게 string을 찾음
                Lcontext = Split(Cutting, "tit bold")

                For i2 = 1 To UBound(Lname)
                    Lname(i2) = Split(Split(Lname(i2), "tit_txt"">")(1), "</span>")(0).Replace(vbTab, "") '강의 제목
                    Lcontext(i2) = Split(Split(Lcontext(i2), "class=""way""")(1), "</div>")(0) '목차 부분만 따오기
                    Lend = Split(Lcontext(i2), "<a href") 'a 부분 반복 ㄱㄱ

                    'Console.WriteLine("<------------------------>" & vbCrLf & Lcontext(i2)) '강의 당 목차 파싱 출력

                    Lcount = 0
                    Ltot = 0 '카운트 초기화 
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

                    Dim CListDesu As New ListViewItem(ClassName, i2 - 1) '과목 제목
                    StatusList.Items.AddRange(New ListViewItem() {CListDesu})
                    CListDesu.SubItems.Add(Lname(i2)) '진도 이름
                    CListDesu.SubItems.Add(strPer) '진도율
                    Application.DoEvents()
                    Lcount = 0
                    Ltot = 0 '카운트 초기화 
                Next i2
            End If
            Application.DoEvents()
        Next i
        '로딩완료 이후
        startNokori.Enabled = True '새로고침 버튼 활성화
        lrnType.Enabled = True '콤보박스 활성화
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/devITae/EBSOCProgressViewer") '깃허브 이동
    End Sub

    Private Sub startNokori_Click(sender As Object, e As EventArgs) Handles startNokori.Click
        Call CallNokori() '새로고침
    End Sub

    Private Sub StatusList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles StatusList.ColumnClick
        '리스트뷰에서 제목열 클릭 시 정렬
        If StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Descending Then
            StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending
        ElseIf StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending Then
            StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Descending
        Else
            StatusList.Columns(e.Column).ListView.Sorting = SortOrder.Ascending
        End If
    End Sub
    Public Sub CheckUpdate(nowVer As String)
        '업데이트 확인
        Dim HTML, lastest, upLink, IU, notice As String
        http2 = CreateObject("WinHttp.WinHttpRequest.5.1")
        http2.Open("GET", "https://github.com/devITae/EBSOCProgressViewer/blob/master/img/version")
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
            IU = MsgBox("새로운 버전이 감지되었습니다!" & vbCrLf & "지금 업데이트 하시겠습니까?", vbYesNo)
            If IU = vbYes Then
                System.Diagnostics.Process.Start(upLink)
            Else
                '흠흠
            End If
        Else
            '지금 버전이 최신보다 클 때
            MsgBox("개발중인 테스트 버전 입니다.", MsgBoxStyle.Exclamation, "Welcome! Beta Tester.")
        End If
    End Sub
End Class
