Imports org.apache.pdfbox.util

Public Class PdfMerge
	Private PDFFunction As PDFFunction = New PDFFunction
	Private PDFValidator As PDFValidator = New PDFValidator
	Private Files As Dictionary(Of String, String) = New Dictionary(Of String, String)
	Private filePath As String = ""
	Private fileName As String = ""
	Private fileExtension As String = ""

	Function getFiles() As Dictionary(Of String, String)
		Return Files
	End Function


	Private Const ERROR_MSG As String = "ERROR"
	Private Const COMP_MSH As String = "COMPLETE"

	Private Sub PdfMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PDFFunction.App_All_Btn_Enabled()
	End Sub

	' Add file
	Private Sub SelectFileBtn_Click(sender As Object, e As EventArgs) Handles SelectFileBtn.Click
		Dim selectFile As OpenFileDialog = New OpenFileDialog
		Dim selectFileResult As DialogResult


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

		If Not (PDFValidator.File_Compare(fileName)) Then ' 목록에 동일한 파일명이 존재할 경우 추가 불가
			Return
		End If

		If Not (PDFValidator.File_Ext_PDF(fileExtension)) Then ' PDF 형식의 파일인지 확인
			MsgBox("PDF 형식의 파일만 선택이 가능합니다.",, COMP_MSH)
			Return
		End If

		AddFileList_Add(fileName, filePath)
	End Sub

	' Delete file
	Private Sub FileDeleteBtn_Click(sender As Object, e As EventArgs) Handles FileDeleteBtn.Click
		Dim selectItem As Integer = AddFileList.SelectedIndex
		'MsgBox("'" + AddFileList.Items(selectItem) + "' 파일을 목록에서 제거합니다.",, "COMP")
		Files.Remove(AddFileList.Items(selectItem))
		AddFileList.Items.RemoveAt(selectItem)
		PDFFunction.Delete_Other_Btn_Enabled()
		PDFFunction.Notis_Add("[삭제]", "선택항목을 삭제하였습니다.")
	End Sub

	' Select ListBox
	Private Sub AddFileList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AddFileList.SelectedIndexChanged
		PDFFunction.List_Select_Btn_Enabled()
	End Sub

	' Clear file
	Private Sub FileCleanBtn_Click(sender As Object, e As EventArgs) Handles FileCleanBtn.Click
		Files.Clear()
		AddFileList.Items.Clear()
		'MsgBox("목록을 초기화 하였습니다.",, "COMP")
		PDFFunction.App_All_Btn_Enabled()
		PDFFunction.Notis_Add("[초기화]", "목록을 초기화 하였습니다.")
	End Sub

	' Change Index Up
	Private Sub FileIndexUp_Click(sender As Object, e As EventArgs) Handles FileIndexUp.Click
		If (AddFileList.SelectedIndex <= 0) Then
			Return
		End If

		Dim upItemIndex As Integer = AddFileList.SelectedIndex
		Dim downItemIndex As Integer = AddFileList.SelectedIndex - 1

		Dim saveUpItem As String = AddFileList.Items(upItemIndex)
		Dim saveDownItem As String = AddFileList.Items(downItemIndex)

		AddFileList.Items(downItemIndex) = saveUpItem
		AddFileList.Items(upItemIndex) = saveDownItem

		AddFileList.SelectedIndex = downItemIndex
		FileIndexUp.Focus()
	End Sub

	' Change Index Down
	Private Sub FileIndexDown_Click(sender As Object, e As EventArgs) Handles FileIndexDown.Click
		If (AddFileList.Items.Count <= AddFileList.SelectedIndex + 1) Then
			Return
		End If

		Dim downItemIndex As Integer = AddFileList.SelectedIndex
		Dim upItemIndex As Integer = AddFileList.SelectedIndex + 1

		Dim saveDownItem As String = AddFileList.Items(downItemIndex)
		Dim saveUpItem As String = AddFileList.Items(upItemIndex)

		AddFileList.Items(upItemIndex) = saveDownItem
		AddFileList.Items(downItemIndex) = saveUpItem

		AddFileList.SelectedIndex = upItemIndex
		FileIndexDown.Focus()
	End Sub

	Private Sub FileMergeBtn_Click(sender As Object, e As EventArgs) Handles FileMergeBtn.Click
		PDFFunction.Merge_PDF(Files)
	End Sub

	Private Sub Notis_SelectedIndexClick(sender As Object, e As EventArgs) Handles Notis.Click
		Notis.SelectedItem = Nothing
	End Sub

	Private Sub AddFileList_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles AddFileList.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		End If
	End Sub


	Private Sub AddFileList_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles AddFileList.DragDrop
		Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
		Dim fileInfo As IO.FileInfo = Nothing

		For index = 0 To files.Length - 1
			filePath = files(index)
			fileName = System.IO.Path.GetFileName(filePath)
			fileInfo = New IO.FileInfo(filePath)
			fileExtension = fileInfo.Extension

			If Not (PDFValidator.File_Compare(fileName)) Then ' 목록에 동일한 파일명이 존재할 경우 추가 불가
				Continue For
			End If

			If Not (PDFValidator.File_Ext_PDF(fileExtension)) Then ' PDF 형식의 파일인지 확인
				Continue For
			End If

			AddFileList_Add(fileName, filePath)
		Next
	End Sub

	Private Sub AddFileList_Add(ByVal name As String, ByVal path As String)
		AddFileList.Items.Add(name)
		Files.Add(name, path)
		PDFFunction.List_Add_Item_Btn_Enabled()
		PDFFunction.List_Add_Two_Item_Btn_Enabled()
		PDFFunction.Notis_Add("[추가]", "파일을 추가하였습니다. " + name)
	End Sub
End Class
