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

Public Class frm_earthquakeOptions

    'Universal parameters
    Dim pMxDoc As IMxDocument
    Dim pMap As IMap
    Dim pWorkspaceFactory As IWorkspaceFactory
    Dim pFeatureWorkspace As IFeatureWorkspace
    Dim pFeatureLayer As IFeatureLayer
    Dim pFLayer As IFeatureLayer
    Dim pFeatureClass As IFeatureClass
    Dim exceptionCount As Integer
    Dim timespan_url As String
    Dim mag_url As String
    Dim mag_naming As String

    'Static folder path information for downloading the CSV.
    Dim folderPath As String
    Dim earthquake_siteURL As String = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/"

    'Additional naming information.
    Dim usgs As String = "usgs_"
    Dim fileExtCSV As String = ".csv"
    Dim curDate As String = "_" & DateTime.Now.ToString("yyyyMMdd")

    'Header text for any error messages.
    Dim errorMessage_header As String = "Error Message"

    'Attribute field parameter that symbology is based on for Earthquake/Hail/Tornado data.
    Dim e_h_t_attField As String = "mag"

    'Current header information for downloaded CSV.
    Dim quake_headers As String = "time" & "," & "latitude" & "," & "longitude" & "," & "depth" & "," & "mag" & "," & "magType" & "," & "nst" & "," & "gap" & "," &
                                  "dmin" & "," & "rms" & "," & "net" & "," & "id" & "," & "updated" & "," & "place" & "," & "type" & "," & "horizontalError" & "," &
                                  "depthError" & "," & "magError" & "," & "magNst" & "," & "status" & "," & "locationSource" & "," & "magSource"

    Private Sub frm_earthquakeOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This function defines what will be populated within the ComboBox list for the earthquake timeframes and magnitudes.

        Try

            lbl_eq_message.Visible = False

            txt_eq_url.Text = "URL will populate once Timespan and Magnitude have been selected."

            Dim timespan As String() = {"Select...", "Past Hour", "Past Day", "Past 7 Days", "Past 30 Days"}

            For Each time_period As String In timespan
                cb_eq_options_timespan.Items.Add(time_period)
            Next

            cb_eq_options_timespan.SelectedIndex = 0

            Dim magnitude As String() = {"Select...", "All", "1.0+", "2.5+", "4.5+"}

            For Each mag As String In magnitude
                cb_eq_options_mag.Items.Add(mag)
            Next

            cb_eq_options_mag.SelectedIndex = 0

        Catch ex As Exception

            MessageBox.Show("Error Location: frm_earthquakeOptions_Load()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub cb_eq_options_timespan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_eq_options_timespan.SelectedIndexChanged

        Try

            Dim selectTime As String = cb_eq_options_timespan.SelectedItem

            'Sets the timeframe parameter from the ComboBox list.

            Select Case selectTime

                Case = "Select..."

                    timespan_url = Nothing
                    txt_eq_url.Text = "URL will populate once Timespan and Magnitude have been selected."

                Case = "Past Hour"

                    timespan_url = "_hour"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "Past Day"

                    timespan_url = "_day"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "Past 7 Days"

                    timespan_url = "_week"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "Past 30 Days"

                    timespan_url = "_month"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

            End Select

        Catch ex As Exception

            MessageBox.Show("Error Location: cb_eq_options_timespan_SelectedIndexChanged()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub cb_eq_options_mag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_eq_options_mag.SelectedIndexChanged

        Try

            Dim selectMag As String = cb_eq_options_mag.SelectedItem

            'Sets the magnitude parameter from the ComboBox list.

            Select Case selectMag

                Case = "Select..."

                    mag_url = Nothing
                    mag_naming = Nothing
                    txt_eq_url.Text = "URL will populate once Timespan and Magnitude have been selected."

                Case = "All"

                    mag_url = "all"
                    mag_naming = "all"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "1.0+"

                    mag_url = "1.0"
                    mag_naming = "1_0"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "2.5+"

                    mag_url = "2.5"
                    mag_naming = "2_5"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

                Case = "4.5+"

                    mag_url = "4.5"
                    mag_naming = "4_5"

                    If mag_url IsNot Nothing And timespan_url IsNot Nothing Then

                        txt_eq_url.Text = earthquake_siteURL & mag_url & timespan_url & fileExtCSV

                    End If

            End Select

        Catch ex As Exception

            MessageBox.Show("Error Location: cb_eq_options_mag_SelectedIndexChanged()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub btn_eq_options_browse_Click(sender As Object, e As EventArgs) Handles btn_eq_options_browse.Click

        'User prompted dialog box to select output workspace so the ComboBox knows where to save the downloaded CSV.

        Try

            Dim dialog As New FolderBrowserDialog()
            dialog.RootFolder = Environment.SpecialFolder.Desktop
            dialog.Description = "Select folder path to save downloaded CSV." & vbCrLf &
                "Output folder should not be nested within a previously downloaded natural hazard folder."

            If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then

                folderPath = dialog.SelectedPath

            ElseIf DialogResult.Cancel And folderPath = Nothing Then

                MessageBox.Show("Output folder must be defined." & vbCrLf & vbCrLf &
                                "You must add an output folder path in order to download the CSV.")
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_eq_options_browse_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        Finally

            'Displays the output path name to the window's textbox.
            txt_eq_outputFolderpath.Text = folderPath

        End Try

    End Sub

    Private Sub btn_eq_options_OK_Click(sender As Object, e As EventArgs) Handles btn_eq_options_OK.Click

        Try

            'If the user fails to select a timespan, show error.
            If cb_eq_options_timespan.SelectedItem = "Select..." Then

                MessageBox.Show("Invalid timespan entry." & vbCrLf &
                                "Please select an option from the drop-down list and try again.",
                                errorMessage_header)
                Exit Sub

            End If

            'If the user fails to select a magnitude, show error.
            If cb_eq_options_mag.SelectedItem = "Select..." Then

                MessageBox.Show("Invalid magnitude entry." & vbCrLf &
                                "Please select an option from the drop-down list and try again.",
                                errorMessage_header)
                Exit Sub

            End If

            'If the user fails to define an output folder path, show error.
            If folderPath Is Nothing Then

                MessageBox.Show("Output folder path not specified. Please try again.",
                                errorMessage_header)
                Exit Sub

            End If

            'Display the "...Processing...Please wait..." message.
            lbl_eq_message.Visible = True

            exceptionCount = 0

            'If input parameters are valid, proceed to next step.
            createFolder()

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_eq_options_OK_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub btn_eq_options_Cancel_Click(sender As Object, e As EventArgs) Handles btn_eq_options_Cancel.Click

        Try

            'Closes the window.

            frm_earthquakeOptions.ActiveForm.Close()

        Catch ex As Exception

            MessageBox.Show("Error Location: btn_eq_options_Cancel_Click()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub createFolder()

        Try

            'Determine whether the directory exists.
            'If directory already exists, delete all contents and the directory folder.
            If Directory.Exists(folderPath & "\" & usgs & mag_naming & timespan_url & curDate) Then

                deleteLayer()

                'time delay.
                Threading.Thread.Sleep(2000)

                'Deletes the output folder that was created to house the data.
                Directory.Delete(folderPath & "\" & usgs & mag_naming & timespan_url & curDate, True)

            End If

            'time delay.
            Threading.Thread.Sleep(2000)

            'If the directory does not exist, the folder will be created with this.
            My.Computer.FileSystem.CreateDirectory(folderPath & "\" & usgs & mag_naming & timespan_url & curDate)

            'time delay.
            Threading.Thread.Sleep(2000)

            'Function to download the CSV from the web URL into the newly created directory.
            download_CSV()

        Catch ex As Exception

            'If the code is unable to delete a previously created folder, run this to locate and release locks.

            Dim countFiles As Integer = 0

            'Make a reference to a directory.
            Dim dir As New DirectoryInfo(folderPath & "\" & usgs & mag_naming & timespan_url & curDate)

            'Get a reference to each file in that directory.
            Dim filesIndir As FileInfo() = dir.GetFiles("*sr.lock*")

            'Display the names of the files.
            Dim fil As FileInfo
            For Each fil In filesIndir
                countFiles = countFiles + 1
            Next fil

            'Run this code if lock file observed and less than two attempts.
            If countFiles = 1 And exceptionCount < 2 Then

                MessageBox.Show("Oops! There is a continued shapefile lock on:" & vbCrLf &
                                usgs & mag_naming & timespan_url & curDate & "_checked.shp" & vbCrLf & "...within folder:" & vbCrLf &
                                folderPath & "\" & usgs & mag_naming & timespan_url & curDate & vbCrLf & vbCrLf &
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

                MessageBox.Show("Oops! " & countFiles.ToString & " shapefile locks observed within folder:" & vbCrLf &
                                folderPath & "\" & usgs & mag_naming & timespan_url & curDate & vbCrLf & vbCrLf &
                                "Please investigate why multiple locks exist within this folder location." & vbCrLf & vbCrLf &
                                "Follow these steps to correct the issue:" & vbCrLf &
                                "1) Ensure that any locked shapefiles within the folder have been removed from ArcMap." & vbCrLf &
                                "2) Press the Lock Release button on the toolbar to remove any locks which may be stuck." & vbCrLf &
                                "3) Once you've done that, try to download the data again.",
                                errorMessage_header)
                Me.Close()

                'If other lock issue encountered (e.g. the user has the CSV open within the folder), notify the user and abort operation.
            Else

                MessageBox.Show("Oops! A file lock exists somewhere within this folder:" & vbCrLf &
                                folderPath & "\" & usgs & mag_naming & timespan_url & curDate & vbCrLf & vbCrLf &
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

    Private Sub download_CSV()

        Try

            'Download the CSV file.

            My.Computer.Network.DownloadFile(earthquake_siteURL & mag_url & timespan_url & fileExtCSV,
                                             folderPath & "\" & usgs & mag_naming & timespan_url & curDate & "\" &
                                             usgs & mag_naming & timespan_url & curDate & fileExtCSV,
                                             Nothing, Nothing, True, 100000, True)

            MessageBox.Show("Download complete for: " & vbCrLf &
                            usgs & mag_naming & timespan_url & curDate & fileExtCSV & vbCrLf & vbCrLf &
                            "Extracting to:" & vbCrLf & folderPath & "\" & usgs & mag_naming & timespan_url & curDate)

            checkCSV_Headers_Zeros()

            Me.Close()

        Catch ex As Exception

            MessageBox.Show("Error Location: download_CSV()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            'If error encountered with download, but folder was already created, then delete it.
            If Directory.Exists(folderPath & "\" & usgs & mag_naming & timespan_url & curDate) Then

                Directory.Delete(folderPath & "\" & usgs & mag_naming & timespan_url & curDate, True)

            End If

            lbl_eq_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub checkCSV_Headers_Zeros()

        Try

            'Open original CSV to review contents.
            Dim SR As New StreamReader(folderPath & "\" & usgs & mag_naming & timespan_url & curDate & "\" &
                                       usgs & mag_naming & timespan_url & curDate & fileExtCSV)

            'Create/Open new CSV that modifications will be saved to.
            Dim SWriter As New StreamWriter(folderPath & "\" & usgs & mag_naming & timespan_url & curDate & "\" &
                                            usgs & mag_naming & timespan_url & curDate & "_checked" & fileExtCSV)

            Dim strLineData() As String
            Dim counter As Integer = 0

            'Do while the reader is able to read the CSV...
            Do While SR.Peek <> -1

                'Read the contents line by line from the existing CSV file and for each line, 
                'Split the contents into an array using the comma as the seperator.
                strLineData = Split(SR.ReadLine, ",")

                If counter = 0 And strLineData(0).Contains("time") Then

                    'If the first line, first row contains "time", then the headers exist. Proceed.
                    Continue Do

                End If

                If counter = 0 And strLineData(0).Contains("time") = False Then

                    'If the first line, first row does not contain "time", then the headers are missing. Write the header line.
                    SWriter.WriteLine(quake_headers)

                End If

                If strLineData(1) <> "0.0" And strLineData(1) <> "0" And strLineData(2) <> "0.0" And strLineData(2) <> "0" Then

                    'Read/Write all lines so long as the specified XY columns (1 & 2) do not contain zeroes. If zeroes exist, exclude those rows.
                    SWriter.WriteLine(strLineData(0) & "," & strLineData(1) & "," & strLineData(2) & "," & strLineData(3) & "," & strLineData(4) & "," &
                                      strLineData(5) & "," & strLineData(6) & "," & strLineData(7) & "," & strLineData(8) & "," & strLineData(9) & "," &
                                      strLineData(10) & "," & strLineData(11) & "," & strLineData(12) & "," & strLineData(13) & "," & strLineData(14) & "," &
                                      strLineData(15) & "," & strLineData(16) & "," & strLineData(17) & "," & strLineData(18) & "," & strLineData(19) & "," &
                                      strLineData(20) & "," & strLineData(21))

                End If

                counter = counter + 1

            Loop

            'Close both files
            SR.Close()
            SWriter.Close()

            MessageBox.Show("File created/checked successfully: " & vbCrLf &
                            usgs & mag_naming & timespan_url & curDate & "_checked" & fileExtCSV & vbCrLf & vbCrLf &
                            "Now exporting to shapefile...")

            'Proceed to next step.
            ifEmptyCSV()

        Catch ex As Exception

            MessageBox.Show("Error Location: checkCSV_Headers_Zeros()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub ifEmptyCSV()

        Try

            If File.ReadAllLines(folderPath & "\" & usgs & mag_naming & timespan_url & curDate & "\" &
                                 usgs & mag_naming & timespan_url & curDate & "_checked" & fileExtCSV).Count <= 1 Then

                'if the CSV has no data rows stored within it aside from headers, show the following message and exit.
                MessageBox.Show("No earthquake features present within:" & vbCrLf &
                                usgs & mag_naming & timespan_url & curDate & "_checked" & fileExtCSV,
                                errorMessage_header)
                Exit Sub

            Else

                'If data rows observed, proceed with these functions.
                XYEvents()
                extentReset()

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: ifEmptyCSV()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub XYEvents()

        Try

            'Part 1: Define the CSV file.
            Dim pWorkspaceName As IWorkspaceName
            Dim pTableName As ITableName
            Dim pDatasetName As IDatasetName

            'Define the input table's workspace.
            pWorkspaceName = New WorkspaceName
            pWorkspaceName.PathName = folderPath & "\" & usgs & mag_naming & timespan_url & curDate
            pWorkspaceName.WorkspaceFactoryProgID = "esriCore.TextFileWorkspaceFactory.1"

            'Define the dataset.
            pTableName = New TableName
            pDatasetName = pTableName
            pDatasetName.Name = usgs & mag_naming & timespan_url & curDate & "_checked" & fileExtCSV
            pDatasetName.WorkspaceName = pWorkspaceName

            'Part 2: Define the XY events source name object.
            Dim pXYEvent2FieldsProperties As IXYEvent2FieldsProperties
            Dim pSpatialReferenceFactory As ISpatialReferenceFactory
            Dim pGeographicCoordinateSystem As IGeographicCoordinateSystem
            Dim pXYEventSourceName As IXYEventSourceName

            'Set the event to fields properties.
            pXYEvent2FieldsProperties = New XYEvent2FieldsProperties
            With pXYEvent2FieldsProperties
                .XFieldName = "longitude"
                .YFieldName = "latitude"
                .ZFieldName = ""
            End With

            'Set the spatial reference.
            pSpatialReferenceFactory = New SpatialReferenceEnvironment
            pGeographicCoordinateSystem = pSpatialReferenceFactory.CreateGeographicCoordinateSystem(esriSRGeoCSType.esriSRGeoCS_WGS1984)

            'Specify the event source and its properties.
            pXYEventSourceName = New XYEventSourceName
            With pXYEventSourceName
                .EventProperties = pXYEvent2FieldsProperties
                .SpatialReference = pGeographicCoordinateSystem
                .EventTableName = pTableName
            End With

            'Part 3: Display XY Data
            Dim pMxDoc As IMxDocument
            Dim pMap As IMap
            Dim pName As IName
            Dim pXYEventSource As IXYEventSource
            Dim pFLayer As IFeatureLayer
            pMxDoc = My.ArcMap.Document
            pMap = pMxDoc.FocusMap

            'Open the events source name object.
            pName = pXYEventSourceName
            pXYEventSource = pName.Open

            'Create a New feature layer And add the layer to the display.
            pFLayer = New FeatureLayer
            pFLayer.FeatureClass = pXYEventSource
            pFLayer.Name = usgs & mag_naming & timespan_url & curDate & "_checked"

            'Export XYEvents to shapefile
            Dim GP As Object
            GP = CreateObject("esriGeoprocessing.GpDispatch.1")
            GP.FeatureClasstoShapefile_conversion(pFLayer, pWorkspaceName.PathName)

            'pMap.AddLayer(pFLayer)

            If checkbox_eq_addData.Checked = False Then

                'If Add to ArcMap checkbox is unchecked, exit.
                Exit Sub

            ElseIf checkbox_eq_addData.Checked = True Then

                'If Add to ArcMap checkbox is checked, add the shapefile to ArcMap.
                AddFeatureClass()

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: XYEvents()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

            Exit Sub

        End Try

    End Sub

    Private Sub AddFeatureClass()

        Try

            'Specify the workspace and the feature class.
            pWorkspaceFactory = New ShapefileWorkspaceFactory
            pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(folderPath & "\" & usgs & mag_naming & timespan_url & curDate, 0)
            pFeatureClass = pFeatureWorkspace.OpenFeatureClass(usgs & mag_naming & timespan_url & curDate & "_checked")

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
            magSymbology()

        Catch ex As Exception

            MessageBox.Show("Error Location: AddFeatureClass()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

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

            lbl_eq_message.Visible = False

            Exit Function

        End Try

    End Function

    Private Sub magSymbology()

        Try

            Dim pFeatureClass As IFeatureClass = pFeatureLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(e_h_t_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." &
                                vbCrLf & vbCrLf & "Missing attribute field:  " & e_h_t_attField,
                                errorMessage_header)
                Exit Sub

            Else

                'If attribute field is present, proceed to symbolize it.
                pCBR.Field = e_h_t_attField

            End If

            'Set the symbol, break, and label for each class.
            Dim pMarkerSymbol As ISimpleMarkerSymbol
            pMarkerSymbol = New SimpleMarkerSymbol
            pCBR.BreakCount = 3

            'Earthquakes with magnitudes less than 3.0
            With pMarkerSymbol
                'Green
                .Color = GetRGBColor(0, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 10
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(0) = pMarkerSymbol
            pCBR.Break(0) = 2.99
            pCBR.Label(0) = "Less than 3.0"

            'Earthquakes with magnitudes between 3.0 and 5.9
            With pMarkerSymbol
                'Orange
                .Color = GetRGBColor(255, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 15
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(1) = pMarkerSymbol
            pCBR.Break(1) = 5.99
            pCBR.Label(1) = "Between 3.0 and 5.9"

            'Earthquakes with magnitudes above 6.0
            With pMarkerSymbol
                'Red
                .Color = GetRGBColor(255, 0, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 20
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(2) = pMarkerSymbol
            pCBR.Break(2) = 9.99
            pCBR.Label(2) = "6.0 and Above"

            Dim pGFLayer As IGeoFeatureLayer = pFeatureLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: magSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

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

            lbl_eq_message.Visible = False

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

                    If pLayer.Name.Equals(usgs & mag_naming & timespan_url & curDate & "_checked") Then

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

            'Time delay
            Threading.Thread.Sleep(2000)

        Catch ex As Exception

            MessageBox.Show("Error Location: deleteLayer()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            lbl_eq_message.Visible = False

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

            lbl_eq_message.Visible = False

            Exit Sub

        Finally

            'Time delay
            Threading.Thread.Sleep(2000)

        End Try

    End Sub

End Class