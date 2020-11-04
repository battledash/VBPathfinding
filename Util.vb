Public Class Util
    Public Shared Function Backtrace(node As AStarNode) As List(Of List(Of Integer))
        Dim path As New List(Of List(Of Integer))
        path.Insert(0, New List(Of Integer))
        path.ElementAt(0).Insert(0, node.x)
        path.ElementAt(0).Insert(1, node.y)
        While (node.parent IsNot Nothing)
            node = node.parent
            Dim list As New List(Of Integer)
            list.Add(node.x)
            list.Add(node.y)
            path.Add(list)
        End While
        path.Reverse()
        Return path
    End Function
    Public Shared Function PopList(listToPop As List(Of AStarNode)) As Tuple(Of AStarNode, List(Of AStarNode))
        Dim index As Integer = listToPop.Count - 1
        Dim val = listToPop.ElementAt(index)
        listToPop.RemoveAt(index)
        Return New Tuple(Of AStarNode, List(Of AStarNode))(val, listToPop)
    End Function
End Class
