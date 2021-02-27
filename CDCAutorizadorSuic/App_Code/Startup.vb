Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Owin

<Assembly: OwinStartup(GetType(Startup))> 
Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        Dim oCookies As New CookieAuthenticationOptions()
        oCookies.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie       
    End Sub
End Class




