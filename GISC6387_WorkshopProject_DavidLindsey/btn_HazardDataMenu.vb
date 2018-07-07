' GISC 6387 - David Lindsey - dcl160230@utdallas.edu
' This button launches a Windows Form that displays different selection options for natural hazard data.

Imports System.Windows.Forms

Public Class btn_HazardDataMenu

    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    'Header text for any error messages.
    Dim errorMessage_header As String = "Error Message"

    Protected Overrides Sub OnClick()

        Try

            'Opens a Windows Form to display natural hazard options.

            Dim selectHazard_options As frm_SelectHazard = New frm_SelectHazard
            selectHazard_options.Show()

        Catch ex As Exception

            MessageBox.Show("Error Location: OnClick()" &
                            vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

        My.ArcMap.Application.CurrentTool = Nothing

    End Sub

    Protected Overrides Sub OnUpdate()

        Enabled = My.ArcMap.Application IsNot Nothing

    End Sub

End Class
