Namespace Utils
    Public Module SwalUtils

        Public Sub ShowSwalMessage(Page As System.Web.UI.Page, title As String, message As String, icon As String)
            title = title.Replace("'", "\'")
            message = message.Replace("'", "\'")
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString, ShowSwalScript(title, message, icon), True)
        End Sub
        Public Function ShowSwalScript(title As String, message As String, icon As String) As String
            Return $"Swal.fire({{title: '{title}', text: '{message}', icon: '{icon}'}});"
        End Function

        Public Sub ShowSwalError(Page As System.Web.UI.Page, title As String, message As String)
            ShowSwalMessage(Page, title, message, "Error")
        End Sub
        Public Sub ShowSwalError(Page As System.Web.UI.Page, message As String)
            ShowSwalMessage(Page, "Error", message, "error")
        End Sub
        Public Sub ShowSwal(Page As System.Web.UI.Page, title As String, Optional message As String = "", Optional icon As String = "success")
            ShowSwalMessage(Page, title, message, icon)
        End Sub

    End Module
End Namespace

