' GISC 6387 - David Lindsey - dcl160230@utdallas.edu
' The lockRelease button tool is designed To assist With any 'sr.lock' occurrences (e.g. shapefile locks) on a data file after it has been removed from ArcMap.
' The user can click this button to remove any locks that the HazardDataButton functionality is unable to accomplish.

Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms

Public Class btn_LockRelease

    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    'Header text for any error messages.
    Dim errorMessage_header As String = "Error Message"

    Protected Overrides Sub OnClick()

        'Depending on the ArcMap view, this button is designed to switch from one view (data view/layout view) to the other, 
        'and then back again. This is a work-around for removing a persistent shapefile lock once a shapefile has been removed from ArcMap.

        Try

            Dim pMxDoc As IMxDocument
            pMxDoc = My.ArcMap.Document

            If pMxDoc.ActiveView Is pMxDoc.PageLayout Then

                pMxDoc.ActiveView = pMxDoc.FocusMap
                pMxDoc.ActiveView = pMxDoc.PageLayout

            Else

                pMxDoc.ActiveView = pMxDoc.PageLayout
                pMxDoc.ActiveView = pMxDoc.FocusMap

            End If

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: OnClick()" &
                            vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

End Class
