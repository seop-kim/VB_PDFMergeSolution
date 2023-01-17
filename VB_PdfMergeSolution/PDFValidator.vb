Public Class PDFValidator
    Private Const LOWER_PDF As String = ".pdf"
    Private Const UPPER_PDF As String = ".PDF"
    Function File_Compare(ByVal fileName As String) As Boolean
        If PdfMerge.getFiles.ContainsKey(fileName) Then ' 목록에 동일한 파일명이 존재할 경우 추가 불가
            Return False
        End If

        Return True
    End Function

    Function File_Ext_PDF(ByVal fileExtension As String) As Boolean
        If Not (fileExtension.Equals(LOWER_PDF) Or fileExtension.Equals(UPPER_PDF)) Then ' PDF 형식의 파일인지 확인
            Return False
        End If
        Return True
    End Function
End Class
