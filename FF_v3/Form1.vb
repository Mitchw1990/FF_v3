Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1


    Dim binder As New BindingSource
    Dim completedExcelRecords As Integer = 0
    Dim dataImported As Boolean = False
    Dim editMode As Boolean = True
    Dim iconColumn As New DataGridViewImageColumn()
    Dim index As Integer = 0
    Dim mouse_move As Point
    Dim NoContactInspectionTypes() As String = {"NO CONTACT INSPECTION", "NO CONTACT INSPECTION (SS)", "NO CONTACT INSPECTION (CO)", "NO CONTACT INSPECTION (FT)", "NO CONTACT INSPECTION (WF)", "NO CONTACT INSPECTION (AFAS)"}
    Dim NotUploading As Boolean = True
    Dim sourceDir As String = ""
    Dim StandardInspectionTypes() As String = {"OCCUPANCY INSPECTION (AFAS)", "OCCUPANCY VERIFICATION", "OCCUPANCY VERIFICATION (CO)", "OCCUPANCY VERIFICATION (SS)", "OCCUPANCY VERIFICATION (FT)", "NO CONTACT INSPECTION", "NO CONTACT INSPECTION (SS)", "NO CONTACT INSPECTION (CO)", "NO CONTACT INSPECTION (FT)", "NO CONTACT INSPECTION (AFAS)"}
    Dim totalExcelRecords As Integer = 0
    Dim UnsupportedTypes As Integer = 0
    Dim WellsFargoInspectionTypes() As String = {"EXTERIOR CALL BACK INSPECTION (WF)", "EXTERIOR INSPECTION (WF)", "NO CONTACT INSPECTION (WF)"}

    Public Sub ClearControlSelections()
        ComboDeterminedBy.SelectedIndex = -1
        ComboOccupantType.SelectedIndex = -1
        ComboConstructionType.SelectedIndex = -1
        ComboGarageType.SelectedIndex = -1
        ComboGrassHeight.SelectedIndex = -1
        ComboLandscapeCondition.SelectedIndex = -1
        ComboLocationType.SelectedIndex = -1
        ComboNeighborhoodIssues.SelectedIndex = -1
        ComboPropertyCondition.SelectedIndex = -1
        ComboPropertyForSale.SelectedIndex = -1
        ComboPropertyHabitable.SelectedIndex = -1
        ComboRoofDamages.SelectedIndex = -1
        ComboSpokeWith.SelectedIndex = -1
        ComboSecurityIssues.SelectedIndex = -1
        ComboPropertyType.SelectedIndex = -1
        ComboNeighborhoodStatus.SelectedIndex = -1
        ComboRoofType.SelectedIndex = -1
        ComboLandscapeType.SelectedIndex = -1
        CheckEscalatedEvents.Checked = False
        CheckGatedCommunity.Checked = False
        CheckHighVandalismArea.Checked = False
        CheckPropertyUnsecure.Checked = False
        TextBoxBrokerNumber.Clear()
        TextBoxBrokerName.Clear()
        TextBoxEscalatedEvents.Clear()
        ListBoxOccupancyIndicators.SelectedIndex = -1
        ResetMainControlColors()
        TextBoxNeighborHouseNumber.Clear()
        If CheckBoxMarkNoAccess.Checked = False Then
            RichTextBox1.Clear()
            CheckBoxNoHouseNumber.Checked = False
            ComboBoxNoAccess.SelectedIndex = -1
        End If

    End Sub

    Public Sub clickCompleteWF()
        WebBrowser1.Document.GetElementById("MobileServiceDetailDynamicFormConfirmation_completeButton").InvokeMember("click")
    End Sub

    Public Sub clickNextStandard()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_nextButton").InvokeMember("click")
    End Sub

    Public Sub clickSaveStandard()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormConfirmation_saveButton").InvokeMember("click")
    End Sub

    Public Sub clickSubmitStandard()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_saveSubmitButton").InvokeMember("click")
    End Sub

    Public Sub clickSubmitWF()
        WebBrowser1.Document.GetElementById("MobileServiceDetailDynamicFormEdit_saveSubmitButton").InvokeMember("click")
    End Sub

    Public Sub ColorCodeExcelData()
        CreateGraphicsColumn()
        Dim existingRecords As Integer = 0
        Dim totalRecords As Integer = DataGridExcel.RowCount - 1
        Dim yesOrNo As String
        totalExcelRecords = DataGridExcel.RowCount - 1

        ProgressBar1.Visible = True
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = DataGridExcel.RowCount
        ProgressBar1.Value = 1
        ProgressBar1.Step = 1

        totalExcelRecords = DataGridExcel.RowCount - 1
        ToolStripProgressBar1.Visible = True
        ToolStripStatusLabel1.Visible = True
        ToolStripProgressBar1.Minimum = 1
        ToolStripProgressBar1.Maximum = DataGridExcel.RowCount
        ToolStripProgressBar1.Value = 1
        ToolStripProgressBar1.Step = 1

        Cursor.Current = Cursors.WaitCursor
        DataGridExcel.Enabled = False

        For index As Integer = 0 To totalRecords
            yesOrNo = DataGridExcel.Rows(index).Cells(4).Value.ToString

            If yesOrNo = "Yes" Then
                DataGridExcel.Rows(index).Cells(4).Style.BackColor = Color.DarkSeaGreen
                DataGridExcel.Rows(index).Cells(4).Style.ForeColor = Color.Black
                existingRecords += 1
            Else
                DataGridExcel.Rows(index).Cells(4).Style.BackColor = Color.DarkRed
            End If
            DataGridExcel.Rows(index).Cells(5).Tag = "Incomplete"
            DataGridExcel.Refresh()
            ProgressBar1.PerformStep()
        Next
        MsgBox("File imported successfully. " & vbNewLine & existingRecords.ToString & " of " & totalRecords + 1 & " imported records exist in the database.  " & UnsupportedTypes & " unsupported inspection types removed.")
        ProgressBar1.Visible = False
        DataGridExcel.Enabled = True
        Cursor.Current = Cursors.Default
        dataImported = True
        SetCompletionLabel()
        ColorCompletionStatus()
        PopulateCombos()

        SelectComboItemsFromDB()
        OpenToolStripButton.Enabled = False
        ForSaleEntryFieldsCheck()
        EnableGlobalControls()
        EnableOrDisableControlsCurrent()
        If Not CurrentRecordExists() Then
            RichTextBox1.Text = GenerateComment()
            If RichTextBox1.TextLength = 0 Then
                LabelCommentGenerator.Text = "Insufficient Details for Comment Generation."
            End If
        Else
            LabelCommentGenerator.Text = "Existing Comment from Database."
        End If
        LoadPresets()
        TabControl1.TabPages(3).Enabled = True

        If (Not (CurrentIsNoContact() Or CurrentIsWellsFargo())) And (Not CurrentSelectionComplete() Or editMode) Then
            If ComboDeterminedBy.Text = "Neighbor" Then
                ComboSpokeWith.Enabled = False
            Else
                ComboSpokeWith.Enabled = True
            End If
        End If

        If LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Then
            If ComboDeterminedBy.Text = "Visual Observation" Then
                ComboDeterminedBy.Enabled = False
                ComboDeterminedBy.SelectedIndex = -1
            End If
        End If
        SelectComboItemsFromDB()
        EnableOrDisableControlsCurrent()

    End Sub

    Public Sub CreateGraphicsColumn()
        If DataGridExcel.ColumnCount < 6 Then
            With iconColumn
                .Image = ImageList1.Images(1)
                .Name = "Completed"
                .HeaderText = "Completed"
            End With
            DataGridExcel.Columns.Insert(5, iconColumn)
        End If
    End Sub

    Public Sub DisableControls()
        ComboDeterminedBy.Enabled = False
        ComboOccupantType.Enabled = False
        ComboConstructionType.Enabled = False
        ComboGarageType.Enabled = False
        ComboGrassHeight.Enabled = False
        ComboLandscapeCondition.Enabled = False
        ComboLocationType.Enabled = False
        ComboNeighborhoodIssues.Enabled = False
        ComboPropertyCondition.Enabled = False
        ComboPropertyForSale.Enabled = False
        ComboPropertyHabitable.Enabled = False
        ComboRoofDamages.Enabled = False
        ComboSpokeWith.Enabled = False
        ComboSecurityIssues.Enabled = False
        ComboPropertyType.Enabled = False
        CheckEscalatedEvents.Enabled = False
        CheckGatedCommunity.Enabled = False
        CheckHighVandalismArea.Enabled = False
        CheckPropertyUnsecure.Enabled = False
        ComboNeighborhoodStatus.Enabled = False
        ComboRoofType.Enabled = False
        ComboLandscapeType.Enabled = False
        TextBoxEscalatedEvents.Enabled = False
        ListBoxOccupancyIndicators.Enabled = False
        TextBoxBrokerName.Enabled = False
        TextBoxBrokerNumber.Enabled = False
        RichTextBox1.Enabled = False
        TextBoxNeighborHouseNumber.Enabled = False
        CheckBoxNoHouseNumber.Enabled = False
    End Sub

    Public Sub DisableMainControls()
        BindingNavigatorExcelSheet.Enabled = False
        BindingNavigatorStandardInspectionPresets.Enabled = False
        ButtonAddPreset.Enabled = False
        ButtonMarkComplete.Enabled = False
        ButtonRevertCompletion.Enabled = False
        ListBoxStandardInspectionPresets.Enabled = False
        RichTextBox1.Enabled = False
        DisableControls()
    End Sub

    Public Sub EnableGlobalControls()
        ComboDeterminedBy.Enabled = True
        ComboOccupantType.Enabled = True
        ComboConstructionType.Enabled = True
        ComboPropertyForSale.Enabled = True
        ComboPropertyCondition.Enabled = True
        ComboPropertyType.Enabled = True
        RichTextBox1.Enabled = True
    End Sub

    Public Sub EnableMainControls()
        BindingNavigatorExcelSheet.Enabled = True
        BindingNavigatorStandardInspectionPresets.Enabled = True
        ButtonAddPreset.Enabled = True
        ButtonMarkComplete.Enabled = True
        ButtonRevertCompletion.Enabled = True
        ListBoxStandardInspectionPresets.Enabled = True
        RichTextBox1.Enabled = True
    End Sub

    Public Sub fillComments(comment As String)
        WebBrowser1.Document.GetElementById("service.preApprovedCompletionNotes").SetAttribute("value", comment)
    End Sub

    Public Sub fillDateStandard(d As String)
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_datePerformedInput").SetAttribute("value", d)
    End Sub

    '******fill wells fargo inspection forms*******
    Public Sub fillDateWF()
        Dim theDate As Date = dateSelector.Value.Date
        Dim stringDate As String = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        WebBrowser1.Document.GetElementById("MobileServiceDetailDynamicFormEdit_datePerformedInput").SetAttribute("value", stringDate)
    End Sub

    Public Sub fillValueAFAS(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("service.detailList" & num & ".preApprovedValue").SetAttribute("value", value)
    End Sub

    Public Sub fillValuesAFAS(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("service.detailList" & num & ".preApprovedValues").SetAttribute("value", value)
    End Sub

    Public Sub fillValuesStandard(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("serviceDetailFormBeanItems" & num & ".detail.preApprovedValues").SetAttribute("value", value)
    End Sub

    '******fill standard inspection forms*******
    Public Sub fillValueStandard(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("serviceDetailFormBeanItems" & num & ".detail.preApprovedValue").SetAttribute("value", value)
    End Sub

    Public Sub fillValuesWF(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("service.detailList" & num & ".preApprovedValues").SetAttribute("value", value)
    End Sub

    Public Sub fillValueWF(value As String, num As Integer)
        WebBrowser1.Document.GetElementById("service.detailList" & num & ".preApprovedValue").SetAttribute("value", value)
    End Sub

    Public Function FormatPhoneNumber(phoneNum As String, phoneFormat As String) As String

        If phoneFormat = "" Then
            phoneFormat = "(###) ###-####"
        End If

        Dim regexObj As Regex = New System.Text.RegularExpressions.Regex("[^\d]")
        phoneNum = regexObj.Replace(phoneNum, "")

        If phoneNum.Length > 0 Then
            phoneNum = Convert.ToInt64(phoneNum).ToString(phoneFormat)
        End If

        Return phoneNum
    End Function

    '-----------------------excel data------------------------------
    Public Sub GridSelectionChange(sender As Object, e As EventArgs) Handles DataGridExcel.SelectionChanged
        If dataImported Then
            CheckBoxMarkNoAccess.Checked = False
            ClearControlSelections()
            PopulateCombos()
            SetCompletionLabel()
            SelectComboItemsFromDB()
            ColorCompletionStatus()
            EnableOrDisableControlsCurrent()
            ForSaleEntryFieldsCheck()
            LoadPresets()
            If Not (CurrentSelectionComplete() Or CurrentRecordExists()) Then
                RichTextBox1.Text = GenerateComment()
            End If

            If CurrentSelectionComplete() Then
                ToolStripMenuItemEditCompletion.Enabled = True
                ToolStripMenuItemGenerateNewComment.Enabled = False
                DisableControls()
            Else
                ToolStripMenuItemEditCompletion.Enabled = False
                ToolStripMenuItemGenerateNewComment.Enabled = True
            End If

            If (Not (CurrentIsNoContact() Or CurrentIsWellsFargo())) And (Not CurrentSelectionComplete()) Then
                If ComboDeterminedBy.Text = "Neighbor" Then
                    ComboSpokeWith.Enabled = False
                Else
                    ComboSpokeWith.Enabled = True
                End If

                If CheckBoxMarkNoAccess.Checked Then
                    DisableControls()
                    ClearControlSelections()
                    ComboBoxNoAccess.Enabled = True
                    RichTextBox1.Enabled = True
                Else
                    EnableOrDisableControlsCurrent()
                    ComboBoxNoAccess.Enabled = False
                End If

            End If

            If CurrentSelectionComplete() Then
                ComboBoxNoAccess.Enabled = False
            End If
        End If

    End Sub

    Public Function ImportExcel() As Boolean
        Dim selectedPath As String
        Dim connection As OleDbConnection
        Dim command As OleDbDataAdapter
        Dim dataSet As New DataTable

        With OpenFileDialog1
            .Title = "Import Excel Spreadsheet"
            .FileName = ""
            .DefaultExt = ".xls"
            .AddExtension = True
            .Filter = "Excel Worksheets|*.xls; *.xlsx"

            Select Case .ShowDialog()

                Case DialogResult.Cancel
                    Return False
                Case DialogResult.No
                    Return False
                Case DialogResult.OK
                    selectedPath = OpenFileDialog1.FileName

                    Try
                        TabControl1.TabPages.Insert(1, TabCurrentDataset)
                        TabControl1.Invalidate()

                        DataGridExcel.DataSource = Nothing

                        connection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & selectedPath.ToString & "';Extended Properties=Excel 8.0;")
                        command = New OleDbDataAdapter("select * from [Sheet1$]", connection)
                        command.TableMappings.Add("Table", "ServiceOrders")

                        command.Fill(dataSet)

                        connection.Close()

                        binder.DataSource = dataSet
                        BindingNavigatorExcelSheet.BindingSource = binder
                        DataGridExcel.DataSource = binder

                        LabelCurrentFile.Text = selectedPath.ToString
                        DataGridExcel.Rows(0).Selected = True

                        TextBoxServiceID.DataBindings.Add("Text", binder, "Service Id")
                        TextBoxPropertyID.DataBindings.Add("Text", binder, "Property Id")
                        LabelInspectionType.DataBindings.Add("Text", binder, "Service")
                        LabelAddress.DataBindings.Add("Text", binder, "Address")
                        RemoveUnsupportedTypes(DataGridExcel)
                        RemoveUnsupportedTypes(DataGridExcel)

                        MarkExistingRecords()
                        EnableMainControls()
                        Return True
                    Catch ex As Exception
                        MessageBox.Show("Error importing Excel file.  Check Source formatting and try again.")
                        Application.Exit()
                    End Try
            End Select
        End With
        Return False
    End Function

    Public Sub InsertPreset()

        Dim completionCheckPassed As Boolean = VerifyCombos()

        If completionCheckPassed Then

            Dim name As String = InputBox("Save preset as:", "Preset Manager", " ")

            If name = " " Then
                MsgBox("Preset name required.")
                Exit Sub
            ElseIf name = "" Then
                Exit Sub
            End If

            If CurrentIsStandard() And (Not CurrentIsNoContact()) Then
                If LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                    name = "AFAS_" & name
                Else
                    name = "OV_" & name
                End If
            ElseIf CurrentIsStandard() And CurrentIsNoContact() Then
                If LabelInspectionType.Text = "NO CONTACT INSPECTION (AFAS)" Then
                    name = "AFNC_" & name
                Else
                    name = "NC_" & name
                End If
            ElseIf CurrentIsWellsFargo() And (Not CurrentIsNoContact()) Then
                If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Then
                    name = "WFEX_" & name
                Else
                    name = "WFCB_" & name
                End If
            ElseIf CurrentIsWellsFargo() And CurrentIsNoContact() Then
                name = "WFNC_" & name
            End If

            If ListBoxStandardInspectionPresets.Items.Count > 0 Then
                For Each item In ListBoxStandardInspectionPresets.Items
                    Dim r As DataRowView = item
                    If r.Item("PresetName").ToString() = name Then
                        MsgBox(name & " already exists.  Choose a unique identifier.")
                        Exit Sub
                    End If
                Next
            End If
            Try

                Dim queryString As String = "INSERT INTO StandardInspections (InspectionType, ConstructionType, OccupantType, GarageType, PropertyCondition, SpokeWith, DeterminedBy, PresetName, PropertyType, PropertyForSale, BrokerName, BrokerNumber, "
                queryString &= "LocationType, NeighborhoodStatus, NeighborhoodIssues, RoofType, RoofDamages, LandscapeType, LandscapeCondition, GrassHeight, SecurityIssues, PropertyHabitable, "
                queryString &= "PropertyUnsecure, GatedCommunity, HighVandalismArea, EscalatedEvents, EscalatedEventsText, OccupancyIndicators, NeighborHouseNumber, NoHouseNumber) VALUES "
                queryString &= "(@InspectionType, @ConstructionType, @OccupantType, @GarageType, @PropertyCondition, @SpokeWith, @DeterminedBy, @PresetName, @PropertyType, @PropertyForSale, @BrokerName, @BrokerNumber, "
                queryString &= "@LocationType, @NeighborhoodStatus, @NeighborhoodIssues, @RoofType, @RoofDamages, @LandscapeType, @LandscapeCondition, @GrassHeight, @SecurityIssues, @PropertyHabitable, "
                queryString &= "@PropertyUnsecure, @GatedCommunity, @HighVandalismArea, @EscalatedEvents, @EscalatedEventsText, @OccupancyIndicators, @NeighborHouseNumber, @NoHouseNumber)"

                Using dbConn As New OleDbConnection With {.ConnectionString = My.Settings.FF_PresetsConnectionString}
                    Using dbCommand As New OleDbCommand()
                        With dbCommand
                            .Connection = dbConn
                            .CommandText = queryString

                            .Parameters.AddWithValue("@InspectionType", LabelInspectionType.Text.ToString)
                            .Parameters.AddWithValue("@ConstructionType", ComboConstructionType.SelectedItem.ToString)
                            .Parameters.AddWithValue("@OccupantType", ComboOccupantType.SelectedItem.ToString)
                            If CurrentIsStandard() Then
                                .Parameters.AddWithValue("@GarageType", ComboGarageType.SelectedItem.ToString)
                            Else
                                .Parameters.AddWithValue("@GarageType", "")
                            End If
                            .Parameters.AddWithValue("@PropertyCondition", ComboPropertyCondition.SelectedItem.ToString)
                            If CurrentIsStandard() And (Not CurrentIsNoContact()) And ComboDeterminedBy.Text <> "Neighbor" And ComboDeterminedBy.Text <> "Visual Observation" Then
                                .Parameters.AddWithValue("@SpokeWith", ComboSpokeWith.SelectedItem.ToString)
                            Else
                                .Parameters.AddWithValue("@SpokeWith", "")
                            End If

                            .Parameters.AddWithValue("@DeterminedBy", ComboDeterminedBy.SelectedItem.ToString)
                            .Parameters.AddWithValue("@PresetName", name)
                            .Parameters.AddWithValue("@PropertyType", ComboPropertyType.SelectedItem.ToString)
                            .Parameters.AddWithValue("@PropertyForSale", ComboPropertyForSale.SelectedItem.ToString)
                            .Parameters.AddWithValue("@BrokerName", TextBoxBrokerName.Text.ToString)
                            .Parameters.AddWithValue("@BrokerNumber", TextBoxBrokerNumber.Text.ToString())

                            If CurrentIsWellsFargo() Then
                                .Parameters.AddWithValue("@LocationType", ComboLocationType.SelectedItem.ToString)
                                .Parameters.AddWithValue("@NeighborhoodStatus", ComboNeighborhoodStatus.SelectedItem.ToString)
                                .Parameters.AddWithValue("@NeighborhoodIssues", ComboNeighborhoodIssues.SelectedItem.ToString)
                                .Parameters.AddWithValue("@RoofType", ComboRoofType.SelectedItem.ToString)
                                .Parameters.AddWithValue("@RoofDamages", ComboRoofDamages.SelectedItem.ToString)
                                .Parameters.AddWithValue("@LandscapeType", ComboLandscapeType.SelectedItem.ToString)
                                .Parameters.AddWithValue("@LandscapeCondition", ComboLandscapeCondition.SelectedItem.ToString)
                                .Parameters.AddWithValue("@GrassHeight", ComboGrassHeight.SelectedItem.ToString)
                                .Parameters.AddWithValue("@SecurityIssues", ComboSecurityIssues.SelectedItem.ToString)
                                .Parameters.AddWithValue("@PropertyHabitable", ComboPropertyHabitable.SelectedItem.ToString)
                                .Parameters.AddWithValue("@PropertyUnsecure", CheckPropertyUnsecure.Checked.ToString())
                                .Parameters.AddWithValue("@GatedCommunity", CheckGatedCommunity.Checked.ToString)
                                .Parameters.AddWithValue("@HighVandalismArea", CheckHighVandalismArea.Checked.ToString)
                                .Parameters.AddWithValue("@EscalatedEvents", CheckEscalatedEvents.Checked.ToString)
                                .Parameters.AddWithValue("@EscalatedEventsText", TextBoxEscalatedEvents.Text.ToString())
                            Else
                                .Parameters.AddWithValue("@LocationType", "")
                                .Parameters.AddWithValue("@NeighborhoodStatus", "")
                                .Parameters.AddWithValue("@NeighborhoodIssues", "")
                                .Parameters.AddWithValue("@RoofType", "")
                                .Parameters.AddWithValue("@RoofDamages", "")
                                .Parameters.AddWithValue("@LandscapeType", "")
                                .Parameters.AddWithValue("@LandscapeCondition", "")
                                .Parameters.AddWithValue("@GrassHeight", "")
                                .Parameters.AddWithValue("@SecurityIssues", "")
                                .Parameters.AddWithValue("@PropertyHabitable", "")
                                .Parameters.AddWithValue("@PropertyUnsecure", "")
                                .Parameters.AddWithValue("@GatedCommunity", "")
                                .Parameters.AddWithValue("@HighVandalismArea", "")
                                .Parameters.AddWithValue("@EscalatedEvents", "")
                                .Parameters.AddWithValue("@EscalatedEventsText", "")
                            End If
                            If ListBoxOccupancyIndicators.SelectedItems.Count > 0 Then
                                .Parameters.AddWithValue("@OccupancyIndicators", GenerateOccupancyIndicatorStringDB())
                            Else
                                .Parameters.AddWithValue("@OccupancyIndicators", "")
                            End If
                            .Parameters.AddWithValue("@NeighborHouseNumber", TextBoxNeighborHouseNumber.Text.ToString)
                            .Parameters.AddWithValue("@NoHouseNumber", CheckBoxNoHouseNumber.Checked.ToString)
                        End With

                        Try
                            dbConn.Open()
                            dbCommand.ExecuteNonQuery()
                            UpdatePresetsDB()
                            dbConn.Close()
                            ResetMainControlColors()
                        Catch ex As SqlException
                            MessageBox.Show(ex.Message.ToString(), "Error")
                        End Try

                    End Using
                End Using
            Catch ex As SqlException
                MsgBox("Error: Failed to save preset.  Make sure the preset name is unique and try again.", "Preset Manager")
            End Try
        Else
            MsgBox("Must specify all applicable details before saving.")
        End If

    End Sub

    Public Sub InsertRecord()

        Dim completionCheckPassed As Boolean = VerifyCombos()
        Dim recordExists As Boolean = (DirectCast(binder.Current, DataRowView).Item("Preexisting Record").ToString = "Yes")

        If completionCheckPassed Then

            If recordExists Or CurrentSelectionComplete() Then
                DeleteRecord()
                DeleteRecord()
                DeleteRecord()
            End If

            Dim queryString As String = "INSERT INTO ServiceOrders (ServiceId, PropertyID , InspectionType, ConstructionType, OccupantType, GarageType, PropertyCondition, SpokeWith, DeterminedBy, PropertyType, PropertyForSale, BrokerName, BrokerNumber, "
            queryString &= "LocationType, NeighborhoodStatus, NeighborhoodIssues, RoofType, RoofDamages, LandscapeType, LandscapeCondition, GrassHeight, SecurityIssues, PropertyHabitable, PropertyUnsecure, GatedCommunity, HighVandalismArea, EscalatedEvents, EscalatedEventsText, OccupancyIndicators, NeighborHouseNumber, Comment, NoHouseNumber, NoAccess, NoAccessReason) VALUES "
            queryString &= "(@ServiceId, @PropertyID, @InspectionType, @ConstructionType, @OccupantType, @GarageType, @PropertyCondition, @SpokeWith, @DeterminedBy, @PropertyType, @PropertyForSale, @BrokerName, @BrokerNumber, "
            queryString &= "@LocationType, @NeighborhoodStatus, @NeighborhoodIssues, @RoofType, @RoofDamages, @LandscapeType, @LandscapeCondition, @GrassHeight, @SecurityIssues, @PropertyHabitable, "
            queryString &= "@PropertyUnsecure, @GatedCommunity, @HighVandalismArea, @EscalatedEvents, @EscalatedEventsText, @OccupancyIndicators, @NeighborHouseNumber, @Comment, @NoHouseNumber, @NoAccess, @NoAccessReason)"

            Using dbConn As New OleDbConnection With {.ConnectionString = My.Settings.FF_DB_ConnectionString}
                Using dbCommand As New OleDbCommand()
                    With dbCommand
                        .Connection = dbConn
                        .CommandText = queryString
                        .Parameters.AddWithValue("@ServiceId", TextBoxServiceID.Text.ToString)
                        .Parameters.AddWithValue("@PropertyID", TextBoxPropertyID.Text.ToString)
                        .Parameters.AddWithValue("@InspectionType", LabelInspectionType.Text.ToString)
                        .Parameters.AddWithValue("@ConstructionType", ComboConstructionType.SelectedItem.ToString)
                        .Parameters.AddWithValue("@OccupantType", ComboOccupantType.SelectedItem.ToString)
                        If CurrentIsStandard() Then
                            .Parameters.AddWithValue("@GarageType", ComboGarageType.SelectedItem.ToString)
                        Else
                            .Parameters.AddWithValue("@GarageType", "")
                        End If
                        .Parameters.AddWithValue("@PropertyCondition", ComboPropertyCondition.SelectedItem.ToString)
                        If Not ComboSpokeWith.SelectedIndex = -1 Then
                            .Parameters.AddWithValue("@SpokeWith", ComboSpokeWith.SelectedItem.ToString)
                        Else
                            .Parameters.AddWithValue("@SpokeWith", "")
                        End If

                        .Parameters.AddWithValue("@DeterminedBy", ComboDeterminedBy.SelectedItem.ToString)
                        .Parameters.AddWithValue("@PropertyType", ComboPropertyType.SelectedItem.ToString)
                        .Parameters.AddWithValue("@PropertyForSale", ComboPropertyForSale.SelectedItem.ToString)
                        .Parameters.AddWithValue("@BrokerName", TextBoxBrokerName.Text.ToString)
                        .Parameters.AddWithValue("@BrokerNumber", TextBoxBrokerNumber.Text.ToString())

                        If CurrentIsWellsFargo() Then
                            .Parameters.AddWithValue("@LocationType", ComboLocationType.SelectedItem.ToString)
                            .Parameters.AddWithValue("@NeighborhoodStatus", ComboNeighborhoodStatus.SelectedItem.ToString)
                            .Parameters.AddWithValue("@NeighborhoodIssues", ComboNeighborhoodIssues.SelectedItem.ToString)
                            .Parameters.AddWithValue("@RoofType", ComboRoofType.SelectedItem.ToString)
                            .Parameters.AddWithValue("@RoofDamages", ComboRoofDamages.SelectedItem.ToString)
                            .Parameters.AddWithValue("@LandscapeType", ComboLandscapeType.SelectedItem.ToString)
                            .Parameters.AddWithValue("@LandscapeCondition", ComboLandscapeCondition.SelectedItem.ToString)
                            .Parameters.AddWithValue("@GrassHeight", ComboGrassHeight.SelectedItem.ToString)
                            .Parameters.AddWithValue("@SecurityIssues", ComboSecurityIssues.SelectedItem.ToString)
                            .Parameters.AddWithValue("@PropertyHabitable", ComboPropertyHabitable.SelectedItem.ToString)
                            .Parameters.AddWithValue("@PropertyUnsecure", CheckPropertyUnsecure.Checked.ToString())
                            .Parameters.AddWithValue("@GatedCommunity", CheckGatedCommunity.Checked.ToString)
                            .Parameters.AddWithValue("@HighVandalismArea", CheckHighVandalismArea.Checked.ToString)
                            .Parameters.AddWithValue("@EscalatedEvents", CheckEscalatedEvents.Checked.ToString)
                            .Parameters.AddWithValue("@EscalatedEventsText", TextBoxEscalatedEvents.Text.ToString())
                        Else
                            .Parameters.AddWithValue("@LocationType", "")
                            .Parameters.AddWithValue("@NeighborhoodStatus", "")
                            .Parameters.AddWithValue("@NeighborhoodIssues", "")
                            .Parameters.AddWithValue("@RoofType", "")
                            .Parameters.AddWithValue("@RoofDamages", "")
                            .Parameters.AddWithValue("@LandscapeType", "")
                            .Parameters.AddWithValue("@LandscapeCondition", "")
                            .Parameters.AddWithValue("@GrassHeight", "")
                            .Parameters.AddWithValue("@SecurityIssues", "")
                            .Parameters.AddWithValue("@PropertyHabitable", "")
                            .Parameters.AddWithValue("@PropertyUnsecure", "")
                            .Parameters.AddWithValue("@GatedCommunity", "")
                            .Parameters.AddWithValue("@HighVandalismArea", "")
                            .Parameters.AddWithValue("@EscalatedEvents", "")
                            .Parameters.AddWithValue("@EscalatedEventsText", "")
                        End If

                        If ListBoxOccupancyIndicators.SelectedItems.Count > 0 Then
                            .Parameters.AddWithValue("@OccupancyIndicators", GenerateOccupancyIndicatorStringDB())
                        Else
                            .Parameters.AddWithValue("@OccupancyIndicators", "")
                        End If
                        .Parameters.AddWithValue("@NeighborHouseNumber", TextBoxNeighborHouseNumber.Text.ToString())
                        .Parameters.AddWithValue("@Comment", RichTextBox1.Text.ToString())
                        .Parameters.AddWithValue("@NoHouseNumber", CheckBoxNoHouseNumber.Checked.ToString())
                        .Parameters.AddWithValue("@NoAccess", "False")
                        .Parameters.AddWithValue("@NoHouseNumber", "")

                    End With

                    Try
                        dbConn.Open()
                        dbCommand.ExecuteNonQuery()
                        UpdateDB()
                        dbConn.Close()
                    Catch ex As SqlException
                        MessageBox.Show(ex.Message.ToString(), "Error")
                    End Try

                End Using
            End Using
            ServiceOrdersTableAdapter1.Fill(FF_DBDataSet1.ServiceOrders)

        Else
            MsgBox("Must specify all applicable details before saving.")
        End If

    End Sub

    Public Sub InsertRecordNoAccess()

        Dim completionCheckPassed As Boolean = VerifyCombos()
        Dim commentBoxNotBlank As Boolean = RichTextBox1.TextLength > 0
        Dim recordExists As Boolean = (DirectCast(binder.Current, DataRowView).Item("Preexisting Record").ToString = "Yes")

        If completionCheckPassed And commentBoxNotBlank Then

            If recordExists Or CurrentSelectionComplete() Then
                DeleteRecord()
                DeleteRecord()
            End If

            Dim queryString As String = "INSERT INTO ServiceOrders (ServiceId, PropertyID , InspectionType, ConstructionType, OccupantType, GarageType, PropertyCondition, SpokeWith, DeterminedBy, PropertyType, PropertyForSale, BrokerName, BrokerNumber, "
            queryString &= "LocationType, NeighborhoodStatus, NeighborhoodIssues, RoofType, RoofDamages, LandscapeType, LandscapeCondition, GrassHeight, SecurityIssues, PropertyHabitable, PropertyUnsecure, GatedCommunity, HighVandalismArea, EscalatedEvents, EscalatedEventsText, OccupancyIndicators, NeighborHouseNumber, Comment, NoHouseNumber, NoAccess, NoAccessReason) VALUES "
            queryString &= "(@ServiceId, @PropertyID, @InspectionType, @ConstructionType, @OccupantType, @GarageType, @PropertyCondition, @SpokeWith, @DeterminedBy, @PropertyType, @PropertyForSale, @BrokerName, @BrokerNumber, "
            queryString &= "@LocationType, @NeighborhoodStatus, @NeighborhoodIssues, @RoofType, @RoofDamages, @LandscapeType, @LandscapeCondition, @GrassHeight, @SecurityIssues, @PropertyHabitable, "
            queryString &= "@PropertyUnsecure, @GatedCommunity, @HighVandalismArea, @EscalatedEvents, @EscalatedEventsText, @OccupancyIndicators, @NeighborHouseNumber, @Comment, @NoHouseNumber, @NoAccess, @NoAccessReason)"

            Using dbConn As New OleDbConnection With {.ConnectionString = My.Settings.FF_DB_ConnectionString}
                Using dbCommand As New OleDbCommand()
                    With dbCommand
                        .Connection = dbConn
                        .CommandText = queryString
                        .Parameters.AddWithValue("@ServiceId", TextBoxServiceID.Text.ToString)
                        .Parameters.AddWithValue("@PropertyID", TextBoxPropertyID.Text.ToString)
                        .Parameters.AddWithValue("@InspectionType", LabelInspectionType.Text.ToString)
                        .Parameters.AddWithValue("@ConstructionType", "")
                        .Parameters.AddWithValue("@OccupantType", "")
                        .Parameters.AddWithValue("@GarageType", "")
                        .Parameters.AddWithValue("@PropertyCondition", "")
                        .Parameters.AddWithValue("@SpokeWith", "")
                        .Parameters.AddWithValue("@DeterminedBy", "")
                        .Parameters.AddWithValue("@PropertyType", "")
                        .Parameters.AddWithValue("@PropertyForSale", "")
                        .Parameters.AddWithValue("@BrokerName", "")
                        .Parameters.AddWithValue("@BrokerNumber", "")
                        .Parameters.AddWithValue("@LocationType", "")
                        .Parameters.AddWithValue("@NeighborhoodStatus", "")
                        .Parameters.AddWithValue("@NeighborhoodIssues", "")
                        .Parameters.AddWithValue("@RoofType", "")
                        .Parameters.AddWithValue("@RoofDamages", "")
                        .Parameters.AddWithValue("@LandscapeType", "")
                        .Parameters.AddWithValue("@LandscapeCondition", "")
                        .Parameters.AddWithValue("@GrassHeight", "")
                        .Parameters.AddWithValue("@SecurityIssues", "")
                        .Parameters.AddWithValue("@PropertyHabitable", "")
                        .Parameters.AddWithValue("@PropertyUnsecure", "False")
                        .Parameters.AddWithValue("@GatedCommunity", "False")
                        .Parameters.AddWithValue("@HighVandalismArea", "False")
                        .Parameters.AddWithValue("@EscalatedEvents", "False")
                        .Parameters.AddWithValue("@EscalatedEventsText", "")
                        .Parameters.AddWithValue("@OccupancyIndicators", "")
                        .Parameters.AddWithValue("@NeighborHouseNumber", "")
                        .Parameters.AddWithValue("@Comment", RichTextBox1.Text.ToString())
                        .Parameters.AddWithValue("@NoHouseNumber", "False")
                        .Parameters.AddWithValue("@NoAccess", "True")
                        .Parameters.AddWithValue("@NoHouseNumber", ComboBoxNoAccess.SelectedItem.ToString())
                    End With
                    Try
                        dbConn.Open()
                        dbCommand.ExecuteNonQuery()
                        UpdateDB()
                        dbConn.Close()
                    Catch ex As SqlException
                        MessageBox.Show(ex.Message.ToString(), "Error")
                    End Try
                End Using
            End Using
            ServiceOrdersTableAdapter1.Fill(FF_DBDataSet1.ServiceOrders)
        Else
            MsgBox("Must specify all applicable details before saving.")
        End If
    End Sub

    Public Sub MarkAsComplete()
        If VerifyCombos() And (Not CurrentSelectionComplete()) And RichTextBox1.TextLength > 0 Then
            DataGridExcel.SelectedRows(0).Cells(5).Value = ImageList1.Images(0)
            DataGridExcel.SelectedRows(0).Cells(5).Tag = "Complete"
            ColorCompletionStatus()
            SetCompletionLabel()
            completedExcelRecords += 1
            UpdateToolbarStatus()
            ToolStripProgressBar1.PerformStep()
            ToolStripMenuItemGenerateNewComment.Enabled = False
            CheckBoxMarkNoAccess.Enabled = False
            ComboBoxNoAccess.Enabled = False
        End If
    End Sub

    '-----------------------completion checks/sets/gets------------------------------
    Public Sub MarkAsIncomplete()
        If ToolStripProgressBar1.Value > 1 And CurrentSelectionComplete() Then
            completedExcelRecords -= 1
            UpdateToolbarStatus()
            ToolStripProgressBar1.Value -= 1
        End If
        DataGridExcel.SelectedRows(0).Cells(5).Value = ImageList1.Images(1)
        DataGridExcel.SelectedRows(0).Cells(5).Tag = "Incomplete"
        DataGridExcel.SelectedRows(0).Cells(4).Value = "No"
        DataGridExcel.SelectedRows(0).Cells(4).Style.BackColor = Color.DarkRed
        DataGridExcel.SelectedRows(0).Cells(4).Style.ForeColor = Color.White
        ColorCompletionStatus()
        SetCompletionLabel()
        ToolStripMenuItemGenerateNewComment.Enabled = True
    End Sub

    Public Sub MarkExistingRecords()

        Dim excelPropertyID As String
        Dim result As Integer?
        Dim totalRecords As Integer = DataGridExcel.RowCount - 1

        SuspendLayout()

        For index As Integer = 0 To totalRecords
            excelPropertyID = DataGridExcel.Rows(index).Cells(1).Value.ToString
            result = SearchDatabaseGrid(excelPropertyID)
            If IsNothing(result) Then
                DataGridExcel.Rows(index).Cells(4).Value = "No"
            Else
                DataGridExcel.Rows(index).Cells(4).Value = "Yes"
            End If
        Next

        ResumeLayout()

    End Sub

    Public Sub SetCompletionLabel()
        If CurrentSelectionComplete() Then
            Label2.Text = "Record Status: Complete"
        ElseIf CurrentRecordExists() Then
            Label2.Text = "Record Status: Preexisting Record"
        Else
            Label2.Text = "Record Status: Incomplete"
        End If
    End Sub

    Public Sub UpdateToolbarStatus()
        ToolStripStatusLabel1.Text = completedExcelRecords.ToString() & " of " & (totalExcelRecords + 1).ToString() & " complete."
    End Sub



    Private Sub ApplyPresets()

        If ListBoxStandardInspectionPresets.SelectedIndex >= 0 Then
            ListBoxOccupancyIndicators.SelectedIndex = -1
            Dim constructionType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("ConstructionType").ToString
            Dim occupantType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("OccupantType").ToString
            Dim propertyCondition As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("PropertyCondition").ToString
            Dim determinedBy As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("DeterminedBy").ToString
            Dim propertyType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("PropertyType").ToString
            Dim propertyForSale As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("PropertyForSale").ToString
            Dim brokerName As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("BrokerName").ToString
            Dim brokerNumber As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("BrokerNumber").ToString
            Dim neighborHouseNumber As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("NeighborHouseNumber").ToString
            Dim occupancyIndicators As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("OccupancyIndicators").ToString
            Dim noHouseNumber As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("NoHouseNumber").ToString

            ComboConstructionType.SelectedItem = constructionType
            ComboPropertyCondition.SelectedItem = propertyCondition
            ComboDeterminedBy.SelectedItem = determinedBy
            ComboOccupantType.SelectedItem = occupantType
            ComboPropertyType.SelectedItem = propertyType
            ComboPropertyForSale.SelectedItem = propertyForSale
            TextBoxBrokerName.Text = brokerName
            TextBoxBrokerNumber.Text = FormatPhoneNumber(brokerNumber, "")

            TextBoxNeighborHouseNumber.Text = neighborHouseNumber

            If CurrentIsNoContact() Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                SetOccupancyIndicatorsListBox(occupancyIndicators)
            End If

            If noHouseNumber = "True" Then
                CheckBoxNoHouseNumber.Checked = True
            Else
                CheckBoxNoHouseNumber.Checked = False
            End If

            If CurrentIsStandard() Then
                Dim garageType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("GarageType").ToString
                Dim spokeWith As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("SpokeWith")
                ComboSpokeWith.SelectedItem = spokeWith
                ComboGarageType.SelectedItem = garageType
            ElseIf CurrentIsWellsFargo() Then

                Dim locationType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("LocationType").ToString
                Dim neighborhoodStatus As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("NeighborhoodStatus").ToString
                Dim neighborhoodIssues As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("NeighborhoodIssues").ToString
                Dim roofType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("RoofType").ToString
                Dim roofDamage As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("RoofDamages").ToString
                Dim landscapeType As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("LandscapeType").ToString
                Dim landscapeCondition As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("LandscapeCondition").ToString
                Dim grassHeight As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("GrassHeight").ToString
                Dim securityIssues As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("SecurityIssues").ToString
                Dim propertyHabitable As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("PropertyHabitable").ToString
                Dim propertyUnsecure As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("PropertyUnsecure").ToString
                Dim gatedCommunity As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("GatedCommunity").ToString
                Dim highVandalismArea As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("HighVandalismArea").ToString
                Dim escalatedEvents As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("EscalatedEvents").ToString
                Dim escalatedEventsText As String = DirectCast(BindingSourcePresets.Current, DataRowView).Item("EscalatedEventsText").ToString

                ComboLocationType.SelectedItem = locationType
                ComboNeighborhoodStatus.SelectedItem = neighborhoodStatus
                ComboNeighborhoodIssues.SelectedItem = neighborhoodIssues
                ComboRoofType.SelectedItem = roofType
                ComboRoofDamages.SelectedItem = roofDamage
                ComboLandscapeType.SelectedItem = landscapeType
                ComboLandscapeCondition.SelectedItem = landscapeCondition
                ComboGrassHeight.SelectedItem = grassHeight
                ComboSecurityIssues.SelectedItem = securityIssues
                ComboPropertyHabitable.SelectedItem = propertyHabitable
                TextBoxEscalatedEvents.Text = escalatedEventsText

                If propertyUnsecure = "True" Then
                    CheckPropertyUnsecure.Checked = True
                Else
                    CheckPropertyUnsecure.Checked = False
                End If

                If gatedCommunity = "True" Then
                    CheckGatedCommunity.Checked = True
                Else
                    CheckGatedCommunity.Checked = False
                End If

                If highVandalismArea = "True" Then
                    CheckHighVandalismArea.Checked = True
                Else
                    CheckHighVandalismArea.Checked = False
                End If

                If escalatedEvents = "True" Then
                    CheckEscalatedEvents.Checked = True
                Else
                    CheckEscalatedEvents.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub ApplyPresetsShortCut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.KeyCode = Keys.Oemplus Then
                ButtonApplyPreset.PerformClick()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BindingNavigatorMoveNextItem2_Click(sender As Object, e As EventArgs) Handles MoveNextStandardPresets.Click
        BindingNavigatorStandardInspectionPresets.BindingSource.MoveNext()
    End Sub

    '-----------------------presets navigator buttons------------------------------
    Private Sub BindingNavigatorMovePreviousItem2_Click(sender As Object, e As EventArgs) Handles Move_PreviousStandardPresets.Click
        BindingNavigatorStandardInspectionPresets.BindingSource.MovePrevious()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Upload_ALL()
    End Sub

    Private Sub ButtonApplyPreset_Click(sender As Object, e As EventArgs) Handles ButtonApplyPreset.Click
        If CheckBoxMarkNoAccess.Checked = False Then
            If CurrentRecordExists() Or CurrentSelectionComplete() Then

                Dim result As Integer = MessageBox.Show("Overwrite record for PID " & " " & DataGridExcel.SelectedRows(0).Cells(1).Value.ToString() & "?",
                                                    "Preset Manager", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    Exit Sub
                ElseIf result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then

                    DeleteRecord()
                    DeleteRecord()
                    MarkAsIncomplete()
                    EnableOrDisableControlsCurrent()
                    ApplyPresets()
                    LoadPresets()
                    RichTextBox1.Text = GenerateComment()
                    ResetMainControlColors()

                End If
            Else
                ApplyPresets()
            End If

        Else
            MsgBox("No access option must be deselected to use this preset.")
        End If
    End Sub

    Private Sub ButtonApplyPreset_Click_1(sender As Object, e As EventArgs) Handles ButtonAddPreset.Click
        InsertPreset()
        LoadPresets()
    End Sub

    Private Sub ButtonCancelEditing_Click(sender As Object, e As EventArgs) Handles ButtonCancelEditing.Click
        CancelEditCompletion()
    End Sub

    Private Sub ButtonDoneEditing_Click(sender As Object, e As EventArgs) Handles ButtonDoneEditing.Click
        ResetMainControlColors()
        If CheckBoxMarkNoAccess.Checked Then
            InsertRecordNoAccess()
        Else
            InsertRecord()
        End If

        If VerifyCombos() And RichTextBox1.TextLength > 0 Then
            editMode = False
            MarkAsComplete()
            UpdateDB()
            BindingNavigatorExcelSheet.Enabled = True
            ButtonDoneEditing.Enabled = False
            ButtonDoneEditing.Visible = False
            ButtonCancelEditing.Visible = False
            ButtonCancelEditing.Enabled = False
            BindingNavigatorStandardInspectionPresets.Enabled = True
            ListBoxStandardInspectionPresets.Enabled = True
            EnableOrDisableControlsCurrent()
            MsgBox("Completion updated successfully.")
            ToolStripMenuItemGenerateNewComment.Enabled = False
        End If
    End Sub

    Private Sub ButtonNextPhoto_Click(sender As Object, e As EventArgs) Handles ButtonNextPhoto.Click
        If ListBoxFiles.SelectedIndex < ListBoxFiles.Items.Count - 1 Then
            ListBoxFiles.SelectedIndex += 1
        End If
    End Sub

    Private Sub ButtonPreviousPhoto_Click(sender As Object, e As EventArgs) Handles ButtonPreviousPhoto.Click
        If ListBoxFiles.SelectedIndex > 0 Then
            ListBoxFiles.SelectedIndex -= 1
        End If
    End Sub

    Private Sub CancelEditCompletion()
        SelectComboItemsFromDB()
        editMode = False
        ResetMainControlColors()
        InsertRecord()
        MarkAsComplete()
        UpdateDB()
        BindingNavigatorExcelSheet.Enabled = True
        ButtonDoneEditing.Enabled = False
        ButtonDoneEditing.Visible = False
        ButtonCancelEditing.Visible = False
        ButtonCancelEditing.Enabled = False
        BindingNavigatorStandardInspectionPresets.Enabled = True
        ListBoxStandardInspectionPresets.Enabled = True
        EnableOrDisableControlsCurrent()
        ToolStripMenuItemGenerateNewComment.Enabled = False
    End Sub

    Private Sub CheckBoxMarkNoAccess_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMarkNoAccess.CheckedChanged
        If CheckBoxMarkNoAccess.Checked Then
            DisableControls()
            ClearControlSelections()
            ComboBoxNoAccess.Enabled = True
            RichTextBox1.Enabled = True
            ButtonAddPreset.Enabled = False
            ButtonDeletePreset.Enabled = False
            ListBoxOccupancyIndicators.Enabled = False
        Else
            EnableOrDisableControlsCurrent()
            ComboBoxNoAccess.Enabled = False
            ButtonAddPreset.Enabled = True
            ButtonDeletePreset.Enabled = True
            ComboBoxNoAccess.SelectedIndex = -1
            RichTextBox1.Clear()
            If CurrentIsNoContact() Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                    If ComboDeterminedBy.Text = "Visual Observation" Then
                        ListBoxOccupancyIndicators.Enabled = True
                    Else
                        ListBoxOccupancyIndicators.Enabled = False
                    End If
                    Exit Sub
                End If
                ListBoxOccupancyIndicators.Enabled = True
            End If
        End If
    End Sub

    Private Sub CheckBoxNoHouseNumber_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNoHouseNumber.CheckedChanged
        If (Not CurrentSelectionComplete() Or editMode) And (Not CurrentIsNoContact() And (Not CurrentIsWellsFargo() Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)")) Then
            If ComboDeterminedBy.Text = "Neighbor" Then
                If CheckBoxNoHouseNumber.Checked Then
                    TextBoxNeighborHouseNumber.Enabled = False
                    TextBoxNeighborHouseNumber.BackColor = Color.Silver
                Else
                    TextBoxNeighborHouseNumber.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Function CheckComboLogic() As Boolean
        If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
            If ComboDeterminedBy.Text = "Visual Observation" And ComboOccupantType.Text = "Occupied by Owner" Then
                MsgBox("Invalid logic: Determined by visual observation cannot determine that property is occupied by owner.")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CheckCommentBox(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged, DataGridExcel.SelectionChanged, ButtonMarkComplete.Click, ButtonRevertCompletion.Click
        If dataImported Then
            If RichTextBox1.TextLength = 0 Then
                LabelCommentGenerator.Text = "Insufficient Details for Comment Generation."
            End If

            If CurrentRecordExists() And Not CurrentSelectionComplete() Then
                LabelCommentGenerator.Text = "Existing Comment from Database."
            ElseIf CurrentSelectionComplete() Then
                LabelCommentGenerator.Text = "Comment Saved."
            ElseIf RichTextBox1.TextLength > 0 Then
                LabelCommentGenerator.Text = "New Comment Generated."
            End If
        End If
    End Sub

    Private Sub CheckEscalatedEvents_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEscalatedEvents.CheckedChanged
        If Not CurrentSelectionComplete() Then
            If CheckEscalatedEvents.Checked Then
                TextBoxEscalatedEvents.Enabled = True
            Else
                TextBoxEscalatedEvents.Enabled = False
                TextBoxEscalatedEvents.Clear()
            End If
            RichTextBox1.Text = GenerateComment()
        End If
        LabelCommentGenerator.Text = "New Comment Generated."
    End Sub

    '-----------------------control formatting------------------------------
    Private Sub ColorCompletionStatus()
        If CurrentSelectionComplete() Then
            DisableControls()
            TextBoxServiceID.BackColor = Color.DarkSeaGreen
            TextBoxPropertyID.BackColor = Color.DarkSeaGreen
            ButtonImageCurrentStatus.Image = ImageList3.Images(0)
            Exit Sub
        ElseIf CurrentRecordExists() Then
            ButtonImageCurrentStatus.Image = ImageList3.Images(2)
        Else
            ButtonImageCurrentStatus.Image = ImageList3.Images(1)
        End If
        TextBoxServiceID.BackColor = Color.LightGray
        TextBoxPropertyID.BackColor = Color.LightGray
    End Sub

    Private Sub ComboBoxComboPropertyType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboPropertyType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboConstructionType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboConstructionType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboDeterminedBy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboDeterminedBy.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboDeterminedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboDeterminedBy.SelectedIndexChanged
        If Not CurrentSelectionComplete() Or editMode Then
            RichTextBox1.Clear()
            RichTextBox1.Text = GenerateComment()
            LabelCommentGenerator.Text = "New Comment Generated."
        End If

        DeterminedByEntryFieldCheck()
        If ComboDeterminedBy.SelectedIndex >= 0 Then
            If Not ComboDeterminedBy.SelectedItem.ToString = "Neighbor" Then
                TextBoxNeighborHouseNumber.Clear()
                TextBoxNeighborHouseNumber.BackColor = Color.Silver
            End If
        End If

        If ComboDeterminedBy.Text = "Neighbor" Then
            CheckBoxNoHouseNumber.Enabled = True
            ListBoxOccupancyIndicators.SelectedIndex = -1
            ListBoxOccupancyIndicators.Enabled = False
        Else
            CheckBoxNoHouseNumber.Enabled = False
        End If

        If Not (CurrentIsNoContact() Or CurrentIsWellsFargo()) Then
            If ComboDeterminedBy.Text = "Neighbor" Then
                ComboSpokeWith.SelectedIndex = -1
                ComboSpokeWith.Enabled = False
            Else
                ComboSpokeWith.Enabled = True
            End If
        Else
            ComboSpokeWith.Enabled = False
        End If

        If ComboDeterminedBy.Text = "Direct Contact" Then
            CheckBoxNoHouseNumber.Checked = False
        End If
        If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
            If ComboDeterminedBy.Text = "Visual Observation" Then
                ListBoxOccupancyIndicators.Enabled = True
                TextBoxNeighborHouseNumber.Clear()
                CheckBoxNoHouseNumber.Checked = False
                ComboSpokeWith.Enabled = False
                ComboSpokeWith.SelectedIndex = -1
            Else
                ListBoxOccupancyIndicators.Enabled = False
                ListBoxOccupancyIndicators.BackColor = Color.Silver
                ListBoxOccupancyIndicators.SelectedIndex = -1
            End If
        End If

    End Sub

    Private Sub ComboGarageType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboGarageType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboGrassHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboGrassHeight.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboLandscapeCondition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboLandscapeCondition.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboLandscapeType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboLandscapeType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboLocationType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboLocationType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboNeighborhoodIssues_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNeighborhoodIssues.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboNeighborhoodStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNeighborhoodStatus.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboOccupantType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboOccupantType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboOccupantType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboOccupantType.SelectedIndexChanged
        If Not CurrentSelectionComplete() Or editMode Then
            RichTextBox1.Clear()
            RichTextBox1.Text = GenerateComment()
            LabelCommentGenerator.Text = "New Comment Generated."
        End If
    End Sub

    Private Sub ComboPropertyCondition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboPropertyCondition.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboPropertyForSale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboPropertyForSale.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboPropertyForSale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboPropertyForSale.SelectedIndexChanged
        ForSaleEntryFieldsCheck()
        If ComboPropertyForSale.SelectedIndex >= 0 Then
            If Not (ComboPropertyForSale.SelectedItem.ToString = "Broker" Or ComboPropertyForSale.SelectedItem.ToString = "For Sale by Broker") Then
                TextBoxBrokerName.Clear()
                TextBoxBrokerNumber.Clear()
                TextBoxBrokerNumber.BackColor = Color.Silver
                TextBoxBrokerName.BackColor = Color.Silver
            End If
        End If
    End Sub

    Private Sub ComboPropertyHabitable_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboPropertyHabitable.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboRoofDamages_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboRoofDamages.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboRoofType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboRoofType.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboSecurityIssues_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSecurityIssues.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboSpokeWith_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSpokeWith.KeyPress
        e.Handled = True
    End Sub

    Private Function CurrentIsNoContact() As Boolean
        Dim current As String = LabelInspectionType.Text.ToString()
        For Each t In NoContactInspectionTypes
            If t = current Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function CurrentIsStandard() As Boolean
        Dim current As String = LabelInspectionType.Text.ToString()
        For Each t In StandardInspectionTypes
            If t = current Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function CurrentIsWellsFargo() As Boolean
        Dim current As String = LabelInspectionType.Text.ToString()
        For Each t In WellsFargoInspectionTypes
            If t = current Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function CurrentRecordExists() As Boolean
        Return (DirectCast(binder.Current, DataRowView).Item("Preexisting Record").ToString = "Yes")
    End Function

    Private Function CurrentSelectionComplete() As Boolean
        Return (DataGridExcel.SelectedRows(0).Cells(5).Tag.ToString() = "Complete")
    End Function

    Private Sub DeleteItemStandardPresets_Click(sender As Object, e As EventArgs) Handles ButtonDeletePreset.Click

        If ListBoxStandardInspectionPresets.SelectedIndex >= 0 Then
            Dim result As Integer = MessageBox.Show("Delete " & " " & ListBoxStandardInspectionPresets.Text.ToString() & "?",
                                                "Edit Presets", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                DeletePreset()
            End If
        End If
    End Sub

    Private Sub DeletePreset()

        Dim queryString As String = "DELETE * FROM StandardInspections WHERE [PresetName]=@PresetName"

        Using dbConn As New OleDbConnection With {.ConnectionString = My.Settings.FF_PresetsConnectionString}
            Using dbCommand As New OleDbCommand()
                With dbCommand
                    .Connection = dbConn
                    .CommandText = queryString
                    .Parameters.AddWithValue("@PresetName", ListBoxStandardInspectionPresets.Text.ToString())
                End With

                Try
                    dbConn.Open()
                    dbCommand.ExecuteNonQuery()
                    UpdatePresetsDB()
                    dbConn.Close()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error")
                End Try

            End Using
        End Using
        LoadPresets()
    End Sub

    Private Sub DeleteRecord()

        Dim queryString As String = "DELETE * FROM ServiceOrders WHERE [PropertyID]=@PropertyID"

        Using dbConn As New OleDbConnection With {.ConnectionString = My.Settings.FF_DB_ConnectionString}
            Using dbCommand As New OleDbCommand()
                With dbCommand
                    .Connection = dbConn
                    .CommandText = queryString
                    .Parameters.AddWithValue("@PropertyID", TextBoxPropertyID.Text.ToString)
                End With

                Try
                    dbConn.Open()
                    dbCommand.ExecuteNonQuery()
                    UpdateDB()
                    dbConn.Close()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error")
                End Try

            End Using
        End Using
    End Sub

    Private Sub DeterminedByEntryFieldCheck()
        If ComboDeterminedBy.SelectedIndex >= 0 Then
            If ComboDeterminedBy.SelectedItem.ToString = "Neighbor" Then
                TextBoxNeighborHouseNumber.Enabled = True
                Exit Sub
            End If
        End If
        TextBoxNeighborHouseNumber.Enabled = False
    End Sub

    Private Sub DisableControlsSpecific(type As String)
        For Each ctrl As Control In TabDataInput.Controls
            Dim p As FlowLayoutPanel = TryCast(ctrl, FlowLayoutPanel)
            If p IsNot Nothing Then
                If p.Tag = type Then
                    For Each ctrl2 In p.Controls
                        Dim c As ComboBox = TryCast(ctrl2, ComboBox)
                        Dim t As CheckBox = TryCast(ctrl2, CheckBox)
                        If c IsNot Nothing Then
                            c.Enabled = False
                        ElseIf t IsNot Nothing Then
                            t.Enabled = False
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub EditCompletion()
        editMode = True
        ButtonDoneEditing.Visible = True
        ButtonDoneEditing.Enabled = True
        ButtonCancelEditing.Visible = True
        ButtonCancelEditing.Enabled = True
        BindingNavigatorExcelSheet.Enabled = False
        EnableOrDisableControlsCurrent()
        BindingNavigatorStandardInspectionPresets.Enabled = False
        ListBoxStandardInspectionPresets.Enabled = False
        ToolStripMenuItemGenerateNewComment.Enabled = True
        CheckBoxMarkNoAccess.Enabled = True
        ComboBoxNoAccess.Enabled = True

        If (Not CurrentIsNoContact()) And (Not CurrentIsWellsFargo() Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)") And ComboDeterminedBy.Text = "Neighbor" Then
            CheckBoxNoHouseNumber.Enabled = True
        End If

        If ComboDeterminedBy.Text = "Neighbor" Then
            TextBoxNeighborHouseNumber.Enabled = True
        Else
            TextBoxNeighborHouseNumber.Enabled = False
        End If

        If CheckBoxNoHouseNumber.Checked Then
            TextBoxNeighborHouseNumber.Enabled = False
        End If

        If CheckBoxMarkNoAccess.Checked Then
            DisableControls()
        End If

    End Sub

    Private Sub EditCompletionShortcut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.Control And e.KeyCode.ToString = "E" Then
                If ToolStripMenuItemEditCompletion.Enabled = True Then
                    EditCompletion()
                End If
            End If
        End If
    End Sub

    Private Sub EditCompletionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditCompletion.Click
        EditCompletion()
    End Sub

    Private Sub EnableControlsSpecific(type As String)
        For Each ctrl As Control In TabDataInput.Controls
            Dim p As FlowLayoutPanel = TryCast(ctrl, FlowLayoutPanel)
            If p IsNot Nothing Then
                If p.Tag = type Then
                    For Each ctrl2 In p.Controls
                        Dim c As ComboBox = TryCast(ctrl2, ComboBox)
                        Dim t As CheckBox = TryCast(ctrl2, CheckBox)
                        If c IsNot Nothing Then
                            c.Enabled = True
                        ElseIf t IsNot Nothing Then
                            t.Enabled = True
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub EnableOrDisableControlsCurrent()
        If (CurrentSelectionComplete() And Not editMode) Then
            DisableControls()
            ComboBoxNoAccess.Enabled = False
            CheckBoxMarkNoAccess.Enabled = False
        Else
            EnableGlobalControls()
            If CurrentIsStandard() Then
                EnableControlsSpecific("Standard")
                DisableControlsSpecific("WellsFargo")
                LabelWellsFargoInspections.Enabled = False
                LabelStandardInspections.Enabled = True
            ElseIf CurrentIsWellsFargo() Then
                EnableControlsSpecific("WellsFargo")
                DisableControlsSpecific("Standard")
                LabelWellsFargoInspections.Enabled = True
                LabelStandardInspections.Enabled = False
            End If

            If CurrentIsNoContact() Then
                ListBoxOccupancyIndicators.Enabled = True
                LabelNoContactInspections.Enabled = True
                ComboSpokeWith.Enabled = False
                TextBoxNeighborHouseNumber.Enabled = False
                CheckBoxNoHouseNumber.Enabled = False
            Else

                ListBoxOccupancyIndicators.Enabled = False
                LabelNoContactInspections.Enabled = False

                If CurrentIsWellsFargo() Then
                    ComboSpokeWith.Enabled = False
                    If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Then
                        If ComboDeterminedBy.Text = "Neighbor" Then
                            TextBoxNeighborHouseNumber.Enabled = True
                            CheckBoxNoHouseNumber.Enabled = True
                        Else
                            TextBoxNeighborHouseNumber.Enabled = False
                            CheckBoxNoHouseNumber.Enabled = False
                        End If
                    Else
                        TextBoxNeighborHouseNumber.Enabled = False
                        CheckBoxNoHouseNumber.Enabled = False
                    End If
                Else
                    If ComboDeterminedBy.Text = "Neighbor" Then
                        ComboSpokeWith.Enabled = False
                        TextBoxNeighborHouseNumber.Enabled = True
                        CheckBoxNoHouseNumber.Enabled = True
                    Else
                        ComboSpokeWith.Enabled = True
                        TextBoxNeighborHouseNumber.Enabled = False
                        CheckBoxNoHouseNumber.Enabled = False
                    End If
                End If

                If LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                    If ComboDeterminedBy.Text = "Visual Observation" Then
                        ListBoxOccupancyIndicators.Enabled = True
                        ComboSpokeWith.Enabled = False
                        ComboSpokeWith.SelectedIndex = -1

                    End If
                End If

            End If

            If CurrentSelectionComplete() Then
                ToolStripMenuItemEditCompletion.Enabled = True
                ToolStripMenuItemGenerateNewComment.Enabled = False
            Else
                ToolStripMenuItemEditCompletion.Enabled = False
                ToolStripMenuItemGenerateNewComment.Enabled = True
            End If

            If CheckBoxNoHouseNumber.Checked Then
                TextBoxNeighborHouseNumber.Enabled = False
            End If

            If Not CurrentSelectionComplete() Then
                CheckBoxMarkNoAccess.Enabled = True
                If CheckBoxMarkNoAccess.Checked Then
                    ComboBoxNoAccess.Enabled = True
                Else
                    ComboBoxNoAccess.Enabled = False
                    ComboBoxNoAccess.SelectedIndex = -1
                End If
            End If

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.AutoSize = False
        Me.KeyPreview = True
        ServiceOrdersTableAdapter1.Fill(FF_DBDataSet1.ServiceOrders)
        StandardInspectionsTableAdapter1.Fill(FF_PresetsDataSet1.StandardInspections)
        TabControl1.TabPages.RemoveAt(1)
        DisableMainControls()
        Label2.Text = "Status: No Data Imported"

        ToolStripProgressBar1.Visible = False
        ToolStripStatusLabel1.Visible = False
        ToolStripMenuItemEditCompletion.Enabled = False
        ToolStripMenuItemGenerateNewComment.Enabled = False
        LoadPresets()

        TextBoxPassword.Text = My.Settings.PassWord
        TextBoxUsername.Text = My.Settings.UserName
        TabControl1.TabPages(2).Enabled = False

    End Sub
    Private Sub ForSaleEntryFieldsCheck()
        If ComboPropertyForSale.SelectedIndex >= 0 Then
            If ComboPropertyForSale.SelectedItem.ToString = "Broker" Or ComboPropertyForSale.SelectedItem.ToString = "For Sale by Broker" Then
                TextBoxBrokerName.Enabled = True
                TextBoxBrokerNumber.Enabled = True
                Exit Sub
            End If
        End If
        TextBoxBrokerName.Enabled = False
        TextBoxBrokerNumber.Enabled = False
    End Sub

    Private Function GenerateComment() As String

        Dim rand1 As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim rand2 As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim rand3 As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim rand4 As Integer = CInt(Math.Ceiling(Rnd() * 5))

        Dim commentString As String = ""
        If ComboOccupantType.SelectedIndex >= 0 And ComboDeterminedBy.SelectedIndex >= 0 Then
            If ComboDeterminedBy.Text = "Direct Contact" Or ComboDeterminedBy.Text = "Visual Observation" Then
                If LabelInspectionType.Text = "EXTERIOR CALL BACK INSPECTION (WF)" Then
                    Select Case rand1
                        Case 1
                            commentString += "Call-back card left with "
                        Case 2
                            commentString += "Made contact and left a Call-back card with "
                        Case 3
                            commentString += "A call-back card was handed to "
                        Case 4
                            commentString += "The cb card was given to "
                        Case 5
                            commentString += "Call-back card was accepted by "
                    End Select

                ElseIf LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION (CO)" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION (SS)" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION (FT)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                    Select Case rand1
                        Case 1
                            commentString += "Property occupied by "
                        Case 2
                            commentString += "Occupied by "
                        Case 3 To 5
                            commentString += "The property is occupied by "
                    End Select
                End If
                If ComboOccupantType.SelectedItem.ToString = "Occupied by Unknown Occupant" And ComboDeterminedBy.Text = "Direct Contact" Then
                    Select Case rand2
                        Case 1
                            commentString += "unknown occupant."
                        Case 2
                            commentString += "unknown occupant at the property."
                        Case 3
                            commentString += "unknown person occupying the property."
                        Case 4
                            commentString += "an occupant who wished not to disclose his identity."
                        Case 5
                            commentString += "an occupant who wished not to disclose her identity."
                    End Select
                ElseIf ComboOccupantType.SelectedItem.ToString = "Occupied by Owner" And ComboDeterminedBy.Text = "Direct Contact" Then
                    Select Case rand3
                        Case 1
                            commentString += "occupant claiming to be a relative of the mortgagor."
                        Case 2
                            commentString += "person who said she was a relative of the owner."
                        Case 3
                            commentString += "someone who claimed to be a relative of the mortgagor."
                        Case 4
                            commentString += "occupant who confirmed the owner lives at the property."
                        Case 5
                            commentString += "individual claiming to be related to the owner occupying the residence."
                    End Select
                ElseIf ComboDeterminedBy.Text = "Visual Observation" Then
                    Select Case rand2
                        Case 1
                            commentString += " unknown occupant. Knocked on door, but nobody was home."
                        Case 2
                            commentString += " unknown occupant. Approached property, but no answer at door."
                        Case 3
                            commentString += " unknown occupant. No answer at door."
                        Case 4
                            commentString += " unknown occupant. Nobody answered when I approached the property."
                        Case 5
                            commentString += " unknown occupant. Nobody answered after knocking on door."
                    End Select

                    Select Case rand3
                        Case 1
                            commentString += " Unable to make contact with neighbor."
                        Case 2
                            commentString += " Unable to verify with neighbors."
                        Case 3
                            commentString += " Neighbors could not confirm occupancy."
                        Case 4
                            commentString += " Neighbors did not provide any info."
                        Case 5
                            commentString += " Unable to speak with neighbors."
                    End Select
                End If
                If ComboDeterminedBy.Text = "Direct Contact" Then
                    Select Case rand4
                        Case 1
                            commentString += "  No other information was disclosed."
                        Case 2
                            commentString += "  Refused to disclose additional information and I was asked to leave."
                        Case 3
                            commentString += "  Additional information was not provided."
                        Case 4
                            commentString += "  No other details were provided and I was asked to leave the property."
                        Case 5
                            commentString += " Occupant declined to provide any additional info."
                    End Select
                ElseIf ComboDeterminedBy.Text = "Visual Observation" Then
                    commentString += " " + GenerateOccupancyIndicatorsComment()
                End If
            ElseIf ComboDeterminedBy.Text = "Neighbor" Then
                commentString = GenerateNeighborComment()
            End If
        End If

        If LabelInspectionType.Text = "NO CONTACT INSPECTION" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (SS)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (WF)" Or
                                LabelInspectionType.Text = "NO CONTACT INSPECTION (CO)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (FT)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (AFAS)" Then
            commentString = GenerateOccupancyIndicatorsComment()
        End If

        If CurrentIsWellsFargo() And (ComboDeterminedBy.Text <> "Visual Observation") Then
            If CheckEscalatedEvents.Checked Then
                commentString += "  " & TextBoxEscalatedEvents.Text
            End If
        End If

        Return commentString
    End Function

    Private Sub GenerateCommentShortcut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.Control And e.KeyCode.ToString = "G" Then
                If ToolStripMenuItemGenerateNewComment.Enabled = True Then
                    If RichTextBox1.Enabled = True Then
                        RichTextBox1.Text = GenerateComment()
                    End If
                End If
            End If
        End If
    End Sub

    Private Function GenerateNeighborComment() As String
        Dim rand1 As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim rand2 As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim rand3 As Integer = CInt(Math.Ceiling(Rnd() * 5))

        Dim commentString As String = ""

        Select Case rand1
            Case 1
                commentString += "Attempted contact, but no answer at door."
            Case 2
                commentString += "Knocked on front door of the property, but no answer."
            Case 3
                commentString += "Approached property, but nobody was home."
            Case 4
                commentString += "No answer after knocking on the front door."
            Case 5
                commentString += "Nobody answered the door upon approaching the property."
        End Select

        If TextBoxNeighborHouseNumber.Text.Length > 0 Then

            Select Case rand2
                Case 1
                    commentString += "  Neighbor at " & TextBoxNeighborHouseNumber.Text
                Case 2
                    commentString += "  The neighbor nextdoor at " & TextBoxNeighborHouseNumber.Text
                Case 3
                    commentString += "  Neighbors located at " & TextBoxNeighborHouseNumber.Text
                Case 4
                    commentString += "  People next door at house number " & TextBoxNeighborHouseNumber.Text
                Case 5
                    commentString += "  The occupants of the property at " & TextBoxNeighborHouseNumber.Text
            End Select
        Else
            Select Case rand2
                Case 1
                    commentString += "  Neighbor"
                Case 2
                    commentString += "  The neighbor nextdoor"
                Case 3
                    commentString += "  Neighbors across the street"
                Case 4
                    commentString += "  The nextdoor neighbor"
                Case 5
                    commentString += "  A neighbor"
            End Select
        End If
        Select Case rand3
            Case 1
                commentString += " confirmed that the property is occupied by "
            Case 2
                commentString += " confirmed that this property is occupied by "
            Case 3
                commentString += " informed me that the property is occupied by "
            Case 4
                commentString += " confirmed property is occupied by "
            Case 5
                commentString += " claimed that this property is occupied by "
        End Select
        If ComboOccupantType.Text = "Occupied by Unknown Occupant" Then
            commentString += " unknown occupant."
        Else
            commentString += " the mortgagor."
        End If

        Return commentString
    End Function

    Private Sub GenerateNewCommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemGenerateNewComment.Click
        If RichTextBox1.Enabled = True Then
            RichTextBox1.Text = GenerateComment()
        End If
    End Sub

    Private Function GenerateOccupancyIndicatorsComment() As String
        Dim rand As Integer = CInt(Math.Ceiling(Rnd() * 5))
        Dim commentString As String = GenerateoOccupancyIndicatorsStringComments()
        If Not (commentString = "") Then
            Dim occupancyIndiators As String() = commentString.Split(New Char() {","c})
            Dim plural As Boolean = occupancyIndiators.Count > 1

            If plural Then
                Select Case rand
                    Case 1
                        commentString += " indicate occupancy."
                    Case 2
                        commentString += " suggest that the property is occupied."
                    Case 3
                        commentString += " are reason to believe the property is occupied."
                    Case 4
                        commentString += " mean that the property is most likely occcupied."
                    Case 5
                        commentString += " lead me to believe that the property is occupied."
                    Case 6
                        commentString += " suggest that someone is living at the property."
                    Case 7
                        commentString += " indicate that someone is occupying the home."
                End Select
            Else
                Select Case rand
                    Case 1
                        commentString += " indicates occupancy."
                    Case 2
                        commentString += " suggests that the property is occupied."
                    Case 3
                        commentString += " provides reason to believe the property is occupied."
                    Case 4
                        commentString += " means that this property is most likely occcupied."
                    Case 5
                        commentString += " leads me to believe that the property is occupied."
                    Case 6
                        commentString += " suggests that someone is living at the property."
                    Case 7
                        commentString += " indicates that someone is occupying the home."
                End Select
            End If
        End If
        Return commentString
    End Function

    Private Function GenerateOccupancyIndicatorStringDB() As String
        Dim count As Integer = ListBoxOccupancyIndicators.SelectedItems.Count
        Dim result As String = ""

        For i As Integer = 0 To count - 1
            result += ListBoxOccupancyIndicators.SelectedItems(i).ToString
            If Not (i + 1 = (count)) Then
                result += ","
            Else
                Return result
            End If
        Next
        Return result
    End Function

    Private Function GenerateoOccupancyIndicatorsStringComments() As String
        Dim count As Integer = ListBoxOccupancyIndicators.SelectedItems.Count
        Dim result As String = ""

        For i As Integer = 0 To count - 1
            If ListBoxOccupancyIndicators.SelectedItems(i).ToString = "Pets inside/outside the property" Then
                result += "Pets"
            Else
                result += ListBoxOccupancyIndicators.SelectedItems(i).ToString
            End If
            If Not (i + 1 = count) Then
                If Not (i + 2 = count) Then
                    result += ", "
                Else
                    result += " and "
                End If
            Else
                Return result
            End If
        Next
        Return result
    End Function

    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ListBoxOccupancyIndicators.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.DarkSeaGreen, e.Bounds)
        End If
        Try

            Using b As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(ListBoxOccupancyIndicators.GetItemText(ListBoxOccupancyIndicators.Items(e.Index)), e.Font, b, e.Bounds)
            End Using
            e.DrawFocusRectangle()
        Catch

        End Try
    End Sub

    Private Sub ListBoxFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxFiles.SelectedIndexChanged
        PictureBox1.ImageLocation = sourceDir & "\" & ListBoxFiles.SelectedItem.ToString()

    End Sub

    Private Sub ListBoxOccupancyIndicators_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxOccupancyIndicators.SelectedIndexChanged
        If Not CurrentSelectionComplete() Or editMode Then
            RichTextBox1.Text = GenerateComment()
        End If

        If ListBoxOccupancyIndicators.SelectedItems.Count > 0 Then
            ListBoxOccupancyIndicators.BackColor = Color.Silver
        End If

    End Sub

    Private Sub ListBoxStandardInspectionPresets_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ListBoxStandardInspectionPresets.DrawItem
        e.DrawBackground()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.DarkSeaGreen, e.Bounds)
        End If
        Try

            Using b As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(ListBoxStandardInspectionPresets.GetItemText(ListBoxStandardInspectionPresets.Items(e.Index)), e.Font, b, e.Bounds)
            End Using
            e.DrawFocusRectangle()
        Catch

        End Try
    End Sub

    Private Sub LoadPresets()
        UpdatePresetsDB()

        Dim current As String = LabelInspectionType.Text.ToString()
        Dim table As DataTable = FF_PresetsDataSet1.Tables("StandardInspections")
        Dim temp As New DataTable
        BindingSourcePresets.DataSource = temp

        If current = "NO CONTACT INSPECTION" Or current = "NO CONTACT INSPECTION (SS)" Or current = "NO CONTACT INSPECTION (CO)" Or current = "NO CONTACT INSPECTION (FT)" Then
            Dim StandardNoContactQuery = From inspection In table.AsEnumerable
                                         Where inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION" Or
                                               inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION (SS)" Or
                                               inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION (FT)" Or
                                               inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION (CO)"
            If StandardNoContactQuery.Count > 0 Then
                BindingSourcePresets.DataSource = StandardNoContactQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If

        ElseIf current = "NO CONTACT INSPECTION (AFAS)" Then
            Dim StandardNoContactQuery = From inspection In table.AsEnumerable
                                         Where inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION (AFAS)"
            If StandardNoContactQuery.Count > 0 Then
                BindingSourcePresets.DataSource = StandardNoContactQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If
        ElseIf current = "OCCUPANCY INSPECTION (AFAS)" Then
            Dim StandardNoContactQuery = From inspection In table.AsEnumerable
                                         Where inspection.Field(Of String)("InspectionType") = "OCCUPANCY INSPECTION (AFAS)"
            If StandardNoContactQuery.Count > 0 Then
                BindingSourcePresets.DataSource = StandardNoContactQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If

        ElseIf current = "EXTERIOR CALL BACK INSPECTION (WF)" Then
            Dim WellsFargoQuery = From inspection In table.AsEnumerable
                                  Where inspection.Field(Of String)("InspectionType") = "EXTERIOR CALL BACK INSPECTION (WF)"
                                  Select inspection

            If WellsFargoQuery.Count > 0 Then
                BindingSourcePresets.DataSource = WellsFargoQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If

        ElseIf current = "EXTERIOR INSPECTION (WF)" Then
            Dim WellsFargoQuery = From inspection In table.AsEnumerable
                                  Where inspection.Field(Of String)("InspectionType") = "EXTERIOR INSPECTION (WF)"
                                  Select inspection

            If WellsFargoQuery.Count > 0 Then
                BindingSourcePresets.DataSource = WellsFargoQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If
        ElseIf current = "NO CONTACT INSPECTION (WF)" Then
            Dim WellsFargoNoContactQuery = From inspection In table.AsEnumerable
                                           Where inspection.Field(Of String)("InspectionType") = "NO CONTACT INSPECTION (WF)"
                                           Select inspection

            If WellsFargoNoContactQuery.Count > 0 Then
                BindingSourcePresets.DataSource = WellsFargoNoContactQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If

        ElseIf current = "OCCUPANCY VERIFICATION" Or current = "OCCUPANCY VERIFICATION (CO)" Or current = "OCCUPANCY VERIFICATION (SS)" Or current = "OCCUPANCY VERIFICATION (FT)" Or current = "OCCUPANCY INSPECTION (AFAS)" Then
            Dim StandardQuery = From inspection In table.AsEnumerable
                                Where inspection.Field(Of String)("InspectionType") = "OCCUPANCY VERIFICATION" Or
                                           inspection.Field(Of String)("InspectionType") = "OCCUPANCY VERIFICATION (SS)" Or
                                           inspection.Field(Of String)("InspectionType") = "OCCUPANCY VERIFICATION (FT)" Or
                                           inspection.Field(Of String)("InspectionType") = "OCCUPANCY VERIFICATION (CO)"
                                Select inspection
            If StandardQuery.Count > 0 Then
                BindingSourcePresets.DataSource = StandardQuery.CopyToDataTable
                ListBoxStandardInspectionPresets.DataSource = BindingSourcePresets
                ListBoxStandardInspectionPresets.DisplayMember = "PresetName"
                ListBoxStandardInspectionPresets.ValueMember = "PresetName"
            End If
        End If
        Application.DoEvents()
    End Sub

    Private Sub MarkAsCompleteShortCut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.KeyCode = Keys.Enter Then
                ButtonMarkComplete.PerformClick()
            End If
        End If
    End Sub

    Private Sub MarkAsIncompleteShortCut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.KeyCode = Keys.Delete Then
                ButtonRevertCompletion.PerformClick()
            End If
        End If
    End Sub

    Private Sub MoveFirstExcel_Click(sender As Object, e As EventArgs) Handles MoveFirstExcel.Click
        If NotUploading Then
            BindingNavigatorExcelSheet.BindingSource.MoveFirst()
        End If
    End Sub

    Private Sub MoveLastExcel_Click(sender As Object, e As EventArgs) Handles MoveLastExcel.Click
        If NotUploading Then
            BindingNavigatorExcelSheet.BindingSource.MoveLast()
        End If
    End Sub

    Private Sub MoveNextExcel_Click(sender As Object, e As EventArgs) Handles MoveNextExcel.Click
        If NotUploading Then
            BindingNavigatorExcelSheet.BindingSource.MoveNext()
        End If
    End Sub

    Private Sub MovePreviousExcel_Click(sender As Object, e As EventArgs) Handles MovePreviousExcel.Click
        If NotUploading Then
            BindingNavigatorExcelSheet.BindingSource.MovePrevious()
        End If
    End Sub

    '--------------------SHORTCUTKEYS------------------------
    Private Sub NextItemShortcut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.KeyCode = Keys.Right Then
                MoveNextExcel.PerformClick()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub OpenExcelShortCut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.Control And e.KeyCode.ToString = "O" Then
                OpenToolStripButton.PerformClick()
            End If
        End If
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click

        If ImportExcel() Then
            TabControl1.SelectedIndex = 1
            ColorCodeExcelData()
            ColorCompletionStatus()
            SetCompletionLabel()
            UpdateToolbarStatus()
        End If
    End Sub

    Private Sub PopulateCombos()

        Dim inspectionType As String = DataGridExcel.SelectedRows(0).Cells(2).Value.ToString
        Select Case inspectionType

            Case "OCCUPANCY VERIFICATION", "OCCUPANCY VERIFICATION (SS)", "OCCUPANCY VERIFICATION (CO)", "OCCUPANCY VERIFICATION (FT)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"For Sale by Broker", "For Sale by Owner", "Not For Sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied by Unknown Occupant", "Occupied by Owner"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Direct Contact", "Neighbor"})
                ComboSpokeWith.Items.Clear()
                ComboSpokeWith.Items.AddRange(New Object() {"Other person at Property", "Relative"})
            Case "OCCUPANCY INSPECTION (AFAS)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"For Sale by Broker", "For Sale by Owner", "Not for Sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied by Unknown Occupant", "Occupied by Owner"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Direct Contact", "Neighbor", "Visual Observation"})
                ComboSpokeWith.Items.Clear()
                ComboSpokeWith.Items.AddRange(New Object() {"Other Person at Property", "Relative"})

            Case "NO CONTACT INSPECTION (AFAS)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"For Sale by Broker", "For Sale by Owner", "Not for Sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied by Unknown Occupant"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Visual Observation"})
                ComboSpokeWith.Items.Clear()

            Case "NO CONTACT INSPECTION", "NO CONTACT INSPECTION (SS)", "NO CONTACT INSPECTION (CO)", "NO CONTACT INSPECTION (FT)", "NO CONTACT INSPECTION (AFAS)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"For Sale by Broker", "For Sale by Owner", "Not For Sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Visual Observation"})
                ComboSpokeWith.Items.Clear()

            Case "EXTERIOR INSPECTION (WF)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"Broker", "Owner", "Property not for sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied by Unknown Occupant", "Occupied by Owner"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Direct Contact", "Neighbor", "Visual Observation"})
                ComboSpokeWith.Items.Clear()
            Case "EXTERIOR CALL BACK INSPECTION (WF)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"Broker", "Owner", "Property not for sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied by Unknown Occupant", "Occupied by Owner"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Direct Contact"})
                ComboSpokeWith.Items.Clear()
            Case "NO CONTACT INSPECTION (WF)"
                ComboPropertyForSale.Items.Clear()
                ComboPropertyForSale.Items.AddRange(New Object() {"Broker", "Owner", "Property not for sale"})
                ComboOccupantType.Items.Clear()
                ComboOccupantType.Items.AddRange(New Object() {"Occupied"})
                ComboDeterminedBy.Items.Clear()
                ComboDeterminedBy.Items.AddRange(New Object() {"Visual Observation"})
                ComboSpokeWith.Items.Clear()
        End Select

    End Sub

    Private Sub PreviousItemShortcut(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If NotUploading Then
            If e.KeyCode = Keys.Left Then
                MovePreviousExcel.PerformClick()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub RemoveUnsupportedTypes(grid As DataGridView)

        For Each row As DataGridViewRow In grid.Rows
            If Not (WellsFargoInspectionTypes.Contains(row.Cells(2).Value.ToString()) Or StandardInspectionTypes.Contains(row.Cells(2).Value.ToString())) Then
                grid.Rows.Remove(row)
                UnsupportedTypes += 1
            End If
        Next

    End Sub

    Private Sub ResetMainControlColors()
        ComboDeterminedBy.BackColor = Color.Silver
        ComboOccupantType.BackColor = Color.Silver
        ComboConstructionType.BackColor = Color.Silver
        ComboGarageType.BackColor = Color.Silver
        ComboGrassHeight.BackColor = Color.Silver
        ComboLandscapeCondition.BackColor = Color.Silver
        ComboLocationType.BackColor = Color.Silver
        ComboNeighborhoodIssues.BackColor = Color.Silver
        ComboPropertyCondition.BackColor = Color.Silver
        ComboPropertyForSale.BackColor = Color.Silver
        ComboPropertyHabitable.BackColor = Color.Silver
        ComboRoofDamages.BackColor = Color.Silver
        ComboSpokeWith.BackColor = Color.Silver
        ComboSecurityIssues.BackColor = Color.Silver
        ComboPropertyType.BackColor = Color.Silver
        ComboNeighborhoodStatus.BackColor = Color.Silver
        ComboRoofType.BackColor = Color.Silver
        ComboLandscapeType.BackColor = Color.Silver
        TextBoxBrokerNumber.BackColor = Color.Silver
        TextBoxBrokerName.BackColor = Color.Silver
        TextBoxEscalatedEvents.BackColor = Color.Silver
        ListBoxOccupancyIndicators.BackColor = Color.Silver
        RichTextBox1.BackColor = Color.Silver
        TextBoxNeighborHouseNumber.BackColor = Color.Silver
    End Sub

    Private Function SearchDatabaseGrid(excelPropertyID As String) As Integer?

        Dim databasePropertyID As String = Nothing

        For index As Integer = 0 To DataGridDatabase.RowCount - 1

            If DataGridDatabase.Rows(index).Cells(1).Value.ToString = String.Empty Then
                Return Nothing
            End If

            databasePropertyID = DataGridDatabase.Rows(index).Cells(1).Value.ToString
            If String.Equals(databasePropertyID, excelPropertyID) Then
                Return index
            End If
        Next

        Return Nothing

    End Function

    Private Sub SelectComboItemsFromDB()

        Dim propertyID As String = DirectCast(binder.Current, DataRowView).Item("Property Id").ToString
        Dim dbIndex As Integer

        If CurrentRecordExists() Or CurrentSelectionComplete() Then
            dbIndex = SearchDatabaseGrid(propertyID)
            Dim constructionType As String = DataGridDatabase.Rows(dbIndex).Cells(3).Value.ToString
            Dim occupantType As String = DataGridDatabase.Rows(dbIndex).Cells(4).Value.ToString
            Dim propertyCondition As String = DataGridDatabase.Rows(dbIndex).Cells(6).Value.ToString
            Dim determinedBy As String = DataGridDatabase.Rows(dbIndex).Cells(8).Value.ToString
            Dim propertyType As String = DataGridDatabase.Rows(dbIndex).Cells(9).Value.ToString
            Dim propertyForSale As String = DataGridDatabase.Rows(dbIndex).Cells(10).Value.ToString
            Dim brokerName As String = DataGridDatabase.Rows(dbIndex).Cells(11).Value.ToString
            Dim brokerNumber As String = DataGridDatabase.Rows(dbIndex).Cells(12).Value.ToString
            brokerNumber = FormatPhoneNumber(brokerNumber, "")
            Dim comment As String = DataGridDatabase.Rows(dbIndex).Cells(30).Value.ToString
            Dim neighborHouseNumber As String = DataGridDatabase.Rows(dbIndex).Cells(29).Value.ToString
            Dim occupancyIndicators As String = DataGridDatabase.Rows(dbIndex).Cells(28).Value.ToString
            Dim NoHouseNumber As String = DataGridDatabase.Rows(dbIndex).Cells(31).Value.ToString
            Dim noAccess As String = DataGridDatabase.Rows(dbIndex).Cells(32).Value.ToString
            Dim noAccessReason As String = DataGridDatabase.Rows(dbIndex).Cells(33).Value.ToString

            If noAccess = "True" Then
                CheckBoxMarkNoAccess.Checked = True
                ComboBoxNoAccess.SelectedItem = noAccessReason
                RichTextBox1.Text = comment
                Exit Sub
            End If

            ComboConstructionType.SelectedItem = constructionType
            ComboPropertyCondition.SelectedItem = propertyCondition
            ComboDeterminedBy.SelectedItem = determinedBy
            ComboOccupantType.SelectedItem = occupantType
            ComboPropertyType.SelectedItem = propertyType
            ComboPropertyForSale.SelectedItem = propertyForSale
            TextBoxBrokerName.Text = brokerName
            TextBoxBrokerNumber.Text = brokerNumber
            RichTextBox1.Text = comment
            TextBoxNeighborHouseNumber.Text = neighborHouseNumber

            If LabelInspectionType.Text = "NO CONTACT INSPECTION" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (SS)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (WF)" Or
                                LabelInspectionType.Text = "NO CONTACT INSPECTION (CO)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (FT)" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (AFAS)" Or
                                LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                SetOccupancyIndicatorsListBox(occupancyIndicators)
            End If

            If CurrentIsStandard() Then

                Dim garageType As String = DataGridDatabase.Rows(dbIndex).Cells(5).Value.ToString
                Dim spokeWith As String = DataGridDatabase.Rows(dbIndex).Cells(7).Value.ToString

                ComboSpokeWith.SelectedItem = spokeWith
                ComboGarageType.SelectedItem = garageType

            ElseIf CurrentIsWellsFargo() Then

                Dim locationType As String = DataGridDatabase.Rows(dbIndex).Cells(13).Value.ToString
                Dim neighborhoodStatus As String = DataGridDatabase.Rows(dbIndex).Cells(14).Value.ToString
                Dim neighborhoodIssues As String = DataGridDatabase.Rows(dbIndex).Cells(15).Value.ToString
                Dim roofType As String = DataGridDatabase.Rows(dbIndex).Cells(16).Value.ToString
                Dim roofDamage As String = DataGridDatabase.Rows(dbIndex).Cells(17).Value.ToString
                Dim landscapeType As String = DataGridDatabase.Rows(dbIndex).Cells(18).Value.ToString
                Dim landscapeCondition As String = DataGridDatabase.Rows(dbIndex).Cells(19).Value.ToString
                Dim grassHeight As String = DataGridDatabase.Rows(dbIndex).Cells(20).Value.ToString
                Dim securityIssues As String = DataGridDatabase.Rows(dbIndex).Cells(21).Value.ToString
                Dim propertyHabitable As String = DataGridDatabase.Rows(dbIndex).Cells(22).Value.ToString
                Dim propertyUnsecure As String = DataGridDatabase.Rows(dbIndex).Cells(23).Value.ToString
                Dim gatedCommunity As String = DataGridDatabase.Rows(dbIndex).Cells(24).Value.ToString
                Dim highVandalismArea As String = DataGridDatabase.Rows(dbIndex).Cells(25).Value.ToString
                Dim escalatedEvents As String = DataGridDatabase.Rows(dbIndex).Cells(26).Value.ToString
                Dim escalatedEventsText As String = DataGridDatabase.Rows(dbIndex).Cells(27).Value.ToString

                ComboLocationType.SelectedItem = locationType
                ComboNeighborhoodStatus.SelectedItem = neighborhoodStatus
                ComboNeighborhoodIssues.SelectedItem = neighborhoodIssues
                ComboRoofType.SelectedItem = roofType
                ComboRoofDamages.SelectedItem = roofDamage
                ComboLandscapeType.SelectedItem = landscapeType
                ComboLandscapeCondition.SelectedItem = landscapeCondition
                ComboGrassHeight.SelectedItem = grassHeight
                ComboSecurityIssues.SelectedItem = securityIssues
                ComboPropertyHabitable.SelectedItem = propertyHabitable
                TextBoxEscalatedEvents.Text = escalatedEventsText

                If propertyUnsecure = "True" Then
                    CheckPropertyUnsecure.Checked = True
                Else
                    CheckPropertyUnsecure.Checked = False
                End If

                If gatedCommunity = "True" Then
                    CheckGatedCommunity.Checked = True
                Else
                    CheckGatedCommunity.Checked = False
                End If

                If highVandalismArea = "True" Then
                    CheckHighVandalismArea.Checked = True
                Else
                    CheckHighVandalismArea.Checked = False
                End If

                If escalatedEvents = "True" Then
                    CheckEscalatedEvents.Checked = True
                Else
                    CheckEscalatedEvents.Checked = False
                End If
            End If

            If NoHouseNumber = "True" Then
                CheckBoxNoHouseNumber.Checked = True
            Else
                CheckBoxNoHouseNumber.Checked = False
            End If
        End If
    End Sub

    Private Sub SelectDir()
        Dim folderDialog As New FolderBrowserDialog()

        If folderDialog.ShowDialog() = DialogResult.OK Then

            sourceDir = folderDialog.SelectedPath

            index = 0
            ListBoxFiles.Items.Clear()
            UpdateListBoxFiles()

            If index > 0 Then
                ListBoxFiles.SelectedIndex = 0
            Else
                ListBoxFiles.Items.Add("Folder is empty.")
            End If
            'Label2.Content = Index & " Files"
        End If
    End Sub

    Private Sub SelectOccupancyIndicatorsWebForm()

        Dim indicatorCombo As HtmlElement = WebBrowser1.Document.GetElementById("serviceDetailFormBeanItems26.detail.preApprovedValues")

        For Each choice As HtmlElement In indicatorCombo.GetElementsByTagName("option")
            For Each indicator In ListBoxOccupancyIndicators.SelectedItems
                If choice.InnerText = indicator.ToString() Then
                    choice.SetAttribute("selected", "true")
                End If
            Next
        Next
    End Sub

    Private Sub SelectOccupancyIndicatorsWebFormAFAS()

        Dim indicatorCombo As HtmlElement = WebBrowser1.Document.GetElementById("service.detailList23.preApprovedValues")

        For Each choice As HtmlElement In indicatorCombo.GetElementsByTagName("option")
            For Each indicator In ListBoxOccupancyIndicators.SelectedItems
                If choice.InnerText = indicator.ToString() Then
                    choice.SetAttribute("selected", "true")
                End If
            Next
        Next
    End Sub

    Private Sub SelectOccupancyIndicatorsWebFormAFASNC()

        Dim indicatorCombo As HtmlElement = WebBrowser1.Document.GetElementById("service.detailList22.preApprovedValues")

        For Each choice As HtmlElement In indicatorCombo.GetElementsByTagName("option")
            For Each indicator In ListBoxOccupancyIndicators.SelectedItems
                If choice.InnerText = indicator.ToString() Then
                    choice.SetAttribute("selected", "true")
                End If
            Next
        Next
    End Sub

    Private Sub SelectOccupancyIndicatorsWebFormSS()

        Dim indicatorCombo As HtmlElement = WebBrowser1.Document.GetElementById("serviceDetailFormBeanItems27.detail.preApprovedValues")

        For Each choice As HtmlElement In indicatorCombo.GetElementsByTagName("option")
            For Each indicator In ListBoxOccupancyIndicators.SelectedItems
                If choice.InnerText = indicator.ToString() Then
                    choice.SetAttribute("selected", "true")
                End If
            Next
        Next
    End Sub

    Private Sub SelectOccupancyIndicatorsWebFormWF()

        Dim indicatorCombo As HtmlElement = WebBrowser1.Document.GetElementById("service.detailList74.preApprovedValues")

        For Each choice As HtmlElement In indicatorCombo.GetElementsByTagName("option")
            For Each indicator In ListBoxOccupancyIndicators.SelectedItems
                If choice.InnerText = indicator.ToString() Then
                    choice.SetAttribute("selected", "true")
                End If
            Next
        Next
    End Sub

    Private Sub SetOccupancyIndicatorsListBox(str As String)
        Dim indicators As String() = str.Split(New Char() {","c})
        For Each indicator As String In indicators
            ListBoxOccupancyIndicators.SelectedItem = indicator
        Next
    End Sub

    Private Sub ShowShortCuts()
        Dim commentString As String = "Move Next                                                             Right Arrow" & vbNewLine
        commentString += "Move Previous                                                      Left Arrow" & vbNewLine
        commentString += "Mark as Completed/Save to Database              Enter" & vbNewLine
        commentString += "Mark as Incomplete/Delete from Database      Delete" & vbNewLine
        commentString += "Apply Preset                                                          +/=" & vbNewLine
        commentString += "Generate New Comment                                    Ctrl + G" & vbNewLine
        commentString += "Edit Completion                                                   Ctrl + E" & vbNewLine
        MessageBox.Show(commentString, "Shortcuts")
    End Sub

    Private Sub ShowSupportedTypes()
        Dim commentString As String = ""
        commentString += "OCCUPANCY INSPECTION (AFAS)" & vbNewLine
        commentString += "NO CONTACT INSPECTION (AFAS)" & vbNewLine
        commentString += "OCCUPANCY VERIFICATION" & vbNewLine
        commentString += "OCCUPANCY VERIFICATION (SS)" & vbNewLine
        commentString += "OCCUPANCY VERIFICATION (CO)" & vbNewLine
        commentString += "OCCUPANCY VERIFICATION (FT)" & vbNewLine
        commentString += "NO CONTACT INSPECTION" & vbNewLine
        commentString += "NO CONTACT INSPECTION (SS)" & vbNewLine
        commentString += "NO CONTACT INSPECTION (CO)" & vbNewLine
        commentString += "NO CONTACT INSPECTION (FT)" & vbNewLine
        commentString += "EXTERIOR CALL BACK INSPECTION (WF)" & vbNewLine
        commentString += "EXTERIOR INSPECTION (WF)" & vbNewLine
        commentString += "NO CONTACT INSPECTION (WF)" & vbNewLine
        MessageBox.Show(commentString, "Supported Inspection Types")
    End Sub

    Private Sub TextBoxEscalatedEvents_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEscalatedEvents.TextChanged
        If Not CurrentSelectionComplete() Or editMode Then
            RichTextBox1.Text = GenerateComment()
            LabelCommentGenerator.Text = "New Comment Generated."
        End If
    End Sub

    Private Sub TextBoxNeighborHouseNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNeighborHouseNumber.TextChanged
        If Not CurrentSelectionComplete() Or editMode Then
            RichTextBox1.Text = GenerateComment()
            LabelCommentGenerator.Text = "New Comment Generated."
        End If
    End Sub

    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged
        My.Settings.PassWord = TextBoxPassword.Text.ToString()
    End Sub

    Private Sub TextBoxUsername_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUsername.TextChanged
        My.Settings.UserName = TextBoxUsername.Text.ToString()
    End Sub

    Private Sub ToolStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStrip1.MouseDown
        mouse_move = New Point(-e.X, -e.Y)
    End Sub

    Private Sub ToolStrip1_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStrip1.MouseMove
        If (e.Button = MouseButtons.Left) Then
            Dim mposition As Point
            mposition = MousePosition
            mposition.Offset(mouse_move.X, mouse_move.Y)
            Me.Location = mposition
        End If
    End Sub

    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to close Form Fucker and delete all unsaved records?",
                                               "Exit Form Fucker", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Exit Sub
        ElseIf result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        SuspendLayout()
        WindowState = FormWindowState.Maximized
        Application.DoEvents()
        ResumeLayout()
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ButtonRevertCompletion.Click
        If CurrentSelectionComplete() Or CurrentRecordExists() Then

            Dim result As Integer = MessageBox.Show("Delete record for PID " & " " & DataGridExcel.SelectedRows(0).Cells(1).Value.ToString() & "?",
                                                "Preset Manager", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                ResetMainControlColors()
                ClearControlSelections()
                DeleteRecord()
                DeleteRecord()
                ColorCompletionStatus()
                UpdateDB()
                MarkAsIncomplete()
                ToolStripMenuItemEditCompletion.Enabled = False
                EnableOrDisableControlsCurrent()
                CheckBoxMarkNoAccess.Checked = False
                CheckBoxMarkNoAccess.Enabled = True
                ComboBoxNoAccess.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SelectDir()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ButtonMarkComplete.Click
        ResetMainControlColors()
        If CheckBoxMarkNoAccess.Checked Then
            InsertRecordNoAccess()
        Else
            InsertRecord()
        End If

        If VerifyCombos() And CheckComboLogic() Then
            MarkAsComplete()
            UpdateDB()
            ToolStripMenuItemEditCompletion.Enabled = True
        End If
    End Sub

    Private Sub UpdateDB()
        Me.Validate()
        Me.BindingSource1.EndEdit()
        Me.FF_DBDataSet1.AcceptChanges()
        TableAdapterManager1.UpdateAll(FF_DBDataSet1)
        ServiceOrdersTableAdapter1.Fill(FF_DBDataSet1.ServiceOrders)
    End Sub

    Private Sub UpdateListBoxFiles()
        Dim fileTypes() As String = {"*.gif*", "*.jpg*", "*.bmp*", "*.png*", "*.JPG*"}

        For Each image As String In My.Computer.FileSystem.GetFiles(sourceDir, FileIO.SearchOption.SearchTopLevelOnly, fileTypes)
            Dim img As String = Path.GetFileName(image)
            ListBoxFiles.Items.Add(img)
            index += 1
        Next
    End Sub

    Private Sub UpdatePresetsDB()
        Me.Validate()
        Me.FF_PresetsDataSet1.AcceptChanges()
        StandardInspectionsTableAdapter1.Fill(FF_PresetsDataSet1.StandardInspections)
    End Sub
    Private Sub Upload_AFAS()
        Dim theDate As Date
        theDate = dateSelector.Value.Date

        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        Dim ServiceId As String = TextBoxServiceID.Text.ToString
        Dim OccupantType As String = ""
        Dim ConstructionType As String = ""
        Dim PropertyCondition As String = ""
        Dim DeterminedBy As String = ""
        Dim PropertyType As String = ""
        Dim PropertyForSale As String = ""
        Dim GarageType As String = ""
        Dim Comment As String = RichTextBox1.Text.ToString
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim SpokeWith As String = ""

        If CheckBoxMarkNoAccess.Checked = False Then
            OccupantType = ComboOccupantType.SelectedItem.ToString()
            ConstructionType = ComboConstructionType.SelectedItem.ToString()
            PropertyCondition = ComboPropertyCondition.SelectedItem.ToString
            DeterminedBy = ComboDeterminedBy.SelectedItem.ToString
            PropertyType = ComboPropertyType.SelectedItem.ToString()
            PropertyForSale = ComboPropertyForSale.SelectedItem.ToString
            GarageType = ComboGarageType.SelectedItem.ToString()

            If Not ComboSpokeWith.SelectedIndex = -1 Then
                SpokeWith = ComboSpokeWith.SelectedItem.ToString()
            End If

            If TextBoxBrokerName.Text IsNot Nothing Then
                BrokerName = TextBoxBrokerName.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerNumber = TextBoxBrokerNumber.Text.ToString
                BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
            End If

            If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
                NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
            End If
        End If
        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailDynamicFormEdit_datePerformedInput").SetAttribute("value", stringDate)

        If CheckBoxMarkNoAccess.Checked Then
            fillValueAFAS("No", 0)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("No", 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValuesAFAS(ComboBoxNoAccess.SelectedItem.ToString, 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Stable", 7)
            fillValueAFAS("At", 8)
        Else
            fillValueAFAS("No", 0)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Yes", 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Stable", 7)
            fillValueAFAS("At", 8)
            fillValueAFAS(PropertyType, 9)
            fillValueAFAS(ConstructionType, 15)
            fillValueAFAS(PropertyForSale, 17)

            If PropertyForSale = "For Sale by Broker" Then
                clickSubmitWF()
                WaitForPageLoad()
                fillValueAFAS(BrokerName, 18)
                fillValueAFAS(BrokerNumber, 19)
            End If

            fillValueAFAS(OccupantType, 20)
            clickSubmitWF()
            WaitForPageLoad()
            fillValuesAFAS(DeterminedBy, 21)
            clickSubmitWF()
            WaitForPageLoad()

            If DeterminedBy = "Neighbor" Then
                fillValuesAFAS("Neighbor", 24)
            ElseIf DeterminedBy = "Visual Observation" Then
                SelectOccupancyIndicatorsWebFormAFAS()
            ElseIf DeterminedBy = "Direct Contact" Then
                fillValuesAFAS(SpokeWith, 24)
                clickSubmitWF()
                WaitForPageLoad()
                fillValueAFAS("Not provided.", 25)
                fillValueAFAS("(000) 000-0000", 26)
                fillValueAFAS("Other No.", 27)
                fillValueAFAS("Indifferent", 28)
            End If

            fillValueAFAS("No", 33)
            fillValueAFAS("0", 39)
            fillValueAFAS("0", 40)
            fillValueAFAS("0", 41)
            fillValueAFAS("0", 42)
            fillValueAFAS("0", 43)
            fillValueAFAS("No", 44)
            fillValueAFAS("No", 45)
            fillValueAFAS("No", 48)
            fillValueAFAS("No", 49)
            fillValueAFAS("Unknown", 50)
            fillValueAFAS("No", 53)
            fillValueAFAS(GarageType, 55)
            fillValueAFAS("No", 56)
            fillValueAFAS("No", 57)
            fillValueAFAS("No", 58)
            fillValuesAFAS("N/A", 59)
            fillValueAFAS("No", 64)
            fillValueAFAS("No", 66)
            fillValueAFAS("No", 67)
            fillValueAFAS("No", 68)
            fillValueAFAS("No", 69)
            fillValueAFAS("No", 70)

            If GarageType = "Detached" Then
                fillValueAFAS("Yes", 71)
                clickSubmitWF()
                WaitForPageLoad()
                fillValuesAFAS("N/A", 72)
                fillValuesAFAS("N/A", 73)
                fillValuesAFAS("N/A", 74)
                fillValuesAFAS("N/A", 75)
                fillValuesAFAS("N/A", 76)
                fillValuesAFAS("N/A", 77)
                fillValuesAFAS("N/A", 78)
            Else
                fillValueAFAS("No", 71)
            End If
            fillValueAFAS("No", 80)
            fillValueAFAS("No", 82)
            fillValuesAFAS("None", 85)
            fillValueAFAS("No", 89)
            fillValuesAFAS("Unknown", 97)
            fillValueAFAS("Unknown", 98)
            fillValueAFAS("Unknown", 99)
            fillValueAFAS("Unknown", 100)

            If PropertyCondition = "Good" Then
                fillValueAFAS("C1 - great condition no work needs to be done to the property - newer construction", 101)
                fillValueAFAS("Exterior of property is in good condition.", 102)
            Else
                fillValueAFAS("C2 - very minor work needed to bring property up to good condition - mechanicals intact", 101)
                fillValueAFAS("Exterior of property is in fair condition.", 102)
            End If
        End If
        fillComments(Comment)

        clickSubmitWF()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickCompleteWF()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_AFAS_NC()
        Dim theDate As Date
        theDate = dateSelector.Value.Date
        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        Dim ServiceId As String = TextBoxServiceID.Text.ToString
        Dim Comment As String = RichTextBox1.Text.ToString
        Dim OccupantType As String = ""
        Dim ConstructionType As String = ""
        Dim PropertyCondition As String = ""
        Dim DeterminedBy As String = ""
        Dim PropertyType As String = ""
        Dim PropertyForSale As String = ""
        Dim GarageType As String = ""
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim SpokeWith As String = ""

        If CheckBoxMarkNoAccess.Checked = False Then
            OccupantType = ComboOccupantType.SelectedItem.ToString()
            ConstructionType = ComboConstructionType.SelectedItem.ToString()
            PropertyCondition = ComboPropertyCondition.SelectedItem.ToString
            DeterminedBy = ComboDeterminedBy.SelectedItem.ToString
            PropertyType = ComboPropertyType.SelectedItem.ToString()
            PropertyForSale = ComboPropertyForSale.SelectedItem.ToString
            GarageType = ComboGarageType.SelectedItem.ToString()

            If Not ComboSpokeWith.SelectedIndex = -1 Then
                SpokeWith = ComboSpokeWith.SelectedItem.ToString()
            End If

            If TextBoxBrokerName.Text IsNot Nothing Then
                BrokerName = TextBoxBrokerName.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerNumber = TextBoxBrokerNumber.Text.ToString
                BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
            End If

            If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
                NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
            End If

        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailDynamicFormEdit_datePerformedInput").SetAttribute("value", stringDate)

        If CheckBoxMarkNoAccess.Checked Then
            fillValueAFAS("No", 0)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("No", 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValuesAFAS(ComboBoxNoAccess.SelectedItem.ToString, 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Stable", 7)
            fillValueAFAS("At", 8)
        Else

            fillValueAFAS("No", 0)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Yes", 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueAFAS("Stable", 7)
            fillValueAFAS("At", 8)
            fillValueAFAS(PropertyType, 9)
            fillValueAFAS(ConstructionType, 15)
            fillValueAFAS(PropertyForSale, 17)

            If PropertyForSale = "For Sale by Broker" Then
                clickSubmitWF()
                WaitForPageLoad()
                fillValueAFAS(BrokerName, 18)
                fillValueAFAS(BrokerNumber, 19)
            End If

            fillValueAFAS("No", 20)
            fillValueAFAS("Occupied by Unknown Occupant", 21)
            clickSubmitWF()
            WaitForPageLoad()
            SelectOccupancyIndicatorsWebFormAFASNC()
            fillValueAFAS("No", 28)
            fillValueAFAS("0", 34)
            fillValueAFAS("0", 35)
            fillValueAFAS("0", 36)
            fillValueAFAS("0", 37)
            fillValueAFAS("0", 38)
            fillValueAFAS("No", 39)
            fillValueAFAS("No", 40)
            fillValueAFAS("No", 43)
            fillValueAFAS("No", 44)
            fillValueAFAS("No", 45)
            fillValueAFAS("No", 48)
            fillValueAFAS(GarageType, 50)
            fillValueAFAS("No", 51)
            fillValueAFAS("No", 52)
            fillValueAFAS("No", 53)
            fillValuesAFAS("N/A", 54)
            fillValueAFAS("No", 59)
            fillValueAFAS("No", 61)
            fillValueAFAS("No", 62)
            fillValueAFAS("No", 63)
            fillValueAFAS("No", 64)
            fillValueAFAS("No", 65)

            If GarageType = "Detached" Then
                fillValueAFAS("Yes", 66)
                clickSubmitWF()
                WaitForPageLoad()
                fillValuesAFAS("N/A", 67)
                fillValuesAFAS("N/A", 68)
                fillValuesAFAS("N/A", 69)
                fillValuesAFAS("N/A", 70)
                fillValuesAFAS("N/A", 71)
                fillValuesAFAS("N/A", 72)
                fillValuesAFAS("N/A", 73)
            Else
                fillValueAFAS("No", 66)
            End If
            fillValueAFAS("No", 75)
            fillValueAFAS("No", 77)
            fillValuesAFAS("None", 80)
            fillValueAFAS("No", 83)
            fillValuesAFAS("Unknown", 91)
            fillValueAFAS("Unknown", 92)
            fillValueAFAS("Unknown", 93)
            fillValueAFAS("Unknown", 94)

            If PropertyCondition = "Good" Then
                fillValueAFAS("C1 - great condition no work needs to be done to the property - newer construction", 95)
                fillValueAFAS("Exterior of property is in good condition.", 96)
            Else
                fillValueAFAS("C2 - very minor work needed to bring property up to good condition - mechanicals intact", 95)
                fillValueAFAS("Exterior of property is in fair condition.", 96)
            End If
        End If
        fillComments(Comment)

        clickSubmitWF()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickCompleteWF()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_ALL()

        Dim max As Decimal = binder.Count
        Dim current As Integer = binder.Position
        Dim completed As Decimal = Convert.ToInt32(completedExcelRecords)
        Dim successful As Integer = Convert.ToInt32(completedExcelRecords)
        Dim message As String
        Dim recordStatus As String = ""

        If completed / max = 1 Then
            message = "Once the Auto-Uploader begins, no further changes can be made.  Continue?"
        Else
            message = "Not all records are marked as complete.  Once the Auto-Uploader begins, no further changes can be made.  Continue and upload only the completed records?"
        End If

        Dim result As Integer = MessageBox.Show(message, "Auto-Uploader", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Exit Sub
        ElseIf result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            DisableControls()
            ListBoxStandardInspectionPresets.Enabled = False
            BindingNavigatorStandardInspectionPresets.Enabled = False
            NotUploading = False
            DataGridExcel.Enabled = False

            TabControl1.TabPages(1).Enabled = False
            TabControl1.TabPages(2).Enabled = False
            ToolStripProgressBar1.Visible = False

            LabelUploader.Visible = True
            ProgressBarUploader.Visible = True
            ProgressBarUploader.Minimum = 0
            ProgressBarUploader.Maximum = completed
            ProgressBarUploader.Value = 0
            ProgressBarUploader.Step = 1

            Try
                BindingNavigatorExcelSheet.BindingSource.MoveFirst()
                WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/login")
                WaitForPageLoad()
                WebBrowser1.Document.All.GetElementsByName("j_username")(0).SetAttribute("value", TextBoxUsername.Text.ToString())
                WebBrowser1.Document.All.GetElementsByName("j_password")(0).SetAttribute("value", TextBoxPassword.Text.ToString())
                WebBrowser1.Document.GetElementById("loginForm").InvokeMember("submit")
                WaitForPageLoad()

            Catch ex As Exception
                MsgBox("Login Error.  Please verify your credentials and try again.")
                Exit Sub
            End Try

            While current <= max
                Try
                    recordStatus = DataGridExcel.CurrentRow.Cells(4).Value.ToString
                    If CurrentSelectionComplete() Then

                        If LabelInspectionType.Text = "EXTERIOR CALL BACK INSPECTION (WF)" Or LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Then
                            Upload_Exterior_WF()
                        ElseIf LabelInspectionType.Text = "OCCUPANCY VERIFICATION" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION (CO)" Or LabelInspectionType.Text = "OCCUPANCY VERIFICATION (FT)" Then
                            Upload_OV()
                        ElseIf LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)" Then
                            Upload_AFAS()
                        ElseIf LabelInspectionType.Text = "NO CONTACT INSPECTION (AFAS)" Then
                            Upload_AFAS_NC()
                        ElseIf LabelInspectionType.Text = "NO CONTACT INSPECTION (WF)" Then
                            Upload_NoContact_WF()
                        ElseIf LabelInspectionType.Text = "NO CONTACT INSPECTION (SS)" Then
                            Upload_NoContact_SS()
                        ElseIf LabelInspectionType.Text = "NO CONTACT INSPECTION" Or LabelInspectionType.Text = "NO CONTACT INSPECTION (CO)" Then
                            Upload_NoContact()
                        ElseIf LabelInspectionType.Text = "OCCUPANCY VERIFICATION (SS)" Then
                            Upload_OV_SS()
                        End If

                        ProgressBarUploader.PerformStep()
                        DataGridExcel.CurrentRow.Cells(4).Value = "Uploaded"
                        DataGridExcel.CurrentRow.Cells(4).Style.BackColor = Color.DodgerBlue
                        DataGridExcel.CurrentRow.Cells(4).Style.ForeColor = Color.Black
                    Else
                        DataGridExcel.CurrentRow.Cells(4).Value = "Skipped"
                        DataGridExcel.CurrentRow.Cells(4).Style.BackColor = Color.White
                        DataGridExcel.CurrentRow.Cells(4).Style.ForeColor = Color.Black

                    End If

                Catch ex As Exception
                    ''MsgBox("SID " & DataGridExcel.SelectedRows(0).Cells(0).Value.ToString() & " failed to upload.  This order may have been uploaded, or is linked to the wrong inspection type.")
                    successful -= 1
                    DataGridExcel.CurrentRow.Cells(4).Value = "Failed"
                    DataGridExcel.CurrentRow.Cells(4).Style.BackColor = Color.OrangeRed
                    DataGridExcel.CurrentRow.Cells(4).Style.ForeColor = Color.Black
                End Try

                If current = max Then
                    Exit While
                End If

                BindingNavigatorExcelSheet.BindingSource.MoveNext()
                current = Convert.ToInt32(BindingNavigatorPositionItem1.Text)
            End While
            ProgressBarUploader.PerformStep()
            MsgBox(successful.ToString() & " services orders uploaded successfully.  " & (Convert.ToInt32(completed) - successful).ToString & " failed.")
            LabelUploader.Visible = False
            ProgressBarUploader.Visible = False

            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = True
            TabControl1.TabPages(2).Enabled = True
            ToolStripProgressBar1.Visible = True

            NotUploading = True
            DataGridExcel.Enabled = True
            ListBoxStandardInspectionPresets.Enabled = True
            BindingNavigatorStandardInspectionPresets.Enabled = True
            EnableOrDisableControlsCurrent()
            NotUploading = True
        End If
    End Sub

    Private Sub Upload_Exterior_WF()

        Dim comment As String = RichTextBox1.Text.ToString
        Dim ServiceId As String = TextBoxServiceID.Text.ToString()
        Dim ConstructionType As String = ""
        Dim OccupantType As String = ""
        Dim PropertyCondition As String = ""
        Dim DeterminedBy As String = ""
        Dim PropertyType As String = ""
        Dim PropertyForSale As String = ""
        Dim LocationType As String = ""
        Dim NeighborhoodStatus As String = ""
        Dim NeighborhoodIssues As String = ""
        Dim RoofType As String = ""
        Dim RoofDamages As String = ""
        Dim LandscapeType As String = ""
        Dim LandscapeCondition As String = ""
        Dim GrassHeight As String = ""
        Dim SecurityIssues As String = ""
        Dim PropertyHabitable As String = ""
        Dim EscalatedEventsText As String = ""
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim PropertyUnsecure As String = ""
        Dim GatedCommunity As String = ""
        Dim HighVandalismArea As String = ""
        Dim EscalatedEvents As String = ""

        If CheckBoxMarkNoAccess.Checked = False Then

            ConstructionType = ComboConstructionType.SelectedItem.ToString()
            OccupantType = ComboOccupantType.SelectedItem.ToString
            PropertyCondition = ComboPropertyCondition.SelectedItem.ToString
            DeterminedBy = ComboDeterminedBy.SelectedItem.ToString
            PropertyType = ComboPropertyType.SelectedItem.ToString()
            PropertyForSale = ComboPropertyForSale.SelectedItem.ToString
            LocationType = ComboLocationType.SelectedItem.ToString
            NeighborhoodStatus = ComboNeighborhoodStatus.SelectedItem.ToString
            NeighborhoodIssues = ComboNeighborhoodIssues.SelectedItem.ToString
            RoofType = ComboRoofType.SelectedItem.ToString
            RoofDamages = ComboRoofDamages.SelectedItem.ToString
            LandscapeType = ComboLandscapeType.SelectedItem.ToString
            LandscapeCondition = ComboLandscapeCondition.SelectedItem.ToString()
            GrassHeight = ComboGrassHeight.SelectedItem.ToString
            SecurityIssues = ComboSecurityIssues.SelectedItem.ToString()
            PropertyHabitable = ComboPropertyHabitable.SelectedItem.ToString

            If TextBoxEscalatedEvents.Text IsNot Nothing Then
                EscalatedEventsText = TextBoxEscalatedEvents.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerName = TextBoxBrokerName.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerNumber = TextBoxBrokerNumber.Text.ToString
                BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
            End If

            If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
                NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
            End If

            If CheckPropertyUnsecure.Checked Then
                PropertyUnsecure = "Yes"
            Else
                PropertyUnsecure = "No"
            End If

            If CheckGatedCommunity.Checked Then
                GatedCommunity = "Yes"
            Else
                GatedCommunity = "No"
            End If

            If CheckHighVandalismArea.Checked Then
                HighVandalismArea = "Yes"
            Else
                HighVandalismArea = "No"
            End If

            If CheckEscalatedEvents.Checked Then
                EscalatedEvents = "Yes"
            Else
                EscalatedEvents = "No"
            End If

        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()

        If CheckBoxMarkNoAccess.Checked Then
            fillDateWF()
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("Suburban", 8)
            fillValueWF("No", 9)
            fillValueWF("Stable", 10)
            fillValuesWF("None", 44)
            fillValueWF("Yes", 4)
            fillComments(comment)

            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("No", 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(ComboBoxNoAccess.SelectedItem.ToString(), 6)
            clickSubmitWF()
            WaitForPageLoad()
        Else
            fillDateWF()
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(GatedCommunity, 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("Yes", 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(LocationType, 8)
            fillValueWF(HighVandalismArea, 9)
            fillValueWF(NeighborhoodStatus, 10)
            fillValueWF(PropertyType, 11)
            fillValueWF(RoofType, 13)
            fillValuesWF(RoofDamages, 15)
            fillValueWF(PropertyUnsecure, 16)
            fillValueWF("No", 18)
            fillValuesWF("None", 33)
            fillValueWF(PropertyCondition, 36)
            fillValueWF("No", 39)
            fillValueWF("None", 40)
            fillValueWF("None", 41)
            fillValuesWF("None", 42)
            fillValuesWF(NeighborhoodIssues, 44)
            fillValueWF(ConstructionType, 45)
            fillValueWF(PropertyForSale, 47)

            If PropertyForSale = "Broker" Then
                clickSubmitWF()
                WaitForPageLoad()
                fillValueWF(BrokerName, 48)
                fillValueWF(BrokerNumber, 49)
            End If

            fillValuesWF("None", 50)
            fillValueWF("No", 69)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(OccupantType, 70)
            clickSubmitWF()
            WaitForPageLoad()

            fillValueWF(LandscapeType, 126)
            fillValueWF(GrassHeight, 128)
            fillValueWF(LandscapeCondition, 129)
            fillValuesWF(SecurityIssues, 130)
            fillValueWF(PropertyHabitable, 136)

            fillValueWF(EscalatedEvents, 137)

            If EscalatedEvents = "Yes" Then
                clickSubmitWF()
                WaitForPageLoad()
                fillValueWF(EscalatedEventsText, 138)
            End If
            If LabelInspectionType.Text.ToString() = "EXTERIOR CALL BACK INSPECTION (WF)" Then
                fillValueWF("Yes", 139)
            End If
            fillComments(comment)

            fillValuesWF(DeterminedBy, 72)
            clickSubmitWF()
            WaitForPageLoad()

            If DeterminedBy = "Visual Observation" And LabelInspectionType.Text.ToString() = "EXTERIOR INSPECTION (WF)" Then
                SelectOccupancyIndicatorsWebFormWF()
                clickSubmitWF()
                WaitForPageLoad()
            End If



        End If


        If CheckTestMode.Checked = False Then
            clickCompleteWF()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_NoContact()
        Dim theDate As Date
        theDate = dateSelector.Value.Date

        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")

        Dim ConstructionType As String = ComboConstructionType.SelectedItem.ToString()
        Dim PropertyCondition As String = ComboPropertyCondition.SelectedItem.ToString
        Dim PropertyType As String = ComboPropertyType.SelectedItem.ToString()
        Dim PropertyForSale As String = ComboPropertyType.SelectedItem.ToString
        Dim Comment As String = RichTextBox1.Text.ToString
        Dim ServiceId As String = TextBoxServiceID.Text.ToString
        Dim GarageType As String = ComboGarageType.SelectedItem.ToString()
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""

        If TextBoxBrokerName.Text IsNot Nothing Then
            BrokerName = TextBoxBrokerName.Text.ToString
        End If

        If TextBoxBrokerNumber.Text IsNot Nothing Then
            BrokerNumber = TextBoxBrokerNumber.Text.ToString
            BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_datePerformedInput").SetAttribute("value", stringDate)

        clickNextStandard()
        WaitForPageLoad()

        If CheckBoxMarkNoAccess.Checked Then
            fillValueStandard("No", 4)
            clickNextStandard()
            WaitForPageLoad()
            fillValueStandard(ComboBoxNoAccess.SelectedItem.ToString, 5)
        Else
            clickNextStandard()
            WaitForPageLoad()
            fillValueStandard("Stable", 6)
            fillValueStandard(PropertyType, 7)
            fillValuesStandard("None", 13)
            fillValueStandard(ConstructionType, 16)
            fillValueStandard(GarageType, 18)
            fillValueStandard(PropertyCondition, 19)
            fillValueStandard(PropertyForSale, 20)
            fillValueStandard("No", 23)
            fillValueStandard("No", 24)
            fillValueStandard("Occupied", 25)
            clickNextStandard()
            WaitForPageLoad()

            If PropertyForSale = "For Sale by Broker" Then
                fillValueStandard(BrokerName, 21)
                fillValueStandard(BrokerNumber, 22)
            End If

            SelectOccupancyIndicatorsWebForm()

            clickNextStandard()
            WaitForPageLoad()
        End If
        fillComments(Comment)
        clickSubmitStandard()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickSaveStandard()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_NoContact_SS()
        Dim theDate As Date
        theDate = dateSelector.Value.Date

        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        Dim ConstructionType As String = ComboConstructionType.SelectedItem.ToString()
        Dim PropertyCondition As String = ComboPropertyCondition.SelectedItem.ToString
        Dim GarageType As String = ComboGarageType.SelectedItem.ToString
        Dim PropertyType As String = ComboPropertyType.SelectedItem.ToString()
        Dim PropertyForSale As String = ComboPropertyType.SelectedItem.ToString
        Dim Comment As String = RichTextBox1.Text.ToString
        Dim ServiceId As String = TextBoxServiceID.Text.ToString
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""

        If TextBoxBrokerName.Text IsNot Nothing Then
            BrokerName = TextBoxBrokerName.Text.ToString
        End If

        If TextBoxBrokerNumber.Text IsNot Nothing Then
            BrokerNumber = TextBoxBrokerNumber.Text.ToString
            BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_datePerformedInput").SetAttribute("value", stringDate)

        If CheckBoxMarkNoAccess.Checked Then
            fillValueStandard("No", 4)
            clickNextStandard()
            WaitForPageLoad()
            fillValueStandard(ComboBoxNoAccess.SelectedItem.ToString, 5)
        Else
            clickNextStandard()
            WaitForPageLoad()
            clickNextStandard()
            WaitForPageLoad()
            fillValueStandard("Stable", 6)
            fillValueStandard(PropertyType, 7)
            fillValuesStandard("None", 13)
            fillValueStandard(ConstructionType, 17)
            fillValueStandard(GarageType, 19)
            fillValueStandard(PropertyCondition, 20)
            fillValueStandard(PropertyForSale, 21)
            fillValueStandard("No", 24)
            fillValueStandard("No", 25)
            fillValueStandard("Occupied", 26)
            clickNextStandard()
            WaitForPageLoad()

            If PropertyForSale = "For Sale by Broker" Then
                fillValueStandard(BrokerName, 22)
                fillValueStandard(BrokerNumber, 23)
            End If

            SelectOccupancyIndicatorsWebFormSS()

            clickNextStandard()
            WaitForPageLoad()
        End If
        fillComments(Comment)
        clickSubmitStandard()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickSaveStandard()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_NoContact_WF()
        Dim ServiceId As String = TextBoxServiceID.Text.ToString()
        Dim comment As String = RichTextBox1.Text.ToString
        Dim ConstructionType As String = ""
        Dim PropertyCondition As String = ""
        Dim PropertyType As String = ""
        Dim PropertyForSale As String = ""
        Dim LocationType As String = ""
        Dim NeighborhoodStatus As String = ""
        Dim NeighborhoodIssues As String = ""
        Dim RoofType As String = ""
        Dim RoofDamages As String = ""
        Dim LandscapeType As String = ""
        Dim LandscapeCondition As String = ""
        Dim GrassHeight As String = ""
        Dim SecurityIssues As String = ""
        Dim PropertyHabitable As String = ""
        Dim EscalatedEventsText As String = ""
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim PropertyUnsecure As String = ""
        Dim GatedCommunity As String = ""
        Dim HighVandalismArea As String = ""
        Dim EscalatedEvents As String = ""

        If CheckBoxMarkNoAccess.Checked = False Then

            ConstructionType = ComboConstructionType.SelectedItem.ToString()
            PropertyCondition = ComboPropertyCondition.SelectedItem.ToString
            PropertyType = ComboPropertyType.SelectedItem.ToString()
            PropertyForSale = ComboPropertyForSale.SelectedItem.ToString
            LocationType = ComboLocationType.SelectedItem.ToString
            NeighborhoodStatus = ComboNeighborhoodStatus.SelectedItem.ToString
            NeighborhoodIssues = ComboNeighborhoodIssues.SelectedItem.ToString
            RoofType = ComboRoofType.SelectedItem.ToString
            RoofDamages = ComboRoofDamages.SelectedItem.ToString
            LandscapeType = ComboLandscapeType.SelectedItem.ToString
            LandscapeCondition = ComboLandscapeCondition.SelectedItem.ToString()
            GrassHeight = ComboGrassHeight.SelectedItem.ToString
            SecurityIssues = ComboSecurityIssues.SelectedItem.ToString()
            PropertyHabitable = ComboPropertyHabitable.SelectedItem.ToString

            If TextBoxEscalatedEvents.Text IsNot Nothing Then
                EscalatedEventsText = TextBoxEscalatedEvents.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerName = TextBoxBrokerName.Text.ToString
            End If

            If TextBoxBrokerNumber.Text IsNot Nothing Then
                BrokerNumber = TextBoxBrokerNumber.Text.ToString
                BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
            End If

            If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
                NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
            End If

            If CheckPropertyUnsecure.Checked Then
                PropertyUnsecure = "Yes"
            Else
                PropertyUnsecure = "No"
            End If

            If CheckGatedCommunity.Checked Then
                GatedCommunity = "Yes"
            Else
                GatedCommunity = "No"
            End If

            If CheckHighVandalismArea.Checked Then
                HighVandalismArea = "Yes"
            Else
                HighVandalismArea = "No"
            End If

            If CheckEscalatedEvents.Checked Then
                EscalatedEvents = "Yes"
            Else
                EscalatedEvents = "No"
            End If
        End If
        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()

        If CheckBoxMarkNoAccess.Checked Then
            fillDateWF()
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("Suburban", 8)
            fillValueWF("No", 9)
            fillValueWF("Stable", 10)
            fillValuesWF("None", 44)
            fillComments(comment)
            fillValueWF("Yes", 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("No", 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(ComboBoxNoAccess.SelectedItem.ToString(), 6)
        Else
            fillDateWF()
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(GatedCommunity, 4)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF("Yes", 5)
            clickSubmitWF()
            WaitForPageLoad()
            fillValueWF(LocationType, 8)
            fillValueWF(HighVandalismArea, 9)
            fillValueWF(NeighborhoodStatus, 10)
            fillValueWF(PropertyType, 11)
            fillValueWF(RoofType, 13)
            fillValuesWF(RoofDamages, 15)
            fillValueWF(PropertyUnsecure, 16)
            fillValueWF("No", 18)
            fillValuesWF("None", 33)
            fillValueWF(PropertyCondition, 36)
            fillValueWF("No", 39)
            fillValueWF("None", 40)
            fillValueWF("None", 41)
            fillValuesWF("None", 42)
            fillValuesWF(NeighborhoodIssues, 44)
            fillValueWF(ConstructionType, 45)
            fillValueWF(PropertyForSale, 47)

            fillValuesWF("None", 56)
            fillValueWF(LandscapeType, 104)
            fillValueWF(GrassHeight, 106)
            fillValueWF(LandscapeCondition, 107)
            fillValuesWF(SecurityIssues, 108)
            fillValueWF(PropertyHabitable, 114)
            fillValueWF(EscalatedEvents, 115)
            fillComments(comment)

            If EscalatedEvents = "Yes" Then
                fillValueWF(EscalatedEventsText, 116)
            End If
        End If

        If PropertyForSale = "Broker" Then
                fillValueWF(BrokerName, 48)
                fillValueWF(BrokerNumber, 49)
            End If

        fillValueWF("Occupied", 50)
        clickSubmitWF()
        WaitForPageLoad()
        fillValuesWF("Visual Observation", 51)
        clickSubmitWF()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickCompleteWF()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_OV()
        Dim theDate As Date
        theDate = dateSelector.Value.Date

        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        Dim ServiceId As String = TextBoxServiceID.Text.ToString

        Dim OccupantType As String = ComboOccupantType.SelectedItem.ToString()
        Dim ConstructionType As String = ComboConstructionType.SelectedItem.ToString()
        Dim PropertyCondition As String = ComboPropertyCondition.SelectedItem.ToString
        Dim DeterminedBy As String = ComboDeterminedBy.SelectedItem.ToString
        Dim PropertyType As String = ComboPropertyType.SelectedItem.ToString()
        Dim PropertyForSale As String = ComboPropertyForSale.SelectedItem.ToString
        Dim GarageType As String = ComboGarageType.SelectedItem.ToString()
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim SpokeWith As String = ""

        Dim Comment As String = RichTextBox1.Text.ToString

        If Not ComboSpokeWith.SelectedIndex = -1 Then
            SpokeWith = ComboSpokeWith.SelectedItem.ToString()
        End If

        If TextBoxBrokerName.Text IsNot Nothing Then
            BrokerName = TextBoxBrokerName.Text.ToString
        End If

        If TextBoxBrokerNumber.Text IsNot Nothing Then
            BrokerNumber = TextBoxBrokerNumber.Text.ToString
            BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
        End If

        If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
            NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_datePerformedInput").SetAttribute("value", stringDate)

        clickNextStandard()
        WaitForPageLoad()
        clickNextStandard()
        WaitForPageLoad()
        fillValueStandard("Stable", 6)

        fillValueStandard(PropertyType, 7)
        fillValuesStandard("None", 14)
        fillValueStandard(ConstructionType, 17)
        fillValueStandard(GarageType, 19)
        fillValueStandard(PropertyCondition, 20)
        fillValueStandard(PropertyForSale, 21)
        fillValuesStandard("None", 24)
        fillValueStandard("No", 27)
        fillValueStandard(OccupantType, 28)
        clickNextStandard()
        WaitForPageLoad()

        If PropertyForSale = "For Sale by Broker" Then
            fillValueStandard(BrokerName, 22)
            fillValueStandard(BrokerNumber, 23)
        End If

        fillValuesStandard(DeterminedBy, 30)
        clickNextStandard()
        WaitForPageLoad()

        If DeterminedBy = "Neighbor" Then
            fillValueStandard("Yes", 32)
            clickNextStandard()
            WaitForPageLoad()
        ElseIf DeterminedBy = "Direct Contact" Then
            fillValueStandard(SpokeWith, 35)
            clickNextStandard()
            WaitForPageLoad()
        End If

        fillComments(Comment)
        clickSubmitStandard()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickSaveStandard()
            WaitForPageLoad()
        End If
    End Sub

    Private Sub Upload_OV_SS()
        Dim theDate As Date
        theDate = dateSelector.Value.Date

        Dim stringDate As String
        stringDate = dateSelector.Value.Date.ToString("MM'/'dd'/'yyyy")
        Dim ServiceId As String = TextBoxServiceID.Text.ToString

        Dim OccupantType As String = ComboOccupantType.SelectedItem.ToString()
        Dim ConstructionType As String = ComboConstructionType.SelectedItem.ToString()
        Dim PropertyCondition As String = ComboPropertyCondition.SelectedItem.ToString
        Dim DeterminedBy As String = ComboDeterminedBy.SelectedItem.ToString
        Dim PropertyType As String = ComboPropertyType.SelectedItem.ToString()
        Dim PropertyForSale As String = ComboPropertyForSale.SelectedItem.ToString
        Dim GarageType As String = ComboGarageType.SelectedItem.ToString()
        Dim BrokerName As String = ""
        Dim BrokerNumber As String = ""
        Dim NeighborHouseNumber As String = ""
        Dim spokeWith As String = ""

        If Not ComboSpokeWith.SelectedIndex = -1 Then
            spokeWith = ComboSpokeWith.SelectedItem.ToString()
        End If

        Dim Comment As String = RichTextBox1.Text.ToString

        If TextBoxBrokerName.Text IsNot Nothing Then
            BrokerName = TextBoxBrokerName.Text.ToString
        End If

        If TextBoxBrokerNumber.Text IsNot Nothing Then
            BrokerNumber = TextBoxBrokerNumber.Text.ToString
            BrokerNumber = FormatPhoneNumber(BrokerNumber, "")
        End If

        If TextBoxNeighborHouseNumber.Text IsNot Nothing Then
            NeighborHouseNumber = TextBoxNeighborHouseNumber.Text.ToString
        End If

        WebBrowser1.Navigate("https://prism.spectrumfsi.com/web/m/service/" + ServiceId + "/detail/flow/form")
        WaitForPageLoad()
        WebBrowser1.Document.GetElementById("MobileServiceDetailFlowFormEdit_datePerformedInput").SetAttribute("value", stringDate)
        clickNextStandard()
        WaitForPageLoad()
        clickNextStandard()
        WaitForPageLoad()
        fillValueStandard("Stable", 6)
        fillValueStandard(PropertyType, 7)
        fillValuesStandard("None", 14)
        fillValueStandard(ConstructionType, 18)
        fillValueStandard(GarageType, 20)
        fillValueStandard(PropertyCondition, 21)
        fillValueStandard(PropertyForSale, 22)
        fillValuesStandard("None", 25)
        fillValueStandard("No", 28)
        fillValueStandard(OccupantType, 29)
        clickNextStandard()
        WaitForPageLoad()

        If PropertyForSale = "For Sale by Broker" Then
            fillValueStandard(BrokerName, 23)
            fillValueStandard(BrokerNumber, 24)
        End If

        fillValuesStandard(DeterminedBy, 31)
        clickNextStandard()
        WaitForPageLoad()

        If DeterminedBy = "Neighbor" Then
            fillValueStandard("Yes", 32)
            clickNextStandard()
            WaitForPageLoad()
        ElseIf DeterminedBy = "Direct Contact" Then
            fillValueStandard(spokeWith, 36)
            clickNextStandard()
            WaitForPageLoad()
        End If

        fillComments(Comment)
        clickSubmitStandard()
        WaitForPageLoad()

        If CheckTestMode.Checked = False Then
            clickSaveStandard()
            WaitForPageLoad()
        End If
    End Sub

    Private Function VerifyCombos() As Boolean
        Dim result As Boolean = True
        For Each ctrl As Control In TabDataInput.Controls
            Dim p As FlowLayoutPanel = TryCast(ctrl, FlowLayoutPanel)
            If p IsNot Nothing Then
                For Each ctrl2 In p.Controls
                    Dim combo As ComboBox = TryCast(ctrl2, ComboBox)
                    Dim txt As TextBox = TryCast(ctrl2, TextBox)

                    If combo IsNot Nothing Then
                        If combo.Enabled = True And combo.SelectedIndex = -1 Then
                            combo.BackColor = Color.LightCoral
                            result = False
                        End If
                    ElseIf txt IsNot Nothing Then
                        If txt.Enabled = True And txt.Text.Length < 1 Then
                            txt.BackColor = Color.LightCoral
                            result = False
                        End If
                    End If
                Next
            End If
        Next

        If (CurrentIsNoContact() Or ((LabelInspectionType.Text = "EXTERIOR INSPECTION (WF)" Or LabelInspectionType.Text = "OCCUPANCY INSPECTION (AFAS)") And ComboDeterminedBy.Text = "Visual Observation")) And ListBoxOccupancyIndicators.SelectedIndex = -1 And CheckBoxMarkNoAccess.Checked = False Then
            ListBoxOccupancyIndicators.BackColor = Color.LightCoral
            result = False
        End If

        If RichTextBox1.TextLength = 0 Then
            RichTextBox1.BackColor = Color.LightCoral
            result = False
        End If

        If CheckBoxMarkNoAccess.Checked Then
            If ComboBoxNoAccess.SelectedIndex = -1 Then
                ComboBoxNoAccess.BackColor = Color.LightCoral
                result = False
            Else
                ComboBoxNoAccess.BackColor = Color.LightGray
                result = True
            End If
        End If

        Return result
    End Function
    Private Sub ViewShortcutsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewShortcutsToolStripMenuItem.Click
        ShowShortCuts()
    End Sub

    Private Sub ViewSupportedInspectionTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSupportedInspectionTypesToolStripMenuItem.Click
        ShowSupportedTypes()
    End Sub


End Class