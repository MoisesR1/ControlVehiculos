Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New dbPersona()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub Btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            persona.Nombre = Txt_nombre.Text
            persona.Apellido1 = Txt_apellido1.Text
            persona.Apellido2 = Txt_apellido2.Text
            persona.Nacionalidad = Txt_nacionalidad.Text
            persona.FechaNacimiento = Txt_FechaNacimiento.Text
            persona.Telefono = Txt_Telefono.Text


            lbl_mensaje.Text = dbHelper.create(persona)
            Txt_nombre.Text = ""
                Txt_apellido1.Text = ""
                Txt_apellido2.Text = ""
                Txt_nacionalidad.Text = ""
                Txt_FechaNacimiento.Text = ""
                Txt_Telefono.Text = ""


                Gv_personas.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar la persona: " & ex.Message
        End Try

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
            .Apellido1 = e.NewValues("Apellido1"),
            .Apellido2 = e.NewValues("Apellido2"),
            .Nacionalidad = e.NewValues("Nacionalidad"),
            .FechaNacimiento = e.NewValues("Fecha de Nacimiento"),
            .Telefono = e.NewValues("Telefono"),
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
        Txt_apellido1.Text = row.Cells(4).Text
        Txt_apellido2.Text = row.Cells(5).Text
        Txt_nacionalidad.Text = row.Cells(6).Text
        Txt_FechaNacimiento.Text = row.Cells(5).Text
        Txt_Telefono.Text = row.Cells(8).Text

        editando.Value = id


    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs)

        Dim persona As Persona = New Persona With {
            .Nombre = Txt_nombre.Text(),
            .Apellido1 = Txt_apellido1.Text(),
            .Apellido2 = Txt_apellido2.Text(),
            .Nacionalidad = Txt_nacionalidad.Text(),
            .FechaNacimiento = Txt_FechaNacimiento.Text(),
            .Telefono = Txt_Telefono.Text(),
            .IdPersona = editando.Value()
        }
        dbHelper.update(persona)
        Gv_personas.DataBind()
        Gv_personas.EditIndex = -1

    End Sub

    Protected Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)

    End Sub
End Class
