Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim usuario As Usuario = Session("Usuario")
        If usuario Is Nothing Then
            Response.Redirect("Login.aspx")
            Return
        End If
        If usuario.Rol <> "2" Then
            Response.Redirect("Login.aspx")
            Return
        End If
        LblUsuario.Text = "Bienvenido, " & usuario.NombreUsuario
        Lbl_Email.Text = "Correo electronico: " & usuario.Email
    End Sub

End Class