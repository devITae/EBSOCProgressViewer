Imports System.Windows.Forms '디버거 참조가 올바른지 반드시 확인!
Public Class ListViewSort
    'Code by JFLHV, Chris Raisin https://youtu.be/fRMztyQ06xI
    Implements IComparer

    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub
    Public Sub New(column As Integer, order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim returnVal As Integer
        Try

            '2개의 DateTime 오브젝트로 파싱 시도
            Dim firstDate As System.DateTime = DateTime.Parse(CType(x, ListViewItem).SubItems(col).Text)
            Dim secondDate As System.DateTime = DateTime.Parse(CType(y, ListViewItem).SubItems(col).Text)

            If IsDate(CType(x, ListViewItem).SubItems(col).Text) And IsDate(CType(y, ListViewItem).SubItems(col).Text) Then
                'returnVal = 1
                returnVal = DateTime.Compare(firstDate, secondDate) '날짜로 비교

            Else
                If IsNumeric(CType(x, ListViewItem).SubItems(col).Text) And IsNumeric(CType(y, ListViewItem).SubItems(col).Text) Then
                    '숫자로 비교
                    returnVal = Val(CType(x, ListViewItem).SubItems(col).Text).CompareTo(Val(CType(y, ListViewItem).SubItems(col).Text))
                Else
                    '숫자 말고, 문자로 비교
                    returnVal = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
                End If
            End If
        Catch ex As Exception
            Return 1
            '재작업과 동시에 분류하는 동안 사용자와 리스트뷰와의 상호작용으로 인해 
            '또는 열이 날짜, 숫자, 문자가 아닌 개체를 포함한다면 오류를 방지하기 위해 발생할 수 있음.
        End Try

        '순서가 내림차순이면 값을 반전시킨다.
        If order = SortOrder.Descending Then
            returnVal *= -1
            '현재 값의 REVERSE 값을 "-1"로 곱하여 반환한다.
        End If

        Return returnVal

    End Function
End Class