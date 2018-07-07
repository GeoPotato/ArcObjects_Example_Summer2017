<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_earthquakeOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_eq_options_timespan = New System.Windows.Forms.Label()
        Me.lbl_eq_options_mag = New System.Windows.Forms.Label()
        Me.cb_eq_options_timespan = New System.Windows.Forms.ComboBox()
        Me.cb_eq_options_mag = New System.Windows.Forms.ComboBox()
        Me.lbl_eq_options_outputPath = New System.Windows.Forms.Label()
        Me.btn_eq_options_browse = New System.Windows.Forms.Button()
        Me.btn_eq_options_OK = New System.Windows.Forms.Button()
        Me.btn_eq_options_Cancel = New System.Windows.Forms.Button()
        Me.txt_eq_outputFolderpath = New System.Windows.Forms.TextBox()
        Me.lbl_eq_options_url = New System.Windows.Forms.Label()
        Me.txt_eq_url = New System.Windows.Forms.TextBox()
        Me.lbl_eq_message = New System.Windows.Forms.Label()
        Me.checkbox_eq_addData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lbl_eq_options_timespan
        '
        Me.lbl_eq_options_timespan.AutoSize = True
        Me.lbl_eq_options_timespan.Location = New System.Drawing.Point(45, 13)
        Me.lbl_eq_options_timespan.Name = "lbl_eq_options_timespan"
        Me.lbl_eq_options_timespan.Size = New System.Drawing.Size(89, 13)
        Me.lbl_eq_options_timespan.TabIndex = 0
        Me.lbl_eq_options_timespan.Text = "Select Timespan:"
        '
        'lbl_eq_options_mag
        '
        Me.lbl_eq_options_mag.AutoSize = True
        Me.lbl_eq_options_mag.Location = New System.Drawing.Point(204, 13)
        Me.lbl_eq_options_mag.Name = "lbl_eq_options_mag"
        Me.lbl_eq_options_mag.Size = New System.Drawing.Size(90, 13)
        Me.lbl_eq_options_mag.TabIndex = 1
        Me.lbl_eq_options_mag.Text = "Select Magnitude"
        '
        'cb_eq_options_timespan
        '
        Me.cb_eq_options_timespan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_eq_options_timespan.FormattingEnabled = True
        Me.cb_eq_options_timespan.Location = New System.Drawing.Point(41, 38)
        Me.cb_eq_options_timespan.Name = "cb_eq_options_timespan"
        Me.cb_eq_options_timespan.Size = New System.Drawing.Size(93, 21)
        Me.cb_eq_options_timespan.TabIndex = 2
        '
        'cb_eq_options_mag
        '
        Me.cb_eq_options_mag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_eq_options_mag.FormattingEnabled = True
        Me.cb_eq_options_mag.Location = New System.Drawing.Point(207, 38)
        Me.cb_eq_options_mag.Name = "cb_eq_options_mag"
        Me.cb_eq_options_mag.Size = New System.Drawing.Size(87, 21)
        Me.cb_eq_options_mag.TabIndex = 3
        '
        'lbl_eq_options_outputPath
        '
        Me.lbl_eq_options_outputPath.AutoSize = True
        Me.lbl_eq_options_outputPath.Location = New System.Drawing.Point(25, 142)
        Me.lbl_eq_options_outputPath.Name = "lbl_eq_options_outputPath"
        Me.lbl_eq_options_outputPath.Size = New System.Drawing.Size(131, 13)
        Me.lbl_eq_options_outputPath.TabIndex = 4
        Me.lbl_eq_options_outputPath.Text = "Select Folder to Save File:"
        '
        'btn_eq_options_browse
        '
        Me.btn_eq_options_browse.Location = New System.Drawing.Point(28, 158)
        Me.btn_eq_options_browse.Name = "btn_eq_options_browse"
        Me.btn_eq_options_browse.Size = New System.Drawing.Size(75, 23)
        Me.btn_eq_options_browse.TabIndex = 5
        Me.btn_eq_options_browse.Text = "Browse..."
        Me.btn_eq_options_browse.UseVisualStyleBackColor = True
        '
        'btn_eq_options_OK
        '
        Me.btn_eq_options_OK.Location = New System.Drawing.Point(155, 226)
        Me.btn_eq_options_OK.Name = "btn_eq_options_OK"
        Me.btn_eq_options_OK.Size = New System.Drawing.Size(75, 23)
        Me.btn_eq_options_OK.TabIndex = 6
        Me.btn_eq_options_OK.Text = "OK"
        Me.btn_eq_options_OK.UseVisualStyleBackColor = True
        '
        'btn_eq_options_Cancel
        '
        Me.btn_eq_options_Cancel.Location = New System.Drawing.Point(252, 226)
        Me.btn_eq_options_Cancel.Name = "btn_eq_options_Cancel"
        Me.btn_eq_options_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_eq_options_Cancel.TabIndex = 7
        Me.btn_eq_options_Cancel.Text = "Cancel"
        Me.btn_eq_options_Cancel.UseVisualStyleBackColor = True
        '
        'txt_eq_outputFolderpath
        '
        Me.txt_eq_outputFolderpath.Location = New System.Drawing.Point(111, 160)
        Me.txt_eq_outputFolderpath.Name = "txt_eq_outputFolderpath"
        Me.txt_eq_outputFolderpath.ReadOnly = True
        Me.txt_eq_outputFolderpath.Size = New System.Drawing.Size(216, 20)
        Me.txt_eq_outputFolderpath.TabIndex = 8
        '
        'lbl_eq_options_url
        '
        Me.lbl_eq_options_url.AutoSize = True
        Me.lbl_eq_options_url.Location = New System.Drawing.Point(25, 80)
        Me.lbl_eq_options_url.Name = "lbl_eq_options_url"
        Me.lbl_eq_options_url.Size = New System.Drawing.Size(102, 13)
        Me.lbl_eq_options_url.TabIndex = 21
        Me.lbl_eq_options_url.Text = "URL Download File:"
        '
        'txt_eq_url
        '
        Me.txt_eq_url.Location = New System.Drawing.Point(28, 98)
        Me.txt_eq_url.Name = "txt_eq_url"
        Me.txt_eq_url.ReadOnly = True
        Me.txt_eq_url.Size = New System.Drawing.Size(299, 20)
        Me.txt_eq_url.TabIndex = 20
        '
        'lbl_eq_message
        '
        Me.lbl_eq_message.AutoSize = True
        Me.lbl_eq_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_eq_message.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_eq_message.Location = New System.Drawing.Point(64, 195)
        Me.lbl_eq_message.Name = "lbl_eq_message"
        Me.lbl_eq_message.Size = New System.Drawing.Size(206, 16)
        Me.lbl_eq_message.TabIndex = 22
        Me.lbl_eq_message.Text = "...Processing...Please Wait..."
        '
        'checkbox_eq_addData
        '
        Me.checkbox_eq_addData.AutoSize = True
        Me.checkbox_eq_addData.Location = New System.Drawing.Point(12, 232)
        Me.checkbox_eq_addData.Name = "checkbox_eq_addData"
        Me.checkbox_eq_addData.Size = New System.Drawing.Size(97, 17)
        Me.checkbox_eq_addData.TabIndex = 23
        Me.checkbox_eq_addData.Text = "Add to ArcMap"
        Me.checkbox_eq_addData.UseVisualStyleBackColor = True
        '
        'frm_earthquakeOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 261)
        Me.Controls.Add(Me.checkbox_eq_addData)
        Me.Controls.Add(Me.lbl_eq_message)
        Me.Controls.Add(Me.lbl_eq_options_url)
        Me.Controls.Add(Me.txt_eq_url)
        Me.Controls.Add(Me.txt_eq_outputFolderpath)
        Me.Controls.Add(Me.btn_eq_options_Cancel)
        Me.Controls.Add(Me.btn_eq_options_OK)
        Me.Controls.Add(Me.btn_eq_options_browse)
        Me.Controls.Add(Me.lbl_eq_options_outputPath)
        Me.Controls.Add(Me.cb_eq_options_mag)
        Me.Controls.Add(Me.cb_eq_options_timespan)
        Me.Controls.Add(Me.lbl_eq_options_mag)
        Me.Controls.Add(Me.lbl_eq_options_timespan)
        Me.Name = "frm_earthquakeOptions"
        Me.Text = "Earthquake Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_eq_options_timespan As Windows.Forms.Label
    Friend WithEvents lbl_eq_options_mag As Windows.Forms.Label
    Friend WithEvents cb_eq_options_timespan As Windows.Forms.ComboBox
    Friend WithEvents cb_eq_options_mag As Windows.Forms.ComboBox
    Friend WithEvents lbl_eq_options_outputPath As Windows.Forms.Label
    Friend WithEvents btn_eq_options_browse As Windows.Forms.Button
    Friend WithEvents btn_eq_options_OK As Windows.Forms.Button
    Friend WithEvents btn_eq_options_Cancel As Windows.Forms.Button
    Friend WithEvents txt_eq_outputFolderpath As Windows.Forms.TextBox
    Friend WithEvents lbl_eq_options_url As Windows.Forms.Label
    Friend WithEvents txt_eq_url As Windows.Forms.TextBox
    Friend WithEvents lbl_eq_message As Windows.Forms.Label
    Friend WithEvents checkbox_eq_addData As Windows.Forms.CheckBox
End Class
