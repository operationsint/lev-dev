Public Class lvColumnSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private IsColumnDate As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New()
        ' Initialize the column to '0'.
        ColumnToSort = 0

        ' Initialize the sort order to 'none'.
        OrderOfSort = SortOrder.None

        ' Initialize the CaseInsensitiveComparer object.
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Cast the objects to be compared to ListViewItem objects.
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        '20160927 Dikman : Sort Date ListView
        ' Determine whether the type being compared is a date type.
        If IsColumnDate = 1 Then
            Try
                ' Parse the two objects passed as a parameter as a DateTime.
                Dim firstDate As System.DateTime = DateTime.Parse(listviewX.SubItems(ColumnToSort).Text)
                Dim secondDate As System.DateTime = DateTime.Parse(listviewY.SubItems(ColumnToSort).Text)
                ' Compare the two dates.
                compareResult = DateTime.Compare(firstDate, secondDate)
                ' If neither compared object has a valid date format, 
                ' compare as a string.
            Catch
                'Compare the two items.
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
            End Try
        Else
            'Compare the two items.
            compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)
        End If

        ' Calculate the correct return value based on the object 
        ' comparison.
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return typical result of 
            ' compare operation.
            Return compareResult
        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of 
            ' compare operation.
            Return (-compareResult)
        Else
            ' Return '0' to indicate that they are equal.
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property

    '20160927 Dikman : Sort Date ListView
    Public Property DateColumn() As Integer
        Set(ByVal Value As Integer)
            IsColumnDate = Value
        End Set

        Get
            Return IsColumnDate
        End Get
    End Property
End Class