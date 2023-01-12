Public Class PDFFunction
    Public Sub App_Lunch_Btn_Enabled()
        PdfMerge.FileCleanBtn.Enabled = False
        PdfMerge.FileDeleteBtn.Enabled = False
        PdfMerge.FileMergeBtn.Enabled = False
        PdfMerge.FileIndexUp.Enabled = False
        PdfMerge.FileIndexDown.Enabled = False
    End Sub

    Public Sub List_Add_Item_Btn_Enabled()
        PdfMerge.FileCleanBtn.Enabled = True
        PdfMerge.FileDeleteBtn.Enabled = True
    End Sub

    Public Sub List_Add_Two_Item_Btn_Enabled()
        If PdfMerge.AddFileList.Items.Count >= 2 Then
            PdfMerge.FileMergeBtn.Enabled = True
            PdfMerge.FileIndexUp.Enabled = True
            PdfMerge.FileIndexDown.Enabled = True
        End If
    End Sub
End Class
