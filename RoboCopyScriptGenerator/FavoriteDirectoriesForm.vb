Public Class FavoriteDirectoriesForm

    Private Sub FavoriteDirectoriesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PropertyGrid1.SelectedObject = My.Settings
    End Sub
End Class