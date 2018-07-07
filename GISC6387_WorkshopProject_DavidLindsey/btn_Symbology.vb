' GISC 6387 - David Lindsey - dcl160230@utdallas.edu
' This button is designed to assign a preset symbology to the currently selected feature layer within the ArcMap Table of Contents.

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
Imports ESRI.ArcGIS.CatalogUI
Imports ESRI.ArcGIS.Catalog

Public Class btn_Symbology

    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    'Universal parameters.
    Dim usgs As String = "usgs"
    Dim hail As String = "hail"
    Dim torn As String = "torn"
    Dim ibtracs As String = "ibtracs"

    'Header text for any error messages.
    Dim errorMessage_header As String = "Error Message"

    'Attribute field parameter that symbology is based on for Earthquake/Hail/Tornado data.
    Dim e_h_t_attField As String = "mag"

    'Attribute field parameter that symbology is based on for Hurricane data.
    Dim hurr_attField As String = "wmo_wind"

    Protected Overrides Sub OnClick()

        'Click the Add-in button will launch the selectedLayer() function.
        selectedLayer()

    End Sub

    Private Sub selectedLayer()

        'This function controls the feature layer selection within ArcMap Table of Contents.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As ILayer = pMxDoc.SelectedLayer

            If pLayer Is Nothing Or TypeOf pLayer IsNot IFeatureLayer Then

                'If a feature layer is not selected, or if more than one layer is selected, show this error message.
                MessageBox.Show("Oops! You either didn't select a feature layer OR you selected more than one." &
                                vbCrLf & vbCrLf & "Please select one feature layer within the Table of Contents and try again.",
                                errorMessage_header)

            Else

                'Else, if one feature layer is selected, proceed to the determineLayerType() function.
                determineLayerType()

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: selectedLayer()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub determineLayerType()

        'This function determines if the selected feature layer is a shapefile.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            'Sets the feature class to the feature layer.
            Dim pFc As IFeatureClass
            pFc = pLayer.FeatureClass

            'Sets the dataset to the feature class.
            Dim pDataset As IDataset
            pDataset = pFc

            If pLayer.DataSourceType.Contains("Shapefile") Then

                'If the data source type is Shapefile, launch the determineShapeType() function.
                determineShapeType()

            Else

                'If data source type is not a Shapefile, launch this error message.
                MessageBox.Show("The selected feature layer is not a shapefile. Try again.",
                                errorMessage_header)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: determineLayerType()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub determineShapeType()

        'This function determines if the shapefile consists of points, polylines, or other features.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            'Sets the feature class to the feature layer.
            Dim pFc As IFeatureClass
            pFc = pLayer.FeatureClass

            'Sets the dataset to the feature class.
            Dim pDataset As IDataset
            pDataset = pFc

            If pFc.ShapeType.ToString.Equals("esriGeometryPoint") Then

                'If the shapefile consists of points, launch the determinePointSource() function.
                determinePointSource()

            ElseIf pFc.ShapeType.ToString.Equals("esriGeometryPolyline") Then

                'If the shapefile consists of polylines, launch the determinePolylineSource() function.
                determinePolylineSource()

            Else

                'If the shapefile is neither point or polyline, then it is not a shapefile downloaded/created from the Natural Hazard functionality. 
                MessageBox.Show("Oops! This is not a point or polyline shapefile. Try again.",
                                errorMessage_header)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: determineShapeType()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub determinePointSource()

        'This function determines if the point shapefile data source name contains a specific string value.
        'With this setup, the user is allowed to rename the feature layer within ArcMap, so long as the data source name is unaltered.
        'This code is dependent on the data source name remaining unaltered.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            'Sets the feature class to the feature layer.
            Dim pFc As IFeatureClass
            pFc = pLayer.FeatureClass

            'Sets the dataset to the feature class.
            Dim pDataset As IDataset
            pDataset = pFc

            If pDataset.Name.Contains(usgs) Then

                'If the point shapefile data source name contains "usgs", launch the earthquakeSymbology() function.
                earthquakeSymbology()

            ElseIf pDataset.Name.Contains(hail) Then

                'If the point shapefile data source name contains "hail", launch the hailSymbology() function.
                hailSymbology()

            ElseIf pDataset.Name.Contains(torn) Then

                'If the point shapefile data source name contains "torn", launch the tornSymbology() function.
                tornadoSymbology()

            Else

                'If the point shapefile data source name does not contain the above string options, return this error message and exit the function.
                MessageBox.Show("Uh oh! Did you rename the source shapefile to something customized?" & vbCrLf & vbCrLf &
                                "The code is unable to pair with the correct symbology.",
                                errorMessage_header)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: determinePointSource()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub determinePolylineSource()

        'This function determines if the polyline shapefile data source name contains a specific string value.
        'With this setup, the user is allowed to rename the feature layer within ArcMap, so long as the data source name is unaltered.
        'This code is dependent on the data source name remaining unaltered.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            'Sets the feature class to the feature layer.
            Dim pFc As IFeatureClass
            pFc = pLayer.FeatureClass

            'Sets the dataset to the feature class.
            Dim pDataset As IDataset
            pDataset = pFc

            If pDataset.Name.Contains(ibtracs) Then

                'If the polyline shapefile data source name contains "ibtracs", launch the hurricaneSymbology() function.
                hurricaneSymbology()

            Else

                'If the polyline shapefile data source name does not contain the above string option, return this error message and exit the function.
                MessageBox.Show("Uh oh! Did you customize the shapefile's name or attributes?" & vbCrLf & vbCrLf &
                                "The code is unable to pair the shapefile with the correct symbology.",
                                errorMessage_header)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Error Location: determinePolylineSource()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)
            Exit Sub

        End Try

    End Sub

    Private Sub earthquakeSymbology()

        'This function assigns the symbology for the earthquake shapefile.

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            Dim pFeatureClass As IFeatureClass = pLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(e_h_t_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." & vbCrLf & vbCrLf &
                                "Missing attribute field:  " & e_h_t_attField,
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

            Dim pGFLayer As IGeoFeatureLayer = pLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: magSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            Exit Sub

        End Try

    End Sub

    Private Sub hailSymbology()

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            Dim pFeatureClass As IFeatureClass = pLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(e_h_t_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." & vbCrLf & vbCrLf &
                                "Missing attribute field:  " & e_h_t_attField,
                                errorMessage_header)
                Exit Sub

            Else

                'If attribute field is present, proceed to symbolize it.
                pCBR.Field = e_h_t_attField

            End If

            'Set the symbol, break, and label for each class.
            Dim pMarkerSymbol As ISimpleMarkerSymbol
            pMarkerSymbol = New SimpleMarkerSymbol
            pCBR.BreakCount = 4

            'Hail with diameter less than 1"
            With pMarkerSymbol
                'Green
                .Color = GetRGBColor(0, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 4
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(0) = pMarkerSymbol
            pCBR.Break(0) = 0.99
            pCBR.Label(0) = "Less than 1" & Chr(34)

            'Hail with diameter between 1" and 1.99"
            With pMarkerSymbol
                'Dark Yellow
                .Color = GetRGBColor(255, 235, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 6
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(1) = pMarkerSymbol
            pCBR.Break(1) = 1.99
            pCBR.Label(1) = "Between 1" & Chr(34) & " and 1.99" & Chr(34)

            'Hail with diameter between 2" and 2.99"
            With pMarkerSymbol
                'Orange
                .Color = GetRGBColor(255, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 8
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(2) = pMarkerSymbol
            pCBR.Break(2) = 2.99
            pCBR.Label(2) = "Between 2" & Chr(34) & " and 2.99" & Chr(34)

            'Hail with diameter 3" and above
            With pMarkerSymbol
                'Red
                .Color = GetRGBColor(255, 0, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 10
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(3) = pMarkerSymbol
            pCBR.Break(3) = 9.99
            pCBR.Label(3) = "3" & Chr(34) & " and Above"

            Dim pGFLayer As IGeoFeatureLayer = pLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: hailSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            Exit Sub

        End Try

    End Sub

    Private Sub hurricaneSymbology()

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            Dim pFeatureClass As IFeatureClass = pLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(hurr_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." & vbCrLf & vbCrLf &
                                "Missing attribute field:  " & hurr_attField,
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

            Dim pGFLayer As IGeoFeatureLayer = pLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: hurricaneSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

            Exit Sub

        End Try

    End Sub

    Private Sub tornadoSymbology()

        Try

            Dim pMxDoc As IMxDocument = My.ArcMap.Document
            Dim pLayer As IFeatureLayer = pMxDoc.SelectedLayer

            Dim pFeatureClass As IFeatureClass = pLayer.FeatureClass
            Dim pFields As IFields = pFeatureClass.Fields

            'Index location for the attribute field to symbolize on.
            Dim int As Integer = pFields.FindField(e_h_t_attField)

            'Defines the class breaks
            Dim pCBR As IClassBreaksRenderer
            pCBR = New ClassBreaksRenderer

            If int = -1 Then

                'If attribute field index location is not found, display error message and exit the function.
                MessageBox.Show("Unable to symbolize the layer due to missing attribute field." & vbCrLf & vbCrLf &
                                "Missing attribute field:  " & e_h_t_attField,
                                errorMessage_header)
                Exit Sub

            Else

                'If attribute field is present, proceed to symbolize it.
                pCBR.Field = e_h_t_attField

            End If

            'Set the symbol, break, and label for each class.
            Dim pMarkerSymbol As ISimpleMarkerSymbol
            pMarkerSymbol = New SimpleMarkerSymbol
            pCBR.BreakCount = 7

            'Tornado category with unspecified (negative) values.
            With pMarkerSymbol
                'Black
                .Color = GetRGBColor(0, 0, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 4
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(0) = pMarkerSymbol
            pCBR.Break(0) = -0.01
            pCBR.Label(0) = "Unspecified"

            'Tornadoes classified as EF-0.
            With pMarkerSymbol
                'Green
                .Color = GetRGBColor(0, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 6
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(1) = pMarkerSymbol
            pCBR.Break(1) = 0
            pCBR.Label(1) = "EF-0"

            'Tornadoes classified as EF-1.
            With pMarkerSymbol
                'Dark Yellow
                .Color = GetRGBColor(255, 235, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 8
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(2) = pMarkerSymbol
            pCBR.Break(2) = 1
            pCBR.Label(2) = "EF-1"

            'Tornadoes classified as EF-2.
            With pMarkerSymbol
                'Orange
                .Color = GetRGBColor(255, 150, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 10
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(3) = pMarkerSymbol
            pCBR.Break(3) = 2
            pCBR.Label(3) = "EF-2"

            'Tornadoes classified as EF-3.
            With pMarkerSymbol
                'Dark Orange
                .Color = GetRGBColor(255, 75, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 12
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(4) = pMarkerSymbol
            pCBR.Break(4) = 3
            pCBR.Label(4) = "EF-3"

            'Tornadoes classified as EF-4.
            With pMarkerSymbol
                'Red
                .Color = GetRGBColor(255, 0, 0)
                .Outline = True
                .OutlineSize = 1
                .Size = 14
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(5) = pMarkerSymbol
            pCBR.Break(5) = 4
            pCBR.Label(5) = "EF-4"

            'Tornadoes classified as EF-5.
            With pMarkerSymbol
                'Pink
                .Color = GetRGBColor(255, 0, 255)
                .Outline = True
                .OutlineSize = 1
                .Size = 16
                .Style = esriSimpleMarkerStyle.esriSMSCircle
            End With

            pCBR.Symbol(6) = pMarkerSymbol
            pCBR.Break(6) = 5
            pCBR.Label(6) = "EF-5"

            Dim pGFLayer As IGeoFeatureLayer = pLayer
            pGFLayer.Renderer = pCBR

            pMxDoc.ActiveView.Refresh()
            pMxDoc.UpdateContents()

        Catch ex As Exception

            MessageBox.Show("Error Location: tornadoSymbology()" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.GetType.ToString,
                            errorMessage_header)

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

            Exit Function

        End Try

    End Function

    Protected Overrides Sub OnUpdate()

        'This disables/enables the Add-In button if no feature layers are present with the ArcMap table of contents.

        Dim MxDoc As IMxDocument
        MxDoc = My.ArcMap.Document
        If MxDoc.FocusMap.LayerCount = 0 Then
            Enabled = False
        Else
            Enabled = True
        End If

    End Sub
End Class
