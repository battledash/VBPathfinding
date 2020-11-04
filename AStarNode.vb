Public Class AStarNode
    Public x As Integer
    Public y As Integer
    Public walkable As Boolean = True
    Public g As Integer = 0
    Public h As Integer = 0
    Public f As Integer = 0
    Public opened As Boolean = False
    Public closed As Boolean = False
    Public parent As AStarNode

    Public Sub New(dx As Integer, dy As Integer, dWalkable As Boolean)
        x = dx
        y = dy
        walkable = dWalkable
    End Sub
End Class
