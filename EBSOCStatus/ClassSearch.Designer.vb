<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClassSearch
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("error")
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nbox = New System.Windows.Forms.TextBox()
        Me.cbox = New System.Windows.Forms.TextBox()
        Me.gbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusList = New System.Windows.Forms.ListView()
        Me.ClassHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CourseHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProgressHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.StartDate = New System.Windows.Forms.DateTimePicker()
        Me.lrnType = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(223, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "번"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(149, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "반"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "학년"
        '
        'nbox
        '
        Me.nbox.Location = New System.Drawing.Point(172, 42)
        Me.nbox.MaxLength = 2
        Me.nbox.Name = "nbox"
        Me.nbox.Size = New System.Drawing.Size(45, 21)
        Me.nbox.TabIndex = 14
        '
        'cbox
        '
        Me.cbox.Location = New System.Drawing.Point(98, 42)
        Me.cbox.MaxLength = 2
        Me.cbox.Name = "cbox"
        Me.cbox.Size = New System.Drawing.Size(45, 21)
        Me.cbox.TabIndex = 13
        '
        'gbox
        '
        Me.gbox.Location = New System.Drawing.Point(12, 42)
        Me.gbox.MaxLength = 1
        Me.gbox.Name = "gbox"
        Me.gbox.Size = New System.Drawing.Size(45, 21)
        Me.gbox.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "자신의 학번을 입력하세요."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(293, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(228, 44)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "전송 시작"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 69)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(509, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 19
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 140)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(509, 47)
        Me.RichTextBox1.TabIndex = 21
        Me.RichTextBox1.Text = "'선생님과 연동'은 부가기능으로, 담임선생님과의 합의가 이루어진 상태에서 제공합니다." & Global.Microsoft.VisualBasic.ChrW(10) & "서버로 수집되는 정보는 이름, ID, 진도율로 민감한 개인정" &
    "보는 수집되지 않습니다."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(444, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 24)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "0학년 0반" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "담임 : 홍길동"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label5.Visible = False
        '
        'ErrorList
        '
        Me.ErrorList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ErrorList.Enabled = False
        Me.ErrorList.FullRowSelect = True
        Me.ErrorList.GridLines = True
        Me.ErrorList.HideSelection = False
        Me.ErrorList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5})
        Me.ErrorList.Location = New System.Drawing.Point(633, 12)
        Me.ErrorList.Name = "ErrorList"
        Me.ErrorList.Size = New System.Drawing.Size(85, 82)
        Me.ErrorList.TabIndex = 27
        Me.ErrorList.UseCompatibleStateImageBehavior = False
        Me.ErrorList.View = System.Windows.Forms.View.Details
        Me.ErrorList.Visible = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "클래스명"
        Me.ColumnHeader2.Width = 218
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "강의명"
        Me.ColumnHeader3.Width = 204
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Tag = "Numeric"
        Me.ColumnHeader4.Text = "진도율"
        Me.ColumnHeader4.Width = 66
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Tag = "Date"
        Me.ColumnHeader5.Text = "학습 시작일"
        Me.ColumnHeader5.Width = 98
        '
        'StatusList
        '
        Me.StatusList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClassHeader, Me.CourseHeader, Me.ProgressHeader, Me.DateHeader})
        Me.StatusList.Enabled = False
        Me.StatusList.FullRowSelect = True
        Me.StatusList.GridLines = True
        Me.StatusList.HideSelection = False
        Me.StatusList.Location = New System.Drawing.Point(551, 12)
        Me.StatusList.Name = "StatusList"
        Me.StatusList.Size = New System.Drawing.Size(76, 82)
        Me.StatusList.TabIndex = 26
        Me.StatusList.UseCompatibleStateImageBehavior = False
        Me.StatusList.View = System.Windows.Forms.View.Details
        Me.StatusList.Visible = False
        '
        'ClassHeader
        '
        Me.ClassHeader.Text = "클래스명"
        Me.ClassHeader.Width = 218
        '
        'CourseHeader
        '
        Me.CourseHeader.Text = "강의명"
        Me.CourseHeader.Width = 204
        '
        'ProgressHeader
        '
        Me.ProgressHeader.Tag = "Numeric"
        Me.ProgressHeader.Text = "진도율"
        Me.ProgressHeader.Width = 66
        '
        'DateHeader
        '
        Me.DateHeader.Tag = "Date"
        Me.DateHeader.Text = "학습 시작일"
        Me.DateHeader.Width = 98
        '
        'EndDate
        '
        Me.EndDate.CustomFormat = "YYYY.MM.DD"
        Me.EndDate.Enabled = False
        Me.EndDate.Location = New System.Drawing.Point(551, 139)
        Me.EndDate.MinDate = New Date(2020, 3, 1, 0, 0, 0, 0)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(213, 21)
        Me.EndDate.TabIndex = 25
        Me.EndDate.Visible = False
        '
        'StartDate
        '
        Me.StartDate.AccessibleDescription = ""
        Me.StartDate.AccessibleName = ""
        Me.StartDate.CustomFormat = "YYYY.MM.DD"
        Me.StartDate.Enabled = False
        Me.StartDate.Location = New System.Drawing.Point(551, 100)
        Me.StartDate.MinDate = New Date(2020, 3, 1, 0, 0, 0, 0)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(213, 21)
        Me.StartDate.TabIndex = 24
        Me.StartDate.Tag = ""
        Me.StartDate.Value = New Date(2020, 10, 5, 13, 2, 36, 0)
        Me.StartDate.Visible = False
        '
        'lrnType
        '
        Me.lrnType.AutoSize = True
        Me.lrnType.Location = New System.Drawing.Point(721, 51)
        Me.lrnType.Name = "lrnType"
        Me.lrnType.Size = New System.Drawing.Size(41, 12)
        Me.lrnType.TabIndex = 28
        Me.lrnType.Text = "학습중"
        Me.lrnType.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 12)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Label6"
        Me.Label6.Visible = False
        '
        'ClassSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(535, 198)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lrnType)
        Me.Controls.Add(Me.ErrorList)
        Me.Controls.Add(Me.StatusList)
        Me.Controls.Add(Me.EndDate)
        Me.Controls.Add(Me.StartDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nbox)
        Me.Controls.Add(Me.cbox)
        Me.Controls.Add(Me.gbox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClassSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "선생님과 연동"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nbox As TextBox
    Friend WithEvents cbox As TextBox
    Friend WithEvents gbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ErrorList As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents StatusList As ListView
    Friend WithEvents ClassHeader As ColumnHeader
    Friend WithEvents CourseHeader As ColumnHeader
    Friend WithEvents ProgressHeader As ColumnHeader
    Friend WithEvents DateHeader As ColumnHeader
    Friend WithEvents EndDate As DateTimePicker
    Friend WithEvents StartDate As DateTimePicker
    Friend WithEvents lrnType As Label
    Friend WithEvents Label6 As Label
End Class
