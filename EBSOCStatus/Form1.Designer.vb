<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("로그인이 필요합니다!")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.IDBox = New System.Windows.Forms.TextBox()
        Me.PWBox = New System.Windows.Forms.TextBox()
        Me.LoginBtn = New System.Windows.Forms.Button()
        Me.ClassList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusList = New System.Windows.Forms.ListView()
        Me.ClassHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CourseHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProgressHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.startNokori = New System.Windows.Forms.Button()
        Me.SCodeBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IDSaveBox = New System.Windows.Forms.CheckBox()
        Me.SCodeFind = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lrnType = New System.Windows.Forms.ComboBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.EnrollBtn = New System.Windows.Forms.Button()
        Me.EnrollPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GoClass = New System.Windows.Forms.Button()
        Me.openSender = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.EnrollPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDBox
        '
        Me.IDBox.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.IDBox.Location = New System.Drawing.Point(16, 101)
        Me.IDBox.Name = "IDBox"
        Me.IDBox.Size = New System.Drawing.Size(135, 25)
        Me.IDBox.TabIndex = 0
        '
        'PWBox
        '
        Me.PWBox.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.PWBox.Location = New System.Drawing.Point(16, 132)
        Me.PWBox.Name = "PWBox"
        Me.PWBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PWBox.Size = New System.Drawing.Size(135, 25)
        Me.PWBox.TabIndex = 1
        '
        'LoginBtn
        '
        Me.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LoginBtn.Location = New System.Drawing.Point(157, 101)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(88, 56)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "로그인"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'ClassList
        '
        Me.ClassList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ClassList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ClassList.Enabled = False
        Me.ClassList.FullRowSelect = True
        Me.ClassList.HideSelection = False
        Me.ClassList.Location = New System.Drawing.Point(16, 185)
        Me.ClassList.MultiSelect = False
        Me.ClassList.Name = "ClassList"
        Me.ClassList.Size = New System.Drawing.Size(229, 304)
        Me.ClassList.TabIndex = 5
        Me.ClassList.UseCompatibleStateImageBehavior = False
        Me.ClassList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "가입한 클래스"
        Me.ColumnHeader1.Width = 231
        '
        'StatusList
        '
        Me.StatusList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClassHeader, Me.CourseHeader, Me.ProgressHeader, Me.DateHeader})
        Me.StatusList.Enabled = False
        Me.StatusList.FullRowSelect = True
        Me.StatusList.GridLines = True
        Me.StatusList.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.StatusList.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.StatusList.Location = New System.Drawing.Point(262, 72)
        Me.StatusList.Name = "StatusList"
        Me.StatusList.Size = New System.Drawing.Size(742, 456)
        Me.StatusList.TabIndex = 6
        Me.StatusList.UseCompatibleStateImageBehavior = False
        Me.StatusList.View = System.Windows.Forms.View.Details
        '
        'ClassHeader
        '
        Me.ClassHeader.Text = "클래스명"
        Me.ClassHeader.Width = 245
        '
        'CourseHeader
        '
        Me.CourseHeader.Text = "강의명"
        Me.CourseHeader.Width = 290
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
        'startNokori
        '
        Me.startNokori.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.startNokori.Enabled = False
        Me.startNokori.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.startNokori.Font = New System.Drawing.Font("맑은 고딕", 9.818182!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.startNokori.Location = New System.Drawing.Point(919, 11)
        Me.startNokori.Name = "startNokori"
        Me.startNokori.Size = New System.Drawing.Size(85, 54)
        Me.startNokori.TabIndex = 7
        Me.startNokori.Text = "새로고침"
        Me.startNokori.UseVisualStyleBackColor = True
        '
        'SCodeBox
        '
        Me.SCodeBox.Location = New System.Drawing.Point(86, 72)
        Me.SCodeBox.Name = "SCodeBox"
        Me.SCodeBox.ReadOnly = True
        Me.SCodeBox.Size = New System.Drawing.Size(96, 21)
        Me.SCodeBox.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.12727!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "학교코드"
        '
        'IDSaveBox
        '
        Me.IDSaveBox.AutoSize = True
        Me.IDSaveBox.Location = New System.Drawing.Point(157, 163)
        Me.IDSaveBox.Name = "IDSaveBox"
        Me.IDSaveBox.Size = New System.Drawing.Size(88, 16)
        Me.IDSaveBox.TabIndex = 12
        Me.IDSaveBox.Text = "아이디 저장"
        Me.IDSaveBox.UseVisualStyleBackColor = True
        '
        'SCodeFind
        '
        Me.SCodeFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SCodeFind.Location = New System.Drawing.Point(188, 72)
        Me.SCodeFind.Name = "SCodeFind"
        Me.SCodeFind.Size = New System.Drawing.Size(57, 21)
        Me.SCodeFind.TabIndex = 13
        Me.SCodeFind.Text = "검색"
        Me.SCodeFind.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(203, 574)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(42, 12)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "GitHub"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 551)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "제작: 이재형 (ITae)"
        '
        'lrnType
        '
        Me.lrnType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lrnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lrnType.Enabled = False
        Me.lrnType.Font = New System.Drawing.Font("맑은 고딕", 9.818182!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lrnType.FormattingEnabled = True
        Me.lrnType.Items.AddRange(New Object() {"학습중", "학습완료", "미수강중"})
        Me.lrnType.Location = New System.Drawing.Point(800, 27)
        Me.lrnType.Name = "lrnType"
        Me.lrnType.Size = New System.Drawing.Size(109, 25)
        Me.lrnType.TabIndex = 17
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(262, 540)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(651, 57)
        Me.RichTextBox1.TabIndex = 18
        Me.RichTextBox1.Text = "※ 진도율은 프로그램 내에서 진행된 자체적인 계산입니다. (완강수 / 목차수 * 100)" & Global.Microsoft.VisualBasic.ChrW(10) & "※ 열(Column) 클릭 : 오름/내림차순  ※행(Ro" &
    "w) 더블클릭 : 기본 브라우저로 열기 or 선택 항목 수강신청" & Global.Microsoft.VisualBasic.ChrW(10) & "※ 조회 내용이 잘못되었다면, 새로고침하거나 홈페이지에서 다시 확인해주세요."
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 574)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 12)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "버전: v2.6.1 (Build 201118)"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(179, 551)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(66, 12)
        Me.LinkLabel2.TabIndex = 21
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Changelog"
        '
        'EnrollBtn
        '
        Me.EnrollBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EnrollBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.EnrollBtn.Font = New System.Drawing.Font("맑은 고딕", 9.818182!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EnrollBtn.Location = New System.Drawing.Point(457, 0)
        Me.EnrollBtn.Name = "EnrollBtn"
        Me.EnrollBtn.Size = New System.Drawing.Size(285, 33)
        Me.EnrollBtn.TabIndex = 22
        Me.EnrollBtn.Text = "선택한 항목 전체를 수강신청"
        Me.EnrollBtn.UseVisualStyleBackColor = True
        '
        'EnrollPanel
        '
        Me.EnrollPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EnrollPanel.Controls.Add(Me.Label1)
        Me.EnrollPanel.Controls.Add(Me.EnrollBtn)
        Me.EnrollPanel.Location = New System.Drawing.Point(262, 495)
        Me.EnrollPanel.Name = "EnrollPanel"
        Me.EnrollPanel.Size = New System.Drawing.Size(742, 33)
        Me.EnrollPanel.TabIndex = 23
        Me.EnrollPanel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(349, 12)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "* 드래그 or Ctrl로 다중 선택 후 체크박스 클릭 시 동시선택 가능"
        '
        'GoClass
        '
        Me.GoClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GoClass.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GoClass.Font = New System.Drawing.Font("맑은 고딕", 9.818182!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GoClass.Location = New System.Drawing.Point(16, 495)
        Me.GoClass.Name = "GoClass"
        Me.GoClass.Size = New System.Drawing.Size(229, 33)
        Me.GoClass.TabIndex = 24
        Me.GoClass.Text = "학교 페이지 바로가기"
        Me.GoClass.UseVisualStyleBackColor = True
        '
        'openSender
        '
        Me.openSender.Enabled = False
        Me.openSender.Location = New System.Drawing.Point(919, 540)
        Me.openSender.Name = "openSender"
        Me.openSender.Size = New System.Drawing.Size(85, 57)
        Me.openSender.TabIndex = 25
        Me.openSender.Text = "선생님과" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "연동"
        Me.openSender.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.EBSOCStatus.My.Resources.Resources.title
        Me.PictureBox1.Location = New System.Drawing.Point(16, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(387, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1022, 606)
        Me.Controls.Add(Me.openSender)
        Me.Controls.Add(Me.GoClass)
        Me.Controls.Add(Me.EnrollPanel)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.lrnType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.SCodeFind)
        Me.Controls.Add(Me.IDSaveBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SCodeBox)
        Me.Controls.Add(Me.startNokori)
        Me.Controls.Add(Me.StatusList)
        Me.Controls.Add(Me.ClassList)
        Me.Controls.Add(Me.LoginBtn)
        Me.Controls.Add(Me.PWBox)
        Me.Controls.Add(Me.IDBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EBS OnlineClass 진도율 뷰어 v2.6.1"
        Me.EnrollPanel.ResumeLayout(False)
        Me.EnrollPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IDBox As TextBox
    Friend WithEvents PWBox As TextBox
    Friend WithEvents LoginBtn As Button
    Friend WithEvents ClassList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents StatusList As ListView
    Friend WithEvents CourseHeader As ColumnHeader
    Friend WithEvents ProgressHeader As ColumnHeader
    Friend WithEvents ClassHeader As ColumnHeader
    Friend WithEvents startNokori As Button
    Friend WithEvents SCodeBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents IDSaveBox As CheckBox
    Friend WithEvents SCodeFind As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents lrnType As ComboBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents EnrollBtn As Button
    Friend WithEvents DateHeader As ColumnHeader
    Friend WithEvents EnrollPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GoClass As Button
    Friend WithEvents openSender As Button
End Class
