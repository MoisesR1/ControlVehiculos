Imports ControlVehiculos.Utils
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

            Dim mensaje = dbHelper.create(persona)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, "Persona creada")
            End If

            Txt_nombre.Text = ""
            Txt_apellido1.Text = ""
            Txt_apellido2.Text = ""
            Txt_nacionalidad.Text = ""
            Txt_FechaNacimiento.Text = ""
            Txt_Telefono.Text = ""


            Gv_personas.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al guardar la persona: " & ex.Message
            SwalUtils.ShowSwalError(Me, "Error al guardar la persona: ", ex.Message)
        End Try

    End Sub

    Protected Sub Gv_personas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(Gv_personas.DataKeys(e.RowIndex).Value)

            Dim mensaje = dbHelper.delete(id)
            If mensaje.Contains("Error") Then
                ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, "Éxito", mensaje, "success")
            End If

            e.Cancel = True
            Gv_personas.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la persona: " & ex.Message
            ShowSwalError(Me, "Error al eliminar la persona: ", ex.Message)
        End Try
    End Sub

    Protected Sub Gv_personas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        Gv_personas.EditIndex = -1
        Gv_personas.DataBind()

    End Sub

    Protected Sub Gv_personas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(Gv_personas.DataKeys(e.RowIndex).Value)
            Dim persona = New Persona With {
                .Nombre = e.NewValues("Nombre"),
                .Apellido1 = e.NewValues("Apellido1"),
                .Apellido2 = e.NewValues("Apellido2"),
                .Nacionalidad = e.NewValues("Nacionalidad"),
                .FechaNacimiento = e.NewValues("Fecha de Nacimiento"),
                .Telefono = e.NewValues("Telefono"),
                .IdPersona = id
            }
            Dim mensaje = dbHelper.update(persona)
            If mensaje.Contains("Error") Then
                ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If

            Gv_personas.DataBind()
            e.Cancel = True
            Gv_personas.EditIndex = -1
        Catch ex As Exception
            ShowSwalError(Me, "Error al actualizar la persona: ", ex.Message)
        End Try


    End Sub

    Protected Sub Gv_personas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub Gv_personas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = Gv_personas.SelectedRow()
        Dim id As Integer
        Integer.TryParse(Gv_personas.SelectedDataKey.Value?.ToString(), id)
        Dim persona As Persona = New Persona()

        Txt_nombre.Text = row.Cells(2).Text
        Txt_apellido1.Text = row.Cells(3).Text
        Txt_apellido2.Text = row.Cells(4).Text
        Txt_nacionalidad.Text = row.Cells(5).Text
        Txt_FechaNacimiento.Text = row.Cells(6).Text
        Txt_Telefono.Text = row.Cells(7).Text

        editando.Value = id


    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs)

        Try
            Dim persona = New Persona With {
            .Nombre = Txt_nombre.Text(),
            .Apellido1 = Txt_apellido1.Text(),
            .Apellido2 = Txt_apellido2.Text(),
            .Nacionalidad = Txt_nacionalidad.Text(),
            .FechaNacimiento = Txt_FechaNacimiento.Text(),
            .Telefono = Txt_Telefono.Text(),
            .IdPersona = editando.Value()
        }
            Dim mensaje = dbHelper.update(persona)
            If mensaje.Contains("Error") Then
                ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If

            Gv_personas.DataBind()
            Gv_personas.EditIndex = -1
            LimpiarCampos()

        Catch ex As Exception
            ShowSwalError(Me, "Error al actualizar la persona: ", ex.Message)
        End Try

    End Sub

    Protected Sub LimpiarCampos()
        Txt_nombre.Text = ""
        Txt_apellido1.Text = ""
        Txt_apellido2.Text = ""
        Txt_nacionalidad.Text = ""
        Txt_FechaNacimiento.Text = ""
        Txt_Telefono.Text = ""
        Btn_guardar.Visible = True


    End Sub

    Protected Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
    End Sub
End Class
