Imports System.IO

Public Class Form1

    Dim FilesList As String = vbNewLine
    Dim SourceDirectory As String = ""
    Dim DestinationDirectory As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDirectoryTrees()
    End Sub

    Private Sub LoadDirectoryTrees()
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()
        Debug.Print(My.Settings.FavoriteDirectories)

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

    Private Sub LoadAssets(ByVal Treenode As TreeNode, ByVal ListView As ListView)
        Dim Directory As String = Treenode.Tag
        If My.Computer.FileSystem.DirectoryExists(Directory) Then
            'Try
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

            LoadListView(ListView, Directory)

            'Catch ex As Exception
            '    MsgBox(Treenode.Text & "(" & ex.Message & ")")
            '    Treenode.StateImageIndex = 3
            'End Try
        Else
            Treenode.Text = Treenode.Text & "(missing)"
        End If
    End Sub

    Private Sub LoadListView(ByVal ListView As ListView, ByVal Directory As String)
        'load the directory's files into the listbox
        ListView.Items.Clear()
        For Each File As String In My.Computer.FileSystem.GetFiles(Directory)
            Dim FileInfo As New FileInfo(File)
            Dim FileListViewItem As New ListViewItem(FileInfo.Name, 4)
            FileListViewItem.SubItems.Add("") 'status
            FileListViewItem.SubItems.Add(FileInfo.LastWriteTime) 'last updated
            FileListViewItem.SubItems.Add("") 'relative age
            ListView.Items.Add(FileListViewItem)
        Next
    End Sub

    Private Sub SourceTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles SourceTreeView.NodeMouseClick
        Me.SourceDirectoryToolStripTextBox.Text = ""
        Me.SourceDirectoryToolStripTextBox.Text = e.Node.Tag
        SourceDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadAssets(e.Node, Me.SourceListView)
        End If
        BuildScript()
        ReconcileListViewItems(True)
    End Sub

    Private Sub DestinationTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles DestinationTreeView.NodeMouseClick
        Me.DestinationDirectoryToolStripTextBox.Text = ""
        Me.DestinationDirectoryToolStripTextBox.Text = e.Node.Tag
        DestinationDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadAssets(e.Node, Me.DestinationListView)
        End If
        BuildScript()
        ReconcileListViewItems(True)
        ReconcileListViewItems(False)
    End Sub



    Private Sub BuildScript()
        Me.ScriptTextBox.Text = "Robocopy """ & SourceDirectory & """ """ & DestinationDirectory & """ """ & FilesList & """"
    End Sub

    Private Sub ReconcileListViewItems(ByVal Reset As Boolean)
        If Not Reset = True Then
            For Each Item As ListViewItem In Me.SourceListView.SelectedItems
                For Each DestinationListViewItem As ListViewItem In Me.DestinationListView.Items
                    'Debug.Print(DestinationListViewItem.Text.Trim.ToLower & " = " & Item.Text.Trim.ToLower)
                    If DestinationListViewItem.Text.Trim.ToLower = Item.Text.Trim.ToLower Then
                        Dim SourceFileInfo As New FileInfo(SourceDirectory & "\" & Item.Text.Trim)
                        Dim DestinationFileInfo As New FileInfo(DestinationDirectory & "\" & DestinationListViewItem.Text.Trim)
                        Dim DestinationFileRelativeAge As String = ""
                        If DestinationFileInfo.LastWriteTime = SourceFileInfo.LastWriteTime Then
                            DestinationFileRelativeAge = "Same age"
                        ElseIf DestinationFileInfo.LastWriteTime > SourceFileInfo.LastWriteTime Then
                            DestinationFileRelativeAge = "Newer"
                        Else
                            DestinationFileRelativeAge = "Older"
                        End If
                        DestinationListViewItem.ImageKey = "File_Error"
                        DestinationListViewItem.ForeColor = Color.Red
                        DestinationListViewItem.SubItems(1).Text = "Overwrite"
                        DestinationListViewItem.SubItems(2).Text = DestinationFileInfo.LastWriteTime
                        DestinationListViewItem.SubItems(3).Text = DestinationFileRelativeAge
                    End If
                Next
            Next
        Else
            For Each DestinationListViewItem As ListViewItem In Me.DestinationListView.Items
                DestinationListViewItem.ImageKey = "File"
                DestinationListViewItem.ForeColor = Color.Black
                'DestinationListViewItem.SubItems(1).Text = ""
                'DestinationListViewItem.SubItems(2).Text = ""
                'DestinationListViewItem.SubItems(3).Text = ""
            Next
        End If
    End Sub

    Private Sub SourceListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SourceListView.SelectedIndexChanged
        'clear the existing list of files
        FilesList = vbNewLine

        'add the files from the listview to the fileslist one by one
        For Each Item As ListViewItem In Me.SourceListView.SelectedItems
            FilesList = FilesList & Item.Text & ","
        Next
        'trim last comma
        FilesList = FilesList.Substring(0, Len(Trim(FilesList)) - 1)

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
                        'My.Computer.FileSystem.DeleteFile(Filepath)
                        MsgBox("pretend to delete file " & Filepath)
                        LoadListView(DestinationListView, DestinationDirectory)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            End If
        Else
            MsgBox("No files are selected for deletion.")
        End If
    End Sub

    Private Sub RunCommand(ByVal Arguments As String)
        Dim p As Process = New Process()
        Dim pi As ProcessStartInfo = New ProcessStartInfo()
        pi.Arguments = " ROBOCOPY /L " & Arguments
        pi.FileName = "cmd.exe"
        p.StartInfo = pi
        p.Start()
    End Sub

    Private Sub RunScriptToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunScriptToolStripButton.Click
        If MsgBox("Run script: " & Me.ScriptTextBox.Text, MsgBoxStyle.OkCancel, "Confirm") = MsgBoxResult.Ok Then
            Process.Start("cmd", "/k " & Me.ScriptTextBox.Text)
        End If
    End Sub

    Private Sub OpenTerminalToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTerminalToolStripButton.Click
        My.Computer.Clipboard.SetText(Me.ScriptTextBox.Text)
        Process.Start("cmd.exe")
    End Sub
End Class
