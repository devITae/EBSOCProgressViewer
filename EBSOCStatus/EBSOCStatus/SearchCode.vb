Public Class SearchCode
    Public http, http2 As Object
    Dim html, html2, SchAll, SchHubo(), SchHuboUrl(), SchName, SchNameResult, host(), selectCode As String
    Private Sub SearchCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        http = CreateObject("WinHttp.WinHttpRequest.5.1")
    End Sub
    Private Sub goSearch_Click(sender As Object, e As EventArgs) Handles goSearch.Click
        If Keyword.Text.Trim() = "" Then
            MsgBox("학교를 입력하세요.", MsgBoxStyle.Exclamation, "검색 오류")
            'ElseIf Keyword.Text = "초등학교" Or "중학교" Or "고등학교" Or "학교" Then
            '    MsgBox("검색어를 더 자세히 입력해주세요.")
        Else
            Call Searching()
        End If
    End Sub
    Private Sub goSelect_Click(sender As Object, e As EventArgs) Handles goSelect.Click
        Form1.SCodeBox.Text = selectCode
        Me.Close()
    End Sub
    Private Sub Keyword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Keyword.KeyDown
        If e.KeyCode = Keys.Return Then
            goSearch_Click(sender, New System.EventArgs())
        End If
    End Sub
    Private Sub Searching()
        Result.Items.Clear()
        http.Open("GET", "https://oc.ebssw.kr/resource/schoolList.js")
        http.Send()
        http.WaitForResponse()
        html = System.Text.Encoding.UTF8.GetString(http.ResponseBody)

        SchAll = Split(html, "schulList")(1)

        SchHubo = Split(SchAll, Keyword.Text)
        host = Split(SchAll, Keyword.Text)

        Try
            For i = 1 To UBound(SchHubo)
                SchHubo(i) = Split(Split(SchHubo(i), "schulCcode:'")(1), "',host")(0)
                host(i) = Split(Split(host(i), "host:'")(1), "'}")(0)


                Dim HuboListDesu As New ListViewItem(SchNameExtract(SchHubo(i), host(i)), i - 1)
                Result.Items.AddRange(New ListViewItem() {HuboListDesu}) '학교이름
                HuboListDesu.SubItems.Add(SchHubo(i)) '코드
                Application.DoEvents()
                'If i = UBound(SchHubo) Then
                '    Result.Items.Add("<-- 검색 완료 -->") '코드
                'End If
            Next i

            goSelect.Enabled = True
        Catch ex As Exception
            MsgBox("검색어의 범위가 너무 넓거나 서버가 불안정합니다.", MsgBoxStyle.Exclamation, "검색 오류")
        End Try
    End Sub
    Private Function SchNameExtract(code As String, hosted As String) As String
        http2 = CreateObject("WinHttp.WinHttpRequest.5.1")
        http2.Open("GET", "https://" & hosted & ".ebssw.kr/onlineClass/search/onlineClassSearchView.do?schulCcode=" & code)
        http2.Send()
        http2.WaitForResponse()
        html2 = System.Text.Encoding.UTF8.GetString(http2.ResponseBody)
        SchName = Split(Split(html2, "loadSchulList('" & code & "', '', '', '', '")(1), "' );")(0)
        My.Settings.SchHost = hosted
        My.Settings.Save()
        Return SchName
    End Function
    Private Sub Result_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Result.SelectedIndexChanged
        Dim i As Integer
        With Me.Result
            For i = 0 To .Items.Count - 1
                If .Items(i).Selected = True Then
                    selectCode = .Items(i).SubItems(1).Text
                End If
            Next
        End With
    End Sub
End Class