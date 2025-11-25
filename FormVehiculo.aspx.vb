Imports ControlVehiculos.Utils
Public Class FormVehiculo
    Inherits System.Web.UI.Page
    Public vehiculo As New Vehiculo()
    Protected dbHelper As New dbVehiculo()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Btn_guardar_Click(sender As Object, e As EventArgs)
        Try
            vehiculo.IdVehiculo = Txt_idVehiculo.Text
            vehiculo.Placa = Txt_placa.Text
            vehiculo.Marca = Txt_marca.Text
            vehiculo.Modelo = Txt_modelo.Text
            vehiculo.IdPropietario = Convert.ToInt32(Ddl_personas.SelectedValue)

            Dim mensaje = dbHelper.create(vehiculo)
            If mensaje.Contains("Error") Then
                SwalUtils.ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If
            Txt_placa.Text = ""
            Txt_marca.Text = ""
            Txt_modelo.Text = ""
            Ddl_personas.SelectedIndex = 0
            Gv_vehiculos.DataBind()
        Catch ex As Exception
            lbl_mensaje.
            SwalUtils.ShowSwalError(Me, "Error al guardar vehiculo! ", ex.Message)
        End Try
    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs)
        Try
            Dim vehiculo = New Vehiculo With {
            .Marca = Txt_marca.Text(),
            .Modelo = Txt_modelo.Text(),
            .Placa = Txt_placa.Text(),
            .IdVehiculo = editando.Value()
        }
            Dim mensaje = dbHelper.update(vehiculo)
            If mensaje.Contains("Error") Then
                ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If

            Gv_vehiculos.DataBind()
            Gv_vehiculos.EditIndex = -1
            LimpiarCampos()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub LimpiarCampos()
        Txt_marca.Text = ""
        Txt_modelo.Text = ""
        Txt_placa.Text = ""
        Btn_guardar.Visible = True


    End Sub

    Protected Sub Btn_Cancelar_Click(sender As Object, e As EventArgs)

        LimpiarCampos()
    End Sub


    Protected Sub Gv_vehiculos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim placa As String = Gv_vehiculos.DataKeys(e.RowIndex).Value.ToString()
            Dim mensaje As String = dbHelper.delete(placa)
            If mensaje.Contains("Error") Then
                ShowSwalError(Me, "Error", mensaje)
            Else
                ShowSwal(Me, mensaje)
            End If

            e.Cancel = True
            Gv_vehiculos.DataBind()
        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar vehiculo: " & ex.Message
            ShowSwalError(Me, "Error al eliminar vehiculo! ", ex.Message)
        End Try
    End Sub

    Protected Sub Gv_vehiculos_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = Gv_vehiculos.SelectedRow()
        Ddl_personas.SelectedValue = Gv_vehiculos.DataKeys(Gv_vehiculos.SelectedIndex).Values("IdPropietario").ToString()
        Btn_guardar.Visible = False
        editando.Value = Gv_vehiculos.DataKeys(Gv_vehiculos.SelectedIndex).Values("IdVehiculo").ToString()

        Txt_placa.Text = row.Cells(2).Text
        Txt_marca.Text = row.Cells(3).Text
        Txt_modelo.Text = row.Cells(4).Text

    End Sub

    Protected Sub Ddl_personas_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Protected Sub Gv_vehiculos_RowEditing(sender As Object, e As GridViewEditEventArgs)
    End Sub

    Protected Sub Gv_vehiculos_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        Gv_vehiculos.EditIndex = -1
        Gv_vehiculos.DataBind()

    End Sub

    Protected Sub Gv_vehiculos_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
    End Sub


End Class