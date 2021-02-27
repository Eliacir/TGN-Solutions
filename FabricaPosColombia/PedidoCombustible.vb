Public Class PedidoCombustible
    Private _EsPedidoLocal As Boolean
    Public Property EsPedidoLocal() As Boolean
        Get
            Return _EsPedidoLocal
        End Get
        Set(ByVal value As Boolean)
            _EsPedidoLocal = value
        End Set
    End Property

    Private _Productos As List(Of ProductoCombustible)
    Public Property Productos() As List(Of ProductoCombustible)
        Get
            Return _Productos
        End Get
        Set(ByVal value As List(Of ProductoCombustible))
            _Productos = value
        End Set
    End Property
End Class

Public Class CantidadProductos

    Private _CodigoProducto As Integer
    Private _Cantidad As Decimal
    Private _Nombre As String

    Public Property CodigoProducto() As Integer
        Get
            Return _CodigoProducto
        End Get
        Set(ByVal value As Integer)
            _CodigoProducto = value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

End Class

Public Class ConfiguracionReciboCombustible

    Private _Tanque As String
    Private _CodProducto As Integer
    Private _Cantidad As Decimal
    Private _NombreProducto As String

    Public Property Tanque() As String
        Get
            Return _Tanque
        End Get
        Set(ByVal value As String)
            _Tanque = value
        End Set
    End Property

    Public Property CodProducto() As Integer
        Get
            Return _CodProducto
        End Get
        Set(ByVal value As Integer)
            _CodProducto = value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property NombreProducto() As String
        Get
            Return _NombreProducto
        End Get
        Set(ByVal value As String)
            _NombreProducto = value
        End Set
    End Property

End Class

