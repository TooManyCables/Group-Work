Public Class Document


    Public Day As UInt16, Month As UInt16, Year As UInt16
    Private CurrentFontSize As Int16 = 11


    Sub New()

        InitializeComponent()

        '    'Me.Title = "Dear Diary - " & Day & "/" & Month & "/" & Year + 2000
        '    'rtxContent.Document

        Dim OldPath As String = AppDomain.CurrentDomain.BaseDirectory
        Dim NewPath As String = Nothing

        For c As UInt16 = 0 To OldPath.Length - 10

            NewPath = OldPath.Chars(c)

        Next

        Me.Icon = (NewPath & "Images\Logo.ico")

    End Sub

    Private Sub txtFontSize_LostFocus(sender As Object, e As RoutedEventArgs) Handles txtFontSize.LostFocus

        Try

            If txtFontSize.Text > 0 And txtFontSize.Text <= 72 Then

                rtxContent.FontSize = txtFontSize.Text
                CurrentFontSize = txtFontSize.Text

            End If

        Catch
            'The exception would be "Cannot convert string to double".
            'Reset the text to what it was before exception, resolving the issue.

            txtFontSize.Text = CurrentFontSize
            rtxContent.Focus()

        End Try

    End Sub

    Private Sub txtFontSize_GotFocus(sender As Object, e As RoutedEventArgs) Handles txtFontSize.GotFocus

        CurrentFontSize = txtFontSize.Text

    End Sub

    Private Sub rtxContent_GotFocus(sender As Object, e As RoutedEventArgs) Handles rtxContent.GotFocus



    End Sub


    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)

        'Save the document.

        'Dim a = rtxContent.

        'If rtxContent.ExtentWidth Then

        'FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "Save Files\" & Day & "-" & Month & "-" & Year, OpenMode.Output)

        For lines As UInt16 = 0 To rtxContent.ExtentHeight

        Next

        FileClose(1)


        Dim winSelc As New Selection
        winSelc.Show()


    End Sub
End Class
