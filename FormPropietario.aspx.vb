Public Class FormPropietario
    Inherits System.Web.UI.Page
    Protected dbHelper As New dbPersona()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Public Sub CargarPersonas()
        Ddl_personas.DataSource = dbHelper.Consulta()
        Ddl_personas.DataTextField = "NombreCompleto"
        Ddl_personas.DataValueField = "idPersona"
        Ddl_personas.DataBind()
        Ddl_personas.Items.Insert(0, New ListItem("--Seleccione una persona--", "0"))
    End Sub

End Class