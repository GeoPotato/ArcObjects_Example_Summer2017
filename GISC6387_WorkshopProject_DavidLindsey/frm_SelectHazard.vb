Public Class frm_SelectHazard
    Private Sub btn_earthquake_Click(sender As Object, e As EventArgs) Handles btn_earthquake.Click

        Try

            'Opens a Windows Form for earthquakes.

            Dim earthquake_options As frm_earthquakeOptions = New frm_earthquakeOptions
            earthquake_options.ShowDialog()

        Catch ex As Exception

            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString)

        Finally

            'Me.Close()

        End Try

    End Sub

    Private Sub btn_tornado_Click(sender As Object, e As EventArgs) Handles btn_tornado.Click

        Try

            'Opens a Windows Form for tornadoes.

            Dim tornado_options As frm_tornadoOptions = New frm_tornadoOptions
            tornado_options.ShowDialog()

        Catch ex As Exception

            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString)

        Finally

            'Me.Close()

        End Try

    End Sub

    Private Sub btn_hail_Click(sender As Object, e As EventArgs) Handles btn_hail.Click

        Try

            'Opens a Windows Form for hail.

            Dim hail_options As frm_hailOptions = New frm_hailOptions
            hail_options.ShowDialog()

        Catch ex As Exception

            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString)

        Finally

            'Me.Close()

        End Try

    End Sub

    Private Sub btn_hurricane_Click(sender As Object, e As EventArgs) Handles btn_hurricane.Click

        Try

            'Opens a Windows Form for hurricanes.

            Dim hurricane_options As frm_hurricaneOptions = New frm_hurricaneOptions
            hurricane_options.ShowDialog()

        Catch ex As Exception

            MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString)

        Finally

            'Me.Close()

        End Try

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click

        'Cancels/closes the selection window.

        frm_SelectHazard.ActiveForm.Close()

    End Sub

End Class