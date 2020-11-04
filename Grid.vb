Public Class Grid
    Public width As Integer
    Public height As Integer
    Public nodes As List(Of List(Of AStarNode))
    Public Sub New(dwidth As Integer, dheight As Integer)
        width = dwidth
        height = dheight
        nodes = BuildNodes()
    End Sub
    Public Function BuildNodes()
        Dim i As Integer
        Dim j As Integer
        Dim nodes As New List(Of List(Of AStarNode))
        For i = 0 To height
            nodes.Insert(i, New List(Of AStarNode)(width))
            For j = 0 To width
                nodes.ElementAt(i).Insert(j, New AStarNode(j, i, True))
            Next
        Next
        Return nodes
    End Function
    Public Function GetNodeAt(x As Integer, y As Integer) As AStarNode
        Return nodes.ElementAt(y).ElementAt(x)
    End Function
    Public Function IsWalkable(x As Integer, y As Integer) As Boolean
        Return IsInside(x, y) AndAlso GetNodeAt(x, y).walkable
    End Function
    Public Sub SetWalkable(x As Integer, y As Integer, walkable As Boolean)
        GetNodeAt(x, y).walkable = walkable
    End Sub
    Public Function IsInside(x As Integer, y As Integer) As Boolean
        Return (x >= 0 AndAlso x < width) AndAlso (y >= 0 AndAlso y < height)
    End Function
    Public Function GetNeighbours(node As AStarNode, diagonalMovement As DiagonalMovement) As List(Of AStarNode)
        Dim x As Integer = node.x,
            y As Integer = node.y,
            neighbours As New List(Of AStarNode),
            s0 As Boolean = False, d0 As Boolean = False,
            s1 As Boolean = False, d1 As Boolean = False,
            s2 As Boolean = False, d2 As Boolean = False,
            s3 As Boolean = False, d3 As Boolean = False,
            nodeList As List(Of List(Of AStarNode)) = nodes

        ' Up
        If (IsWalkable(x, y - 1)) Then
            neighbours.Add(GetNodeAt(x, y - 1))
            s0 = True
        End If
        ' Right
        If (IsWalkable(x + 1, y)) Then
            neighbours.Add(GetNodeAt(x + 1, y))
            s1 = True
        End If
        ' Down
        If (IsWalkable(x, y + 1)) Then
            neighbours.Add(GetNodeAt(x, y + 1))
            s0 = True
        End If
        ' Left
        If (IsWalkable(x - 1, y)) Then
            neighbours.Add(GetNodeAt(x - 1, y))
            s0 = True
        End If

        If (diagonalMovement = DiagonalMovement.Never) Then
            Return neighbours
        End If
        Return neighbours
    End Function
End Class
