Class MainWindow 

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Dim awds As New Application

        'Me.Icon = awds.GetIcon

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As RoutedEventArgs) Handles btnSearch.Click
        'Sub written by Steven.

        'Make the code, and if there's time, create a transition animation.

        Dim winSelc As New Selection
        winSelc.Show()
        Me.Close()

    End Sub

End Class
