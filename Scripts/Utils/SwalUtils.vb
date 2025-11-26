Namespace Utils
    Public Module SwalUtils

        Public Sub ShowSwalMessage(Page As System.Web.UI.Page, title As String, message As String, icon As String)
            title = title.Replace("'", "\'")
            message = message.Replace("'", "\'")
            message = message.Replace(vbCrLf, "<br>")
            message = message.Replace(vbLf, "<br>")
            message = message.Replace(vbCr, "<br>")
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString, ShowSwalScript(title, message, icon), True)
        End Sub
        Public Function ShowSwalScript(title As String, message As String, icon As String) As String
            Return $"Swal.fire({{title: '{title}', html: '{message}', icon: '{icon}'}});"
        End Function

        Public Sub ShowSwalError(Page As System.Web.UI.Page, title As String, message As String)
            ShowSwalMessage(Page, title, message, "error")
        End Sub
        Public Sub ShowSwalError(Page As System.Web.UI.Page, message As String)
            ShowSwalMessage(Page, "error", message, "error")
        End Sub
        Public Sub ShowSwal(Page As System.Web.UI.Page, title As String, Optional message As String = "", Optional icon As String = "success")
            ShowSwalMessage(Page, title, message, icon)
        End Sub

    End Module
End Namespace

