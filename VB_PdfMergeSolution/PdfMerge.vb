Public Class PdfMerge
    Public Shared main As PdfMerge
    Private PDFFunction As PDFFunction
    Private Sub PdfMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PDFFunction.Btn_Enabled()
    End Sub
    Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click

    End Sub
End Class
