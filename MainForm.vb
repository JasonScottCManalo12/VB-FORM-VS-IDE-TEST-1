Imports System.Drawing
Imports System.Windows.Forms

Namespace VB_FORM_VS_IDE_TEST_1
    Friend NotInheritable Class MainForm
        Inherits Form

        Public Sub New()
            Text = "VB-FORM-VS-IDE-TEST-1"
            StartPosition = FormStartPosition.CenterScreen
            ClientSize = New Size(640, 360)
            MinimumSize = New Size(480, 300)

            Dim heading As New Label With {
                .AutoSize = False,
                .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Font = New Font("Segoe UI", 18.0F, FontStyle.Bold),
                .Text = "Workflow-built VB.NET Windows Forms"
            }

            Dim details As New Label With {
                .AutoSize = False,
                .Dock = DockStyle.Bottom,
                .Height = 72,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Text = "Built by GitHub Actions." & Environment.NewLine &
                        "No Visual Studio IDE required on the developer PC."
            }

            Controls.Add(heading)
            Controls.Add(details)
        End Sub
    End Class
End Namespace
