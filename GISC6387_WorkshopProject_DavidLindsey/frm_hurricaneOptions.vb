Imports ESRI.ArcGIS.Desktop
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.CartoUI
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geoprocessing
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.DisplayUI
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.EditorExt
Imports ESRI.ArcGIS.GeoDatabaseUI
Imports System.Linq
Imports System.Windows.Forms
Imports System.IO
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.Framework
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.IO.Compression

Public Class frm_hurricaneOptions

    'Universal parameters.
    Dim pMxDoc As IMxDocument
    Dim pMap As IMap
    Dim pWorkspaceFactory As IWorkspaceFactory
    Dim pFeatureWorkspace As IFeatureWorkspace
    Dim pFeatureLayer As IFeatureLayer
    Dim pFeatureClass As IFeatureClass
    Dim exceptionCount As Integer
    Dim timespan_url As String

    'Static folder path information for downloading the CSV.
    Dim folderPath As String
    Dim hurr_YYYY_siteURL As String = "ftp://eclipse.ncdc.noaa.gov/pub/ibtracs/v03r10/all/shp/year/"
    Dim hurr_ALL_siteURL As String = "ftp://eclipse.ncdc.noaa.gov/pub/ibtracs/v03r10/all/shp/"

    'Additional naming information.
    Dim noaa As String = "noaa_"
    Dim ibtracs As String = ".ibtracs"
    Dim fileExtZIP As String = ".zip"
    Dim curYear As Integer = DateTime.Now.ToString("yyyy")
    Dim curDate As String = "_" & DateTime.Now.ToString("yyyyMMdd")

    'Header text for any error messages.
    Dim errorMessage_header As String = "Error Message"

    'Attribute field parameter that symbology is based on for Hurricane data.
    Dim hurr_attField As String = "wmo_wind"

    Private Sub frm_hurrOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This function defines what will be populated within the ComboBox list for the hurricane timeframes.

        Try

            txt_hurr_url.Text = "URL will populate once Timespan has been selected."

            lbl_hurr_message.Visible = False

            'This will attempt to keep the tool up-to-date by populating the ComboBox with previous year.
            Dim time_period As Integer = curYear - 1

            cb_hurr_options_timespan.Items.Add("Select...")
            cb_hurr_options_timespan.Items.Add("All | 1842-" & time_period.ToString)

            Do While (time_period >= 1842)

                cb_hurr_options_timespan.Items.Add(time_period.ToString)
                time_period -= 1

            Loop

            cb_hurr_options_timespan.SelectedIndex = 0

        Catch ex As Exception

            MessageBox.Show("Error Location: frm_hurrOptions_Load()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub cb_hurr_options_timespan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_hurr_options_timespan.SelectedIndexChanged

        Try

            Dim selectTime As String = cb_hurr_options_timespan.SelectedItem

            Dim time_period As Integer = curYear - 1

            'Sets the timeframe parameter from the ComboBox list.

            Select Case selectTime

                Case = "Select..."

                    timespan_url = Nothing
                    txt_hurr_url.Text = "URL will populate once Timespan has been selected."

                Case = "All | 1842-" & time_period.ToString

                    timespan_url = "Allstorms"
                    txt_hurr_url.Text = hurr_ALL_siteURL & timespan_url & ibtracs & "_all_lines.v03r10" & fileExtZIP

                Case = cb_hurr_options_timespan.SelectedItem.ToString

                    timespan_url = "Year." & cb_hurr_options_timespan.SelectedItem.ToString
                    txt_hurr_url.Text = hurr_YYYY_siteURL & timespan_url & ibtracs & "_all_lines.v03r10" & fileExtZIP

            End Select

        Catch ex As Exception

            MessageBox.Show("Error Location: cb_hurr_options_timespan_SelectedIndexChanged()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub btn_hurr_options_browse_Click(sender As Object, e As EventArgs) Handles btn_hurr_options_browse.Click

        'User prompted dialog box to select output workspace so the ComboBox knows where to save the downloaded zipped folder.

        Try

            Dim dialog As New FolderBrowserDialog()
            dialog.RootFolder = Environment.SpecialFolder.Desktop
            dialog.Description = "Select folder path to save downloaded shapefile." & vbCrLf &
                "Output folder should not be nested within a previously downloaded natural hazard folder."

            If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

                folderPath = dialog.SelectedPath

            ElseIf DialogResult.Cancel And folderPath = Nothing Then

                MessageBox.Show("Output folder must be defined." & vbCrLf & vbCrLf &
                                "You must add an output folder path in order to download the data.",
                                errorMessage_header)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_hurr_options_browse_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        Finally

            'Displays the output path name to the window's textbox.
            txt_hurr_outputFolderpath.Text = folderPath

        End Try

    End Sub

    Private Sub btn_hurr_options_OK_Click(sender As Object, e As EventArgs) Handles btn_hurr_options_OK.Click

        Try

            'If the user fails to select a timespan, show error.
            If cb_hurr_options_timespan.SelectedItem.ToString = "Select..." Then

                MessageBox.Show("Invalid timespan entry." & vbCrLf &
                                "Please select an option from the drop-down list and try again.",
                                errorMessage_header)
                Exit Sub

            End If

            'If the user fails to define an output folder path, show error.
            If folderPath Is Nothing Then

                MessageBox.Show("Output folder path not specified. Please try again.")
                Exit Sub

            End If

            'Display the "...Processing...Please wait..." message.
            lbl_hurr_message.Visible = True

            exceptionCount = 0

            'If input parameters are valid, proceed to next step.
            createFolder()

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_hurr_options_OK_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub btn_hurr_options_Cancel_Click(sender As Object, e As EventArgs) Handles btn_hurr_options_Cancel.Click

        Try

            'Closes the window.

            frm_hurricaneOptions.ActiveForm.Close()

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_hurr_options_Cancel_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub createFolder()

        Try

            'Determine whether the directory exists.
            'If directory already exists, delete all contents and the directory folder.
            If Directory.Exists(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate) Then

                deleteLayer()

                'time delay
                Threading.Thread.Sleep(2000)

                'Deletes the output folder that was created to house the data.
                Directory.Delete(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate, True)

            End If

            'time delay
            Threading.Thread.Sleep(2000)

            'If the directory does not exist, the folder will be created with this.
            My.Computer.FileSystem.CreateDirectory(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)

            'time delay
            Threading.Thread.Sleep(2000)

            'Function to download the CSV from the web URL into the newly created directory.
            download_zippedFolder()

        Catch ex As Exception

            Dim countFiles As Integer = 0

            ' Make a reference to a directory.
            Dim dir As New DirectoryInfo(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)

            ' Get a reference to each file in that directory.
            Dim filesIndir As FileInfo() = dir.GetFiles("*sr.lock*")

            ' Display the names of the files.
            Dim fil As FileInfo
            For Each fil In filesIndir

                countFiles = countFiles + 1

            Next fil

            'Run this code if lock file observed and less than two attempts.
            If countFiles = 1 And exceptionCount < 2 Then

                MessageBox.Show("Oops! There is a continued shapefile lock on:" & vbCrLf & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & "_checked.shp" & vbCrLf &
                                "...within folder:" & vbCrLf & folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & vbCrLf & vbCrLf &
                                "Not a big deal. Once you click OK to this message, we'll attempt to get that stubborn lock removed for you and try again." & vbCrLf & vbCrLf &
                                "If this issue persists, just follow these steps to correct the issue:" & vbCrLf &
                                "1) Ensure that this shapefile has been removed from ArcMap." & vbCrLf &
                                "2) Press the Lock Release button on the toolbar to remove any locks which may be stuck." & vbCrLf &
                                "3) Once you've done that, try to download the data again.",
                                errorMessage_header)

                'Function that controls release of lock file
                ToggleActiveView()

                'time delay.
                Threading.Thread.Sleep(2000)

                exceptionCount = exceptionCount + 1

                'Attempt to re-run the createFolder function.
                createFolder()

                'If multiple lock files observed, notify the user with this code, then abort the operation.
            ElseIf countFiles > 1 Then

                MessageBox.Show("Oops! " & countFiles.ToString & " shapefile locks observed within folder:" & vbCrLf & folderPath & "\" &
                                noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & vbCrLf & vbCrLf &
                                "Please investigate why multiple locks exist within this folder location." & vbCrLf & vbCrLf &
                                "Follow these steps to correct the issue:" & vbCrLf &
                                "1) Ensure that any locked shapefiles within the folder have been removed from ArcMap." & vbCrLf &
                                "2) Press the Lock Release button on the toolbar to remove any locks which may be stuck." & vbCrLf &
                                "3) Once you've done that, try to download the data again.",
                                errorMessage_header)
                Me.Close()

                'If other lock issue encountered (e.g. the user has the CSV open within the folder), notify the user and abort operation.
            Else

                MessageBox.Show("Oops! A file lock exists somewhere within this folder:" & vbCrLf & folderPath & "\" &
                                noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & vbCrLf & vbCrLf &
                                "Please review the following error message for details:" & vbCrLf & ex.Message & vbCrLf & vbCrLf &
                                "Follow these steps to correct the issue:" & vbCrLf &
                                "1) Ensure that any files within the folder are no longer open and/or have been removed from ArcMap." & vbCrLf &
                                "2) Press the Lock Release button on the toolbar to remove any shapefile locks which may be stuck." & vbCrLf &
                                "3) Once you've done that, try to download the data again.",
                                errorMessage_header)
                Me.Close()

            End If

        End Try

    End Sub

    Private Sub download_zippedFolder()

        'This function controls the downloading of zipped data from URL.

        Try

            'If timespan is all encompassing, download via these parameters...
            If timespan_url = "Allstorms" Then

                My.Computer.Network.DownloadFile(hurr_ALL_siteURL & timespan_url & ibtracs & "_all_lines.v03r10" & fileExtZIP,
                                                 folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP,
                                                 Nothing, Nothing, True, 100000, True)

                MessageBox.Show("Download complete for " & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP & vbCrLf & vbCrLf &
                                "Extracting zipped file to:" & vbCrLf & folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)

                'The process to read/extract zipped files.
                Using archive As System.IO.Compression.ZipArchive = ZipFile.OpenRead(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP)

                    For Each entry As ZipArchiveEntry In archive.Entries

                        If entry.FullName.StartsWith(timespan_url & ibtracs & "_all_lines.v03r10", StringComparison.OrdinalIgnoreCase) Then

                            entry.ExtractToFile(System.IO.Path.Combine(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & "\",
                                                                       entry.FullName.Replace(timespan_url & ibtracs & "_all_lines.v03r10",
                                                                       noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)), True)

                        End If

                    Next
                End Using

                'Delete original zipped folder, as it is no longer needed.
                My.Computer.FileSystem.DeleteFile(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP)

            Else

                'If timespan is not all encompassing, download via these parameters...
                My.Computer.Network.DownloadFile(hurr_YYYY_siteURL & timespan_url & ibtracs & "_all_lines.v03r10" & fileExtZIP,
                                                 folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP,
                                                 Nothing, Nothing, True, 100000, True)

                MessageBox.Show("Download complete for " & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP & vbCrLf & vbCrLf &
                                "Extracting zipped file to:" & vbCrLf & folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)

                'The process to read/extract zipped files.
                Using archive As System.IO.Compression.ZipArchive = ZipFile.OpenRead(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP)

                    For Each entry As ZipArchiveEntry In archive.Entries

                        If entry.FullName.StartsWith(timespan_url & ibtracs & "_all_lines.v03r10", StringComparison.OrdinalIgnoreCase) Then

                            entry.ExtractToFile(System.IO.Path.Combine(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & "\",
                                                                       entry.FullName.Replace(timespan_url & ibtracs & "_all_lines.v03r10",
                                                                       noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)), True)

                        End If

                    Next

                End Using

                'Delete original zipped folder, as it is no longer needed.
                My.Computer.FileSystem.DeleteFile(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate & fileExtZIP)

            End If

            If checkbox_hurr_addData.Checked = False Then

                'If Add to ArcMap checkbox is unchecked, exit.
                Me.Close()

            ElseIf checkbox_hurr_addData.Checked = True Then

                'If Add to ArcMap checkbox is checked, proceed to these steps.
                AddFeatureClass()
                extentReset()
                Me.Close()

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: download_zippedFolder()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            'If error encountered with download, but folder was already created, then delete it.
            If Directory.Exists(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate) Then

                Directory.Delete(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate, True)

            End If

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub AddFeatureClass()

        Try

            'Specify the workspace and the feature class.
            pWorkspaceFactory = New ShapefileWorkspaceFactory
            pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(folderPath & "\" & noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate, 0)
            pFeatureClass = pFeatureWorkspace.OpenFeatureClass(noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate)

            'Prepare a feature layer.
            pFeatureLayer = New FeatureLayer
            pFeatureLayer.FeatureClass = pFeatureClass
            pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName

            'Add the feature layer to the active map.
            pMxDoc = My.ArcMap.Document
            pMap = pMxDoc.FocusMap
            pMap.AddLayer(pFeatureLayer)

            'Refresh the active view
            pMxDoc.ActiveView.Refresh()

            'Symbolize the shapefile.
            hurricaneSymbology()

        Catch ex As Exception

            MessageBox.Show("Error Location: AddFeatureClass()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Function GetRGBColor(R As Long, G As Long, B As Long)

        'This function defines the RGB color values.

        Try

            Dim pColor As IRgbColor
            pColor = New RgbColor
            pColor.Red = R
            pColor.Green = G
            pColor.Blue = B
            GetRGBColor = pColor

        Catch ex As Exception

            MessageBox.Show("Error Location: GetRGBColor()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Function

        End Try

    End Function

    Private Sub hurricaneSymbology()

        Try

            Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(hurr_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." &
                                vbCrLf & vbCrLf & "Missing attribute field:  " & hurr_attField,
                                errorMessage_header)
                Exit Sub

            Else

                'If attribute field is present, proceed to symbolize it.
                pCBR.Field = hurr_attField

            End If

            'Set the symbol, break, and label for each class.
            Dim pLineSymbol As ISimpleLineSymbol
            pLineSymbol = New SimpleLineSymbol
            pCBR.BreakCount = 8

            'Hurricane category with invalid/unspecified (negative) wind values.
            With pLineSymbol
                'Black
                .Color = GetRGBColor(0, 0, 0)
                .Width = 1
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(0) = pLineSymbol
            pCBR.Break(0) = 0
            pCBR.Label(0) = "Unspecified"

            'Category with wind speeds from 0-38.99 mph
            With pLineSymbol
                'Light Green
                .Color = GetRGBColor(150, 200, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(1) = pLineSymbol
            pCBR.Break(1) = 38.99
            pCBR.Label(1) = "Tropical Depression"

            'Category with wind speeds between 39-73.99 mph.
            With pLineSymbol
                'Green
                .Color = GetRGBColor(0, 150, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(2) = pLineSymbol
            pCBR.Break(2) = 73.99
            pCBR.Label(2) = "Tropical Storm"

            'Category with wind speeds between 74-95.99 mph.
            With pLineSymbol
                'Dark Yellow
                .Color = GetRGBColor(255, 235, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(3) = pLineSymbol
            pCBR.Break(3) = 95.99
            pCBR.Label(3) = "Category 1"

            'Category with wind speeds between 96-110.99 mph.
            With pLineSymbol
                'Orange
                .Color = GetRGBColor(255, 150, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(4) = pLineSymbol
            pCBR.Break(4) = 110.99
            pCBR.Label(4) = "Category 2"

            'Category with wind speeds between 111-129.99 mph.
            With pLineSymbol
                'Dark Orange
                .Color = GetRGBColor(255, 75, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(5) = pLineSymbol
            pCBR.Break(5) = 129.99
            pCBR.Label(5) = "Category 3"

            'Category with wind speeds between 130-156.99 mph.
            With pLineSymbol
                'Red
                .Color = GetRGBColor(255, 0, 0)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(6) = pLineSymbol
            pCBR.Break(6) = 156.99
            pCBR.Label(6) = "Category 4"

            'Category with wind speeds between 157-200 mph
            With pLineSymbol
                'Pink
                .Color = GetRGBColor(255, 0, 255)
                .Width = 1.5
                .Style = esriSimpleLineStyle.esriSLSSolid
            End With

            pCBR.Symbol(7) = pLineSymbol
            pCBR.Break(7) = 200
            pCBR.Label(7) = "Category 5"

            Dim pGFLayer As IGeoFeatureLayer = pFeatureLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: hurricaneSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub extentReset()

        Try

            'Reset the extent to all loaded layers.
            pMxDoc = My.ArcMap.Document
            Dim pActiveView As IActiveView = pMxDoc.FocusMap
            pMxDoc.ActiveView.Extent = pActiveView.FullExtent
            pMxDoc.ActivatedView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: extentReset()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub deleteLayer()

        Try

            pMxDoc = My.ArcMap.Document
            pMap = pMxDoc.FocusMap
            Dim pEnumLayer As IEnumLayer = pMap.Layers
            Dim pLayer As ILayer = pEnumLayer.Next
            pEnumLayer.Reset()

            'If no layers present within ArcMap, exit.
            If pLayer Is Nothing Then

                Exit Sub

            Else

                'If layers are observed within ArcMap...
                Do While Not pLayer Is Nothing

                    If pLayer.Name.Equals(noaa & timespan_url.Replace("-", "_to_") & ibtracs.Replace(".", "_") & curDate) Then

                        'If layer name in ArcMap Table of Contents matches this string, remove layer from ArcMap.
                        Dim GP As Object
                        GP = CreateObject("esriGeoprocessing.GpDispatch.1")
                        GP.Delete_management(pLayer)

                    End If

                    pLayer = pEnumLayer.Next

                Loop

                pMxDoc.UpdateContents()
                pMxDoc.ActiveView.Refresh()

            End If

            'Time delay.
            Threading.Thread.Sleep(2000)

        Catch ex As Exception

            MessageBox.Show("Error Location: deleteLayer()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub ToggleActiveView()

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

            MessageBox.Show("Error Location: ToggleActiveView()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_hurr_message.Visible = False

            Exit Sub

        Finally

            'Time delay.
            Threading.Thread.Sleep(2000)

        End Try

    End Sub

End Class