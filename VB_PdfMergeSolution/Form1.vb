Public Class PdfMerge
    Private Sub PdfMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_Enabled()
    End Sub
    Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click

    End Sub


    Private Sub Btn_Enabled()
        FileCleanBtn.Enabled = False
        FileDeleteBtn.Enabled = False
        FileMergeBtn.Enabled = False
        FileIndexUp.Enabled = False
        FileIndexDown.Enabled = False
    End Sub
End Class
