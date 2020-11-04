Public Class AStarGridForm
    Function Collision(p As PictureBox, Optional ByRef other As Object = vbNull)
        For Each c In Controls
            Dim obj As Control = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) Then
                other = obj
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub DrawRect(p As Point, p2 As Point, color As Color)
        Dim picture As New PictureBox
        picture.BackColor = color
        picture.Location = p
        picture.Visible = True
        picture.Width = p2.X - p.X
        picture.Height = p2.Y - p.Y
        Dim other As Control
        If (Collision(picture, other)) Then
            Controls.Remove(other)
        End If
        picture.BringToFront()
        picture.SizeMode = PictureBoxSizeMode.StretchImage
        picture.Name = "UserPictureBox"
        Controls.Add(picture)
    End Sub
    Private Sub DrawGridItem(x As Integer, y As Integer, color As Color)
        Dim dx As Integer = 60 + x * 50
        Dim dy As Integer = 60 + y * 50
        DrawRect(New Point(dx, dy),
                 New Point(dx + 40, dy + 40),
                 color)
    End Sub
    Private Sub OnLoadEvent() Handles Me.Load
        ' Clear all items that are about to be rendered
        ClearAll()

        ' Draw grid of square nodes
        Const COLUMNS = 5
        Const ROWS = 5
        For x = 0 To COLUMNS
            For y = 0 To ROWS
                DrawGridItem(x, y, Color.Black)
            Next
        Next

        Dim gridTest As Grid = New Grid(10, 10)
        gridTest.SetWalkable(0, 1, True)
        Dim finder As New AStarFinder()
        Dim path = finder.FindPath(0, 0, 5, 5, gridTest)
        For i = 0 To path.Count - 1
            Dim list As List(Of Integer) = path.ElementAt(i)
            DrawGridItem(list.ElementAt(0), list.ElementAt(1), Color.Blue)
            Debug.WriteLine("X" & i & ": " & list.ElementAt(0))
            Debug.WriteLine("Y" & i & ": " & list.ElementAt(1))
        Next

    End Sub
    Private Sub ClearAll()
        Controls.Clear()
    End Sub
End Class
