Imports System.Threading

Public Class Form1

    Public thread As New Thread(AddressOf mainloop)
    Public display As New VBGame

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display.setDisplay(Me, New Size(800, 600), "Spritesheet Tester", True)
        thread.Start()
    End Sub

    Public Sub mainloop()
        Dim opendialog As New OpenFileDialog
        Dim path As String
        Me.Invoke(Sub() opendialog.ShowDialog())
        path = opendialog.FileName

        Dim image As Image = VBGame.loadImage(path)

        display.fill(VBGame.white)
        display.blit(image, display.getRect())
        display.update()

        Dim animation As New Animation(Image, New Size(InputBox("Amount of images in width?"), InputBox("Amount of images in height?")), InputBox("Time between each frame? (milliseconds)"), InputBox("Number of frames?"))
        animation.playAnim()

        While True

            display.fill(VBGame.white)

            display.blit(animation.handle(), New Point(0, 0))

            display.update()
            display.clockTick(64)

        End While

    End Sub

End Class
