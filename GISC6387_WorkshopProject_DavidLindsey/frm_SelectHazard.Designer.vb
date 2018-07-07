<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SelectHazard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_earthquake = New System.Windows.Forms.Button()
        Me.lbl_hazard = New System.Windows.Forms.Label()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_tornado = New System.Windows.Forms.Button()
        Me.btn_hail = New System.Windows.Forms.Button()
        Me.btn_hurricane = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_earthquake
        '
        Me.btn_earthquake.Location = New System.Drawing.Point(99, 59)
        Me.btn_earthquake.Name = "btn_earthquake"
        Me.btn_earthquake.Size = New System.Drawing.Size(75, 23)
        Me.btn_earthquake.TabIndex = 0
        Me.btn_earthquake.Text = "Earthquake"
        Me.btn_earthquake.UseVisualStyleBackColor = True
        '
        'lbl_hazard
        '
        Me.lbl_hazard.AutoSize = True
        Me.lbl_hazard.Location = New System.Drawing.Point(76, 26)
        Me.lbl_hazard.Name = "lbl_hazard"
        Me.lbl_hazard.Size = New System.Drawing.Size(131, 13)
        Me.lbl_hazard.TabIndex = 1
        Me.lbl_hazard.Text = "Please select hazard type:"
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(99, 202)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 2
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_tornado
        '
        Me.btn_tornado.Location = New System.Drawing.Point(99, 146)
        Me.btn_tornado.Name = "btn_tornado"
        Me.btn_tornado.Size = New System.Drawing.Size(75, 23)
        Me.btn_tornado.TabIndex = 3
        Me.btn_tornado.Text = "Tornado"
        Me.btn_tornado.UseVisualStyleBackColor = True
        '
        'btn_hail
        '
        Me.btn_hail.Location = New System.Drawing.Point(99, 88)
        Me.btn_hail.Name = "btn_hail"
        Me.btn_hail.Size = New System.Drawing.Size(75, 23)
        Me.btn_hail.TabIndex = 4
        Me.btn_hail.Text = "Hail"
        Me.btn_hail.UseVisualStyleBackColor = True
        '
        'btn_hurricane
        '
        Me.btn_hurricane.Location = New System.Drawing.Point(99, 117)
        Me.btn_hurricane.Name = "btn_hurricane"
        Me.btn_hurricane.Size = New System.Drawing.Size(75, 23)
        Me.btn_hurricane.TabIndex = 5
        Me.btn_hurricane.Text = "Hurricane"
        Me.btn_hurricane.UseVisualStyleBackColor = True
        '
        'frm_SelectHazard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(270, 239)
        Me.Controls.Add(Me.btn_hurricane)
        Me.Controls.Add(Me.btn_hail)
        Me.Controls.Add(Me.btn_tornado)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.lbl_hazard)
        Me.Controls.Add(Me.btn_earthquake)
        Me.Name = "frm_SelectHazard"
        Me.Text = "Select Hazard Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_earthquake As Windows.Forms.Button
    Friend WithEvents lbl_hazard As Windows.Forms.Label
    Friend WithEvents btn_cancel As Windows.Forms.Button
    Friend WithEvents btn_tornado As Windows.Forms.Button
    Friend WithEvents btn_hail As Windows.Forms.Button
    Friend WithEvents btn_hurricane As Windows.Forms.Button
End Class
