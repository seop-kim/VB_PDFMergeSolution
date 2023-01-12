Public Class PdfMerge
	Private PDFFunction As PDFFunction = New PDFFunction
	Private Files As Dictionary(Of String, String) = New Dictionary(Of String, String)

	Private Const ERROR_MSG As String = "ERROR"
	Private Const PDF As String = ".pdf"
	Private Const COMP_MSH As String = "COMPLETE"

	Private Sub PdfMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PDFFunction.App_Lunch_Btn_Enabled()
	End Sub

	Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click
		Dim selectFile As OpenFileDialog = New OpenFileDialog
		Dim selectFileResult As DialogResult
		Dim filePath As String = ""
		Dim fileName As String = ""
		Dim fileExtension As String = ""

		selectFile.Filter = "PDF (.pdf)|*.pdf" ' PDF만 선택할 수 있도록 Filter 설정
		selectFileResult = selectFile.ShowDialog()

		If selectFileResult = DialogResult.OK Then ' 파일을 선택했는지 확인
			filePath = selectFile.FileName
			fileName = selectFile.SafeFileName
			fileExtension = IO.Path.GetExtension(filePath)

		ElseIf selectFileResult = DialogResult.Cancel Then
			MsgBox("파일을 선택하지 않았습니다.",, ERROR_MSG)
			Return
		End If

		If Files.ContainsKey(fileName) Then ' 목록에 동일한 파일명이 존재할 경우 추가 불가
			MsgBox("'" + fileName + "'과 동일한 파일명이 존재합니다.
파일명을 다르게 설정해 주세요.",, ERROR_MSG)
			Return
		End If

		If fileExtension.Equals(PDF) Then ' PDF 형식의 파일인지 확인
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

	Private Sub FileDeleteBtn_Click(sender As Object, e As EventArgs) Handles FileDeleteBtn.Click
		Dim selectItem As Integer = AddFileList.SelectedIndex
		MsgBox("'" + AddFileList.Items(selectItem) + "' 파일을 목록에서 제거합니다.",, "COMP")
		Files.Remove(AddFileList.Items(selectItem))
		AddFileList.Items.RemoveAt(selectItem)
		PDFFunction.Delete_Other_Btn_Enabled()
	End Sub

	Private Sub AddFileList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AddFileList.SelectedIndexChanged
		PDFFunction.Delete_Btn_Enabled()
	End Sub


End Class
