Public Class DateDialog
    Private Sub DateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True '항상 위
        ControlEnable(True)
        Me.Cursor = Cursors.Default '커서 디폴트로 복귀
        If Form1.lrnType.Text = "학습완료" Then
            RadioWeek.Checked = True
            RadioMonth.Checked = False
        ElseIf Form1.lrnType.Text = "미수강중" Then
            RadioMonth.Checked = True
            RadioWeek.Checked = False
        End If
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub GoWork_Click(sender As Object, e As EventArgs) Handles GoWork.Click
        Try
            RemoveCloseButton(Me.Handle)
            ControlEnable(False)
            'Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor '로딩 커서
            If Form1.lrnType.Text = "학습완료" Then
                Call Form1.CallNokori()
                Application.DoEvents()
            ElseIf Form1.lrnType.Text = "미수강중" Then
                Call Form1.CallNotEnrolled()
                Application.DoEvents()
            End If
            'Me.Cursor = Cursors.Default '커서 디폴트로 복귀
        Catch ex As IndexOutOfRangeException
            Call Form1.LoginCheck() '로그인 재확인
            Me.Hide()
        End Try
        Me.Close()
    End Sub
    Private Sub RadioAll_CheckedChanged(sender As Object, e As EventArgs) Handles RadioAll.CheckedChanged
        DateEnable(False)
        StartDate.Value = New DateTime(2020, 3, 1) 'Min
        EndDate.Value = DateTime.Today 'Max
    End Sub
    Private Sub RadioWeek_CheckedChanged(sender As Object, e As EventArgs) Handles RadioWeek.CheckedChanged
        '이번주 월요일~일요일
        DateEnable(False)
        Dim Today As Integer
        Today = DateTime.Today.DayOfWeek
        StartDate.Value = DateTime.Today.AddDays(1 - Today) 'Monday
        EndDate.Value = DateTime.Today.AddDays(0 - Today + 7) 'Sunday
    End Sub
    Private Sub RadioLastWeek_CheckedChanged(sender As Object, e As EventArgs) Handles RadioLastWeek.CheckedChanged
        '저번주 월요일~일요일
        DateEnable(False)
        Dim Today As Integer
        Today = DateTime.Today.DayOfWeek
        StartDate.Value = DateTime.Today.AddDays(1 - Today - 7) 'Monday
        EndDate.Value = DateTime.Today.AddDays(0 - Today) 'Sunday
    End Sub
    Private Sub RadioMonth_CheckedChanged(sender As Object, e As EventArgs) Handles RadioMonth.CheckedChanged
        '최근 한 달
        DateEnable(False)
        StartDate.Value = DateTime.Today.AddDays(-30) '-30일
        EndDate.Value = DateTime.Today 'Today
    End Sub
    Private Sub RadioCustom_CheckedChanged(sender As Object, e As EventArgs) Handles RadioCustom.CheckedChanged
        DateEnable(True)
    End Sub
    Private Sub DateEnable(Bool As Boolean)
        StartDate.Enabled = Bool
        EndDate.Enabled = Bool
    End Sub
    Public Sub ControlEnable(Bool As Boolean)
        RadioAll.Enabled = Bool
        RadioWeek.Enabled = Bool
        RadioLastWeek.Enabled = Bool
        RadioMonth.Enabled = Bool
        RadioCustom.Enabled = Bool
        GoWork.Enabled = Bool
        Cancel.Enabled = Bool
    End Sub

    'https://happybono.wordpress.com/2017/08/28/vb-net-%EB%8B%AB%EA%B8%B0-x-%EB%B2%84%ED%8A%BC-%EB%B9%84%ED%99%9C%EC%84%B1%ED%99%94-%ED%95%98%EA%B8%B0/
    Public Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer
    Public Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
    Public Const SC_CLOSE = &HF060&
    Public Const MF_BYCOMMAND = &H0&

    Function RemoveCloseButton(ByVal iHWND As Integer) As Integer
        Dim iSysMenu As Integer
        iSysMenu = GetSystemMenu(iHWND, False)
        Return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND)
    End Function
End Class