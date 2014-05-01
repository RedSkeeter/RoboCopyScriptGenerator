Imports System.IO

Public Class Form1

    Dim FilesList As String = vbNewLine
    Dim SourceDirectory As String = ""
    Dim DestinationDirectory As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSourceDirectoriesTree()
    End Sub

    Private Sub LoadSourceDirectoriesTree()
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives()

        Try
            Dim FavoriteDirectories() As String = My.Settings.FavoriteDirectories.Split(",")
            Debug.Print(My.Settings.FavoriteDirectories)
            For Each FavoriteDirectory As String In FavoriteDirectories
                Debug.Print(FavoriteDirectory)
                If My.Computer.FileSystem.DirectoryExists(FavoriteDirectory) Then
                    Dim drive As New DriveInfo(FavoriteDirectory)
                    Dim FavoriteDriveTreenode As New TreeNode(drive.Name & " " & drive.VolumeLabel)
                    FavoriteDriveTreenode.Tag = drive.Name
                    FavoriteDriveTreenode.SelectedImageKey = "Drive_Mapped"
                    FavoriteDriveTreenode.StateImageKey = "Drive_Mapped"
                    Me.SourceTreeView.Nodes.Add(FavoriteDriveTreenode)
                End If
            Next
        Catch ex As Exception
            Me.ScriptTextBox.Text = ex.Message
        End Try


        For Each Drive As DriveInfo In allDrives
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
    End Sub

    Private Sub LoadAssets(ByVal Treenode As TreeNode, ByVal ListView As ListView)
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

                'load the directory's files into the listbox
                ListView.Items.Clear()
                For Each File As String In My.Computer.FileSystem.GetFiles(Directory)
                    Dim DirInfo As New FileInfo(File)
                    Dim FileListViewItem As New ListViewItem(DirInfo.Name, 4)
                    ListView.Items.Add(FileListViewItem)
                Next
            Catch ex As Exception
                Treenode.Text = Treenode.Text & "(" & ex.Message & ")"
                Treenode.StateImageIndex = 3
            End Try
        Else
            Treenode.Text = Treenode.Text & "(missing)"
        End If
    End Sub

    Private Sub SourceTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles SourceTreeView.NodeMouseClick
        Me.SourceDirectoryToolStripTextBox.Text = ""
        Me.SourceDirectoryToolStripTextBox.Text = e.Node.Tag
        SourceDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadAssets(e.Node, Me.SourceListView)
        End If
        BuildScript()
    End Sub

    Private Sub DestinationTreeView_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles DestinationTreeView.NodeMouseClick
        Me.DestinationDirectoryToolStripTextBox.Text = ""
        Me.DestinationDirectoryToolStripTextBox.Text = e.Node.Tag
        DestinationDirectory = e.Node.Tag
        If My.Computer.FileSystem.DirectoryExists(e.Node.Tag) Then
            LoadAssets(e.Node, Me.DestinationListView)
        End If
        BuildScript()
    End Sub



    Private Sub BuildScript()
        Me.ScriptTextBox.Text = "Robocopy """ & SourceDirectory & """ """ & DestinationDirectory & """ """ & FilesList & """"
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
        'build the script
        BuildScript()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.ScriptTextBox.WordWrap = True Then
            Me.ScriptTextBox.WordWrap = False
            Me.ScriptTextBox.Text = "Wrap on"
        Else
            Me.ScriptTextBox.WordWrap = True
            Me.ScriptTextBox.Text = "Wrap off"
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
End Class
