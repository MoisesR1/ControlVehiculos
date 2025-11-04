Imports System.Data.SqlClient

Public Class dbPersona

    Private ReadOnly ConectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Persona (Nombre, Apellido1, Apellido2, Nacionalidad, Fecha de Nacimiento, Telefono) VALUES (@Nombre, @Apellido1, @Apellido2, @Nacionalidad, @Fecha de Nacimiento, @Telefono)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido1", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@Fecha de Nacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono)
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
            Dim sql As String = "DELETE FROM Persona WHERE idPersona = @IdPersona"
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
            Return "Error al eliminar la persona: " & ex.Message
        End Try
        Return "Persona Eliminada"
    End Function

    Public Function update(Persona As Persona) As String
        Try
            Dim sql As String = "UPDATE Persona SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Nacionalidad = @Nacionalidad, Fecha de Nacimiento = @Fecha de Nacimiento, Telefono = @Telefono WHERE idPersona = @Id"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Id", Persona.IdPersona),
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido1),
                New SqlParameter("@Apellido2", Persona.Apellido2),
                New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
                New SqlParameter("@Fecha de Nacimiento", Persona.FechaNacimiento),
                New SqlParameter("@Telefono", Persona.Telefono)
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