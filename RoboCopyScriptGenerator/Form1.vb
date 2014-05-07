Imports System.IO
Imports System.Windows.Forms.ListView

Public Class Form1

    Dim FilesList As String = vbNewLine
    Dim SourceDirectory As String = ""
    Dim DestinationDirectory As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDirectoryTrees()
    End Sub

    Private Sub SourceTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles SourceTreeView.NodeMouseClick
        Me.SourceDirectoryToolStripTextBox.Text = e.Node.Tag
        SourceDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadDirectories(e.Node, Me.SourceListView)
            LoadFiles(Me.SourceListView, e.Node.Tag)
            BuildScript()
            CompareDirectories()
        End If
    End Sub

    Private Sub DestinationTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles DestinationTreeView.NodeMouseClick
        Me.DestinationDirectoryToolStripTextBox.Text = e.Node.Tag
        DestinationDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadDirectories(e.Node, Me.DestinationListView)
            LoadFiles(Me.DestinationListView, e.Node.Tag)
            BuildScript()
            CompareDirectories()
        End If
    End Sub

    Private Sub LoadDirectoryTrees()
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()

        Dim SourceFavoritesNode As New TreeNode("Favorite directories", 0, 0)
        Me.SourceTreeView.Nodes.Add(SourceFavoritesNode)

        Dim DestinationFavoritesNode As New TreeNode("Favorite directories", 0, 0)
        Me.DestinationTreeView.Nodes.Add(DestinationFavoritesNode)

        Try
            Dim FavoriteDirectories() As String = My.Settings.FavoriteDirectories.Split(",")
            For Each FavoriteDirectory As String In FavoriteDirectories
                If My.Computer.FileSystem.DirectoryExists(FavoriteDirectory) Then
                    Dim DirInfo As New DirectoryInfo(FavoriteDirectory)
                    Dim SourceFavoriteTreenode As New TreeNode(DirInfo.FullName)
                    SourceFavoriteTreenode.Tag = DirInfo.FullName
                    SourceFavoriteTreenode.SelectedImageKey = "Drive_Mapped"
                    SourceFavoriteTreenode.StateImageKey = "Drive_Mapped"
                    SourceFavoritesNode.Nodes.Add(SourceFavoriteTreenode)

                    Dim DestinationFavoriteTreenode As New TreeNode(DirInfo.FullName)
                    DestinationFavoriteTreenode.Tag = DirInfo.FullName
                    DestinationFavoriteTreenode.SelectedImageKey = "Drive_Mapped"
                    DestinationFavoriteTreenode.StateImageKey = "Drive_Mapped"
                    DestinationFavoritesNode.Nodes.Add(DestinationFavoriteTreenode)
                End If
            Next
        Catch ex As Exception
            Me.ScriptTextBox.Text = ex.Message
        End Try

        Try
            For Each Drive As DriveInfo In AllDrives
                Dim SourceDriveTreenode As New TreeNode(Drive.Name & " " & Drive.VolumeLabel)
                SourceDriveTreenode.Tag = Drive.Name
                SourceDriveTreenode.SelectedImageKey = "Drive"
                SourceDriveTreenode.StateImageKey = "Drive"
                Me.SourceTreeView.Nodes.Add(SourceDriveTreenode)

                Dim DestinationDriveTreenode As New TreeNode(Drive.Name & " " & Drive.VolumeLabel)
                DestinationDriveTreenode.Tag = Drive.Name
                DestinationDriveTreenode.SelectedImageKey = "Drive"
                DestinationDriveTreenode.StateImageKey = "Drive"
                Me.DestinationTreeView.Nodes.Add(DestinationDriveTreenode)
            Next
        Catch ex As Exception
            Me.ScriptTextBox.Text = ex.Message
        End Try

    End Sub

    Private Sub LoadDirectories(ByVal Treenode As TreeNode, ByVal ListView As ListView)
        Dim Directory As String = Treenode.Tag
        If My.Computer.FileSystem.DirectoryExists(Directory) Then
            Try
                'load the directories
                For Each SubDir As String In My.Computer.FileSystem.GetDirectories(Directory)
                    Dim DirInfo As New DirectoryInfo(SubDir)

                    Dim SubDirTreenode As New TreeNode(DirInfo.Name, 2, 2)
                    SubDirTreenode.Tag = DirInfo.FullName

                    Treenode.Nodes.Add(SubDirTreenode)
                    Treenode.Expand()

                    Dim DirectoryListViewItem As New ListViewItem(Directory, 2)
                    ListView.Items.Add(DirectoryListViewItem)
                Next

                LoadFiles(ListView, Directory)

            Catch ex As Exception
                MsgBox(Treenode.Text & "(" & ex.Message & ")")
                Treenode.StateImageIndex = 3
            End Try
        Else
            Treenode.StateImageKey = "Folder_Error"
            Treenode.Text = Treenode.Text & "(missing)"
        End If
    End Sub

    Private Sub LoadFiles(ByVal ListView As ListView, ByVal Directory As String)
        If My.Computer.FileSystem.DirectoryExists(Directory) Then
            'load the directory's files into the listbox
            ListView.Items.Clear()
            Try
                For Each File As String In My.Computer.FileSystem.GetFiles(Directory)
                    Dim FileInfo As New FileInfo(File)
                    Dim FileListViewItem As New ListViewItem(FileInfo.Name, 4)
                    FileListViewItem.SubItems.Add("") 'status
                    FileListViewItem.SubItems.Add(FileInfo.LastWriteTime) 'last updated
                    FileListViewItem.SubItems.Add("") 'relative age
                    ListView.Items.Add(FileListViewItem)
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Could not refresh the destination files list.  The directory " & Directory & " does not exist.")
        End If
    End Sub

    Private Sub CompareDirectories()
        Dim SourcePath As String = Me.SourceDirectoryToolStripTextBox.Text.Trim
        Dim DestinationPath As String = Me.DestinationDirectoryToolStripTextBox.Text.Trim
        If My.Computer.FileSystem.DirectoryExists(SourcePath) And My.Computer.FileSystem.DirectoryExists(DestinationPath) Then
            For Each SourceFile As ListViewItem In Me.SourceListView.Items
                Dim SFName As String = SourceFile.Text
                Dim SFileInfo As New FileInfo(SourcePath & "\" & SFName)
                Dim SFStatus As String
                Dim SF
                For Each DestinationFile As ListViewItem In Me.DestinationListView.Items
                    Dim DFName As String = DestinationFile.Text
                    Dim DFileInfo As New FileInfo(DestinationPath & "\" & DFName)

                    If SFileInfo.Name.Trim.ToLower = DFileInfo.Name.Trim.ToLower Then

                        'compare the source and destination file last write dates
                        Dim SRelativeAge As String = ""
                        Dim DRelativeAge As String = ""

                        'get the last write times
                        If SFileInfo.LastWriteTime = DFileInfo.LastWriteTime Then
                            SRelativeAge = "Same"
                            DRelativeAge = "Same"
                        ElseIf SFileInfo.LastWriteTime > DFileInfo.LastWriteTime Then
                            SRelativeAge = "Newer"
                            DRelativeAge = "Older"
                        End If

                        'color the source and destination files based on relative age
                        If DRelativeAge = "Newer" Then
                            DestinationFile.ForeColor = Color.DarkGreen
                            SourceFile.ForeColor = Color.DarkRed
                        ElseIf DRelativeAge = "Older" Then
                            DestinationFile.ForeColor = Color.DarkRed
                            SourceFile.ForeColor = Color.DarkGreen
                        Else
                            DestinationFile.ForeColor = Color.Black
                            SourceFile.ForeColor = Color.Black
                        End If

                        With DestinationFile
                            .SubItems(1).Text = "Found"
                            .SubItems(3).Text = DRelativeAge
                        End With

                        With SourceFile
                            .SubItems(1).Text = "Found"
                            .SubItems(3).Text = SRelativeAge
                        End With
                    End If
                Next
            Next
        End If
    End Sub



    ''' <summary>
    ''' Assembles the RoboCopy script in the Me.ScriptTextBox TextBox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuildScript()
        Me.ScriptTextBox.Text = "Robocopy """ & SourceDirectory & """ """ & DestinationDirectory & " " & FilesList & " " & Me.SwitchesToolStripTextBox.Text
    End Sub


    ''' <summary>
    ''' Loops through each source file and shows which destination files will be overwritten and 
    ''' </summary>
    ''' <param name="Reset"></param>
    ''' <remarks></remarks>
    Private Sub ReconcileListViewItems(ByVal Reset As Boolean)
        Exit Sub
        If Not Reset = True Then
            For Each SourceListViewItem As ListViewItem In Me.SourceListView.SelectedItems
                For Each DestinationListViewItem As ListViewItem In Me.DestinationListView.Items
                    If DestinationListViewItem.Text.Trim.ToLower = SourceListViewItem.Text.Trim.ToLower Then
                        Dim SourceFileInfo As New FileInfo(SourceDirectory & "\" & SourceListViewItem.Text.Trim)
                        Dim DestinationFileInfo As New FileInfo(DestinationDirectory & "\" & DestinationListViewItem.Text.Trim)
                        Dim DestinationFileRelativeAge As String = ""
                        Dim SourceFileRelativeAge As String = ""
                        If DestinationFileInfo.LastWriteTime = SourceFileInfo.LastWriteTime Then
                            DestinationFileRelativeAge = "Same age"
                            SourceFileRelativeAge = "Same age"
                        ElseIf DestinationFileInfo.LastWriteTime > SourceFileInfo.LastWriteTime Then
                            DestinationFileRelativeAge = "Newer"
                            SourceFileRelativeAge = "Older"
                        Else
                            DestinationFileRelativeAge = "Older"
                            SourceFileRelativeAge = "Newer"
                        End If
                        DestinationListViewItem.ImageKey = "File_Error"
                        DestinationListViewItem.ForeColor = Color.Red
                        DestinationListViewItem.SubItems(1).Text = "Overwrite"
                        DestinationListViewItem.SubItems(2).Text = DestinationFileInfo.LastWriteTime
                        DestinationListViewItem.SubItems(3).Text = DestinationFileRelativeAge

                        SourceListViewItem.SubItems(1).Text = "Source"
                        SourceListViewItem.SubItems(2).Text = SourceFileInfo.LastWriteTime
                        SourceListViewItem.SubItems(3).Text = SourceFileRelativeAge
                    End If
                Next
            Next
        Else
            For Each DestinationListViewItem As ListViewItem In Me.DestinationListView.Items
                DestinationListViewItem.ImageKey = "File"
                DestinationListViewItem.ForeColor = Color.Black
            Next
        End If
    End Sub

    Private Sub SourceListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceListView.SelectedIndexChanged
        'clear the existing list of files
        FilesList = ""

        'add the files from the listview to the fileslist one by one
        For Each Item As ListViewItem In Me.SourceListView.SelectedItems
            FilesList = FilesList & """" & Item.Text & """ "
        Next
        FilesList = FilesList.Trim


        ReconcileListViewItems(False)

        'build the script
        BuildScript()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrapToolStripButton.Click
        If Me.ScriptTextBox.WordWrap = True Then
            Me.ScriptTextBox.WordWrap = False
            Me.WrapToolStripButton.Text = "Wrap on"
        Else
            Me.ScriptTextBox.WordWrap = True
            Me.WrapToolStripButton.Text = "Wrap off"
        End If
    End Sub

    Private Sub MapDriveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MapDriveToolStripButton.Click
        Dim FB As New FolderBrowserDialog
        If FB.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.DestinationDirectoryToolStripTextBox.Text = FB.SelectedPath
        End If
    End Sub

    Private Sub DestinationDirectoryToolStripTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinationDirectoryToolStripTextBox.Leave
        If My.Computer.FileSystem.DirectoryExists(Me.DestinationDirectoryToolStripTextBox.Text.Trim) Then
            Dim DirNode As New TreeNode(Me.DestinationDirectoryToolStripTextBox.Text.Trim, 0, 0)
            DirNode.Tag = Me.DestinationDirectoryToolStripTextBox.Text.Trim
            Me.DestinationTreeView.Nodes.Add(DirNode)
            My.Settings.FavoriteDirectories = My.Settings.FavoriteDirectories & "," & DirNode.Tag
        End If
    End Sub

    Private Sub SourceDirectoryToolStripTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceDirectoryToolStripTextBox.Leave
        If My.Computer.FileSystem.DirectoryExists(Me.SourceDirectoryToolStripTextBox.Text.Trim) Then
            Dim DirNode As New TreeNode(Me.SourceDirectoryToolStripTextBox.Text.Trim, 0, 0)
            DirNode.Tag = Me.SourceDirectoryToolStripTextBox.Text.Trim
            Me.SourceTreeView.Nodes.Add(DirNode)
            My.Settings.FavoriteDirectories = My.Settings.FavoriteDirectories & "," & DirNode.Tag
        End If
    End Sub

    Private Sub FavoriteDirectoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FD As New FavoriteDirectoriesForm
        FD.ShowDialog()
    End Sub

    Private Sub ReloadDrivesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadDirectoryTrees()
    End Sub

    Private Sub DeleteSelectedDestinationFilesToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectedDestinationFilesToolStripButton.Click
        If Me.DestinationListView.SelectedItems.Count > 0 Then
            Dim DeletionFiles As String = "Delete the following files?" & vbNewLine
            For Each FileListViewItem As ListViewItem In Me.DestinationListView.SelectedItems
                Dim Filename As String = FileListViewItem.Text
                DeletionFiles = DeletionFiles & Filename & vbNewLine
            Next
            If MsgBox(DeletionFiles, MsgBoxStyle.OkCancel, "Confirm file deletion") = MsgBoxResult.Ok Then
                For Each FileListViewItem As ListViewItem In Me.DestinationListView.SelectedItems
                    Dim Filename As String = FileListViewItem.Text
                    Dim Filepath As String = DestinationDirectory & "\" & Filename
                    Try
                        'delete the file
                        My.Computer.FileSystem.DeleteFile(Filepath)

                        LoadFiles(DestinationListView, DestinationDirectory)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            End If
        Else
            MsgBox("No files are selected for deletion.")
        End If
    End Sub

    ''' <summary>
    ''' Opens a terminal (command prompt) and submits the RoboCopy script contained in Me.ScriptTextBox.Text
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RunScriptInTerminal(ByVal WithConfirm As Boolean)
        If WithConfirm = True Then
            If MsgBox("Run script? " & vbNewLine & Me.ScriptTextBox.Text, MsgBoxStyle.OkCancel, "Confirm") = MsgBoxResult.Ok Then
                Process.Start("cmd", "/k " & Me.ScriptTextBox.Text)
            End If
        Else
            Process.Start("cmd", "/k " & Me.ScriptTextBox.Text)
        End If
    End Sub

    ''' <summary>
    ''' Opens an empty terminal (command prompt). Also copies the script contained in Me.ScriptTextBox.Text to the clipboard so it can be immediately copied into the terminal if desired.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenTerminal()
        My.Computer.Clipboard.SetText(Me.ScriptTextBox.Text)
        Process.Start("cmd.exe")
    End Sub

    Private Sub RunScriptToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunScriptToolStripButton.Click
        'run the robocopy script in a terminal after confirmation
        RunScriptInTerminal(True)

        LoadFiles(Me.DestinationListView, Me.DestinationDirectoryToolStripTextBox.Text)
    End Sub



    ''' <summary>
    ''' Opens the directory contained in the directory node's tag property.
    ''' </summary>
    ''' <param name="Node">TreeNode</param>
    ''' <remarks></remarks>
    Private Sub OpenTreenodeDirectory(ByVal Node As TreeNode)
        'try to open the directory node
        Try
            Process.Start(Node.Tag)
        Catch ex As Exception
            MsgBox(ex.Message)
            Node.StateImageIndex = "Folder_Error"
            Node.Text = Node.Text & " (Error: " & ex.Message & ")"
        End Try
    End Sub

    Private Sub OpenTerminalToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTerminalToolStripButton.Click
        'open an empty terminal
        OpenTerminal()
    End Sub

    Private Sub SourceTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles SourceTreeView.NodeMouseDoubleClick
        OpenTreenodeDirectory(e.Node)
    End Sub

    Private Sub DestinationTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles DestinationTreeView.NodeMouseDoubleClick
        OpenTreenodeDirectory(e.Node)
    End Sub

    Private Sub SwitchesToolStripTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SwitchesToolStripTextBox.TextChanged
        BuildScript()
    End Sub

    Private Sub RefreshDestinationListViewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshDestinationListViewToolStripButton.Click
        LoadFiles(Me.DestinationListView, Me.DestinationDirectoryToolStripTextBox.Text)
    End Sub

    Private Sub CompareToSourceToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareToSourceToolStripButton.Click
        'DefineSourceFiles()
        'DefineDestinationFiles()

    End Sub
End Class
