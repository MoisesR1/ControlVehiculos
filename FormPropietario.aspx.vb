Imports ControlVehiculos.Utils

Public Class FormPropietario
    Inherits System.Web.UI.Page
    Protected dbPersona As New dbPersona()
    Protected dbPropietario As New dbPropietario()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Public Sub CargarPersonas()
        Ddl_personas.DataSource = dbPersona.Consulta()
        Ddl_personas.DataTextField = "NombreCompleto"
        Ddl_personas.DataValueField = "idPersona"
        Ddl_personas.DataBind()
        Ddl_personas.Items.Insert(0, New ListItem("--Seleccione una persona--", "0"))
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try

            Dim IdPersona = Ddl_personas.SelectedValue
            Dim mensaje = dbPropietario.create(New Persona With {.IdPersona = IdPersona})
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If

        Catch ex As Exception

            SwalUtils.ShowSwalError(Me, "Error", ex.Message)
        End Try
    End Sub
End Class