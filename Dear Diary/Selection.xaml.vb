Public Class Selection

    'Written by Steven.

    Public ComboboxIndexVal As UInt16 = 0

    Sub New()

        InitializeComponent()

        'This is called when the selection window opens.
        _ArrangeMonths()


    End Sub

    Private Sub cmbSelcYear_LostFocus(sender As Object, e As RoutedEventArgs) Handles cmbSelcYear.LostFocus

        If ComboboxIndexVal <> cmbSelcYear.SelectedIndex Then

            ComboboxIndexVal = cmbSelcYear.SelectedIndex
            _ArrangeMonths()

        End If

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

        For m As UInt16 = 0 To 11

            strDate = "1/" & m + 1 & "/" & Year

            'Define row definitions by figuring out how many weeks in the current month.
            'Below I've come up with the formula to figure out how to do that.

            'It works by rounding down the amount of days in the 1-12 month value of c, adding a 0-based
            'number that returns a number on what day the month starts on, then deviding by seven, which is a week.

            For DefCount As UInt16 = 0 To (Math.Floor(((Date.DaysInMonth(Year, m + 1)) + (Weekday(strDate) - 1)) / 7))

                Grids(m).RowDefinitions.Add(New RowDefinition With {.Height = New GridLength(1, GridUnitType.Star)})

            Next
            'DefCount -- Count for row definitions.

            'Grids(c).ShowGridLines = True


            Dim Buttons(Date.DaysInMonth(Year, m + 1)) As Button, x As UInt16 = Weekday(strDate) - 1, y As UInt16 = 0

            For ButtonCount As UInt16 = 0 To Date.DaysInMonth(Year, m + 1) - 1

                Buttons(ButtonCount) = New Button With {.Content = ButtonCount + 1, .Tag = m + 1, .BorderBrush = Brushes.Transparent, .Background = Brushes.Transparent, .FontSize = 6.5, .FontWeight = FontWeights.Bold}

                AddHandler Buttons(ButtonCount).Click, AddressOf DateButton


                Grids(m).Children.Add(Buttons(ButtonCount))

                Grid.SetColumn(Buttons(ButtonCount), x)
                Grid.SetRow(Buttons(ButtonCount), y)

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

    Private Sub DateButton(sender As Object, e As RoutedEventArgs)

        '1. Find what year the has selected using the index of the cmb.
        '2. Check if the user has a file on that date.
        '3a. If so, open the document window and load the text from the file.
        '3b. If not, open the window without loading anything.

        Dim Year As UInteger = Now.Year - 2000

        If cmbSelcYear.SelectedIndex = 1 Then

            Year += 1

        ElseIf cmbSelcYear.SelectedIndex = 2 Then

            Year -= 1

        End If


        'The d/m/y is included with the class for saving purposes.
        Dim winDoc As New Document With {.Title = "Dear Diary - " & sender.content & "/" & sender.tag & "/" & Year + 2000, .Day = sender.Content, .Month = sender.tag + 1, .Year = Year}

        If IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Save Files\" & sender.Content & "-" & sender.tag & "-" & Year & ".txt") Then

            'Get the text from the file, put it into the textbox.

            Dim filelines() As String = IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory & "Save Files\" & sender.Content & "-" & sender.tag & "-" & Year & ".txt")


            For l As UInt16 = 0 To filelines.Length - 1

                winDoc.rtxContent.AppendText(filelines(l))

                If l < filelines.Length - 1 Then
                    winDoc.rtxContent.AppendText(vbCr)
                End If

            Next


        End If

        winDoc.Show()
        Me.Close()

    End Sub

End Class