Public Class PDFValidator

    Private Const ERROR_MSG As String = "ERROR"
    Private Const COMP_MSH As String = "COMPLETE"
    Private Const PDF As String = ".pdf"
    Function File_Compare(ByVal fileName As String) As Boolean
        If PdfMerge.getFiles.ContainsKey(fileName) Then ' 목록에 동일한 파일명이 존재할 경우 추가 불가
            MsgBox("'" + fileName + "'과 동일한 파일명이 존재합니다.
파일명을 다르게 설정해 주세요.",, ERROR_MSG)
            Return False
        End If

        Return True
    End Function

    Function File_Ext_PDF(ByVal fileExtension As String) As Boolean
        If Not (fileExtension.Equals(PDF)) Then ' PDF 형식의 파일인지 확인
            MsgBox("PDF 형식의 파일만 선택이 가능합니다.",, COMP_MSH)
            Return False
        End If

        Return True
    End Function
End Class
