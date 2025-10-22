Imports System.Data.SqlClient

Public Class dbPersona

    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre, Apellido, Edad) VALUES (@Nombre, @Apellido, @Edad)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido1),
                New SqlParameter("@Edad", Persona.FechaNacimiento)
                }

            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return False

        End Try
        Return True
    End Function

    Public Function delete(id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Personas WHERE ID = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", id)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona Eliminada"
    End Function

    Public Function update(Persona As Persona) As String
        Try
            Dim sql As String = "UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad WHERE ID = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", Persona.IdPersona),
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido1),
                New SqlParameter("@Edad", Persona.FechaNacimiento)
                }
            Using connection As New SqlConnection(ConectionString)
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona Actualizada"
    End Function
End Class