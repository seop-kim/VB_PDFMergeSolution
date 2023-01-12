Public Class PdfMerge
	Private PDFFunction As PDFFunction = New PDFFunction
	Private Files As Dictionary(Of String, String) = New Dictionary(Of String, String)

	Private Const ERROR_MSG As String = "ERROR"
	Private Const PDF As String = ".PDF"
	Private Const COMP_MSH As String = "COMPLETE"

	Private Sub PdfMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PDFFunction.App_Lunch_Btn_Enabled()
	End Sub

	Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click
		Dim selectFile As OpenFileDialog = New OpenFileDialog
		Dim selectFileResult As DialogResult
		Dim filePath As String = ""
		Dim fileName As String = ""

		selectFileResult = selectFile.ShowDialog()

		' 파일을 선택했는지 확인
		If selectFileResult = DialogResult.OK Then
			filePath = selectFile.FileName
			fileName = selectFile.SafeFileName

		ElseIf selectFileResult = DialogResult.Cancel Then
			MsgBox("파일을 선택하지 않았습니다.",, ERROR_MSG)
			Return
		End If

		If Files.ContainsKey(fileName) Then
			MsgBox("'" + fileName + "'과 동일한 파일명이 존재합니다.
파일명을 다르게 설정해 주세요.",, ERROR_MSG)
			Return
		End If


		' PDF 형식의 파일인지 확인
		If filePath.Contains(PDF) Then
			AddFileList.Items.Add(fileName)
			Files.Add(fileName, filePath)
			PDFFunction.List_Add_Item_Btn_Enabled()
			MsgBox("'" + fileName + "'이(가) 추가되었습니다.",, COMP_MSH)
		Else
			MsgBox("PDF 형식의 파일만 선택이 가능합니다.",, COMP_MSH)
			Return
		End If

		PDFFunction.List_Add_Two_Item_Btn_Enabled()
	End Sub



End Class
