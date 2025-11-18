Imports ControlVehiculos.Utils
Imports Microsoft.VisualBasic.ApplicationServices
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs)

        Dim nombreUsuario = txtUsuario.Text
        Dim Password = txtPassword.Text
        Dim encrypter As New Simple3Des("MiClaveSecreta123") ' Clave de encriptación
        Dim pass As String = encrypter.EncryptData(Password) ' Encriptar la contraseña
        Dim DbHelper As New dbLogin()
        Dim isValid As Boolean = DbHelper.ValidateLogin(nombreUsuario, pass)
        If isValid Then
            ' Inicio exitoso de sesion
            Dim User As Usuario = DbHelper.GetUser(nombreUsuario) 'Obtener el usuario
            Session("Usuario") = User 'Guardar el usuario en la sesion
            If User.Rol = "2" Then
                Response.Redirect("Admin.aspx") 'Redirige a la pagina administrador
                Return
            End If
            Response.Redirect("Home.aspx")
        Else
            ' Mostrar mensaje de error si las credenciales son incorrectas
            SwalUtils.ShowSwalError(Me, "Error de inicio de sesión", "Credenciales incorrectas.")
        End If
    End Sub
End Class