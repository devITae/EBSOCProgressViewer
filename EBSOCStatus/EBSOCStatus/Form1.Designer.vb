<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.startNokori = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SCodeBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IDSaveBox = New System.Windows.Forms.CheckBox()
        Me.SCodeFind = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.LoginBtn.Location = New System.Drawing.Point(157, 101)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Size = New System.Drawing.Size(88, 56)
        Me.LoginBtn.TabIndex = 2
        Me.LoginBtn.Text = "로그인"
        Me.LoginBtn.UseVisualStyleBackColor = True
        '
        'ClassList
        '
        Me.ClassList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ClassList.Enabled = False
        Me.ClassList.Location = New System.Drawing.Point(16, 185)
        Me.ClassList.Name = "ClassList"
        Me.ClassList.Size = New System.Drawing.Size(229, 369)
        Me.ClassList.TabIndex = 5
        Me.ClassList.UseCompatibleStateImageBehavior = False
        Me.ClassList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "가입된 클래스"
        Me.ColumnHeader1.Width = 205
        '
        'StatusList
        '
        Me.StatusList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ClassHeader, Me.CourseHeader, Me.ProgressHeader})
        Me.StatusList.Enabled = False
        Me.StatusList.Location = New System.Drawing.Point(262, 72)
        Me.StatusList.Name = "StatusList"
        Me.StatusList.Size = New System.Drawing.Size(641, 482)
        Me.StatusList.TabIndex = 6
        Me.StatusList.UseCompatibleStateImageBehavior = False
        Me.StatusList.View = System.Windows.Forms.View.Details
        '
        'ClassHeader
        '
        Me.ClassHeader.Text = "클래스명"
        Me.ClassHeader.Width = 214
        '
        'CourseHeader
        '
        Me.CourseHeader.Text = "강의명"
        Me.CourseHeader.Width = 326
        '
        'ProgressHeader
        '
        Me.ProgressHeader.Text = "진도율"
        Me.ProgressHeader.Width = 90
        '
        'startNokori
        '
        Me.startNokori.Enabled = False
        Me.startNokori.Font = New System.Drawing.Font("Noto Sans CJK KR Regular", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.startNokori.Location = New System.Drawing.Point(825, 18)
        Me.startNokori.Name = "startNokori"
        Me.startNokori.Size = New System.Drawing.Size(78, 48)
        Me.startNokori.TabIndex = 7
        Me.startNokori.Text = "새로고침"
        Me.startNokori.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Noto Sans CJK KR Regular", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(360, 40)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "EBS OnlineClass 진도율 조회"
        '
        'SCodeBox
        '
        Me.SCodeBox.Location = New System.Drawing.Point(87, 72)
        Me.SCodeBox.Name = "SCodeBox"
        Me.SCodeBox.Size = New System.Drawing.Size(95, 21)
        Me.SCodeBox.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 72)
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
        Me.SCodeFind.Location = New System.Drawing.Point(188, 72)
        Me.SCodeFind.Name = "SCodeFind"
        Me.SCodeFind.Size = New System.Drawing.Size(57, 21)
        Me.SCodeFind.TabIndex = 13
        Me.SCodeFind.Text = "찾기"
        Me.SCodeFind.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(132, 565)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(42, 12)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "GitHub"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 561)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(477, 24)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "※ 학습중(진도율 100% 이하) 인 강의들만 목록만 표시됩니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "※ EBS의 DB오류로 인해 간헐적으로 100%를 달성한 강의가 조회되는 경우" &
    "가 있습니다."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 565)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "제작: 이재형 (ITae)"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(919, 595)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.SCodeFind)
        Me.Controls.Add(Me.IDSaveBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SCodeBox)
        Me.Controls.Add(Me.Label1)
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
        Me.Text = "EBS OnlineClass 진도율 조회 v1.10"
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
    Friend WithEvents Label1 As Label
    Friend WithEvents SCodeBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents IDSaveBox As CheckBox
    Friend WithEvents SCodeFind As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
