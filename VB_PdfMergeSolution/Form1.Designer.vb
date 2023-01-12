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
        Me.SelectFileBtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FileMergeBtn = New System.Windows.Forms.Button()
        Me.AddFileLabel = New System.Windows.Forms.Label()
        Me.AddFileList = New System.Windows.Forms.ListBox()
        Me.FileIndexUp = New System.Windows.Forms.Button()
        Me.FileIndexDown = New System.Windows.Forms.Button()
        Me.FileDeleteBtn = New System.Windows.Forms.Button()
        Me.FileCleanBtn = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'SelectFileBtn
        '
        Me.SelectFileBtn.Location = New System.Drawing.Point(12, 125)
        Me.SelectFileBtn.Name = "SelectFileBtn"
        Me.SelectFileBtn.Size = New System.Drawing.Size(75, 23)
        Me.SelectFileBtn.TabIndex = 0
        Me.SelectFileBtn.Text = "파일추가"
        Me.SelectFileBtn.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FileMergeBtn
        '
        Me.FileMergeBtn.Location = New System.Drawing.Point(338, 31)
        Me.FileMergeBtn.Name = "FileMergeBtn"
        Me.FileMergeBtn.Size = New System.Drawing.Size(75, 115)
        Me.FileMergeBtn.TabIndex = 1
        Me.FileMergeBtn.Text = "병합하기"
        Me.FileMergeBtn.UseVisualStyleBackColor = True
        '
        'AddFileLabel
        '
        Me.AddFileLabel.AutoSize = True
        Me.AddFileLabel.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.AddFileLabel.Location = New System.Drawing.Point(10, 14)
        Me.AddFileLabel.Name = "AddFileLabel"
        Me.AddFileLabel.Size = New System.Drawing.Size(136, 12)
        Me.AddFileLabel.TabIndex = 2
        Me.AddFileLabel.Text = "PDF 목록 (병합 순서)"
        '
        'AddFileList
        '
        Me.AddFileList.FormattingEnabled = True
        Me.AddFileList.ItemHeight = 12
        Me.AddFileList.Location = New System.Drawing.Point(12, 31)
        Me.AddFileList.Name = "AddFileList"
        Me.AddFileList.Size = New System.Drawing.Size(320, 88)
        Me.AddFileList.TabIndex = 3
        '
        'FileIndexUp
        '
        Me.FileIndexUp.Location = New System.Drawing.Point(276, 125)
        Me.FileIndexUp.Name = "FileIndexUp"
        Me.FileIndexUp.Size = New System.Drawing.Size(25, 23)
        Me.FileIndexUp.TabIndex = 4
        Me.FileIndexUp.Text = "▲"
        Me.FileIndexUp.UseVisualStyleBackColor = True
        '
        'FileIndexDown
        '
        Me.FileIndexDown.Location = New System.Drawing.Point(307, 125)
        Me.FileIndexDown.Name = "FileIndexDown"
        Me.FileIndexDown.Size = New System.Drawing.Size(25, 23)
        Me.FileIndexDown.TabIndex = 5
        Me.FileIndexDown.Text = "▼"
        Me.FileIndexDown.UseVisualStyleBackColor = True
        '
        'FileDeleteBtn
        '
        Me.FileDeleteBtn.Location = New System.Drawing.Point(93, 125)
        Me.FileDeleteBtn.Name = "FileDeleteBtn"
        Me.FileDeleteBtn.Size = New System.Drawing.Size(75, 23)
        Me.FileDeleteBtn.TabIndex = 0
        Me.FileDeleteBtn.Text = "파일삭제"
        Me.FileDeleteBtn.UseVisualStyleBackColor = True
        '
        'FileCleanBtn
        '
        Me.FileCleanBtn.Location = New System.Drawing.Point(174, 125)
        Me.FileCleanBtn.Name = "FileCleanBtn"
        Me.FileCleanBtn.Size = New System.Drawing.Size(75, 23)
        Me.FileCleanBtn.TabIndex = 0
        Me.FileCleanBtn.Text = "초기화"
        Me.FileCleanBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 155)
        Me.Controls.Add(Me.FileIndexDown)
        Me.Controls.Add(Me.FileIndexUp)
        Me.Controls.Add(Me.AddFileList)
        Me.Controls.Add(Me.AddFileLabel)
        Me.Controls.Add(Me.FileMergeBtn)
        Me.Controls.Add(Me.FileCleanBtn)
        Me.Controls.Add(Me.FileDeleteBtn)
        Me.Controls.Add(Me.SelectFileBtn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectFileBtn As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FileMergeBtn As Button
    Friend WithEvents AddFileLabel As Label
    Friend WithEvents AddFileList As ListBox
    Friend WithEvents FileIndexUp As Button
    Friend WithEvents FileIndexDown As Button
    Friend WithEvents FileDeleteBtn As Button
    Friend WithEvents FileCleanBtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