Public Class ReciboDeCombustible

    Private _lstProductos As New List(Of CantidadProductos)
    Private _lstConfiguracionRecibo As New List(Of ConfiguracionReciboCombustible)
    Private _EsPedidoLocal As Boolean
    Private _EsLeyFrontera As Boolean
    Private _EsAjusteOperacion As Boolean
    Private _RealizarBloqueoTanque As Boolean
    Private _EsDetenido As Boolean
    Private _Documento As String
    Private _Placa As String
    Private _Estado As Integer
    Private _TipoCombustible As Integer
    Private _GuiaDespacho As String
    Private _Ruc As String
    Private _Nit As String
    Private _HojaRuta As String


    Public Property HojaRuta() As String
        Get
            Return _HojaRuta
        End Get
        Set(ByVal value As String)
            _HojaRuta = value
        End Set
    End Property



    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property


    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Public Property GuiaDespacho() As String
        Get
            Return _GuiaDespacho
        End Get
        Set(ByVal value As String)
            _GuiaDespacho = value
        End Set
    End Property

    Public Property TipoCombustible() As Integer
        Get
            Return _TipoCombustible
        End Get
        Set(ByVal value As Integer)
            _TipoCombustible = value
        End Set
    End Property

    Public Property EsPedidoLocal() As Boolean
        Get
            Return _EsPedidoLocal
        End Get
        Set(ByVal value As Boolean)
            _EsPedidoLocal = value
        End Set
    End Property

    Public Property EsLeyFrontera() As Boolean
        Get
            Return _EsLeyFrontera
        End Get
        Set(ByVal value As Boolean)
            _EsLeyFrontera = value
        End Set
    End Property

    Public Property EsAjusteOperacion() As Boolean
        Get
            Return _EsAjusteOperacion
        End Get
        Set(ByVal value As Boolean)
            _EsAjusteOperacion = value
        End Set
    End Property

    Public Property RealizarBloqueoTanque() As Boolean
        Get
            Return _RealizarBloqueoTanque
        End Get
        Set(ByVal value As Boolean)
            _RealizarBloqueoTanque = value
        End Set
    End Property

    Public Property EsDetenido() As Boolean
        Get
            Return _EsDetenido
        End Get
        Set(ByVal value As Boolean)
            _EsDetenido = value
        End Set
    End Property

    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return _Estado
        End Get
        Set(ByVal value As Integer)
            _Estado = value
        End Set
    End Property

    Public Property lstProductos() As List(Of CantidadProductos)
        Get
            Return _lstProductos
        End Get
        Set(ByVal value As List(Of CantidadProductos))
            _lstProductos = value
        End Set
    End Property

    Public Property lstConfiguracionRecibo() As List(Of ConfiguracionReciboCombustible)
        Get
            Return _lstConfiguracionRecibo
        End Get
        Set(ByVal value As List(Of ConfiguracionReciboCombustible))
            _lstConfiguracionRecibo = value
        End Set
    End Property

    Public Function VerificarCantidad(ByVal producto As Integer, ByVal cantidad As Decimal) As Short
        Dim VerificarCantidadResultado As Short = CantidadReciboCombustible.Mayor
        Try
            'Recorremos la lista hasta que encontremos el producto
            For i As Integer = 0 To lstProductos.Count - 1
                'Si ya encontramos el producto
                If lstProductos.Item(i).CodigoProducto = producto Then

                    'Evaluamos si la cantidad recibida es mayor, igual o menor que la cantidad que se tiene del producto
                    If lstProductos.Item(i).Cantidad > cantidad Then
                        VerificarCantidadResultado = CShort(CantidadReciboCombustible.Menor)
                    ElseIf lstProductos.Item(i).Cantidad < cantidad Then
                        VerificarCantidadResultado = CShort(CantidadReciboCombustible.Mayor)
                    Else
                        VerificarCantidadResultado = CShort(CantidadReciboCombustible.Igual)
                    End If

                End If
            Next

            Return VerificarCantidadResultado
        Catch
            Throw
        End Try
    End Function

    Public Function VerificarConfiguracionReciboCombustible(ByVal tanque As String, ByVal codProducto As Integer, ByVal cantidad As Decimal) As Decimal
        Try
            'Recorremos la lista hasta que encontramos el tanque asociado con el mismo producto
            For i As Integer = 0 To lstConfiguracionRecibo.Count - 1
                'Si ya encontramos la configuración
                If lstConfiguracionRecibo.Item(i).Tanque = tanque And lstConfiguracionRecibo.Item(i).CodProducto = codProducto Then

                    'Retornamos que encontramos los datos
                    Return lstConfiguracionRecibo.Item(i).Cantidad + cantidad

                End If
            Next

            'Si nunca encontramos nada retornamos un false
            Return 0
        Catch
            Throw
        End Try
    End Function

    Public Sub AgregarConfiguracionReciboCombustible(ByVal tanque As String, ByVal codProducto As Integer, ByVal cantidad As Decimal, ByVal nombre As String)
        Try
            'Variables que nos determinan si el tanque y/o el producto existen
            Dim existeTanque As Boolean = False
            Dim existeProducto As Boolean = False

            'Recorremos la lista hasta que encontremos el tanque
            For i As Integer = 0 To lstConfiguracionRecibo.Count - 1

                'Si ya encontramos el tanque
                If lstConfiguracionRecibo.Item(i).Tanque = tanque Then

                    'Decimos que ya encontramos el tanque
                    existeTanque = True

                    'Si tiene un producto asociado este tanque
                    If lstConfiguracionRecibo.Item(i).CodProducto = codProducto Then

                        'Decimos que ya encontramos el producto
                        existeProducto = True

                        'Adicionamos la nueva cantidad a la cantidad que tenía anteriormente el tanque
                        lstConfiguracionRecibo.Item(i).Cantidad += cantidad

                    End If

                End If

            Next

            'Instanciamos la clase de Configuración
            Dim oConfiguracion As New ConfiguracionReciboCombustible

            'Evaluamos si encontramos el tanque
            If Not existeTanque Or Not existeProducto Then
                'Adicionamos la configuración
                oConfiguracion.Tanque = tanque
                oConfiguracion.CodProducto = codProducto
                oConfiguracion.Cantidad = cantidad

                'Verificamos que el nombre no tenga más de 15 caracteres
                If nombre.Length > 14 Then
                    nombre = nombre.Substring(0, 14)
                End If

                oConfiguracion.NombreProducto = nombre

                'Adicionamos la lista
                lstConfiguracionRecibo.Add(oConfiguracion)
            End If
        Catch
            Throw
        End Try
    End Sub

    Public Sub RestarCantidadAProducto(ByVal codProducto As Integer, ByVal cantidad As Decimal)
        Try
            'Recorremos la lista hasta que encontremos el producto
            For i As Integer = 0 To lstProductos.Count - 1
                'Si ya encontramos el producto
                If lstProductos.Item(i).CodigoProducto = codProducto Then

                    'Restamos la cantidad
                    lstProductos.Item(i).Cantidad -= cantidad

                End If
            Next
        Catch
            Throw
        End Try
    End Sub

    Public Function DatosParaConfirmarPedido() As String
        Try
            'Variable para ir armando el paquete que va para el Terminal host
            Dim sbStr As New System.Text.StringBuilder
            'Variable que nos mostrará el nombre del producto formateado a 15 caracteres, esto es para la MR
            Dim nombreProducto As String = ""

            'Recorremos la lista
            For i As Integer = 0 To lstConfiguracionRecibo.Count - 1

                With lstConfiguracionRecibo.Item(i)
                    'Vamos armando la trama
                    sbStr.Append(.NombreProducto & ":" & .Tanque & ":" & CStr(.Cantidad) & ":")
                End With

            Next

            'Retornamos la cadena
            Return sbStr.ToString()
        Catch
            Throw
        End Try
    End Function

    Public Function RecuperarTanques() As List(Of String)
        Try
            'Lista que nos va a ayudar para no repetir los tanques
            Dim lstTanques As New List(Of String)

            'Recorremos la lista
            For i As Integer = 0 To lstConfiguracionRecibo.Count - 1

                'Si el tanque no está en la lista lo adicionamos
                If Not lstTanques.Contains(lstConfiguracionRecibo.Item(i).Tanque) Then
                    lstTanques.Add(lstConfiguracionRecibo.Item(i).Tanque)
                End If

            Next

            'Retornamos la lista
            Return lstTanques
        Catch
            Throw
        End Try
    End Function

    Public Function RecuperarProductoPorTanque(ByVal CodTanque As String) As Integer
        Dim RecuperarProductoPorTanqueResultado As Integer = 0
        Try
            'Recorremos la lista hasta que encontremos el tanque
            For i As Integer = 0 To lstConfiguracionRecibo.Count - 1

                'Si encontramos el producto
                If lstConfiguracionRecibo.Item(i).Tanque = CodTanque Then
                    'Retornamos el Codigo del Producto
                    RecuperarProductoPorTanqueResultado = lstConfiguracionRecibo.Item(i).CodProducto
                End If

            Next

            Return RecuperarProductoPorTanqueResultado
        Catch
            Throw
        End Try
    End Function

End Class