Public Class SiteMaster
    Inherits MasterPage
    Protected Autenticado As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim usuario As Usuario = Session("Usuario")
        Autenticado = usuario IsNot Nothing 'Verifica si el usuario está autenticado
        Dim esAdmin As Boolean = usuario?.Rol = "2" 'Verifica si el usuario es administrador
        liAdmin.Visible = esAdmin 'Muestra u oculta el enlace de administrador según el rol
    End Sub

    Protected Sub LogOut_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub
End Class