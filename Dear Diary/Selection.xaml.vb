Public Class Selection

    'Written by Steven.

    Private Sub cmbSelcYear_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbSelcYear.SelectionChanged

        'This is called when the selection window opens.
        _ArrangeMonths()

    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        'This is the code to return to main window.

        Dim winMenu As New MainWindow
        winMenu.Show()
        Me.Close()

    End Sub


    Private Sub _ArrangeMonths()

        'Date.DaysInMonth(Year, Month)
        'Weekday(DateValue As Date)

        ' 1. Arrange each month by finding what day of week they start.
        ' 2. Find their length, including number of weeks.
        ' 3. Output to the user.

        'Perfect!

        Dim strDate As String, Year As UInteger = Now.Year

        If cmbSelcYear.SelectedIndex = 1 Then
            Year -= 1

        ElseIf cmbSelcYear.SelectedIndex = 2 Then
            Year += 1

        End If

        For c As UInt16 = 0 To 11

            strDate = "1/" & c + 1 & "/" & Year

            'Define row definitions by figuring out how many weeks in the current month.
            'Below I've come up with the formula to figure out how to do that.

            'It works by rounding up the amount of days in the 1-12 month value of c, adding a 0-based
            'number that returns a number on what day the month starts on, then deviding by seven, which is a week.

            'I come up with this by myself, and without having to search for any methods that make this up.

            Dim WeeksInMonth As Single = (Math.Ceiling(((Date.DaysInMonth(Year, c + 1)) + (Weekday(strDate) - 1)) / 7))


            For DefCount As UInt16 = 0 To CInt(WeeksInMonth)



            Next
            'DefCount -- Count for row definitions.


            'Use Weekday(strDate)) here to find where the first button goes.

            For ButtonCount As UInt16 = 0 To Date.DaysInMonth(Year, c + 1)



            Next
            'ButtonCount -- Count for the amount of buttons created for days.

        Next


    End Sub
End Class