Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class dbVehiculo

    ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString
    Private ReadOnly dbHelper = New DbHelper() 'clase para manejar la conexion y consultas a la base de datos
    Public Function create(Vehiculo As Vehiculo) As String
        Try
            Dim sql As String = "INSERT INTO Vehiculos (idVehiculo,Placa, Marca, Modelo, IdPropietario) 
             VALUES (@Placa, @Marca, @Modelo, @IdPropietario)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idVehiculo", Vehiculo.IdVehiculo),
                New SqlParameter("@Placa", Vehiculo.Placa),
                New SqlParameter("@Marca", Vehiculo.Marca),
                New SqlParameter("@Modelo", Vehiculo.Modelo),
                New SqlParameter("@IdPropietario", Vehiculo.IdPropietario)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)
        Catch ex As Exception
            Return "Error al guardar el vehiculo: " & ex.Message
        End Try
        Return "Vehiculo Guardado"
    End Function

    Public Function delete(Placa As String) As String
        Try
            Dim sql As String = "DELETE FROM Vehiculos WHERE Placa = @Placa"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", Placa)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return "Error al eliminar el vehiculo: " & ex.Message
        End Try
        Return "Vehiculo Eliminado"
    End Function

    Public Function update(ByRef Vehiculo As Vehiculo) As String
        Try
            Dim sql As String = "UPDATE Vehiculos SET Marca = @Marca, Modelo = @Modelo, IdPropietario = @IdPropietario WHERE Placa = @Placa"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Placa", Vehiculo.Placa),
                New SqlParameter("@Marca", Vehiculo.Marca),
                New SqlParameter("@Modelo", Vehiculo.Modelo),
                New SqlParameter("@IdPropietario", Vehiculo.IdPropietario)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return "Error al actualizar el vehiculo: " & ex.Message
        End Try
        Return "Vehiculo Actualizado"
    End Function
End Class
