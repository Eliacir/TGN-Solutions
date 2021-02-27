Imports System.Security.Principal
'Imports System.Threading

Public Class Seguridad
    Public Shared Function EsAdministrador() As Boolean
        My.User.InitializeWithWindowsUser()

        Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
    End Function

    Public Shared Function EsAdministradorEds() As Boolean
        My.User.InitializeWithWindowsUser()

        Return My.User.IsInRole("AdministradorEds")
    End Function

    Public Shared Function Usuario() As String
        Return My.User.Name
    End Function

    'Private Function EsAdministrador() As Boolean
    '    System.Threading.Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)

    '    Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
    'End Function

    '    // Otra forma de saber si se está ejecutando como administrador

    '// Hay que tener las importaciones a estos dos espacios de nombres:
    'using System.Security.Principal;
    'using System.Threading;

    'private bool EsAdministrador()
    '{
    '    Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

    '    WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
    '    return myUser.IsInRole(WindowsBuiltInRole.Administrator);
    '}

End Class
