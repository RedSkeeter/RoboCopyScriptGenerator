<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SourcePanel = New System.Windows.Forms.Panel()
        Me.SourceSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SourceTreeView = New System.Windows.Forms.TreeView()
        Me.AssetsImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SourceListView = New System.Windows.Forms.ListView()
        Me.SourceFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SourceFileStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SourceFileLastUpdated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SourceFileRelativeAge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SourceDirectoryToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DestinationSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.DestinationTreeView = New System.Windows.Forms.TreeView()
        Me.DestinationListView = New System.Windows.Forms.ListView()
        Me.DestinationFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DestinationFileStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DestinationFileLastUpdated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DestinationFileRelativeAge = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.DestinationDirectoryToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MapDriveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteSelectedDestinationFilesToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.RefreshDestinationListViewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CompareToSourceToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ScriptPanel = New System.Windows.Forms.Panel()
        Me.ScriptTextBox = New System.Windows.Forms.TextBox()
        Me.ScriptToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SwitchesToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RunScriptToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenTerminalToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.WrapToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MainSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.DestinationListViewMenuContextStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SourcePanel.SuspendLayout()
        CType(Me.SourceSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SourceSplitContainer.Panel1.SuspendLayout()
        Me.SourceSplitContainer.Panel2.SuspendLayout()
        Me.SourceSplitContainer.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DestinationSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DestinationSplitContainer.Panel1.SuspendLayout()
        Me.DestinationSplitContainer.Panel2.SuspendLayout()
        Me.DestinationSplitContainer.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ScriptPanel.SuspendLayout()
        Me.ScriptToolStrip.SuspendLayout()
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitContainer.Panel1.SuspendLayout()
        Me.MainSplitContainer.Panel2.SuspendLayout()
        Me.MainSplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SourcePanel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Size = New System.Drawing.Size(997, 519)
        Me.SplitContainer1.SplitterDistance = 512
        Me.SplitContainer1.TabIndex = 0
        '
        'SourcePanel
        '
        Me.SourcePanel.Controls.Add(Me.SourceSplitContainer)
        Me.SourcePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourcePanel.Location = New System.Drawing.Point(0, 27)
        Me.SourcePanel.Name = "SourcePanel"
        Me.SourcePanel.Size = New System.Drawing.Size(512, 492)
        Me.SourcePanel.TabIndex = 2
        '
        'SourceSplitContainer
        '
        Me.SourceSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourceSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SourceSplitContainer.Name = "SourceSplitContainer"
        '
        'SourceSplitContainer.Panel1
        '
        Me.SourceSplitContainer.Panel1.Controls.Add(Me.SourceTreeView)
        '
        'SourceSplitContainer.Panel2
        '
        Me.SourceSplitContainer.Panel2.Controls.Add(Me.SourceListView)
        Me.SourceSplitContainer.Size = New System.Drawing.Size(512, 492)
        Me.SourceSplitContainer.SplitterDistance = 244
        Me.SourceSplitContainer.TabIndex = 0
        '
        'SourceTreeView
        '
        Me.SourceTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourceTreeView.ImageIndex = 0
        Me.SourceTreeView.ImageList = Me.AssetsImageList
        Me.SourceTreeView.Location = New System.Drawing.Point(0, 0)
        Me.SourceTreeView.Name = "SourceTreeView"
        Me.SourceTreeView.SelectedImageIndex = 0
        Me.SourceTreeView.Size = New System.Drawing.Size(244, 492)
        Me.SourceTreeView.TabIndex = 0
        '
        'AssetsImageList
        '
        Me.AssetsImageList.ImageStream = CType(resources.GetObject("AssetsImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.AssetsImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.AssetsImageList.Images.SetKeyName(0, "Drive")
        Me.AssetsImageList.Images.SetKeyName(1, "Drive_Error")
        Me.AssetsImageList.Images.SetKeyName(2, "Folder")
        Me.AssetsImageList.Images.SetKeyName(3, "Folder_Error")
        Me.AssetsImageList.Images.SetKeyName(4, "File")
        Me.AssetsImageList.Images.SetKeyName(5, "File_Error")
        Me.AssetsImageList.Images.SetKeyName(6, "Drive_Mapped")
        '
        'SourceListView
        '
        Me.SourceListView.AllowColumnReorder = True
        Me.SourceListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.SourceFileName, Me.SourceFileStatus, Me.SourceFileLastUpdated, Me.SourceFileRelativeAge})
        Me.SourceListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourceListView.LargeImageList = Me.AssetsImageList
        Me.SourceListView.Location = New System.Drawing.Point(0, 0)
        Me.SourceListView.Name = "SourceListView"
        Me.SourceListView.Size = New System.Drawing.Size(264, 492)
        Me.SourceListView.SmallImageList = Me.AssetsImageList
        Me.SourceListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.SourceListView.StateImageList = Me.AssetsImageList
        Me.SourceListView.TabIndex = 1
        Me.SourceListView.UseCompatibleStateImageBehavior = False
        Me.SourceListView.View = System.Windows.Forms.View.Details
        '
        'SourceFileName
        '
        Me.SourceFileName.Text = "Name"
        Me.SourceFileName.Width = 255
        '
        'SourceFileStatus
        '
        Me.SourceFileStatus.Text = "Status"
        '
        'SourceFileLastUpdated
        '
        Me.SourceFileLastUpdated.Text = "Last updated"
        Me.SourceFileLastUpdated.Width = 150
        '
        'SourceFileRelativeAge
        '
        Me.SourceFileRelativeAge.Text = "Relative age"
        Me.SourceFileRelativeAge.Width = 100
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SourceDirectoryToolStripTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(512, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SourceDirectoryToolStripTextBox
        '
        Me.SourceDirectoryToolStripTextBox.Name = "SourceDirectoryToolStripTextBox"
        Me.SourceDirectoryToolStripTextBox.Size = New System.Drawing.Size(400, 27)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DestinationSplitContainer)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(481, 490)
        Me.Panel2.TabIndex = 1
        '
        'DestinationSplitContainer
        '
        Me.DestinationSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DestinationSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.DestinationSplitContainer.Name = "DestinationSplitContainer"
        '
        'DestinationSplitContainer.Panel1
        '
        Me.DestinationSplitContainer.Panel1.Controls.Add(Me.DestinationTreeView)
        '
        'DestinationSplitContainer.Panel2
        '
        Me.DestinationSplitContainer.Panel2.Controls.Add(Me.DestinationListView)
        Me.DestinationSplitContainer.Size = New System.Drawing.Size(481, 490)
        Me.DestinationSplitContainer.SplitterDistance = 160
        Me.DestinationSplitContainer.TabIndex = 0
        '
        'DestinationTreeView
        '
        Me.DestinationTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DestinationTreeView.ImageIndex = 0
        Me.DestinationTreeView.ImageList = Me.AssetsImageList
        Me.DestinationTreeView.Location = New System.Drawing.Point(0, 0)
        Me.DestinationTreeView.Name = "DestinationTreeView"
        Me.DestinationTreeView.SelectedImageIndex = 0
        Me.DestinationTreeView.Size = New System.Drawing.Size(160, 490)
        Me.DestinationTreeView.TabIndex = 0
        '
        'DestinationListView
        '
        Me.DestinationListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DestinationFileName, Me.DestinationFileStatus, Me.DestinationFileLastUpdated, Me.DestinationFileRelativeAge})
        Me.DestinationListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DestinationListView.LargeImageList = Me.AssetsImageList
        Me.DestinationListView.Location = New System.Drawing.Point(0, 0)
        Me.DestinationListView.Name = "DestinationListView"
        Me.DestinationListView.Size = New System.Drawing.Size(317, 490)
        Me.DestinationListView.SmallImageList = Me.AssetsImageList
        Me.DestinationListView.StateImageList = Me.AssetsImageList
        Me.DestinationListView.TabIndex = 0
        Me.DestinationListView.UseCompatibleStateImageBehavior = False
        Me.DestinationListView.View = System.Windows.Forms.View.Details
        '
        'DestinationFileName
        '
        Me.DestinationFileName.Text = "Name"
        Me.DestinationFileName.Width = 255
        '
        'DestinationFileStatus
        '
        Me.DestinationFileStatus.Text = "Status"
        '
        'DestinationFileLastUpdated
        '
        Me.DestinationFileLastUpdated.Text = "Last updated"
        Me.DestinationFileLastUpdated.Width = 150
        '
        'DestinationFileRelativeAge
        '
        Me.DestinationFileRelativeAge.Text = "Relative age"
        Me.DestinationFileRelativeAge.Width = 100
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.DestinationDirectoryToolStripTextBox, Me.MapDriveToolStripButton, Me.DeleteSelectedDestinationFilesToolStripButton, Me.RefreshDestinationListViewToolStripButton, Me.ToolStripSeparator5, Me.ToolStripSeparator6, Me.CompareToSourceToolStripButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(481, 29)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(88, 26)
        Me.ToolStripLabel2.Text = "Destination:"
        '
        'DestinationDirectoryToolStripTextBox
        '
        Me.DestinationDirectoryToolStripTextBox.Name = "DestinationDirectoryToolStripTextBox"
        Me.DestinationDirectoryToolStripTextBox.Size = New System.Drawing.Size(400, 27)
        '
        'MapDriveToolStripButton
        '
        Me.MapDriveToolStripButton.Image = CType(resources.GetObject("MapDriveToolStripButton.Image"), System.Drawing.Image)
        Me.MapDriveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MapDriveToolStripButton.Name = "MapDriveToolStripButton"
        Me.MapDriveToolStripButton.Size = New System.Drawing.Size(105, 24)
        Me.MapDriveToolStripButton.Text = "Map drive..."
        '
        'DeleteSelectedDestinationFilesToolStripButton
        '
        Me.DeleteSelectedDestinationFilesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteSelectedDestinationFilesToolStripButton.Image = CType(resources.GetObject("DeleteSelectedDestinationFilesToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteSelectedDestinationFilesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteSelectedDestinationFilesToolStripButton.Name = "DeleteSelectedDestinationFilesToolStripButton"
        Me.DeleteSelectedDestinationFilesToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.DeleteSelectedDestinationFilesToolStripButton.Text = "Delete"
        Me.DeleteSelectedDestinationFilesToolStripButton.ToolTipText = "Delete selected file"
        '
        'RefreshDestinationListViewToolStripButton
        '
        Me.RefreshDestinationListViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RefreshDestinationListViewToolStripButton.Image = CType(resources.GetObject("RefreshDestinationListViewToolStripButton.Image"), System.Drawing.Image)
        Me.RefreshDestinationListViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshDestinationListViewToolStripButton.Name = "RefreshDestinationListViewToolStripButton"
        Me.RefreshDestinationListViewToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.RefreshDestinationListViewToolStripButton.Text = "Refresh"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'CompareToSourceToolStripButton
        '
        Me.CompareToSourceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CompareToSourceToolStripButton.Image = CType(resources.GetObject("CompareToSourceToolStripButton.Image"), System.Drawing.Image)
        Me.CompareToSourceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CompareToSourceToolStripButton.Name = "CompareToSourceToolStripButton"
        Me.CompareToSourceToolStripButton.Size = New System.Drawing.Size(23, 20)
        Me.CompareToSourceToolStripButton.Text = "Compare to source"
        Me.CompareToSourceToolStripButton.ToolTipText = "Compare destination files to source"
        '
        'ScriptPanel
        '
        Me.ScriptPanel.Controls.Add(Me.ScriptTextBox)
        Me.ScriptPanel.Controls.Add(Me.ScriptToolStrip)
        Me.ScriptPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScriptPanel.Location = New System.Drawing.Point(0, 0)
        Me.ScriptPanel.Name = "ScriptPanel"
        Me.ScriptPanel.Size = New System.Drawing.Size(997, 81)
        Me.ScriptPanel.TabIndex = 1
        '
        'ScriptTextBox
        '
        Me.ScriptTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ScriptTextBox.Font = New System.Drawing.Font("Courier New", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScriptTextBox.Location = New System.Drawing.Point(0, 27)
        Me.ScriptTextBox.Multiline = True
        Me.ScriptTextBox.Name = "ScriptTextBox"
        Me.ScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ScriptTextBox.Size = New System.Drawing.Size(997, 54)
        Me.ScriptTextBox.TabIndex = 0
        Me.ScriptTextBox.WordWrap = False
        '
        'ScriptToolStrip
        '
        Me.ScriptToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SwitchesToolStripTextBox, Me.ToolStripSeparator4, Me.ToolStripSeparator1, Me.RunScriptToolStripButton, Me.ToolStripSeparator2, Me.OpenTerminalToolStripButton, Me.ToolStripSeparator3, Me.WrapToolStripButton})
        Me.ScriptToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ScriptToolStrip.Name = "ScriptToolStrip"
        Me.ScriptToolStrip.Size = New System.Drawing.Size(997, 27)
        Me.ScriptToolStrip.TabIndex = 1
        Me.ScriptToolStrip.Text = "Robocopy script"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 24)
        Me.ToolStripLabel1.Text = "Switches"
        '
        'SwitchesToolStripTextBox
        '
        Me.SwitchesToolStripTextBox.Name = "SwitchesToolStripTextBox"
        Me.SwitchesToolStripTextBox.Size = New System.Drawing.Size(400, 27)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'RunScriptToolStripButton
        '
        Me.RunScriptToolStripButton.Image = CType(resources.GetObject("RunScriptToolStripButton.Image"), System.Drawing.Image)
        Me.RunScriptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RunScriptToolStripButton.Name = "RunScriptToolStripButton"
        Me.RunScriptToolStripButton.Size = New System.Drawing.Size(178, 24)
        Me.RunScriptToolStripButton.Text = "Run script in terminal..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'OpenTerminalToolStripButton
        '
        Me.OpenTerminalToolStripButton.Image = CType(resources.GetObject("OpenTerminalToolStripButton.Image"), System.Drawing.Image)
        Me.OpenTerminalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenTerminalToolStripButton.Name = "OpenTerminalToolStripButton"
        Me.OpenTerminalToolStripButton.Size = New System.Drawing.Size(179, 24)
        Me.OpenTerminalToolStripButton.Text = "Open empty terminal..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'WrapToolStripButton
        '
        Me.WrapToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.WrapToolStripButton.Image = CType(resources.GetObject("WrapToolStripButton.Image"), System.Drawing.Image)
        Me.WrapToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.WrapToolStripButton.Name = "WrapToolStripButton"
        Me.WrapToolStripButton.Size = New System.Drawing.Size(74, 24)
        Me.WrapToolStripButton.Text = " Wrap on"
        '
        'MainSplitContainer
        '
        Me.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.MainSplitContainer.Name = "MainSplitContainer"
        Me.MainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'MainSplitContainer.Panel1
        '
        Me.MainSplitContainer.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'MainSplitContainer.Panel2
        '
        Me.MainSplitContainer.Panel2.Controls.Add(Me.ScriptPanel)
        Me.MainSplitContainer.Size = New System.Drawing.Size(997, 604)
        Me.MainSplitContainer.SplitterDistance = 519
        Me.MainSplitContainer.TabIndex = 0
        '
        'DestinationListViewMenuContextStrip
        '
        Me.DestinationListViewMenuContextStrip.Name = "DestinationListViewMenuContextStrip"
        Me.DestinationListViewMenuContextStrip.Size = New System.Drawing.Size(61, 4)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 604)
        Me.Controls.Add(Me.MainSplitContainer)
        Me.Name = "Form1"
        Me.Text = "RoboCopy Script Generator"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SourcePanel.ResumeLayout(False)
        Me.SourceSplitContainer.Panel1.ResumeLayout(False)
        Me.SourceSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SourceSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SourceSplitContainer.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.DestinationSplitContainer.Panel1.ResumeLayout(False)
        Me.DestinationSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.DestinationSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DestinationSplitContainer.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ScriptPanel.ResumeLayout(False)
        Me.ScriptPanel.PerformLayout()
        Me.ScriptToolStrip.ResumeLayout(False)
        Me.ScriptToolStrip.PerformLayout()
        Me.MainSplitContainer.Panel1.ResumeLayout(False)
        Me.MainSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SourcePanel As System.Windows.Forms.Panel
    Friend WithEvents SourceSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents SourceTreeView As System.Windows.Forms.TreeView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DestinationSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents DestinationTreeView As System.Windows.Forms.TreeView
    Friend WithEvents DestinationListView As System.Windows.Forms.ListView
    Friend WithEvents ScriptPanel As System.Windows.Forms.Panel
    Friend WithEvents ScriptTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SourceListView As System.Windows.Forms.ListView
    Friend WithEvents SourceFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents AssetsImageList As System.Windows.Forms.ImageList
    Friend WithEvents DestinationFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SourceDirectoryToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents DestinationDirectoryToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ScriptToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents WrapToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents MainSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents MapDriveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DestinationFileStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents SourceFileStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents SourceFileLastUpdated As System.Windows.Forms.ColumnHeader
    Friend WithEvents DestinationFileLastUpdated As System.Windows.Forms.ColumnHeader
    Friend WithEvents DestinationFileRelativeAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeleteSelectedDestinationFilesToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DestinationListViewMenuContextStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RunScriptToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenTerminalToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SwitchesToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshDestinationListViewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SourceFileRelativeAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CompareToSourceToolStripButton As System.Windows.Forms.ToolStripButton

End Class
