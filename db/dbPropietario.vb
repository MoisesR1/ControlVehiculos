Imports System.Data.SqlClient

Public Class dbPropietario
    Private ReadOnly dbHelper = New DbHelper() 'clase para manejar la conexion y consultas a la base de datos
    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Propietarios (IdPersona) 
             VALUES (@IdPersona)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@idPersona", Persona.IdPersona)
            }
            dbHelper.ExecuteNonQuery(sql, parametros)

        Catch ex As Exception
            Return "Error al guardar la persona: " & ex.Message
        End Try
        Return "Propietario Guardada"
    End Function
    Public Function Consulta() As DataTable
        Dim sql As String = "SELECT pr.IdPropietario, (p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2) AS NombreCompleto
                             FROM Persona p
                             INNER JOIN Propietarios pr ON p.idPersona = pr.IdPersona"
        Return dbHelper.ExecuteQuery(sql)
    End Function
End Class

