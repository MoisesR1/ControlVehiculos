Imports System.Data.SqlClient

Public Class dbPropietario
    Private ReadOnly dbHelper = New DbHelper() 'clase para manejar la conexion y consultas a la base de datos
    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Propietarios (IdPropietario, IdPersona) 
             VALUES (@IdPropietario, @IdPersona)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPersona", Persona.Nombre)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)

        Catch ex As Exception
            Return "Error al guardar la persona: " & ex.Message

        End Try
        Return "Persona Guardada"
    End Function
End Class

