Public Class Selection

    'Written by Steven.

    Private Sub cmbSelcYear_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbSelcYear.SelectionChanged

        'This is called when the selection window opens.
        _ArrangeMonths()

        Dim winDoc As New Document
        winDoc.Show()


    End Sub

    Private Sub _ArrangeMonths()

        'Date.DaysInMonth(Year, Month) - Returns a number on what days on month is in the two values.
        'Weekday(DateValue As Date) - Returns a non-zero based number on what day of week DateValue is valued.

        ' 1. Arrange each month by finding what day of week they start.
        ' 2. Find their length, including number of weeks.
        ' 3. Output to the user.

        'Perfect!

        grdJanuary.RowDefinitions.Clear()


        Dim strDate As String, Year As Integer = Now.Year

        If cmbSelcYear.SelectedIndex = 1 Then
            Year -= 1

        ElseIf cmbSelcYear.SelectedIndex = 2 Then
            Year += 1

        End If

        Dim Grids As New List(Of Grid)
        Grids.Add(grdJanuary)
        Grids.Add(grdFebruary)
        Grids.Add(grdMarch)
        Grids.Add(grdApril)
        Grids.Add(grdMay)
        Grids.Add(grdJune)
        Grids.Add(grdJuly)
        Grids.Add(grdAugust)
        Grids.Add(grdSeptember)
        Grids.Add(grdOctober)
        Grids.Add(grdNovember)
        Grids.Add(grdDecember)

        For c As UInt16 = 0 To 11

                strDate = "1/" & c + 1 & "/" & Year

                'Define row definitions by figuring out how many weeks in the current month.
                'Below I've come up with the formula to figure out how to do that.

                'It works by rounding up the amount of days in the 1-12 month value of c, adding a 0-based
                'number that returns a number on what day the month starts on, then deviding by seven, which is a week.

                Dim WeeksInMonth As Single = (Math.Floor(((Date.DaysInMonth(Year, c + 1)) + (Weekday(strDate) - 1)) / 7))

                For DefCount As UInt16 = 0 To CInt(WeeksInMonth)
                    Grids(c).RowDefinitions.Add(New RowDefinition With {.Height = New GridLength(1, GridUnitType.Star)})

                Next
                'DefCount -- Count for row definitions.

                'Grids(c).ShowGridLines = True


                Dim btnDay(30) As Button, x As UInt16 = Weekday(strDate) - 1, y As UInt16 = 0

                For ButtonCount As UInt16 = 0 To Date.DaysInMonth(Year, c + 1) - 1

                    btnDay(ButtonCount) = New Button With {.Content = ButtonCount + 1, .BorderBrush = Brushes.Transparent, .Background = Brushes.Transparent, .FontSize = 6.5, .FontWeight = FontWeights.Bold}

                    Grids(c).Children.Add(btnDay(ButtonCount))

                    Grid.SetColumn(btnDay(ButtonCount), x)
                    Grid.SetRow(btnDay(ButtonCount), y)

                    x += 1

                    If x = 7 Then

                        x = 0
                        y += 1

                    End If

                Next
                'ButtonCount -- Count for the amount of buttons created for days.

        Next

        'Here is where the current day has to be found.

        '1. Get the grid that its index is the same as the current month.
        '2. Get its child element with the index of today minus one,
        '3. Set its properties.


        Dim btnToday As Button = Grids(Now.Month - 1).Children.Item(Now.Day - 1)

        btnToday.BorderBrush = Brushes.SteelBlue
        btnToday.Background = Brushes.LightSkyBlue

        'Debug.Write("")

    End Sub
End Class