Public Class AStarFinder
    Public allowDiagonal As Boolean
    Public dontCrossCorners As Boolean
    Public weight As Integer
    Public diagonalMovement As DiagonalMovement
    Public Sub New()
        allowDiagonal = False
        dontCrossCorners = True
        weight = 1
        diagonalMovement = DiagonalMovement.Never

    End Sub
    Public Function FindPath(startX As Integer, startY As Integer, endX As Integer, endY As Integer, grid As Grid) As List(Of List(Of Integer))
        Dim startNode As AStarNode = grid.GetNodeAt(startX, startY),
            openList As New List(Of AStarNode), 'New BinaryHeapTree(startNode, Function(a As Object, b As Object) a.f - b.f),
            endNode As AStarNode = grid.GetNodeAt(endX, endY),
            SQRT2 As Double = 1.4142135623730952,
            node As AStarNode,
            neighbors As List(Of AStarNode),
            neighbor As AStarNode,
            i As Integer,
            l As Integer,
            x As Integer,
            y As Integer,
            ng As Integer
        openList.Add(startNode)
        startNode.opened = True
        While Not openList.Count = 0
            Debug.WriteLine("Iterating Path")
            openList.Sort(Function(a As Object, b As Object) b.f - a.f)
            Dim tuple As Tuple(Of AStarNode, List(Of AStarNode)) = Util.PopList(openList)
            openList = tuple.Item2
            node = tuple.Item1
            If (node.closed) Then
                Console.WriteLine("Exiting")
                Exit While
            End If
            node.closed = True

            If node.Equals(endNode) Then
                Debug.WriteLine("Found Path")
                Return Util.Backtrace(endNode)
            End If

            neighbors = grid.GetNeighbours(node, diagonalMovement)
            i = 0
            l = neighbors.Count
            While i < l
                neighbor = neighbors.ElementAt(i)
                If (neighbor.closed) Then
                    i += 1
                    Continue While
                End If
                x = neighbor.x
                y = neighbor.y
                ng = node.g + (If(x - node.x = 0 OrElse y - node.y = 0, 1, SQRT2))
                If (Not neighbor.opened OrElse ng < neighbor.g) Then
                    neighbor.g = ng
                    If (neighbor.h) Then
                        neighbor.h = neighbor.h
                    Else
                        neighbor.h = weight * Heuristics.Manhattan(Math.Abs(x - endX), Math.Abs(y - endY))
                    End If
                    neighbor.f = neighbor.g + neighbor.h
                    neighbor.parent = node

                    If Not neighbor.opened Then
                        openList.Add(neighbor)
                        neighbor.opened = True
                    Else

                    End If
                End If
                i += 1
            End While

        End While
        Debug.WriteLine("Found No Path")
        Return New List(Of List(Of Integer))
    End Function
End Class
