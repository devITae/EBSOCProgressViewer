<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateDialog
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
        Me.GoWork = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.StartDate = New System.Windows.Forms.DateTimePicker()
        Me.EndDate = New System.Windows.Forms.DateTimePicker()
        Me.RadioAll = New System.Windows.Forms.RadioButton()
        Me.RadioCustom = New System.Windows.Forms.RadioButton()
        Me.RadioWeek = New System.Windows.Forms.RadioButton()
        Me.RadioLastWeek = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioMonth = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'GoWork
        '
        Me.GoWork.Location = New System.Drawing.Point(12, 127)
        Me.GoWork.Name = "GoWork"
        Me.GoWork.Size = New System.Drawing.Size(103, 23)
        Me.GoWork.TabIndex = 0
        Me.GoWork.Text = "조회"
        Me.GoWork.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(122, 127)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(103, 23)
        Me.Cancel.TabIndex = 1
        Me.Cancel.Text = "취소"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'StartDate
        '
        Me.StartDate.AccessibleDescription = ""
        Me.StartDate.AccessibleName = ""
        Me.StartDate.CustomFormat = "YYYY.MM.DD"
        Me.StartDate.Enabled = False
        Me.StartDate.Location = New System.Drawing.Point(12, 56)
        Me.StartDate.MinDate = New Date(2020, 3, 1, 0, 0, 0, 0)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(213, 21)
        Me.StartDate.TabIndex = 2
        Me.StartDate.Tag = ""
        Me.StartDate.Value = New Date(2020, 10, 5, 13, 2, 36, 0)
        '
        'EndDate
        '
        Me.EndDate.CustomFormat = "YYYY.MM.DD"
        Me.EndDate.Enabled = False
        Me.EndDate.Location = New System.Drawing.Point(12, 95)
        Me.EndDate.MinDate = New Date(2020, 3, 1, 0, 0, 0, 0)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(213, 21)
        Me.EndDate.TabIndex = 3
        '
        'RadioAll
        '
        Me.RadioAll.AutoSize = True
        Me.RadioAll.Location = New System.Drawing.Point(12, 12)
        Me.RadioAll.Name = "RadioAll"
        Me.RadioAll.Size = New System.Drawing.Size(75, 16)
        Me.RadioAll.TabIndex = 4
        Me.RadioAll.Text = "전체 범위"
        Me.RadioAll.UseVisualStyleBackColor = True
        '
        'RadioCustom
        '
        Me.RadioCustom.AutoSize = True
        Me.RadioCustom.Location = New System.Drawing.Point(12, 34)
        Me.RadioCustom.Name = "RadioCustom"
        Me.RadioCustom.Size = New System.Drawing.Size(75, 16)
        Me.RadioCustom.TabIndex = 5
        Me.RadioCustom.Text = "날짜 지정"
        Me.RadioCustom.UseVisualStyleBackColor = True
        '
        'RadioWeek
        '
        Me.RadioWeek.AutoSize = True
        Me.RadioWeek.Checked = True
        Me.RadioWeek.Location = New System.Drawing.Point(93, 12)
        Me.RadioWeek.Name = "RadioWeek"
        Me.RadioWeek.Size = New System.Drawing.Size(63, 16)
        Me.RadioWeek.TabIndex = 6
        Me.RadioWeek.TabStop = True
        Me.RadioWeek.Text = "이번 주"
        Me.RadioWeek.UseVisualStyleBackColor = True
        '
        'RadioLastWeek
        '
        Me.RadioLastWeek.AutoSize = True
        Me.RadioLastWeek.Location = New System.Drawing.Point(162, 12)
        Me.RadioLastWeek.Name = "RadioLastWeek"
        Me.RadioLastWeek.Size = New System.Drawing.Size(63, 16)
        Me.RadioLastWeek.TabIndex = 7
        Me.RadioLastWeek.Text = "저번 주"
        Me.RadioLastWeek.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "~"
        '
        'RadioMonth
        '
        Me.RadioMonth.AutoSize = True
        Me.RadioMonth.Location = New System.Drawing.Point(146, 34)
        Me.RadioMonth.Name = "RadioMonth"
        Me.RadioMonth.Size = New System.Drawing.Size(79, 16)
        Me.RadioMonth.TabIndex = 9
        Me.RadioMonth.Text = "최근 한 달"
        Me.RadioMonth.UseVisualStyleBackColor = True
        '
        'DateDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(241, 162)
        Me.Controls.Add(Me.RadioMonth)
        Me.Controls.Add(Me.EndDate)
        Me.Controls.Add(Me.StartDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioLastWeek)
        Me.Controls.Add(Me.RadioWeek)
        Me.Controls.Add(Me.RadioCustom)
        Me.Controls.Add(Me.RadioAll)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.GoWork)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DateDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "범위 설정"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GoWork As Button
    Friend WithEvents Cancel As Button
    Friend WithEvents StartDate As DateTimePicker
    Friend WithEvents EndDate As DateTimePicker
    Friend WithEvents RadioAll As RadioButton
    Friend WithEvents RadioCustom As RadioButton
    Friend WithEvents RadioWeek As RadioButton
    Friend WithEvents RadioLastWeek As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioMonth As RadioButton
End Class
