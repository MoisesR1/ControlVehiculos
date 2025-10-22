Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub Btn_guardar_Click(sender As Object, e As EventArgs)
        Persona.Nombre = Txt_nombre.Text
        persona.Apellido1 = Txt_apellido.Text
        persona.Apellido2 = Txt_apellido.Text
        persona.FechaNacimiento = Txt_edad.Text

        If dbHelper.create(Persona) Then
            lbl_mensaje.Text = "Persona guardada correctamente"
            Txt_nombre.Text = ""
            Txt_apellido.Text = ""
            Txt_edad.Text = ""
        Else
            lbl_mensaje.Text = "Error al guardar la persona"
        End If

        Gv_personas.DataBind()

    End Sub

    Protected Sub Gv_personas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Gv_personas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            e.Cancel = True
            Gv_personas.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la persona: " & ex.Message

        End Try
    End Sub

    Protected Sub Gv_personas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        Gv_personas.EditIndex = -1
        Gv_personas.DataBind()

    End Sub

    Protected Sub Gv_personas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim id As Integer = Convert.ToInt32(Gv_personas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .Nombre = e.NewValues("Nombre"),
            .Apellido1 = e.NewValues("Apellido"),
            .Apellido2 = e.NewValues("Apellido"),
            .FechaNacimiento = e.NewValues("Edad"),
            .IdPersona = id
        }
        dbHelper.update(persona)
        Gv_personas.DataBind()
        e.Cancel = True
        Gv_personas.EditIndex = -1

    End Sub

    Protected Sub Gv_personas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub Gv_personas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = Gv_personas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()

        Txt_nombre.Text = row.Cells(3).Text
        Txt_apellido.Text = row.Cells(4).Text
        Txt_edad.Text = row.Cells(5).Text

        editando.Value = id


    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs)

        Dim persona As Persona = New Persona With {
            .Nombre = Txt_nombre.Text(),
            .Apellido1 = Txt_apellido.Text(),
            .Apellido2 = Txt_apellido.Text(),
            .FechaNacimiento = Txt_edad.Text(),
            .IdPersona = editando.Value()
        }
        dbHelper.update(persona)
        Gv_personas.DataBind()
        Gv_personas.EditIndex = -1

    End Sub
End Class
