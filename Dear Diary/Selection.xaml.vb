Public Class Selection

    'Written by Steven.

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Get calender arrangement on each label; since this is also needed when
        'cmbSelcYear changes its selected index, it's put into its own sub.

        'I won't put it into another class because this class doesn't need a subclass for
        'multiple methods.

        _ArrangeMonths()

    End Sub

    Private Sub _ArrangeMonths()

        'Date.DaysInMonth(Year, Month)
        'Weekday(DateValue As Date)


        ' 1. Arrange each month by finding what day of week they start.
        ' 2. Find their length, including number of weeks.
        ' 3. Output to the user.

        'Perfect!

        'Dim strDate As String, Year As UInteger = Now.Year

        'If cmbSelcYear.SelectedIndex = 1 Then
        '    Year -= 1

        'ElseIf cmbSelcYear.SelectedIndex = 2 Then
        '    Year += 1

        'End If

        'For c As UInt16 = 0 To 11

        '    strDate = "1/" & c + 1 & "/" & Year

        '    'Define row definitions by figuring out how many weeks in the current month that is the value of c + 1

        '    Dim WeeksInMonth As UInt16

        '    If Date.DaysInMonth(Year, c + 1) <= 28 Then
        '        WeeksInMonth = 4
        '    Else
        '        WeeksInMonth = 5
        '    End If

        '    If WeeksInMonth = 4 Then



        '    End If

        '    'For DefCount As UInt16 = 0 To WeeksInMonth



        '    'Next
        '    'DefCount -- Count for row definitions.


        '    'Use Weekday(strDate)) here.


        '    For ButtonCount As UInt16 = 0 To Date.DaysInMonth(Year, c + 1)



        '    Next
        '    'ButtonCount -- Count for the amount of buttons created for days.

        'Next



    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        'This is the code to return to main window.

        Dim winMenu As New MainWindow
        winMenu.Show()
        Me.Close()

    End Sub

End Class
