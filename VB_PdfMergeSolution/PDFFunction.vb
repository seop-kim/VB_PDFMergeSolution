Imports org.apache.pdfbox.util

Public Class PDFFunction
	Dim ListIndexLocation As Integer = -1
	Public Sub App_All_Btn_Enabled()
		PdfMerge.FileCleanBtn.Enabled = False
		PdfMerge.FileDeleteBtn.Enabled = False
		PdfMerge.FileMergeBtn.Enabled = False
		PdfMerge.FileIndexUp.Enabled = False
		PdfMerge.FileIndexDown.Enabled = False
	End Sub

	Public Sub List_Add_Item_Btn_Enabled()
		PdfMerge.FileCleanBtn.Enabled = True
	End Sub

	Public Sub List_Add_Two_Item_Btn_Enabled()
		If PdfMerge.AddFileList.Items.Count >= 2 Then
			PdfMerge.FileMergeBtn.Enabled = True
		End If
	End Sub

	Public Sub List_Select_Btn_Enabled()
		If PdfMerge.AddFileList.SelectedIndex = -1 Then
			PdfMerge.FileDeleteBtn.Enabled = False
			PdfMerge.FileIndexUp.Enabled = False
			PdfMerge.FileIndexDown.Enabled = False
		Else
			PdfMerge.FileDeleteBtn.Enabled = True
			PdfMerge.FileIndexUp.Enabled = True
			PdfMerge.FileIndexDown.Enabled = True
		End If
	End Sub

	Public Sub Delete_Other_Btn_Enabled()
		If PdfMerge.AddFileList.Items.Count = 1 Then
			PdfMerge.FileMergeBtn.Enabled = False
			PdfMerge.FileIndexUp.Enabled = False
			PdfMerge.FileIndexDown.Enabled = False
		End If

		If PdfMerge.AddFileList.Items.Count = 0 Then
			PdfMerge.FileCleanBtn.Enabled = False
			PdfMerge.FileMergeBtn.Enabled = False
		End If
	End Sub

	Public Sub Merge_PDF(ByVal Files As Dictionary(Of String, String))
		Dim util As New PDFMergerUtility
		Dim saveFilePath As New DialogResult



		Dim savePath As SaveFileDialog = Save_File_Setup()
		saveFilePath = savePath.ShowDialog()
		PdfMerge.Merge_ProgressBar.Visible = True
		PdfMerge.Merge_ProgressBar.Value = 50
		If Not (saveFilePath = DialogResult.OK) Then
			Notis_Add("[취소]", "파일 병합을 취소하였습니다.")
			PdfMerge.Merge_ProgressBar.Visible = False
			Return
		End If

		Dim File_Validate As Boolean = PDF_Merge_Source(util, Files)

		PdfMerge.Merge_ProgressBar.Value = 70
		If Not (File_Validate) Then
			PdfMerge.Merge_ProgressBar.Visible = False
			Return
		End If
		PdfMerge.Merge_ProgressBar.Value = 80
		util.setDestinationFileName(savePath.FileName.ToString)

		' 병합 완료 표현을 위한 프로그래스바 응용
		For value = 80 To 99
			PdfMerge.Merge_ProgressBar.Value = value
			Threading.Thread.Sleep(20)
		Next

		Try
			util.mergeDocuments()

		Catch e_all As Exception
			MsgBox("[ERROR] 병합이 불가능한 파일이 있습니다
확인 후 병합을 재시도 해주세요.
" + e_all.ToString,, "ERROR")

			PdfMerge.Merge_ProgressBar.Visible = False
			PdfMerge.Merge_ProgressBar.Value = 0
			Return
		End Try

		PdfMerge.Merge_ProgressBar.Value = 100
		Notis_Add("[병합]", "파일 병합이 완료되었습니다.")
		PdfMerge.Merge_ProgressBar.Visible = False
		PdfMerge.Merge_ProgressBar.Value = 0
	End Sub

	' SaveFileDialog Default Setup
	Private Function Save_File_Setup() As SaveFileDialog
		Dim savePath As SaveFileDialog = New SaveFileDialog()
		savePath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
		savePath.DefaultExt = "pdf"
		savePath.Filter = "PDF (.pdf)|*.pdf"
		Return savePath
	End Function

	' 받은 매개변수의 file 을 병합한다.
	Private Function PDF_Merge_Source(ByRef util As PDFMergerUtility, ByVal Files As Dictionary(Of String, String)) As Boolean
		Dim findName As String = ""
		Try
			For index = 0 To PdfMerge.AddFileList.Items.Count - 1
				findName = PdfMerge.AddFileList.Items(index)
				util.addSource(Files(findName))
			Next
			Return True
		Catch e_runtime As java.lang.RuntimeException
			MsgBox("'" + findName + "' 파일을 확인해 주세요.", , "ERROR")
			Return False
		Catch e_all As Exception
			MsgBox("[ERROR] 예상치 못한 에러가 발생하였습니다.
관리자에게 문의해 주세요.
" + e_all.ToString,, "ERROR")
			Return False
		End Try
	End Function

	Public Sub Notis_Add(ByVal functionName As String, ByVal msg As String)
		PdfMerge.Notis.Items.Add(functionName + " " + msg)
		ListIndexLocation = ListIndexLocation + 1
		PdfMerge.Notis.SelectedIndex = ListIndexLocation
		PdfMerge.Notis.SelectedItem = Nothing
	End Sub
End Class
