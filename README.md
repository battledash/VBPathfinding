# VB Pathfinding
An A* Pathfinding Library for VB.NET

Includes Manhattan (default), Euclidean, Octile, and Chebyshev Heuristics
Currently does not support diagonal pathfinding

Basic Usage:
```vb
Dim gridTest As Grid = New Grid(10, 10)
gridTest.SetWalkable(0, 1, Fale)
Dim finder As New AStarFinder()
Dim path = finder.FindPath(0, 0, 5, 5, gridTest)
For i = 0 To path.Count - 1
    Dim list As List(Of Integer) = path.ElementAt(i)
    Debug.WriteLine("X" & i & ": " & list.ElementAt(0))
    Debug.WriteLine("Y" & i & ": " & list.ElementAt(1))
Next
```
