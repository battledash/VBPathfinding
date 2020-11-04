
# WinFormsPathfinding
An A* Pathfinding Library for Windows Forms

Includes Manhattan, Euclidean, Octile, and Shevychev Heuristics, (Manhattan by default)
Currently does not support diagonal pathfinding

Basic Usage:
```java
        Dim gridTest As Grid = New Grid(10, 10)
        gridTest.SetWalkable(0, 1, Fale)
        Dim finder As New AStarFinder()
        Dim path = finder.FindPath(0, 0, 5, 5, gridTest)
        For i = 0 To path.Count - 1
            Dim list As List(Of Integer) = path.ElementAt(i)
            Debug.WriteLine("X" & i & ": " & list.ElementAt(0))
            Debug.WriteLine("Y" & i & ": " & list.ElementAt(1))
        Next```