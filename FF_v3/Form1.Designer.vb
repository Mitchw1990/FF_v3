<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Private Property pageready As Boolean = False
    Private Sub WaitForPageLoad()
        AddHandler WebBrowser1.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If WebBrowser1.ReadyState = WebBrowserReadyState.Complete Then
            pageready = True
            RemoveHandler WebBrowser1.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelNumberCompleted = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabDatabaseView = New System.Windows.Forms.TabPage()
        Me.DataGridDatabase = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NeighborHouseNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoHouseNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoAccessDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoAccessReasonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceOrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FF_DBDataSet1 = New FF_v3.FF_DBDataSet()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.MoveFirstDB = New System.Windows.Forms.ToolStripButton()
        Me.MovePreviousDB = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveNextDB = New System.Windows.Forms.ToolStripButton()
        Me.MoveLastDB = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabCurrentDataset = New System.Windows.Forms.TabPage()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LabelCurrentFile = New System.Windows.Forms.Label()
        Me.DataGridExcel = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabDataInput = New System.Windows.Forms.TabPage()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuickActions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEditCompletion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemGenerateNewComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewShortcutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewSupportedInspectionTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.CheckBoxMarkNoAccess = New System.Windows.Forms.CheckBox()
        Me.ComboBoxNoAccess = New System.Windows.Forms.ComboBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.LabelPhotos = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ListBoxFiles = New System.Windows.Forms.ListBox()
        Me.ButtonNextPhoto = New System.Windows.Forms.Button()
        Me.ButtonPreviousPhoto = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelCommentGenerator = New System.Windows.Forms.Label()
        Me.ButtonCancelEditing = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.ButtonDoneEditing = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListBoxOccupancyIndicators = New System.Windows.Forms.ListBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.LabelPresetManager = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LabelNoContactInspections = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelGarageType = New System.Windows.Forms.Label()
        Me.ComboGarageType = New System.Windows.Forms.ComboBox()
        Me.LabelSpokeWith = New System.Windows.Forms.Label()
        Me.ComboSpokeWith = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelOccupancy = New System.Windows.Forms.Label()
        Me.ComboOccupantType = New System.Windows.Forms.ComboBox()
        Me.LabelPropertyType = New System.Windows.Forms.Label()
        Me.ComboPropertyType = New System.Windows.Forms.ComboBox()
        Me.LabelConstructionType = New System.Windows.Forms.Label()
        Me.ComboConstructionType = New System.Windows.Forms.ComboBox()
        Me.LabelPropertyCondition = New System.Windows.Forms.Label()
        Me.ComboPropertyCondition = New System.Windows.Forms.ComboBox()
        Me.LabelPropertyForSale = New System.Windows.Forms.Label()
        Me.ComboPropertyForSale = New System.Windows.Forms.ComboBox()
        Me.LabelDeterminedBy = New System.Windows.Forms.Label()
        Me.ComboDeterminedBy = New System.Windows.Forms.ComboBox()
        Me.LabelBrokerName = New System.Windows.Forms.Label()
        Me.TextBoxBrokerName = New System.Windows.Forms.TextBox()
        Me.LabelBrokerNumber = New System.Windows.Forms.Label()
        Me.TextBoxBrokerNumber = New System.Windows.Forms.TextBox()
        Me.LabelNeighborHouseNumber = New System.Windows.Forms.Label()
        Me.TextBoxNeighborHouseNumber = New System.Windows.Forms.TextBox()
        Me.CheckBoxNoHouseNumber = New System.Windows.Forms.CheckBox()
        Me.BindingNavigatorExcelSheet = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem1 = New System.Windows.Forms.ToolStripLabel()
        Me.ButtonMarkComplete = New System.Windows.Forms.ToolStripButton()
        Me.MoveFirstExcel = New System.Windows.Forms.ToolStripButton()
        Me.MovePreviousExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveNextExcel = New System.Windows.Forms.ToolStripButton()
        Me.MoveLastExcel = New System.Windows.Forms.ToolStripButton()
        Me.ButtonRevertCompletion = New System.Windows.Forms.ToolStripButton()
        Me.PanelWellsFargo1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelLocationType = New System.Windows.Forms.Label()
        Me.ComboLocationType = New System.Windows.Forms.ComboBox()
        Me.LabelNeighborhoodStatus = New System.Windows.Forms.Label()
        Me.ComboNeighborhoodStatus = New System.Windows.Forms.ComboBox()
        Me.LabelNeighborhoodIssues = New System.Windows.Forms.Label()
        Me.ComboNeighborhoodIssues = New System.Windows.Forms.ComboBox()
        Me.LabelRoofType = New System.Windows.Forms.Label()
        Me.ComboRoofType = New System.Windows.Forms.ComboBox()
        Me.LabelRoofDamages = New System.Windows.Forms.Label()
        Me.ComboRoofDamages = New System.Windows.Forms.ComboBox()
        Me.LabelLandscapeType = New System.Windows.Forms.Label()
        Me.ComboLandscapeType = New System.Windows.Forms.ComboBox()
        Me.LabelLandscapeCondition = New System.Windows.Forms.Label()
        Me.ComboLandscapeCondition = New System.Windows.Forms.ComboBox()
        Me.LabelGrassHeight = New System.Windows.Forms.Label()
        Me.ComboGrassHeight = New System.Windows.Forms.ComboBox()
        Me.PanelWellsFargo2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelSecurityIssues = New System.Windows.Forms.Label()
        Me.ComboSecurityIssues = New System.Windows.Forms.ComboBox()
        Me.LabelPropertyHabitable = New System.Windows.Forms.Label()
        Me.ComboPropertyHabitable = New System.Windows.Forms.ComboBox()
        Me.CheckPropertyUnsecure = New System.Windows.Forms.CheckBox()
        Me.CheckGatedCommunity = New System.Windows.Forms.CheckBox()
        Me.CheckHighVandalismArea = New System.Windows.Forms.CheckBox()
        Me.CheckEscalatedEvents = New System.Windows.Forms.CheckBox()
        Me.TextBoxEscalatedEvents = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.LabelComment = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LabelWellsFargoInspections = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LabelGlobalDetails = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BindingNavigatorStandardInspectionPresets = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Move_PreviousStandardPresets = New System.Windows.Forms.ToolStripButton()
        Me.MoveNextStandardPresets = New System.Windows.Forms.ToolStripButton()
        Me.ButtonApplyPreset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonAddPreset = New System.Windows.Forms.ToolStripButton()
        Me.ButtonDeletePreset = New System.Windows.Forms.ToolStripButton()
        Me.ListBoxStandardInspectionPresets = New System.Windows.Forms.ListBox()
        Me.BindingSourcePresets = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.LabelStandardInspections = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelServiceID = New System.Windows.Forms.Label()
        Me.TextBoxServiceID = New System.Windows.Forms.TextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.LabelPropertyID = New System.Windows.Forms.Label()
        Me.TextBoxPropertyID = New System.Windows.Forms.TextBox()
        Me.LabelInspectionType = New System.Windows.Forms.Label()
        Me.LabelAddress = New System.Windows.Forms.Label()
        Me.ButtonImageCurrentStatus = New System.Windows.Forms.Button()
        Me.Uploader = New System.Windows.Forms.TabPage()
        Me.CheckTestMode = New System.Windows.Forms.CheckBox()
        Me.LabelUploader = New System.Windows.Forms.Label()
        Me.ProgressBarUploader = New System.Windows.Forms.ProgressBar()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dateSelector = New System.Windows.Forms.DateTimePicker()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.ServiceOrdersTableAdapter1 = New FF_v3.FF_DBDataSetTableAdapters.ServiceOrdersTableAdapter()
        Me.TableAdapterManager1 = New FF_v3.FF_DBDataSetTableAdapters.TableAdapterManager()
        Me.FF_PresetsDataSet1 = New FF_v3.FF_PresetsDataSet()
        Me.StandardInspectionsTableAdapter1 = New FF_v3.FF_PresetsDataSetTableAdapters.StandardInspectionsTableAdapter()
        Me.StatusStrip1.SuspendLayout()
        Me.TabDatabaseView.SuspendLayout()
        CType(Me.DataGridDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiceOrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FF_DBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCurrentDataset.SuspendLayout()
        CType(Me.DataGridExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabDataInput.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.BindingNavigatorExcelSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorExcelSheet.SuspendLayout()
        Me.PanelWellsFargo1.SuspendLayout()
        Me.PanelWellsFargo2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.BindingNavigatorStandardInspectionPresets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigatorStandardInspectionPresets.SuspendLayout()
        CType(Me.BindingSourcePresets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.Uploader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FF_PresetsDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gray
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelNumberCompleted, Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 842)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 18, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1395, 31)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabelNumberCompleted
        '
        Me.StatusLabelNumberCompleted.Name = "StatusLabelNumberCompleted"
        Me.StatusLabelNumberCompleted.Size = New System.Drawing.Size(0, 26)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Gray
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(175, 26)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.BackColor = System.Drawing.Color.Black
        Me.ToolStripProgressBar1.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(219, 25)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ImgChecked")
        Me.ImageList1.Images.SetKeyName(1, "ImgUnchecked")
        Me.ImageList1.Images.SetKeyName(2, "delete_database.ico")
        Me.ImageList1.Images.SetKeyName(3, "accept_database.ico")
        Me.ImageList1.Images.SetKeyName(4, "Edit Row-52.png")
        '
        'TabDatabaseView
        '
        Me.TabDatabaseView.Controls.Add(Me.DataGridDatabase)
        Me.TabDatabaseView.Controls.Add(Me.BindingNavigator1)
        Me.TabDatabaseView.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDatabaseView.Location = New System.Drawing.Point(4, 25)
        Me.TabDatabaseView.Margin = New System.Windows.Forms.Padding(4)
        Me.TabDatabaseView.Name = "TabDatabaseView"
        Me.TabDatabaseView.Padding = New System.Windows.Forms.Padding(4)
        Me.TabDatabaseView.Size = New System.Drawing.Size(1362, 751)
        Me.TabDatabaseView.TabIndex = 1
        Me.TabDatabaseView.Text = "Database View"
        Me.TabDatabaseView.UseVisualStyleBackColor = True
        '
        'DataGridDatabase
        '
        Me.DataGridDatabase.AllowUserToAddRows = False
        Me.DataGridDatabase.AllowUserToDeleteRows = False
        Me.DataGridDatabase.AllowUserToResizeRows = False
        Me.DataGridDatabase.AutoGenerateColumns = False
        Me.DataGridDatabase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDatabase.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.OccupancyIndicatorsDataGridViewTextBoxColumn, Me.NeighborHouseNumberDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn, Me.NoHouseNumberDataGridViewTextBoxColumn, Me.NoAccessDataGridViewTextBoxColumn, Me.NoAccessReasonDataGridViewTextBoxColumn})
        Me.DataGridDatabase.DataSource = Me.ServiceOrdersBindingSource
        Me.DataGridDatabase.Location = New System.Drawing.Point(0, 49)
        Me.DataGridDatabase.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridDatabase.MultiSelect = False
        Me.DataGridDatabase.Name = "DataGridDatabase"
        Me.DataGridDatabase.ReadOnly = True
        Me.DataGridDatabase.RowHeadersVisible = False
        Me.DataGridDatabase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridDatabase.ShowEditingIcon = False
        Me.DataGridDatabase.Size = New System.Drawing.Size(1362, 698)
        Me.DataGridDatabase.TabIndex = 3
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ServiceID"
        Me.DataGridViewTextBoxColumn10.HeaderText = "ServiceID"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 119
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "PropertyID"
        Me.DataGridViewTextBoxColumn11.HeaderText = "PropertyID"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 126
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "InspectionType"
        Me.DataGridViewTextBoxColumn12.HeaderText = "InspectionType"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 168
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ConstructionType"
        Me.DataGridViewTextBoxColumn13.HeaderText = "ConstructionType"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 187
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "OccupantType"
        Me.DataGridViewTextBoxColumn14.HeaderText = "OccupantType"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 164
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "GarageType"
        Me.DataGridViewTextBoxColumn15.HeaderText = "GarageType"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 144
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "PropertyCondition"
        Me.DataGridViewTextBoxColumn16.HeaderText = "PropertyCondition"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 189
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "SpokeWith"
        Me.DataGridViewTextBoxColumn17.HeaderText = "SpokeWith"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 130
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "DeterminedBy"
        Me.DataGridViewTextBoxColumn18.HeaderText = "DeterminedBy"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 158
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "PropertyType"
        Me.DataGridViewTextBoxColumn19.HeaderText = "PropertyType"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 152
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "PropertyForSale"
        Me.DataGridViewTextBoxColumn20.HeaderText = "PropertyForSale"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 175
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "BrokerName"
        Me.DataGridViewTextBoxColumn21.HeaderText = "BrokerName"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 145
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "BrokerNumber"
        Me.DataGridViewTextBoxColumn22.HeaderText = "BrokerNumber"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 163
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "LocationType"
        Me.DataGridViewTextBoxColumn23.HeaderText = "LocationType"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 153
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "NeighborhoodStatus"
        Me.DataGridViewTextBoxColumn24.HeaderText = "NeighborhoodStatus"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 212
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "NeighborhoodIssues"
        Me.DataGridViewTextBoxColumn25.HeaderText = "NeighborhoodIssues"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 215
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "RoofType"
        Me.DataGridViewTextBoxColumn26.HeaderText = "RoofType"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 121
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "RoofDamages"
        Me.DataGridViewTextBoxColumn27.HeaderText = "RoofDamages"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 158
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "LandscapeType"
        Me.DataGridViewTextBoxColumn28.HeaderText = "LandscapeType"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Width = 175
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "LandscapeCondition"
        Me.DataGridViewTextBoxColumn29.HeaderText = "LandscapeCondition"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 212
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "GrassHeight"
        Me.DataGridViewTextBoxColumn30.HeaderText = "GrassHeight"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 142
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "SecurityIssues"
        Me.DataGridViewTextBoxColumn31.HeaderText = "SecurityIssues"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Width = 159
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "PropertyHabitable"
        Me.DataGridViewTextBoxColumn32.HeaderText = "PropertyHabitable"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Width = 188
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "PropertyUnsecure"
        Me.DataGridViewTextBoxColumn33.HeaderText = "PropertyUnsecure"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 191
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "GatedCommunity"
        Me.DataGridViewTextBoxColumn34.HeaderText = "GatedCommunity"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 184
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "HighVandalismArea"
        Me.DataGridViewTextBoxColumn35.HeaderText = "HighVandalismArea"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 207
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "EscalatedEvents"
        Me.DataGridViewTextBoxColumn36.HeaderText = "EscalatedEvents"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 178
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "EscalatedEventsText"
        Me.DataGridViewTextBoxColumn37.HeaderText = "EscalatedEventsText"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        Me.DataGridViewTextBoxColumn37.Width = 215
        '
        'OccupancyIndicatorsDataGridViewTextBoxColumn
        '
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn.DataPropertyName = "OccupancyIndicators"
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn.HeaderText = "OccupancyIndicators"
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn.Name = "OccupancyIndicatorsDataGridViewTextBoxColumn"
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn.ReadOnly = True
        Me.OccupancyIndicatorsDataGridViewTextBoxColumn.Width = 216
        '
        'NeighborHouseNumberDataGridViewTextBoxColumn
        '
        Me.NeighborHouseNumberDataGridViewTextBoxColumn.DataPropertyName = "NeighborHouseNumber"
        Me.NeighborHouseNumberDataGridViewTextBoxColumn.HeaderText = "NeighborHouseNumber"
        Me.NeighborHouseNumberDataGridViewTextBoxColumn.Name = "NeighborHouseNumberDataGridViewTextBoxColumn"
        Me.NeighborHouseNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.NeighborHouseNumberDataGridViewTextBoxColumn.Width = 243
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        Me.CommentDataGridViewTextBoxColumn.ReadOnly = True
        Me.CommentDataGridViewTextBoxColumn.Width = 121
        '
        'NoHouseNumberDataGridViewTextBoxColumn
        '
        Me.NoHouseNumberDataGridViewTextBoxColumn.DataPropertyName = "NoHouseNumber"
        Me.NoHouseNumberDataGridViewTextBoxColumn.HeaderText = "NoHouseNumber"
        Me.NoHouseNumberDataGridViewTextBoxColumn.Name = "NoHouseNumberDataGridViewTextBoxColumn"
        Me.NoHouseNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.NoHouseNumberDataGridViewTextBoxColumn.Width = 189
        '
        'NoAccessDataGridViewTextBoxColumn
        '
        Me.NoAccessDataGridViewTextBoxColumn.DataPropertyName = "NoAccess"
        Me.NoAccessDataGridViewTextBoxColumn.HeaderText = "NoAccess"
        Me.NoAccessDataGridViewTextBoxColumn.Name = "NoAccessDataGridViewTextBoxColumn"
        Me.NoAccessDataGridViewTextBoxColumn.ReadOnly = True
        Me.NoAccessDataGridViewTextBoxColumn.Width = 126
        '
        'NoAccessReasonDataGridViewTextBoxColumn
        '
        Me.NoAccessReasonDataGridViewTextBoxColumn.DataPropertyName = "NoAccessReason"
        Me.NoAccessReasonDataGridViewTextBoxColumn.HeaderText = "NoAccessReason"
        Me.NoAccessReasonDataGridViewTextBoxColumn.Name = "NoAccessReasonDataGridViewTextBoxColumn"
        Me.NoAccessReasonDataGridViewTextBoxColumn.ReadOnly = True
        Me.NoAccessReasonDataGridViewTextBoxColumn.Width = 191
        '
        'ServiceOrdersBindingSource
        '
        Me.ServiceOrdersBindingSource.DataMember = "ServiceOrders"
        Me.ServiceOrdersBindingSource.DataSource = Me.FF_DBDataSet1
        '
        'FF_DBDataSet1
        '
        Me.FF_DBDataSet1.DataSetName = "FF_DBDataSet"
        Me.FF_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BindingNavigator1.AutoSize = False
        Me.BindingNavigator1.BindingSource = Me.BindingSource1
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveFirstDB, Me.MovePreviousDB, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.MoveNextDB, Me.MoveLastDB, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(123, 78)
        Me.BindingNavigator1.MoveFirstItem = Me.MoveFirstDB
        Me.BindingNavigator1.MoveLastItem = Me.MoveLastDB
        Me.BindingNavigator1.MoveNextItem = Me.MoveNextDB
        Me.BindingNavigator1.MovePreviousItem = Me.MovePreviousDB
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(1111, 38)
        Me.BindingNavigator1.TabIndex = 0
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "ServiceOrders"
        Me.BindingSource1.DataSource = Me.FF_DBDataSet1
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(45, 35)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'MoveFirstDB
        '
        Me.MoveFirstDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveFirstDB.Image = CType(resources.GetObject("MoveFirstDB.Image"), System.Drawing.Image)
        Me.MoveFirstDB.Name = "MoveFirstDB"
        Me.MoveFirstDB.RightToLeftAutoMirrorImage = True
        Me.MoveFirstDB.Size = New System.Drawing.Size(24, 35)
        Me.MoveFirstDB.Text = "Move first"
        '
        'MovePreviousDB
        '
        Me.MovePreviousDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MovePreviousDB.Image = CType(resources.GetObject("MovePreviousDB.Image"), System.Drawing.Image)
        Me.MovePreviousDB.Name = "MovePreviousDB"
        Me.MovePreviousDB.RightToLeftAutoMirrorImage = True
        Me.MovePreviousDB.Size = New System.Drawing.Size(24, 35)
        Me.MovePreviousDB.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 38)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(62, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'MoveNextDB
        '
        Me.MoveNextDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveNextDB.Image = CType(resources.GetObject("MoveNextDB.Image"), System.Drawing.Image)
        Me.MoveNextDB.Name = "MoveNextDB"
        Me.MoveNextDB.RightToLeftAutoMirrorImage = True
        Me.MoveNextDB.Size = New System.Drawing.Size(24, 35)
        Me.MoveNextDB.Text = "Move next"
        '
        'MoveLastDB
        '
        Me.MoveLastDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveLastDB.Image = CType(resources.GetObject("MoveLastDB.Image"), System.Drawing.Image)
        Me.MoveLastDB.Name = "MoveLastDB"
        Me.MoveLastDB.RightToLeftAutoMirrorImage = True
        Me.MoveLastDB.Size = New System.Drawing.Size(24, 35)
        Me.MoveLastDB.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'TabCurrentDataset
        '
        Me.TabCurrentDataset.Controls.Add(Me.ProgressBar1)
        Me.TabCurrentDataset.Controls.Add(Me.LabelCurrentFile)
        Me.TabCurrentDataset.Controls.Add(Me.DataGridExcel)
        Me.TabCurrentDataset.Location = New System.Drawing.Point(4, 25)
        Me.TabCurrentDataset.Margin = New System.Windows.Forms.Padding(4)
        Me.TabCurrentDataset.Name = "TabCurrentDataset"
        Me.TabCurrentDataset.Size = New System.Drawing.Size(1362, 751)
        Me.TabCurrentDataset.TabIndex = 2
        Me.TabCurrentDataset.Text = "Current Dataset"
        Me.TabCurrentDataset.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(544, 322)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(318, 44)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 6
        '
        'LabelCurrentFile
        '
        Me.LabelCurrentFile.AutoSize = True
        Me.LabelCurrentFile.Location = New System.Drawing.Point(972, 806)
        Me.LabelCurrentFile.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCurrentFile.Name = "LabelCurrentFile"
        Me.LabelCurrentFile.Size = New System.Drawing.Size(152, 17)
        Me.LabelCurrentFile.TabIndex = 4
        Me.LabelCurrentFile.Text = "Import file to view data."
        '
        'DataGridExcel
        '
        Me.DataGridExcel.AllowUserToAddRows = False
        Me.DataGridExcel.AllowUserToDeleteRows = False
        Me.DataGridExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridExcel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DataGridExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridExcel.CausesValidation = False
        Me.DataGridExcel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridExcel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.WindowFrame
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridExcel.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridExcel.Location = New System.Drawing.Point(1, 1)
        Me.DataGridExcel.Margin = New System.Windows.Forms.Padding(1)
        Me.DataGridExcel.MultiSelect = False
        Me.DataGridExcel.Name = "DataGridExcel"
        Me.DataGridExcel.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridExcel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridExcel.RowHeadersVisible = False
        Me.DataGridExcel.RowHeadersWidth = 10
        Me.DataGridExcel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridExcel.RowTemplate.Height = 28
        Me.DataGridExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridExcel.Size = New System.Drawing.Size(1362, 747)
        Me.DataGridExcel.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDataInput)
        Me.TabControl1.Controls.Add(Me.TabCurrentDataset)
        Me.TabControl1.Controls.Add(Me.TabDatabaseView)
        Me.TabControl1.Controls.Add(Me.Uploader)
        Me.TabControl1.Location = New System.Drawing.Point(12, 50)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1370, 780)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 0
        '
        'TabDataInput
        '
        Me.TabDataInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabDataInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabDataInput.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TabDataInput.Controls.Add(Me.Panel15)
        Me.TabDataInput.Controls.Add(Me.Panel13)
        Me.TabDataInput.Controls.Add(Me.Panel5)
        Me.TabDataInput.Controls.Add(Me.Panel12)
        Me.TabDataInput.Controls.Add(Me.LabelCommentGenerator)
        Me.TabDataInput.Controls.Add(Me.ButtonCancelEditing)
        Me.TabDataInput.Controls.Add(Me.ButtonDoneEditing)
        Me.TabDataInput.Controls.Add(Me.Panel1)
        Me.TabDataInput.Controls.Add(Me.RichTextBox1)
        Me.TabDataInput.Controls.Add(Me.Panel11)
        Me.TabDataInput.Controls.Add(Me.Panel10)
        Me.TabDataInput.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabDataInput.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabDataInput.Controls.Add(Me.BindingNavigatorExcelSheet)
        Me.TabDataInput.Controls.Add(Me.PanelWellsFargo1)
        Me.TabDataInput.Controls.Add(Me.PanelWellsFargo2)
        Me.TabDataInput.Controls.Add(Me.Panel9)
        Me.TabDataInput.Controls.Add(Me.Panel7)
        Me.TabDataInput.Controls.Add(Me.Panel6)
        Me.TabDataInput.Controls.Add(Me.Panel3)
        Me.TabDataInput.Controls.Add(Me.Panel8)
        Me.TabDataInput.Controls.Add(Me.Panel2)
        Me.TabDataInput.Controls.Add(Me.FlowLayoutPanel4)
        Me.TabDataInput.Location = New System.Drawing.Point(4, 25)
        Me.TabDataInput.Margin = New System.Windows.Forms.Padding(1)
        Me.TabDataInput.Name = "TabDataInput"
        Me.TabDataInput.Padding = New System.Windows.Forms.Padding(4)
        Me.TabDataInput.Size = New System.Drawing.Size(1362, 751)
        Me.TabDataInput.TabIndex = 0
        Me.TabDataInput.Text = "Data Input"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuickActions})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(190, 32)
        '
        'QuickActions
        '
        Me.QuickActions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEditCompletion, Me.ToolStripMenuItemGenerateNewComment, Me.ViewShortcutsToolStripMenuItem, Me.ViewSupportedInspectionTypesToolStripMenuItem})
        Me.QuickActions.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuickActions.Name = "QuickActions"
        Me.QuickActions.Size = New System.Drawing.Size(189, 28)
        Me.QuickActions.Text = "Quick Actions"
        '
        'ToolStripMenuItemEditCompletion
        '
        Me.ToolStripMenuItemEditCompletion.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItemEditCompletion.Name = "ToolStripMenuItemEditCompletion"
        Me.ToolStripMenuItemEditCompletion.ShortcutKeyDisplayString = "Ctr+E"
        Me.ToolStripMenuItemEditCompletion.Size = New System.Drawing.Size(338, 28)
        Me.ToolStripMenuItemEditCompletion.Text = "Edit Completion"
        '
        'ToolStripMenuItemGenerateNewComment
        '
        Me.ToolStripMenuItemGenerateNewComment.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItemGenerateNewComment.Name = "ToolStripMenuItemGenerateNewComment"
        Me.ToolStripMenuItemGenerateNewComment.ShortcutKeyDisplayString = "Ctr+G"
        Me.ToolStripMenuItemGenerateNewComment.Size = New System.Drawing.Size(338, 28)
        Me.ToolStripMenuItemGenerateNewComment.Text = "Generate new comment"
        '
        'ViewShortcutsToolStripMenuItem
        '
        Me.ViewShortcutsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewShortcutsToolStripMenuItem.Name = "ViewShortcutsToolStripMenuItem"
        Me.ViewShortcutsToolStripMenuItem.Size = New System.Drawing.Size(338, 28)
        Me.ViewShortcutsToolStripMenuItem.Text = "View Shortcuts"
        '
        'ViewSupportedInspectionTypesToolStripMenuItem
        '
        Me.ViewSupportedInspectionTypesToolStripMenuItem.Name = "ViewSupportedInspectionTypesToolStripMenuItem"
        Me.ViewSupportedInspectionTypesToolStripMenuItem.Size = New System.Drawing.Size(338, 28)
        Me.ViewSupportedInspectionTypesToolStripMenuItem.Text = "View Supported Inspection Types"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel15.Controls.Add(Me.CheckBoxMarkNoAccess)
        Me.Panel15.Controls.Add(Me.ComboBoxNoAccess)
        Me.Panel15.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel15.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel15.Location = New System.Drawing.Point(452, 590)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(341, 34)
        Me.Panel15.TabIndex = 45
        '
        'CheckBoxMarkNoAccess
        '
        Me.CheckBoxMarkNoAccess.AutoSize = True
        Me.CheckBoxMarkNoAccess.Enabled = False
        Me.CheckBoxMarkNoAccess.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMarkNoAccess.Location = New System.Drawing.Point(7, 5)
        Me.CheckBoxMarkNoAccess.Name = "CheckBoxMarkNoAccess"
        Me.CheckBoxMarkNoAccess.Size = New System.Drawing.Size(176, 27)
        Me.CheckBoxMarkNoAccess.TabIndex = 16
        Me.CheckBoxMarkNoAccess.Text = "Mark as No Access"
        Me.CheckBoxMarkNoAccess.UseVisualStyleBackColor = True
        '
        'ComboBoxNoAccess
        '
        Me.ComboBoxNoAccess.BackColor = System.Drawing.Color.Silver
        Me.ComboBoxNoAccess.Enabled = False
        Me.ComboBoxNoAccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxNoAccess.FormattingEnabled = True
        Me.ComboBoxNoAccess.Items.AddRange(New Object() {"Gated Community", "Access Code Required", "Guard"})
        Me.ComboBoxNoAccess.Location = New System.Drawing.Point(170, 5)
        Me.ComboBoxNoAccess.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxNoAccess.Name = "ComboBoxNoAccess"
        Me.ComboBoxNoAccess.Size = New System.Drawing.Size(165, 25)
        Me.ComboBoxNoAccess.TabIndex = 15
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel13.Controls.Add(Me.LabelPhotos)
        Me.Panel13.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel13.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel13.Location = New System.Drawing.Point(1119, 590)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(218, 32)
        Me.Panel13.TabIndex = 43
        '
        'LabelPhotos
        '
        Me.LabelPhotos.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPhotos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelPhotos.Location = New System.Drawing.Point(-1, 0)
        Me.LabelPhotos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelPhotos.Name = "LabelPhotos"
        Me.LabelPhotos.Size = New System.Drawing.Size(218, 31)
        Me.LabelPhotos.TabIndex = 2
        Me.LabelPhotos.Text = "Photos"
        Me.LabelPhotos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.ListBoxFiles)
        Me.Panel5.Controls.Add(Me.ButtonNextPhoto)
        Me.Panel5.Controls.Add(Me.ButtonPreviousPhoto)
        Me.Panel5.Location = New System.Drawing.Point(1119, 623)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(218, 118)
        Me.Panel5.TabIndex = 42
        '
        'ListBoxFiles
        '
        Me.ListBoxFiles.BackColor = System.Drawing.Color.Silver
        Me.ListBoxFiles.FormattingEnabled = True
        Me.ListBoxFiles.ItemHeight = 16
        Me.ListBoxFiles.Location = New System.Drawing.Point(4, 1)
        Me.ListBoxFiles.Name = "ListBoxFiles"
        Me.ListBoxFiles.Size = New System.Drawing.Size(208, 68)
        Me.ListBoxFiles.TabIndex = 9
        '
        'ButtonNextPhoto
        '
        Me.ButtonNextPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonNextPhoto.Location = New System.Drawing.Point(109, 85)
        Me.ButtonNextPhoto.Name = "ButtonNextPhoto"
        Me.ButtonNextPhoto.Size = New System.Drawing.Size(103, 28)
        Me.ButtonNextPhoto.TabIndex = 8
        Me.ButtonNextPhoto.Text = "Next"
        Me.ButtonNextPhoto.UseVisualStyleBackColor = True
        '
        'ButtonPreviousPhoto
        '
        Me.ButtonPreviousPhoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPreviousPhoto.Location = New System.Drawing.Point(4, 85)
        Me.ButtonPreviousPhoto.Name = "ButtonPreviousPhoto"
        Me.ButtonPreviousPhoto.Size = New System.Drawing.Size(103, 28)
        Me.ButtonPreviousPhoto.TabIndex = 7
        Me.ButtonPreviousPhoto.Text = "Previous"
        Me.ButtonPreviousPhoto.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.PictureBox1)
        Me.Panel12.Location = New System.Drawing.Point(669, 75)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(668, 506)
        Me.Panel12.TabIndex = 41
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(640, 480)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'LabelCommentGenerator
        '
        Me.LabelCommentGenerator.BackColor = System.Drawing.Color.Gray
        Me.LabelCommentGenerator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCommentGenerator.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LabelCommentGenerator.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCommentGenerator.ForeColor = System.Drawing.Color.Black
        Me.LabelCommentGenerator.Location = New System.Drawing.Point(809, 714)
        Me.LabelCommentGenerator.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelCommentGenerator.Name = "LabelCommentGenerator"
        Me.LabelCommentGenerator.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelCommentGenerator.Size = New System.Drawing.Size(297, 20)
        Me.LabelCommentGenerator.TabIndex = 38
        Me.LabelCommentGenerator.Text = "Comment Generator"
        Me.LabelCommentGenerator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonCancelEditing
        '
        Me.ButtonCancelEditing.Enabled = False
        Me.ButtonCancelEditing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCancelEditing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancelEditing.ImageIndex = 1
        Me.ButtonCancelEditing.ImageList = Me.ImageList4
        Me.ButtonCancelEditing.Location = New System.Drawing.Point(629, 648)
        Me.ButtonCancelEditing.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonCancelEditing.Name = "ButtonCancelEditing"
        Me.ButtonCancelEditing.Size = New System.Drawing.Size(135, 35)
        Me.ButtonCancelEditing.TabIndex = 37
        Me.ButtonCancelEditing.Text = "Cancel"
        Me.ButtonCancelEditing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancelEditing.UseVisualStyleBackColor = True
        Me.ButtonCancelEditing.Visible = False
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "Actions-dialog-ok-apply-icon.png")
        Me.ImageList4.Images.SetKeyName(1, "Actions-application-exit-icon.png")
        '
        'ButtonDoneEditing
        '
        Me.ButtonDoneEditing.Enabled = False
        Me.ButtonDoneEditing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDoneEditing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDoneEditing.ImageIndex = 0
        Me.ButtonDoneEditing.ImageList = Me.ImageList4
        Me.ButtonDoneEditing.Location = New System.Drawing.Point(490, 648)
        Me.ButtonDoneEditing.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonDoneEditing.Name = "ButtonDoneEditing"
        Me.ButtonDoneEditing.Size = New System.Drawing.Size(135, 35)
        Me.ButtonDoneEditing.TabIndex = 36
        Me.ButtonDoneEditing.Text = "Done"
        Me.ButtonDoneEditing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDoneEditing.UseVisualStyleBackColor = True
        Me.ButtonDoneEditing.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ListBoxOccupancyIndicators)
        Me.Panel1.Location = New System.Drawing.Point(28, 623)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(205, 113)
        Me.Panel1.TabIndex = 35
        '
        'ListBoxOccupancyIndicators
        '
        Me.ListBoxOccupancyIndicators.BackColor = System.Drawing.Color.Silver
        Me.ListBoxOccupancyIndicators.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxOccupancyIndicators.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxOccupancyIndicators.FormattingEnabled = True
        Me.ListBoxOccupancyIndicators.ItemHeight = 16
        Me.ListBoxOccupancyIndicators.Items.AddRange(New Object() {"People", "Pets inside/outside the property", "Lawn Cut", "Car/Boat", "Decorations"})
        Me.ListBoxOccupancyIndicators.Location = New System.Drawing.Point(8, 5)
        Me.ListBoxOccupancyIndicators.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBoxOccupancyIndicators.Name = "ListBoxOccupancyIndicators"
        Me.ListBoxOccupancyIndicators.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxOccupancyIndicators.Size = New System.Drawing.Size(187, 100)
        Me.ListBoxOccupancyIndicators.TabIndex = 34
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Silver
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RichTextBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(809, 623)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(297, 89)
        Me.RichTextBox1.TabIndex = 33
        Me.RichTextBox1.Text = ""
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.LabelPresetManager)
        Me.Panel11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel11.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel11.Location = New System.Drawing.Point(239, 588)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(204, 33)
        Me.Panel11.TabIndex = 32
        '
        'LabelPresetManager
        '
        Me.LabelPresetManager.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPresetManager.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelPresetManager.Location = New System.Drawing.Point(-1, -1)
        Me.LabelPresetManager.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelPresetManager.Name = "LabelPresetManager"
        Me.LabelPresetManager.Size = New System.Drawing.Size(204, 31)
        Me.LabelPresetManager.TabIndex = 1
        Me.LabelPresetManager.Text = "Preset Manager"
        Me.LabelPresetManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.LabelNoContactInspections)
        Me.Panel10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel10.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel10.Location = New System.Drawing.Point(28, 587)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(204, 33)
        Me.Panel10.TabIndex = 31
        '
        'LabelNoContactInspections
        '
        Me.LabelNoContactInspections.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoContactInspections.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelNoContactInspections.Location = New System.Drawing.Point(-1, 2)
        Me.LabelNoContactInspections.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelNoContactInspections.Name = "LabelNoContactInspections"
        Me.LabelNoContactInspections.Size = New System.Drawing.Size(204, 31)
        Me.LabelNoContactInspections.TabIndex = 1
        Me.LabelNoContactInspections.Text = "No Contact Inspections"
        Me.LabelNoContactInspections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel2.Controls.Add(Me.LabelGarageType)
        Me.FlowLayoutPanel2.Controls.Add(Me.ComboGarageType)
        Me.FlowLayoutPanel2.Controls.Add(Me.LabelSpokeWith)
        Me.FlowLayoutPanel2.Controls.Add(Me.ComboSpokeWith)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(452, 430)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(204, 151)
        Me.FlowLayoutPanel2.TabIndex = 30
        Me.FlowLayoutPanel2.Tag = "Standard"
        '
        'LabelGarageType
        '
        Me.LabelGarageType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGarageType.ForeColor = System.Drawing.Color.White
        Me.LabelGarageType.Location = New System.Drawing.Point(4, 4)
        Me.LabelGarageType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.LabelGarageType.Name = "LabelGarageType"
        Me.LabelGarageType.Size = New System.Drawing.Size(102, 18)
        Me.LabelGarageType.TabIndex = 9
        Me.LabelGarageType.Text = "Garage Type:"
        '
        'ComboGarageType
        '
        Me.ComboGarageType.BackColor = System.Drawing.Color.Silver
        Me.ComboGarageType.Enabled = False
        Me.ComboGarageType.FormattingEnabled = True
        Me.ComboGarageType.Items.AddRange(New Object() {"Attached", "Detached", "Carport", "None"})
        Me.ComboGarageType.Location = New System.Drawing.Point(4, 26)
        Me.ComboGarageType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboGarageType.Name = "ComboGarageType"
        Me.ComboGarageType.Size = New System.Drawing.Size(190, 24)
        Me.ComboGarageType.TabIndex = 10
        '
        'LabelSpokeWith
        '
        Me.LabelSpokeWith.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSpokeWith.ForeColor = System.Drawing.Color.White
        Me.LabelSpokeWith.Location = New System.Drawing.Point(4, 54)
        Me.LabelSpokeWith.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelSpokeWith.Name = "LabelSpokeWith"
        Me.LabelSpokeWith.Size = New System.Drawing.Size(92, 18)
        Me.LabelSpokeWith.TabIndex = 13
        Me.LabelSpokeWith.Text = "Spoke With:"
        '
        'ComboSpokeWith
        '
        Me.ComboSpokeWith.BackColor = System.Drawing.Color.Silver
        Me.ComboSpokeWith.Enabled = False
        Me.ComboSpokeWith.FormattingEnabled = True
        Me.ComboSpokeWith.Items.AddRange(New Object() {"Other person at Property", "Relative"})
        Me.ComboSpokeWith.Location = New System.Drawing.Point(4, 76)
        Me.ComboSpokeWith.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboSpokeWith.Name = "ComboSpokeWith"
        Me.ComboSpokeWith.Size = New System.Drawing.Size(190, 24)
        Me.ComboSpokeWith.TabIndex = 14
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelOccupancy)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboOccupantType)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPropertyType)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboPropertyType)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelConstructionType)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboConstructionType)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPropertyCondition)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboPropertyCondition)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelPropertyForSale)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboPropertyForSale)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelDeterminedBy)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComboDeterminedBy)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBrokerName)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxBrokerName)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBrokerNumber)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxBrokerNumber)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelNeighborHouseNumber)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBoxNeighborHouseNumber)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckBoxNoHouseNumber)
        Me.FlowLayoutPanel1.ForeColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(28, 115)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(204, 466)
        Me.FlowLayoutPanel1.TabIndex = 1
        Me.FlowLayoutPanel1.Tag = "Global"
        '
        'LabelOccupancy
        '
        Me.LabelOccupancy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOccupancy.Location = New System.Drawing.Point(4, 4)
        Me.LabelOccupancy.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.LabelOccupancy.Name = "LabelOccupancy"
        Me.LabelOccupancy.Size = New System.Drawing.Size(90, 18)
        Me.LabelOccupancy.TabIndex = 6
        Me.LabelOccupancy.Text = "Occupancy:"
        '
        'ComboOccupantType
        '
        Me.ComboOccupantType.BackColor = System.Drawing.Color.Silver
        Me.ComboOccupantType.Enabled = False
        Me.FlowLayoutPanel1.SetFlowBreak(Me.ComboOccupantType, True)
        Me.ComboOccupantType.Items.AddRange(New Object() {"Occupied by Owner", "Occupied by Unknown Occupant"})
        Me.ComboOccupantType.Location = New System.Drawing.Point(4, 26)
        Me.ComboOccupantType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboOccupantType.Name = "ComboOccupantType"
        Me.ComboOccupantType.Size = New System.Drawing.Size(190, 24)
        Me.ComboOccupantType.TabIndex = 3
        '
        'LabelPropertyType
        '
        Me.LabelPropertyType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPropertyType.Location = New System.Drawing.Point(4, 54)
        Me.LabelPropertyType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPropertyType.Name = "LabelPropertyType"
        Me.LabelPropertyType.Size = New System.Drawing.Size(111, 18)
        Me.LabelPropertyType.TabIndex = 7
        Me.LabelPropertyType.Text = "Property Type:"
        '
        'ComboPropertyType
        '
        Me.ComboPropertyType.BackColor = System.Drawing.Color.Silver
        Me.ComboPropertyType.Enabled = False
        Me.ComboPropertyType.FormattingEnabled = True
        Me.ComboPropertyType.Items.AddRange(New Object() {"Single Family", "Duplex", "Triplex", "Four-Plex", "Condo/Townhouse", "Mobile Home", "Vacant Land"})
        Me.ComboPropertyType.Location = New System.Drawing.Point(4, 76)
        Me.ComboPropertyType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboPropertyType.Name = "ComboPropertyType"
        Me.ComboPropertyType.Size = New System.Drawing.Size(190, 24)
        Me.ComboPropertyType.TabIndex = 8
        '
        'LabelConstructionType
        '
        Me.LabelConstructionType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConstructionType.Location = New System.Drawing.Point(4, 104)
        Me.LabelConstructionType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelConstructionType.Name = "LabelConstructionType"
        Me.LabelConstructionType.Size = New System.Drawing.Size(142, 18)
        Me.LabelConstructionType.TabIndex = 5
        Me.LabelConstructionType.Text = "Construction Type:"
        '
        'ComboConstructionType
        '
        Me.ComboConstructionType.BackColor = System.Drawing.Color.Silver
        Me.ComboConstructionType.Enabled = False
        Me.ComboConstructionType.FormattingEnabled = True
        Me.ComboConstructionType.Items.AddRange(New Object() {"Frame", "Brick/Block", "Stucco", "Vinyl/Aluminum Siding"})
        Me.ComboConstructionType.Location = New System.Drawing.Point(4, 126)
        Me.ComboConstructionType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboConstructionType.Name = "ComboConstructionType"
        Me.ComboConstructionType.Size = New System.Drawing.Size(190, 24)
        Me.ComboConstructionType.TabIndex = 2
        '
        'LabelPropertyCondition
        '
        Me.LabelPropertyCondition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPropertyCondition.Location = New System.Drawing.Point(4, 154)
        Me.LabelPropertyCondition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPropertyCondition.Name = "LabelPropertyCondition"
        Me.LabelPropertyCondition.Size = New System.Drawing.Size(146, 18)
        Me.LabelPropertyCondition.TabIndex = 11
        Me.LabelPropertyCondition.Text = "Property Condition:"
        '
        'ComboPropertyCondition
        '
        Me.ComboPropertyCondition.BackColor = System.Drawing.Color.Silver
        Me.ComboPropertyCondition.Enabled = False
        Me.ComboPropertyCondition.FormattingEnabled = True
        Me.ComboPropertyCondition.Items.AddRange(New Object() {"Good", "Fair"})
        Me.ComboPropertyCondition.Location = New System.Drawing.Point(4, 176)
        Me.ComboPropertyCondition.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboPropertyCondition.Name = "ComboPropertyCondition"
        Me.ComboPropertyCondition.Size = New System.Drawing.Size(190, 24)
        Me.ComboPropertyCondition.TabIndex = 12
        '
        'LabelPropertyForSale
        '
        Me.LabelPropertyForSale.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPropertyForSale.Location = New System.Drawing.Point(4, 204)
        Me.LabelPropertyForSale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPropertyForSale.Name = "LabelPropertyForSale"
        Me.LabelPropertyForSale.Size = New System.Drawing.Size(136, 18)
        Me.LabelPropertyForSale.TabIndex = 20
        Me.LabelPropertyForSale.Text = "Property For Sale:"
        '
        'ComboPropertyForSale
        '
        Me.ComboPropertyForSale.BackColor = System.Drawing.Color.Silver
        Me.ComboPropertyForSale.Enabled = False
        Me.ComboPropertyForSale.FormattingEnabled = True
        Me.ComboPropertyForSale.Location = New System.Drawing.Point(4, 226)
        Me.ComboPropertyForSale.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboPropertyForSale.Name = "ComboPropertyForSale"
        Me.ComboPropertyForSale.Size = New System.Drawing.Size(190, 24)
        Me.ComboPropertyForSale.TabIndex = 21
        '
        'LabelDeterminedBy
        '
        Me.LabelDeterminedBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDeterminedBy.Location = New System.Drawing.Point(4, 254)
        Me.LabelDeterminedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelDeterminedBy.Name = "LabelDeterminedBy"
        Me.LabelDeterminedBy.Size = New System.Drawing.Size(117, 18)
        Me.LabelDeterminedBy.TabIndex = 19
        Me.LabelDeterminedBy.Text = "Determined By:"
        '
        'ComboDeterminedBy
        '
        Me.ComboDeterminedBy.BackColor = System.Drawing.Color.Silver
        Me.ComboDeterminedBy.Enabled = False
        Me.ComboDeterminedBy.FormattingEnabled = True
        Me.ComboDeterminedBy.Items.AddRange(New Object() {"Direct Contact", "Neighbor"})
        Me.ComboDeterminedBy.Location = New System.Drawing.Point(4, 276)
        Me.ComboDeterminedBy.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboDeterminedBy.Name = "ComboDeterminedBy"
        Me.ComboDeterminedBy.Size = New System.Drawing.Size(190, 24)
        Me.ComboDeterminedBy.TabIndex = 18
        '
        'LabelBrokerName
        '
        Me.LabelBrokerName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBrokerName.Location = New System.Drawing.Point(4, 305)
        Me.LabelBrokerName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelBrokerName.Name = "LabelBrokerName"
        Me.LabelBrokerName.Size = New System.Drawing.Size(105, 18)
        Me.LabelBrokerName.TabIndex = 22
        Me.LabelBrokerName.Text = "Broker Name:"
        '
        'TextBoxBrokerName
        '
        Me.TextBoxBrokerName.BackColor = System.Drawing.Color.Silver
        Me.TextBoxBrokerName.Enabled = False
        Me.TextBoxBrokerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxBrokerName.Location = New System.Drawing.Point(2, 327)
        Me.TextBoxBrokerName.Margin = New System.Windows.Forms.Padding(2, 4, 2, 2)
        Me.TextBoxBrokerName.Name = "TextBoxBrokerName"
        Me.TextBoxBrokerName.Size = New System.Drawing.Size(192, 24)
        Me.TextBoxBrokerName.TabIndex = 23
        '
        'LabelBrokerNumber
        '
        Me.LabelBrokerNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBrokerNumber.Location = New System.Drawing.Point(4, 353)
        Me.LabelBrokerNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelBrokerNumber.Name = "LabelBrokerNumber"
        Me.LabelBrokerNumber.Size = New System.Drawing.Size(121, 18)
        Me.LabelBrokerNumber.TabIndex = 24
        Me.LabelBrokerNumber.Text = "Broker Number:"
        '
        'TextBoxBrokerNumber
        '
        Me.TextBoxBrokerNumber.BackColor = System.Drawing.Color.Silver
        Me.TextBoxBrokerNumber.Enabled = False
        Me.TextBoxBrokerNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxBrokerNumber.Location = New System.Drawing.Point(2, 376)
        Me.TextBoxBrokerNumber.Margin = New System.Windows.Forms.Padding(2, 5, 2, 2)
        Me.TextBoxBrokerNumber.Name = "TextBoxBrokerNumber"
        Me.TextBoxBrokerNumber.Size = New System.Drawing.Size(192, 24)
        Me.TextBoxBrokerNumber.TabIndex = 25
        '
        'LabelNeighborHouseNumber
        '
        Me.LabelNeighborHouseNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNeighborHouseNumber.Location = New System.Drawing.Point(4, 402)
        Me.LabelNeighborHouseNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelNeighborHouseNumber.Name = "LabelNeighborHouseNumber"
        Me.LabelNeighborHouseNumber.Size = New System.Drawing.Size(151, 18)
        Me.LabelNeighborHouseNumber.TabIndex = 26
        Me.LabelNeighborHouseNumber.Text = "Nbr. House Number:"
        '
        'TextBoxNeighborHouseNumber
        '
        Me.TextBoxNeighborHouseNumber.BackColor = System.Drawing.Color.Silver
        Me.TextBoxNeighborHouseNumber.Enabled = False
        Me.TextBoxNeighborHouseNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxNeighborHouseNumber.Location = New System.Drawing.Point(2, 424)
        Me.TextBoxNeighborHouseNumber.Margin = New System.Windows.Forms.Padding(2, 4, 2, 2)
        Me.TextBoxNeighborHouseNumber.Name = "TextBoxNeighborHouseNumber"
        Me.TextBoxNeighborHouseNumber.Size = New System.Drawing.Size(192, 24)
        Me.TextBoxNeighborHouseNumber.TabIndex = 27
        '
        'CheckBoxNoHouseNumber
        '
        Me.CheckBoxNoHouseNumber.AutoSize = True
        Me.CheckBoxNoHouseNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxNoHouseNumber.Location = New System.Drawing.Point(2, 452)
        Me.CheckBoxNoHouseNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBoxNoHouseNumber.Name = "CheckBoxNoHouseNumber"
        Me.CheckBoxNoHouseNumber.Size = New System.Drawing.Size(155, 22)
        Me.CheckBoxNoHouseNumber.TabIndex = 32
        Me.CheckBoxNoHouseNumber.Text = "No House Number"
        Me.CheckBoxNoHouseNumber.UseVisualStyleBackColor = True
        '
        'BindingNavigatorExcelSheet
        '
        Me.BindingNavigatorExcelSheet.AddNewItem = Nothing
        Me.BindingNavigatorExcelSheet.BackColor = System.Drawing.Color.Gray
        Me.BindingNavigatorExcelSheet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BindingNavigatorExcelSheet.CountItem = Me.BindingNavigatorCountItem1
        Me.BindingNavigatorExcelSheet.DeleteItem = Nothing
        Me.BindingNavigatorExcelSheet.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigatorExcelSheet.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BindingNavigatorExcelSheet.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigatorExcelSheet.ImageScalingSize = New System.Drawing.Size(35, 35)
        Me.BindingNavigatorExcelSheet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonMarkComplete, Me.MoveFirstExcel, Me.MovePreviousExcel, Me.ToolStripSeparator1, Me.BindingNavigatorPositionItem1, Me.BindingNavigatorCountItem1, Me.ToolStripSeparator2, Me.MoveNextExcel, Me.MoveLastExcel, Me.ButtonRevertCompletion})
        Me.BindingNavigatorExcelSheet.Location = New System.Drawing.Point(449, 692)
        Me.BindingNavigatorExcelSheet.MoveFirstItem = Nothing
        Me.BindingNavigatorExcelSheet.MoveLastItem = Nothing
        Me.BindingNavigatorExcelSheet.MoveNextItem = Nothing
        Me.BindingNavigatorExcelSheet.MovePreviousItem = Nothing
        Me.BindingNavigatorExcelSheet.Name = "BindingNavigatorExcelSheet"
        Me.BindingNavigatorExcelSheet.PositionItem = Me.BindingNavigatorPositionItem1
        Me.BindingNavigatorExcelSheet.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BindingNavigatorExcelSheet.Size = New System.Drawing.Size(347, 42)
        Me.BindingNavigatorExcelSheet.Stretch = True
        Me.BindingNavigatorExcelSheet.TabIndex = 5
        Me.BindingNavigatorExcelSheet.Text = "BindingNavigator2"
        '
        'BindingNavigatorCountItem1
        '
        Me.BindingNavigatorCountItem1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BindingNavigatorCountItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BindingNavigatorCountItem1.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.BindingNavigatorCountItem1.ForeColor = System.Drawing.Color.Black
        Me.BindingNavigatorCountItem1.Name = "BindingNavigatorCountItem1"
        Me.BindingNavigatorCountItem1.Size = New System.Drawing.Size(52, 39)
        Me.BindingNavigatorCountItem1.Text = "of {0}"
        Me.BindingNavigatorCountItem1.ToolTipText = "Total number of items"
        '
        'ButtonMarkComplete
        '
        Me.ButtonMarkComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonMarkComplete.Image = CType(resources.GetObject("ButtonMarkComplete.Image"), System.Drawing.Image)
        Me.ButtonMarkComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonMarkComplete.Name = "ButtonMarkComplete"
        Me.ButtonMarkComplete.Size = New System.Drawing.Size(39, 39)
        Me.ButtonMarkComplete.Text = "Mark as Complete"
        '
        'MoveFirstExcel
        '
        Me.MoveFirstExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveFirstExcel.Image = CType(resources.GetObject("MoveFirstExcel.Image"), System.Drawing.Image)
        Me.MoveFirstExcel.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveFirstExcel.Name = "MoveFirstExcel"
        Me.MoveFirstExcel.RightToLeftAutoMirrorImage = True
        Me.MoveFirstExcel.Size = New System.Drawing.Size(39, 42)
        Me.MoveFirstExcel.Text = "Move first"
        Me.MoveFirstExcel.ToolTipText = "First Record"
        '
        'MovePreviousExcel
        '
        Me.MovePreviousExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MovePreviousExcel.Image = CType(resources.GetObject("MovePreviousExcel.Image"), System.Drawing.Image)
        Me.MovePreviousExcel.Margin = New System.Windows.Forms.Padding(0)
        Me.MovePreviousExcel.Name = "MovePreviousExcel"
        Me.MovePreviousExcel.RightToLeftAutoMirrorImage = True
        Me.MovePreviousExcel.Size = New System.Drawing.Size(39, 42)
        Me.MovePreviousExcel.Text = "Move previous"
        Me.MovePreviousExcel.ToolTipText = "Previous Record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'BindingNavigatorPositionItem1
        '
        Me.BindingNavigatorPositionItem1.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem1.AutoSize = False
        Me.BindingNavigatorPositionItem1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BindingNavigatorPositionItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BindingNavigatorPositionItem1.Font = New System.Drawing.Font("Arial Narrow", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.BindingNavigatorPositionItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BindingNavigatorPositionItem1.Margin = New System.Windows.Forms.Padding(8, 0, 1, 0)
        Me.BindingNavigatorPositionItem1.Name = "BindingNavigatorPositionItem1"
        Me.BindingNavigatorPositionItem1.Size = New System.Drawing.Size(37, 26)
        Me.BindingNavigatorPositionItem1.Text = "0"
        Me.BindingNavigatorPositionItem1.ToolTipText = "Current position"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'MoveNextExcel
        '
        Me.MoveNextExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveNextExcel.Image = CType(resources.GetObject("MoveNextExcel.Image"), System.Drawing.Image)
        Me.MoveNextExcel.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveNextExcel.Name = "MoveNextExcel"
        Me.MoveNextExcel.RightToLeftAutoMirrorImage = True
        Me.MoveNextExcel.Size = New System.Drawing.Size(39, 42)
        Me.MoveNextExcel.Text = " "
        Me.MoveNextExcel.ToolTipText = " Next Record"
        '
        'MoveLastExcel
        '
        Me.MoveLastExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveLastExcel.Image = CType(resources.GetObject("MoveLastExcel.Image"), System.Drawing.Image)
        Me.MoveLastExcel.Margin = New System.Windows.Forms.Padding(0)
        Me.MoveLastExcel.Name = "MoveLastExcel"
        Me.MoveLastExcel.RightToLeftAutoMirrorImage = True
        Me.MoveLastExcel.Size = New System.Drawing.Size(39, 42)
        Me.MoveLastExcel.Text = "Move last"
        Me.MoveLastExcel.ToolTipText = "Last Record"
        '
        'ButtonRevertCompletion
        '
        Me.ButtonRevertCompletion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonRevertCompletion.Image = CType(resources.GetObject("ButtonRevertCompletion.Image"), System.Drawing.Image)
        Me.ButtonRevertCompletion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonRevertCompletion.Name = "ButtonRevertCompletion"
        Me.ButtonRevertCompletion.Size = New System.Drawing.Size(39, 39)
        Me.ButtonRevertCompletion.Text = "Mark as Incomplete"
        '
        'PanelWellsFargo1
        '
        Me.PanelWellsFargo1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelWellsFargo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWellsFargo1.Controls.Add(Me.LabelLocationType)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboLocationType)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelNeighborhoodStatus)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboNeighborhoodStatus)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelNeighborhoodIssues)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboNeighborhoodIssues)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelRoofType)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboRoofType)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelRoofDamages)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboRoofDamages)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelLandscapeType)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboLandscapeType)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelLandscapeCondition)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboLandscapeCondition)
        Me.PanelWellsFargo1.Controls.Add(Me.LabelGrassHeight)
        Me.PanelWellsFargo1.Controls.Add(Me.ComboGrassHeight)
        Me.PanelWellsFargo1.ForeColor = System.Drawing.Color.White
        Me.PanelWellsFargo1.Location = New System.Drawing.Point(239, 115)
        Me.PanelWellsFargo1.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelWellsFargo1.Name = "PanelWellsFargo1"
        Me.PanelWellsFargo1.Size = New System.Drawing.Size(204, 466)
        Me.PanelWellsFargo1.TabIndex = 2
        Me.PanelWellsFargo1.Tag = "WellsFargo"
        '
        'LabelLocationType
        '
        Me.LabelLocationType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLocationType.Location = New System.Drawing.Point(4, 4)
        Me.LabelLocationType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.LabelLocationType.Name = "LabelLocationType"
        Me.LabelLocationType.Size = New System.Drawing.Size(111, 18)
        Me.LabelLocationType.TabIndex = 20
        Me.LabelLocationType.Text = "Location Type:"
        '
        'ComboLocationType
        '
        Me.ComboLocationType.BackColor = System.Drawing.Color.Silver
        Me.ComboLocationType.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboLocationType, True)
        Me.ComboLocationType.Items.AddRange(New Object() {"Urban", "Suburban", "Rural"})
        Me.ComboLocationType.Location = New System.Drawing.Point(4, 26)
        Me.ComboLocationType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboLocationType.Name = "ComboLocationType"
        Me.ComboLocationType.Size = New System.Drawing.Size(190, 24)
        Me.ComboLocationType.TabIndex = 19
        '
        'LabelNeighborhoodStatus
        '
        Me.LabelNeighborhoodStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNeighborhoodStatus.Location = New System.Drawing.Point(4, 54)
        Me.LabelNeighborhoodStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelNeighborhoodStatus.Name = "LabelNeighborhoodStatus"
        Me.LabelNeighborhoodStatus.Size = New System.Drawing.Size(163, 18)
        Me.LabelNeighborhoodStatus.TabIndex = 22
        Me.LabelNeighborhoodStatus.Text = "Neighborhood Status:"
        '
        'ComboNeighborhoodStatus
        '
        Me.ComboNeighborhoodStatus.BackColor = System.Drawing.Color.Silver
        Me.ComboNeighborhoodStatus.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboNeighborhoodStatus, True)
        Me.ComboNeighborhoodStatus.Items.AddRange(New Object() {"Improving", "Stable", "Declining", "Unknown"})
        Me.ComboNeighborhoodStatus.Location = New System.Drawing.Point(4, 76)
        Me.ComboNeighborhoodStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboNeighborhoodStatus.Name = "ComboNeighborhoodStatus"
        Me.ComboNeighborhoodStatus.Size = New System.Drawing.Size(190, 24)
        Me.ComboNeighborhoodStatus.TabIndex = 21
        '
        'LabelNeighborhoodIssues
        '
        Me.LabelNeighborhoodIssues.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNeighborhoodIssues.Location = New System.Drawing.Point(4, 104)
        Me.LabelNeighborhoodIssues.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelNeighborhoodIssues.Name = "LabelNeighborhoodIssues"
        Me.LabelNeighborhoodIssues.Size = New System.Drawing.Size(164, 18)
        Me.LabelNeighborhoodIssues.TabIndex = 25
        Me.LabelNeighborhoodIssues.Text = "Neighborhood Issues:"
        '
        'ComboNeighborhoodIssues
        '
        Me.ComboNeighborhoodIssues.BackColor = System.Drawing.Color.Silver
        Me.ComboNeighborhoodIssues.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboNeighborhoodIssues, True)
        Me.ComboNeighborhoodIssues.Items.AddRange(New Object() {"Streets in Disrepair", "Suspicious Oders", "Drug Activity", "Industrial Plants", "Non-Residential/Commercial Facilities", "Visible Construction/Remodeling", "None"})
        Me.ComboNeighborhoodIssues.Location = New System.Drawing.Point(4, 126)
        Me.ComboNeighborhoodIssues.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboNeighborhoodIssues.Name = "ComboNeighborhoodIssues"
        Me.ComboNeighborhoodIssues.Size = New System.Drawing.Size(190, 24)
        Me.ComboNeighborhoodIssues.TabIndex = 26
        '
        'LabelRoofType
        '
        Me.LabelRoofType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRoofType.Location = New System.Drawing.Point(4, 154)
        Me.LabelRoofType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRoofType.Name = "LabelRoofType"
        Me.LabelRoofType.Size = New System.Drawing.Size(84, 18)
        Me.LabelRoofType.TabIndex = 8
        Me.LabelRoofType.Text = "Roof Type:"
        '
        'ComboRoofType
        '
        Me.ComboRoofType.BackColor = System.Drawing.Color.Silver
        Me.ComboRoofType.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboRoofType, True)
        Me.ComboRoofType.Items.AddRange(New Object() {"Asphalt", "Metal", "Slate", "Tile", "Wood"})
        Me.ComboRoofType.Location = New System.Drawing.Point(4, 176)
        Me.ComboRoofType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboRoofType.Name = "ComboRoofType"
        Me.ComboRoofType.Size = New System.Drawing.Size(190, 24)
        Me.ComboRoofType.TabIndex = 7
        '
        'LabelRoofDamages
        '
        Me.LabelRoofDamages.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRoofDamages.Location = New System.Drawing.Point(4, 204)
        Me.LabelRoofDamages.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRoofDamages.Name = "LabelRoofDamages"
        Me.LabelRoofDamages.Size = New System.Drawing.Size(115, 18)
        Me.LabelRoofDamages.TabIndex = 24
        Me.LabelRoofDamages.Text = "Roof Damages:"
        '
        'ComboRoofDamages
        '
        Me.ComboRoofDamages.BackColor = System.Drawing.Color.Silver
        Me.ComboRoofDamages.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboRoofDamages, True)
        Me.ComboRoofDamages.Items.AddRange(New Object() {"Roof Sagging", "Gutter or Downspouts", "Debris on Roof", "Gutter Debris/Growth", "Snow Greater Than 18 Inches", "None"})
        Me.ComboRoofDamages.Location = New System.Drawing.Point(4, 226)
        Me.ComboRoofDamages.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboRoofDamages.Name = "ComboRoofDamages"
        Me.ComboRoofDamages.Size = New System.Drawing.Size(190, 24)
        Me.ComboRoofDamages.TabIndex = 23
        '
        'LabelLandscapeType
        '
        Me.LabelLandscapeType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLandscapeType.Location = New System.Drawing.Point(4, 254)
        Me.LabelLandscapeType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLandscapeType.Name = "LabelLandscapeType"
        Me.LabelLandscapeType.Size = New System.Drawing.Size(127, 18)
        Me.LabelLandscapeType.TabIndex = 10
        Me.LabelLandscapeType.Text = "Landscape Type:"
        '
        'ComboLandscapeType
        '
        Me.ComboLandscapeType.BackColor = System.Drawing.Color.Silver
        Me.ComboLandscapeType.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboLandscapeType, True)
        Me.ComboLandscapeType.Items.AddRange(New Object() {"Grass", "No lawn", "Desert Landscape", "Bare Dirt", "Dead Lawn", "Snow Covered"})
        Me.ComboLandscapeType.Location = New System.Drawing.Point(4, 276)
        Me.ComboLandscapeType.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboLandscapeType.Name = "ComboLandscapeType"
        Me.ComboLandscapeType.Size = New System.Drawing.Size(190, 24)
        Me.ComboLandscapeType.TabIndex = 9
        '
        'LabelLandscapeCondition
        '
        Me.LabelLandscapeCondition.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLandscapeCondition.Location = New System.Drawing.Point(4, 305)
        Me.LabelLandscapeCondition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLandscapeCondition.Name = "LabelLandscapeCondition"
        Me.LabelLandscapeCondition.Size = New System.Drawing.Size(162, 18)
        Me.LabelLandscapeCondition.TabIndex = 14
        Me.LabelLandscapeCondition.Text = "Landscape Condition:"
        '
        'ComboLandscapeCondition
        '
        Me.ComboLandscapeCondition.BackColor = System.Drawing.Color.Silver
        Me.ComboLandscapeCondition.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboLandscapeCondition, True)
        Me.ComboLandscapeCondition.Items.AddRange(New Object() {"Yard Maintained", "Overgrown Weeds", "Trees/Shrubs Need Trimming", "Overgrown Vines", "Leaves/Pine Needles Present"})
        Me.ComboLandscapeCondition.Location = New System.Drawing.Point(4, 327)
        Me.ComboLandscapeCondition.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboLandscapeCondition.Name = "ComboLandscapeCondition"
        Me.ComboLandscapeCondition.Size = New System.Drawing.Size(190, 24)
        Me.ComboLandscapeCondition.TabIndex = 13
        '
        'LabelGrassHeight
        '
        Me.LabelGrassHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGrassHeight.Location = New System.Drawing.Point(4, 356)
        Me.LabelGrassHeight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelGrassHeight.Name = "LabelGrassHeight"
        Me.LabelGrassHeight.Size = New System.Drawing.Size(105, 18)
        Me.LabelGrassHeight.TabIndex = 12
        Me.LabelGrassHeight.Text = "Grass Height:"
        '
        'ComboGrassHeight
        '
        Me.ComboGrassHeight.BackColor = System.Drawing.Color.Silver
        Me.ComboGrassHeight.Enabled = False
        Me.PanelWellsFargo1.SetFlowBreak(Me.ComboGrassHeight, True)
        Me.ComboGrassHeight.Items.AddRange(New Object() {"Under 4""", "4-12""", "Over 12"""})
        Me.ComboGrassHeight.Location = New System.Drawing.Point(4, 378)
        Me.ComboGrassHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboGrassHeight.Name = "ComboGrassHeight"
        Me.ComboGrassHeight.Size = New System.Drawing.Size(190, 24)
        Me.ComboGrassHeight.TabIndex = 11
        '
        'PanelWellsFargo2
        '
        Me.PanelWellsFargo2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PanelWellsFargo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWellsFargo2.Controls.Add(Me.LabelSecurityIssues)
        Me.PanelWellsFargo2.Controls.Add(Me.ComboSecurityIssues)
        Me.PanelWellsFargo2.Controls.Add(Me.LabelPropertyHabitable)
        Me.PanelWellsFargo2.Controls.Add(Me.ComboPropertyHabitable)
        Me.PanelWellsFargo2.Controls.Add(Me.CheckPropertyUnsecure)
        Me.PanelWellsFargo2.Controls.Add(Me.CheckGatedCommunity)
        Me.PanelWellsFargo2.Controls.Add(Me.CheckHighVandalismArea)
        Me.PanelWellsFargo2.Controls.Add(Me.CheckEscalatedEvents)
        Me.PanelWellsFargo2.Controls.Add(Me.TextBoxEscalatedEvents)
        Me.PanelWellsFargo2.ForeColor = System.Drawing.Color.White
        Me.PanelWellsFargo2.Location = New System.Drawing.Point(452, 115)
        Me.PanelWellsFargo2.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelWellsFargo2.Name = "PanelWellsFargo2"
        Me.PanelWellsFargo2.Size = New System.Drawing.Size(204, 273)
        Me.PanelWellsFargo2.TabIndex = 3
        Me.PanelWellsFargo2.Tag = "WellsFargo"
        '
        'LabelSecurityIssues
        '
        Me.LabelSecurityIssues.AutoSize = True
        Me.LabelSecurityIssues.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSecurityIssues.Location = New System.Drawing.Point(4, 4)
        Me.LabelSecurityIssues.Margin = New System.Windows.Forms.Padding(4, 4, 4, 0)
        Me.LabelSecurityIssues.Name = "LabelSecurityIssues"
        Me.LabelSecurityIssues.Size = New System.Drawing.Size(120, 18)
        Me.LabelSecurityIssues.TabIndex = 27
        Me.LabelSecurityIssues.Text = "Security Issues:"
        '
        'ComboSecurityIssues
        '
        Me.ComboSecurityIssues.BackColor = System.Drawing.Color.Silver
        Me.ComboSecurityIssues.Enabled = False
        Me.PanelWellsFargo2.SetFlowBreak(Me.ComboSecurityIssues, True)
        Me.ComboSecurityIssues.Items.AddRange(New Object() {"Unsecure OutBuilding", "Damaged Outbuilding", "Property Boarded", "Exposure to Elements/Casual Entry/Possible Crimes", "Back Door Unsecure", "Basement Unsecure", "Crawl Space Unsecure", "Front Door Unsecure", "Garage Door Unsecure", "Open Ground Level Windows", "Pet Door Unsecure", "Side Door Unsecure", "Upper Story Doors/Windows Unsecure", "Boarding/Reglazing/Re-Screening Needed", "Lock Change Needed", "None"})
        Me.ComboSecurityIssues.Location = New System.Drawing.Point(4, 26)
        Me.ComboSecurityIssues.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboSecurityIssues.Name = "ComboSecurityIssues"
        Me.ComboSecurityIssues.Size = New System.Drawing.Size(190, 24)
        Me.ComboSecurityIssues.TabIndex = 28
        '
        'LabelPropertyHabitable
        '
        Me.LabelPropertyHabitable.AutoSize = True
        Me.LabelPropertyHabitable.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPropertyHabitable.Location = New System.Drawing.Point(4, 54)
        Me.LabelPropertyHabitable.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPropertyHabitable.Name = "LabelPropertyHabitable"
        Me.LabelPropertyHabitable.Size = New System.Drawing.Size(144, 18)
        Me.LabelPropertyHabitable.TabIndex = 18
        Me.LabelPropertyHabitable.Text = "Property Habitable:"
        '
        'ComboPropertyHabitable
        '
        Me.ComboPropertyHabitable.BackColor = System.Drawing.Color.Silver
        Me.ComboPropertyHabitable.Enabled = False
        Me.PanelWellsFargo2.SetFlowBreak(Me.ComboPropertyHabitable, True)
        Me.ComboPropertyHabitable.Items.AddRange(New Object() {"Yes", "No"})
        Me.ComboPropertyHabitable.Location = New System.Drawing.Point(4, 76)
        Me.ComboPropertyHabitable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 9)
        Me.ComboPropertyHabitable.Name = "ComboPropertyHabitable"
        Me.ComboPropertyHabitable.Size = New System.Drawing.Size(190, 24)
        Me.ComboPropertyHabitable.TabIndex = 17
        '
        'CheckPropertyUnsecure
        '
        Me.CheckPropertyUnsecure.AutoSize = True
        Me.CheckPropertyUnsecure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckPropertyUnsecure.Location = New System.Drawing.Point(2, 111)
        Me.CheckPropertyUnsecure.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckPropertyUnsecure.Name = "CheckPropertyUnsecure"
        Me.CheckPropertyUnsecure.Size = New System.Drawing.Size(154, 22)
        Me.CheckPropertyUnsecure.TabIndex = 31
        Me.CheckPropertyUnsecure.Text = "Property Unsecure"
        Me.CheckPropertyUnsecure.UseVisualStyleBackColor = True
        '
        'CheckGatedCommunity
        '
        Me.CheckGatedCommunity.AutoSize = True
        Me.CheckGatedCommunity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckGatedCommunity.Location = New System.Drawing.Point(2, 137)
        Me.CheckGatedCommunity.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckGatedCommunity.Name = "CheckGatedCommunity"
        Me.CheckGatedCommunity.Size = New System.Drawing.Size(150, 22)
        Me.CheckGatedCommunity.TabIndex = 32
        Me.CheckGatedCommunity.Text = "Gated Community"
        Me.CheckGatedCommunity.UseVisualStyleBackColor = True
        '
        'CheckHighVandalismArea
        '
        Me.CheckHighVandalismArea.AutoSize = True
        Me.CheckHighVandalismArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckHighVandalismArea.Location = New System.Drawing.Point(2, 163)
        Me.CheckHighVandalismArea.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckHighVandalismArea.Name = "CheckHighVandalismArea"
        Me.CheckHighVandalismArea.Size = New System.Drawing.Size(166, 22)
        Me.CheckHighVandalismArea.TabIndex = 30
        Me.CheckHighVandalismArea.Text = "High Vandalism Area"
        Me.CheckHighVandalismArea.UseVisualStyleBackColor = True
        '
        'CheckEscalatedEvents
        '
        Me.CheckEscalatedEvents.AutoSize = True
        Me.CheckEscalatedEvents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEscalatedEvents.Location = New System.Drawing.Point(2, 189)
        Me.CheckEscalatedEvents.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckEscalatedEvents.Name = "CheckEscalatedEvents"
        Me.CheckEscalatedEvents.Size = New System.Drawing.Size(148, 22)
        Me.CheckEscalatedEvents.TabIndex = 19
        Me.CheckEscalatedEvents.Text = "Escalated Events:"
        Me.CheckEscalatedEvents.UseVisualStyleBackColor = True
        '
        'TextBoxEscalatedEvents
        '
        Me.TextBoxEscalatedEvents.BackColor = System.Drawing.Color.Silver
        Me.TextBoxEscalatedEvents.Enabled = False
        Me.TextBoxEscalatedEvents.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBoxEscalatedEvents.Location = New System.Drawing.Point(2, 221)
        Me.TextBoxEscalatedEvents.Margin = New System.Windows.Forms.Padding(2, 8, 2, 2)
        Me.TextBoxEscalatedEvents.Name = "TextBoxEscalatedEvents"
        Me.TextBoxEscalatedEvents.Size = New System.Drawing.Size(192, 24)
        Me.TextBoxEscalatedEvents.TabIndex = 20
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.LabelComment)
        Me.Panel9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel9.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel9.Location = New System.Drawing.Point(809, 590)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(297, 32)
        Me.Panel9.TabIndex = 29
        '
        'LabelComment
        '
        Me.LabelComment.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelComment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelComment.Location = New System.Drawing.Point(-1, 0)
        Me.LabelComment.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelComment.Name = "LabelComment"
        Me.LabelComment.Size = New System.Drawing.Size(297, 31)
        Me.LabelComment.TabIndex = 1
        Me.LabelComment.Text = "Comment"
        Me.LabelComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LabelWellsFargoInspections)
        Me.Panel7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel7.Location = New System.Drawing.Point(239, 75)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(417, 33)
        Me.Panel7.TabIndex = 28
        '
        'LabelWellsFargoInspections
        '
        Me.LabelWellsFargoInspections.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWellsFargoInspections.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelWellsFargoInspections.Location = New System.Drawing.Point(-2, 0)
        Me.LabelWellsFargoInspections.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelWellsFargoInspections.Name = "LabelWellsFargoInspections"
        Me.LabelWellsFargoInspections.Size = New System.Drawing.Size(418, 31)
        Me.LabelWellsFargoInspections.TabIndex = 1
        Me.LabelWellsFargoInspections.Text = "Wells Fargo Inspections"
        Me.LabelWellsFargoInspections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.LabelGlobalDetails)
        Me.Panel6.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel6.Location = New System.Drawing.Point(28, 75)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(204, 33)
        Me.Panel6.TabIndex = 27
        '
        'LabelGlobalDetails
        '
        Me.LabelGlobalDetails.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGlobalDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelGlobalDetails.Location = New System.Drawing.Point(-1, 0)
        Me.LabelGlobalDetails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelGlobalDetails.Name = "LabelGlobalDetails"
        Me.LabelGlobalDetails.Size = New System.Drawing.Size(205, 31)
        Me.LabelGlobalDetails.TabIndex = 0
        Me.LabelGlobalDetails.Text = "Global Details"
        Me.LabelGlobalDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BindingNavigatorStandardInspectionPresets)
        Me.Panel3.Controls.Add(Me.ListBoxStandardInspectionPresets)
        Me.Panel3.Location = New System.Drawing.Point(239, 623)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(204, 113)
        Me.Panel3.TabIndex = 23
        '
        'BindingNavigatorStandardInspectionPresets
        '
        Me.BindingNavigatorStandardInspectionPresets.AddNewItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.BackColor = System.Drawing.Color.Silver
        Me.BindingNavigatorStandardInspectionPresets.CountItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.DeleteItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigatorStandardInspectionPresets.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigatorStandardInspectionPresets.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.BindingNavigatorStandardInspectionPresets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Move_PreviousStandardPresets, Me.MoveNextStandardPresets, Me.ButtonApplyPreset, Me.ToolStripSeparator3, Me.ButtonAddPreset, Me.ButtonDeletePreset})
        Me.BindingNavigatorStandardInspectionPresets.Location = New System.Drawing.Point(22, 74)
        Me.BindingNavigatorStandardInspectionPresets.MoveFirstItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.MoveLastItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.MoveNextItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.MovePreviousItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.Name = "BindingNavigatorStandardInspectionPresets"
        Me.BindingNavigatorStandardInspectionPresets.PositionItem = Nothing
        Me.BindingNavigatorStandardInspectionPresets.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BindingNavigatorStandardInspectionPresets.Size = New System.Drawing.Size(154, 32)
        Me.BindingNavigatorStandardInspectionPresets.TabIndex = 6
        Me.BindingNavigatorStandardInspectionPresets.Text = "BindingNavigator3"
        '
        'Move_PreviousStandardPresets
        '
        Me.Move_PreviousStandardPresets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Move_PreviousStandardPresets.Image = CType(resources.GetObject("Move_PreviousStandardPresets.Image"), System.Drawing.Image)
        Me.Move_PreviousStandardPresets.Name = "Move_PreviousStandardPresets"
        Me.Move_PreviousStandardPresets.RightToLeftAutoMirrorImage = True
        Me.Move_PreviousStandardPresets.Size = New System.Drawing.Size(29, 29)
        Me.Move_PreviousStandardPresets.Text = "Move previous"
        '
        'MoveNextStandardPresets
        '
        Me.MoveNextStandardPresets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveNextStandardPresets.Image = CType(resources.GetObject("MoveNextStandardPresets.Image"), System.Drawing.Image)
        Me.MoveNextStandardPresets.Name = "MoveNextStandardPresets"
        Me.MoveNextStandardPresets.RightToLeftAutoMirrorImage = True
        Me.MoveNextStandardPresets.Size = New System.Drawing.Size(29, 29)
        Me.MoveNextStandardPresets.Text = "Move next"
        '
        'ButtonApplyPreset
        '
        Me.ButtonApplyPreset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonApplyPreset.Image = CType(resources.GetObject("ButtonApplyPreset.Image"), System.Drawing.Image)
        Me.ButtonApplyPreset.Name = "ButtonApplyPreset"
        Me.ButtonApplyPreset.RightToLeftAutoMirrorImage = True
        Me.ButtonApplyPreset.Size = New System.Drawing.Size(29, 29)
        Me.ButtonApplyPreset.Text = "Add new"
        Me.ButtonApplyPreset.ToolTipText = "Fill Form"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'ButtonAddPreset
        '
        Me.ButtonAddPreset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonAddPreset.Image = CType(resources.GetObject("ButtonAddPreset.Image"), System.Drawing.Image)
        Me.ButtonAddPreset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAddPreset.Name = "ButtonAddPreset"
        Me.ButtonAddPreset.Size = New System.Drawing.Size(29, 29)
        Me.ButtonAddPreset.Text = "ToolStripButton3"
        Me.ButtonAddPreset.ToolTipText = "Save as New Preset"
        '
        'ButtonDeletePreset
        '
        Me.ButtonDeletePreset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonDeletePreset.Image = CType(resources.GetObject("ButtonDeletePreset.Image"), System.Drawing.Image)
        Me.ButtonDeletePreset.Name = "ButtonDeletePreset"
        Me.ButtonDeletePreset.RightToLeftAutoMirrorImage = True
        Me.ButtonDeletePreset.Size = New System.Drawing.Size(29, 29)
        Me.ButtonDeletePreset.Text = "Delete"
        Me.ButtonDeletePreset.ToolTipText = "Delete Preset"
        '
        'ListBoxStandardInspectionPresets
        '
        Me.ListBoxStandardInspectionPresets.BackColor = System.Drawing.Color.Silver
        Me.ListBoxStandardInspectionPresets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBoxStandardInspectionPresets.DataSource = Me.BindingSourcePresets
        Me.ListBoxStandardInspectionPresets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ListBoxStandardInspectionPresets.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxStandardInspectionPresets.ForeColor = System.Drawing.Color.Black
        Me.ListBoxStandardInspectionPresets.FormattingEnabled = True
        Me.ListBoxStandardInspectionPresets.ItemHeight = 20
        Me.ListBoxStandardInspectionPresets.Location = New System.Drawing.Point(4, 4)
        Me.ListBoxStandardInspectionPresets.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxStandardInspectionPresets.Name = "ListBoxStandardInspectionPresets"
        Me.ListBoxStandardInspectionPresets.Size = New System.Drawing.Size(193, 62)
        Me.ListBoxStandardInspectionPresets.TabIndex = 5
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.LabelStandardInspections)
        Me.Panel8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.ForeColor = System.Drawing.SystemColors.Control
        Me.Panel8.Location = New System.Drawing.Point(452, 392)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2, 20, 2, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(204, 33)
        Me.Panel8.TabIndex = 28
        '
        'LabelStandardInspections
        '
        Me.LabelStandardInspections.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStandardInspections.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelStandardInspections.Location = New System.Drawing.Point(-1, 0)
        Me.LabelStandardInspections.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelStandardInspections.Name = "LabelStandardInspections"
        Me.LabelStandardInspections.Size = New System.Drawing.Size(205, 31)
        Me.LabelStandardInspections.TabIndex = 1
        Me.LabelStandardInspections.Text = "Standard Inspections"
        Me.LabelStandardInspections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(7, 59)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1346, 10)
        Me.Panel2.TabIndex = 11
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.Controls.Add(Me.LabelServiceID)
        Me.FlowLayoutPanel4.Controls.Add(Me.TextBoxServiceID)
        Me.FlowLayoutPanel4.Controls.Add(Me.Splitter1)
        Me.FlowLayoutPanel4.Controls.Add(Me.LabelPropertyID)
        Me.FlowLayoutPanel4.Controls.Add(Me.TextBoxPropertyID)
        Me.FlowLayoutPanel4.Controls.Add(Me.LabelInspectionType)
        Me.FlowLayoutPanel4.Controls.Add(Me.LabelAddress)
        Me.FlowLayoutPanel4.Controls.Add(Me.ButtonImageCurrentStatus)
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(8, 9)
        Me.FlowLayoutPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(1344, 45)
        Me.FlowLayoutPanel4.TabIndex = 10
        '
        'LabelServiceID
        '
        Me.LabelServiceID.AutoSize = True
        Me.LabelServiceID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelServiceID.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelServiceID.Location = New System.Drawing.Point(4, 0)
        Me.LabelServiceID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelServiceID.Name = "LabelServiceID"
        Me.LabelServiceID.Size = New System.Drawing.Size(43, 24)
        Me.LabelServiceID.TabIndex = 3
        Me.LabelServiceID.Text = "SID:"
        '
        'TextBoxServiceID
        '
        Me.TextBoxServiceID.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxServiceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxServiceID.Location = New System.Drawing.Point(55, 4)
        Me.TextBoxServiceID.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxServiceID.Name = "TextBoxServiceID"
        Me.TextBoxServiceID.ReadOnly = True
        Me.TextBoxServiceID.Size = New System.Drawing.Size(125, 30)
        Me.TextBoxServiceID.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Splitter1.Location = New System.Drawing.Point(188, 4)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(12, 34)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'LabelPropertyID
        '
        Me.LabelPropertyID.AutoSize = True
        Me.LabelPropertyID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPropertyID.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.LabelPropertyID.Location = New System.Drawing.Point(208, 0)
        Me.LabelPropertyID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPropertyID.Name = "LabelPropertyID"
        Me.LabelPropertyID.Size = New System.Drawing.Size(45, 24)
        Me.LabelPropertyID.TabIndex = 5
        Me.LabelPropertyID.Text = "PID:"
        Me.LabelPropertyID.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TextBoxPropertyID
        '
        Me.TextBoxPropertyID.BackColor = System.Drawing.Color.LightGray
        Me.TextBoxPropertyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPropertyID.Location = New System.Drawing.Point(261, 4)
        Me.TextBoxPropertyID.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPropertyID.Name = "TextBoxPropertyID"
        Me.TextBoxPropertyID.ReadOnly = True
        Me.TextBoxPropertyID.Size = New System.Drawing.Size(125, 30)
        Me.TextBoxPropertyID.TabIndex = 6
        '
        'LabelInspectionType
        '
        Me.LabelInspectionType.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInspectionType.ForeColor = System.Drawing.Color.White
        Me.LabelInspectionType.Location = New System.Drawing.Point(392, 0)
        Me.LabelInspectionType.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelInspectionType.Name = "LabelInspectionType"
        Me.LabelInspectionType.Size = New System.Drawing.Size(588, 42)
        Me.LabelInspectionType.TabIndex = 14
        Me.LabelInspectionType.Text = "Import Excel file to begin."
        Me.LabelInspectionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelAddress
        '
        Me.LabelAddress.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAddress.ForeColor = System.Drawing.Color.White
        Me.LabelAddress.Location = New System.Drawing.Point(984, 0)
        Me.LabelAddress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Size = New System.Drawing.Size(306, 42)
        Me.LabelAddress.TabIndex = 40
        Me.LabelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonImageCurrentStatus
        '
        Me.ButtonImageCurrentStatus.BackColor = System.Drawing.Color.Transparent
        Me.ButtonImageCurrentStatus.FlatAppearance.BorderSize = 0
        Me.ButtonImageCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImageCurrentStatus.ImageIndex = 0
        Me.ButtonImageCurrentStatus.Location = New System.Drawing.Point(2, 44)
        Me.ButtonImageCurrentStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonImageCurrentStatus.Name = "ButtonImageCurrentStatus"
        Me.ButtonImageCurrentStatus.Size = New System.Drawing.Size(59, 40)
        Me.ButtonImageCurrentStatus.TabIndex = 13
        Me.ButtonImageCurrentStatus.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.ButtonImageCurrentStatus.UseVisualStyleBackColor = False
        '
        'Uploader
        '
        Me.Uploader.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Uploader.Controls.Add(Me.CheckTestMode)
        Me.Uploader.Controls.Add(Me.LabelUploader)
        Me.Uploader.Controls.Add(Me.ProgressBarUploader)
        Me.Uploader.Controls.Add(Me.Panel4)
        Me.Uploader.Controls.Add(Me.Label4)
        Me.Uploader.Controls.Add(Me.Label3)
        Me.Uploader.Controls.Add(Me.Label1)
        Me.Uploader.Controls.Add(Me.TextBoxPassword)
        Me.Uploader.Controls.Add(Me.TextBoxUsername)
        Me.Uploader.Controls.Add(Me.Button1)
        Me.Uploader.Controls.Add(Me.dateSelector)
        Me.Uploader.Location = New System.Drawing.Point(4, 25)
        Me.Uploader.Margin = New System.Windows.Forms.Padding(2)
        Me.Uploader.Name = "Uploader"
        Me.Uploader.Size = New System.Drawing.Size(1362, 751)
        Me.Uploader.TabIndex = 3
        Me.Uploader.Text = "Uploader"
        '
        'CheckTestMode
        '
        Me.CheckTestMode.AutoSize = True
        Me.CheckTestMode.ForeColor = System.Drawing.Color.White
        Me.CheckTestMode.Location = New System.Drawing.Point(34, 269)
        Me.CheckTestMode.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckTestMode.Name = "CheckTestMode"
        Me.CheckTestMode.Size = New System.Drawing.Size(142, 21)
        Me.CheckTestMode.TabIndex = 11
        Me.CheckTestMode.Text = "Run in Test Mode"
        Me.CheckTestMode.UseVisualStyleBackColor = True
        '
        'LabelUploader
        '
        Me.LabelUploader.AutoSize = True
        Me.LabelUploader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUploader.ForeColor = System.Drawing.Color.White
        Me.LabelUploader.Location = New System.Drawing.Point(30, 554)
        Me.LabelUploader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelUploader.Name = "LabelUploader"
        Me.LabelUploader.Size = New System.Drawing.Size(78, 17)
        Me.LabelUploader.TabIndex = 10
        Me.LabelUploader.Text = "Progress:"
        Me.LabelUploader.Visible = False
        '
        'ProgressBarUploader
        '
        Me.ProgressBarUploader.Location = New System.Drawing.Point(34, 576)
        Me.ProgressBarUploader.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBarUploader.Name = "ProgressBarUploader"
        Me.ProgressBarUploader.Size = New System.Drawing.Size(201, 29)
        Me.ProgressBarUploader.TabIndex = 9
        Me.ProgressBarUploader.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.WebBrowser1)
        Me.Panel4.Location = New System.Drawing.Point(281, 26)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1041, 703)
        Me.Panel4.TabIndex = 8
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(2, 2)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(2)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1038, 697)
        Me.WebBrowser1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(29, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 22)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Spectrum Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 84)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 22)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Spectrum Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 22)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Service Completed Date:"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxPassword.Location = New System.Drawing.Point(32, 172)
        Me.TextBoxPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(200, 24)
        Me.TextBoxPassword.TabIndex = 4
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxUsername.Location = New System.Drawing.Point(32, 109)
        Me.TextBoxUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(200, 24)
        Me.TextBoxUsername.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(34, 215)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(201, 48)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Start Auto-Uploader"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dateSelector
        '
        Me.dateSelector.Checked = False
        Me.dateSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateSelector.Location = New System.Drawing.Point(32, 51)
        Me.dateSelector.Margin = New System.Windows.Forms.Padding(2)
        Me.dateSelector.Name = "dateSelector"
        Me.dateSelector.Size = New System.Drawing.Size(200, 24)
        Me.dateSelector.TabIndex = 1
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Actions-document-save-as-icon.png")
        Me.ImageList2.Images.SetKeyName(1, "1454248880_add-to-database.png")
        Me.ImageList2.Images.SetKeyName(2, "1454248898_remove-from-database.png")
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "Actions-dialog-ok-apply-icon.png")
        Me.ImageList3.Images.SetKeyName(1, "Actions-application-exit-icon.png")
        Me.ImageList3.Images.SetKeyName(2, "1454341672_accept-database.png")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1145, 843)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(250, 30)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.AutoSize = False
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(30, 40)
        Me.OpenToolStripButton.Text = "&Open"
        Me.OpenToolStripButton.ToolTipText = "Open Excel File"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(40, 50)
        Me.ToolStripButton1.Text = "Exit Form Fucker"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(24, 28)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        Me.ToolStripButton2.ToolTipText = "Minimize"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1395, 31)
        Me.ToolStrip1.TabIndex = 1
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(24, 28)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        Me.ToolStripButton3.ToolTipText = "Open Photo Directory"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'ServiceOrdersTableAdapter1
        '
        Me.ServiceOrdersTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.ServiceOrdersTableAdapter = Me.ServiceOrdersTableAdapter1
        Me.TableAdapterManager1.UpdateOrder = FF_v3.FF_DBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FF_PresetsDataSet1
        '
        Me.FF_PresetsDataSet1.DataSetName = "FF_PresetsDataSet"
        Me.FF_PresetsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StandardInspectionsTableAdapter1
        '
        Me.StandardInspectionsTableAdapter1.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1395, 873)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabDatabaseView.ResumeLayout(False)
        CType(Me.DataGridDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiceOrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FF_DBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCurrentDataset.ResumeLayout(False)
        Me.TabCurrentDataset.PerformLayout()
        CType(Me.DataGridExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDataInput.ResumeLayout(False)
        Me.TabDataInput.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.BindingNavigatorExcelSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorExcelSheet.ResumeLayout(False)
        Me.BindingNavigatorExcelSheet.PerformLayout()
        Me.PanelWellsFargo1.ResumeLayout(False)
        Me.PanelWellsFargo2.ResumeLayout(False)
        Me.PanelWellsFargo2.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.BindingNavigatorStandardInspectionPresets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigatorStandardInspectionPresets.ResumeLayout(False)
        Me.BindingNavigatorStandardInspectionPresets.PerformLayout()
        CType(Me.BindingSourcePresets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.FlowLayoutPanel4.PerformLayout()
        Me.Uploader.ResumeLayout(False)
        Me.Uploader.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FF_PresetsDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents StatusStrip1 As StatusStrip

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents FF_DBDataSet As FF_DBDataSet
    Friend WithEvents ServiceIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropertyIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InspectionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ConstructionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OccupantTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GarageTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropertyConditionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SpokeWithDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DeterminedByDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ServiceOrdersTableAdapter1 As FF_DBDataSetTableAdapters.ServiceOrdersTableAdapter
    Friend WithEvents TableAdapterManager1 As FF_DBDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents StatusLabelNumberCompleted As ToolStripStatusLabel
    Private WithEvents TabDatabaseView As TabPage
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents MoveFirstDB As ToolStripButton
    Friend WithEvents MovePreviousDB As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents MoveNextDB As ToolStripButton
    Friend WithEvents MoveLastDB As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents TabCurrentDataset As TabPage
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents LabelCurrentFile As Label
    Friend WithEvents DataGridExcel As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabDataInput As TabPage
    Friend WithEvents BindingNavigatorExcelSheet As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem1 As ToolStripLabel
    Friend WithEvents MoveFirstExcel As ToolStripButton
    Friend WithEvents MovePreviousExcel As ToolStripButton
    Friend WithEvents BindingNavigatorPositionItem1 As ToolStripTextBox
    Friend WithEvents MoveNextExcel As ToolStripButton
    Friend WithEvents MoveLastExcel As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BindingNavigatorStandardInspectionPresets As BindingNavigator
    Friend WithEvents Move_PreviousStandardPresets As ToolStripButton
    Friend WithEvents MoveNextStandardPresets As ToolStripButton
    Friend WithEvents ButtonApplyPreset As ToolStripButton
    Friend WithEvents ButtonDeletePreset As ToolStripButton
    Friend WithEvents ListBoxStandardInspectionPresets As ListBox
    Friend WithEvents FlowLayoutPanel4 As FlowLayoutPanel
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents TextBoxServiceID As TextBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents LabelPropertyID As Label
    Friend WithEvents TextBoxPropertyID As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LabelOccupancy As Label
    Friend WithEvents ComboOccupantType As ComboBox
    Friend WithEvents LabelDeterminedBy As Label
    Friend WithEvents ComboDeterminedBy As ComboBox
    Friend WithEvents LabelPropertyType As Label
    Friend WithEvents ComboPropertyType As ComboBox
    Friend WithEvents LabelConstructionType As Label
    Friend WithEvents ComboConstructionType As ComboBox
    Friend WithEvents LabelGarageType As Label
    Friend WithEvents ComboGarageType As ComboBox
    Friend WithEvents LabelPropertyCondition As Label
    Friend WithEvents ComboPropertyCondition As ComboBox
    Friend WithEvents LabelSpokeWith As Label
    Friend WithEvents ComboSpokeWith As ComboBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents PanelWellsFargo1 As FlowLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents PanelWellsFargo2 As FlowLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents LabelRoofType As Label
    Friend WithEvents ComboRoofType As ComboBox
    Friend WithEvents LabelLandscapeType As Label
    Friend WithEvents ComboLandscapeType As ComboBox
    Friend WithEvents LabelGrassHeight As Label
    Friend WithEvents ComboGrassHeight As ComboBox
    Friend WithEvents LabelLandscapeCondition As Label
    Friend WithEvents ComboLandscapeCondition As ComboBox
    Friend WithEvents LabelPropertyHabitable As Label
    Friend WithEvents ComboPropertyHabitable As ComboBox
    Friend WithEvents CheckEscalatedEvents As CheckBox
    Friend WithEvents TextBoxEscalatedEvents As TextBox
    Friend WithEvents LabelPropertyForSale As Label
    Friend WithEvents ComboPropertyForSale As ComboBox
    Friend WithEvents LabelBrokerName As Label
    Friend WithEvents TextBoxBrokerName As TextBox
    Friend WithEvents LabelBrokerNumber As Label
    Friend WithEvents TextBoxBrokerNumber As TextBox
    Friend WithEvents CheckPropertyUnsecure As CheckBox
    Friend WithEvents CheckHighVandalismArea As CheckBox
    Friend WithEvents LabelLocationType As Label
    Friend WithEvents ComboLocationType As ComboBox
    Friend WithEvents LabelNeighborhoodStatus As Label
    Friend WithEvents ComboNeighborhoodStatus As ComboBox
    Friend WithEvents LabelRoofDamages As Label
    Friend WithEvents ComboRoofDamages As ComboBox
    Friend WithEvents LabelNeighborhoodIssues As Label
    Friend WithEvents ComboNeighborhoodIssues As ComboBox
    Friend WithEvents LabelSecurityIssues As Label
    Friend WithEvents ComboSecurityIssues As ComboBox
    Friend WithEvents CheckGatedCommunity As CheckBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButtonMarkComplete As ToolStripButton
    Friend WithEvents ButtonRevertCompletion As ToolStripButton
    Friend WithEvents ButtonAddPreset As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents ButtonImageCurrentStatus As Button
    Friend WithEvents LabelInspectionType As Label
    Friend WithEvents LabelPresetManager As Label
    Friend WithEvents LabelNoContactInspections As Label
    Friend WithEvents LabelComment As Label
    Friend WithEvents LabelWellsFargoInspections As Label
    Friend WithEvents LabelGlobalDetails As Label
    Friend WithEvents LabelStandardInspections As Label
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents PropertyTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropertyForSaleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BrokerNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BrokerNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LocationTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NeighborhoodStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NeighborhoodIssuesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RoofTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RoofDamageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LandscapeTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LandscapeConditionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GrassHeightDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SeccurityIssuesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropertyHabitableDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PropertyUnsecureDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GatedCommunityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HighVandalismAreaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EscalatedEventsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExcalatedEventsTextDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RoofDamagesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SecurityIssuesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EscalatedEventsTextDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListBoxOccupancyIndicators As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents QuickActions As ToolStripMenuItem
    Friend WithEvents LabelNeighborHouseNumber As Label
    Friend WithEvents TextBoxNeighborHouseNumber As TextBox
    Friend WithEvents ButtonDoneEditing As Button
    Friend WithEvents ImageList4 As ImageList
    Friend WithEvents ButtonCancelEditing As Button
    Friend WithEvents ToolStripMenuItemEditCompletion As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemGenerateNewComment As ToolStripMenuItem
    Friend WithEvents ViewShortcutsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FF_DBDataSet1 As FF_DBDataSet
    Friend WithEvents DataGridDatabase As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents LabelCommentGenerator As Label
    Friend WithEvents Uploader As TabPage
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents dateSelector As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents OpenToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelUploader As Label
    Friend WithEvents ProgressBarUploader As ProgressBar
    Friend WithEvents CheckTestMode As CheckBox
    Friend WithEvents ViewSupportedInspectionTypesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBoxNoHouseNumber As CheckBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents LabelPhotos As Label
    Friend WithEvents ButtonNextPhoto As Button
    Friend WithEvents ButtonPreviousPhoto As Button
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ListBoxFiles As ListBox
    Friend WithEvents LabelAddress As Label
    Friend WithEvents FF_PresetsDataSet1 As FF_PresetsDataSet
    Friend WithEvents StandardInspectionsTableAdapter1 As FF_PresetsDataSetTableAdapters.StandardInspectionsTableAdapter
    Friend WithEvents BindingSourcePresets As BindingSource
    Friend WithEvents ServiceOrdersBindingSource As BindingSource
    Friend WithEvents Panel15 As Panel
    Friend WithEvents CheckBoxMarkNoAccess As CheckBox
    Friend WithEvents ComboBoxNoAccess As ComboBox
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn
    Friend WithEvents OccupancyIndicatorsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NeighborHouseNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NoHouseNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NoAccessDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NoAccessReasonDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
