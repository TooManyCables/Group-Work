Public Class Selection

    'Written by Steven.

    Private Sub cmbSelcYear_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbSelcYear.SelectionChanged

        'This is called when the selection window opens.
        _ArrangeMonths()

    End Sub


    Private Sub _ArrangeMonths()

        'Date.DaysInMonth(Year, Month)
        'Weekday(DateValue As Date)

        ' 1. Arrange each month by finding what day of week they start.
        ' 2. Find their length, including number of weeks.
        ' 3. Output to the user.

        'Perfect!

        Dim strDate As String, Year As Integer = Now.Year

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

            Dim WeeksInMonth As Single = (Math.Floor(((Date.DaysInMonth(Year, c + 1)) + (Weekday(strDate) - 1)) / 7))


            If c = 0 Then

                For DefCount As UInt16 = 0 To CInt(WeeksInMonth)
                    grdJanuary.RowDefinitions.Add(New RowDefinition With {.Height = New GridLength(1, GridUnitType.Star)})

                Next

            End If
            'DefCount -- Count for row definitions.

            grdJanuary.ShowGridLines = True

            'Use Weekday(strDate) here to find where the first button goes.

            Dim Positions(grdJanuary.ColumnDefinitions.Count - 1, grdJanuary.RowDefinitions.Count - 1) As Integer
            Dim Finder As UInt16 = 6

            For ButtonCount As UInt16 = 0 To Date.DaysInMonth(Year, c + 1)

                If ButtonCount = 0 Then

                    Positions = (0,0)

                End If

                If Finder = 6 Then

                End If

            Next
            'ButtonCount -- Count for the amount of buttons created for days.

        Next

        Debug.Write("")

    End Sub
End Class