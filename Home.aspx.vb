Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario As Usuario = Session("Usuario")
        LblUsuario.Text = "Bienvenido(a) " & usuario.NombreUsuario
        Lbl_Email.Text = "Correo electronico: " & usuario.Email
    End Sub

End Class