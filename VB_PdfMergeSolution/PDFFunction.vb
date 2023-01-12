Public Class PDFFunction
    Public Sub Btn_Enabled()
        PdfMerge.FileCleanBtn.Enabled = False
        PdfMerge.FileDeleteBtn.Enabled = False
        PdfMerge.FileMergeBtn.Enabled = False
        PdfMerge.FileIndexUp.Enabled = False
        PdfMerge.FileIndexDown.Enabled = False
    End Sub
End Class
