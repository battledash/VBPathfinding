Public Class Heuristics

    ' Totally abusing preprocessor definitions here but whatever lol
#If False Then
    Manhattan distance.
    @param {number} dx - Difference in x.
    @param {number} dy - Difference in y.
    @return {number} dx + dy
#End If
    Public Shared Function Manhattan(dx As Integer, dy As Integer) As Integer
        Return dx + dy
    End Function

#If False Then
    Euclidean distance.
    @param {number} dx - Difference in x.
    @param {number} dy - Difference in y.
    @return {number} sqrt(dx * dx + dy * dy)
#End If
    Public Shared Function Euclidean(dx As Integer, dy As Integer) As Integer
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

#If False Then
    Octile distance.
    @param {number} dx - Difference in x.
    @param {number} dy - Difference in y.
    @return {number} sqrt(dx * dx + dy * dy) for grids
#End If
    Public Shared Function Octile(dx As Integer, dy As Integer) As Integer
        Dim F As Double = 0.41421356237309509
        Return If((dx < dy), F * dx + dy, F * dy + dx)
    End Function

#If False Then
    Chebyshev distance.
    @param {number} dx - Difference in x.
    @param {number} dy - Difference in y.
    @return {number} max(dx, dy)
#End If
    Public Shared Function Chevyshev(dx As Integer, dy As Integer) As Integer
        Return Math.Max(dx, dy)
    End Function

End Class
