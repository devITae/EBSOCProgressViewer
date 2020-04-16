<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchCode))
        Me.Keyword = New System.Windows.Forms.TextBox()
        Me.goSearch = New System.Windows.Forms.Button()
        Me.Result = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.goSelect = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Keyword
        '
        Me.Keyword.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Keyword.Location = New System.Drawing.Point(13, 30)
        Me.Keyword.Name = "Keyword"
        Me.Keyword.Size = New System.Drawing.Size(241, 26)
        Me.Keyword.TabIndex = 0
        '
        'goSearch
        '
        Me.goSearch.Location = New System.Drawing.Point(260, 29)
        Me.goSearch.Name = "goSearch"
        Me.goSearch.Size = New System.Drawing.Size(78, 27)
        Me.goSearch.TabIndex = 1
        Me.goSearch.Text = "검색"
        Me.goSearch.UseVisualStyleBackColor = True
        '
        'Result
        '
        Me.Result.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.Result.Location = New System.Drawing.Point(12, 62)
        Me.Result.Name = "Result"
        Me.Result.Size = New System.Drawing.Size(325, 243)
        Me.Result.TabIndex = 3
        Me.Result.UseCompatibleStateImageBehavior = False
        Me.Result.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "학교이름"
        Me.ColumnHeader1.Width = 219
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "학교코드"
        Me.ColumnHeader2.Width = 78
        '
        'goSelect
        '
        Me.goSelect.Enabled = False
        Me.goSelect.Location = New System.Drawing.Point(12, 311)
        Me.goSelect.Name = "goSelect"
        Me.goSelect.Size = New System.Drawing.Size(324, 32)
        Me.goSelect.TabIndex = 4
        Me.goSelect.Text = "선택하기"
        Me.goSelect.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "학교 이름을 검색해주세요."
        '
        'SearchCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(349, 352)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.goSelect)
        Me.Controls.Add(Me.Result)
        Me.Controls.Add(Me.goSearch)
        Me.Controls.Add(Me.Keyword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "학교코드 검색기"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Keyword As TextBox
    Friend WithEvents goSearch As Button
    Friend WithEvents Result As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents goSelect As Button
    Friend WithEvents Label1 As Label
End Class
