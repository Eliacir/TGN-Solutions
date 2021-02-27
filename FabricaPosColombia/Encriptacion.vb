Imports System
Imports System.Text
Imports System.Security.Cryptography

Public Class Encriptacion
    Inherits Disposable

    '<summary> 
    'Enumeracion con los tipos más comunes de algoritmos hash
    '</summary>
    Enum ListaAlgoritmo
        SHA1
        SHA256
        SHA384
        SHA512
        MD5
    End Enum 'Algoritmos

    '<summary>
    'Genera un codigo criptograficamente seguro aleatoriamente
    '</summary>
    '<returns>Codigo expresado como un array de bytes</returns>
    Public Function GenerarCodigoAletario() As Byte()
        Dim saltBytes() As Byte = Nothing
        'Define el tamaño maximo y el minimo del codigo aletorio.
        Dim minSaltSize As Int32 = 4
        Dim maxSaltSize As Int32 = 8

        'Genera un numero tamaño aleatorio entre el maximo y el minimo.
        Dim random As New Random()
        Dim saltSize As Int32 = random.Next(minSaltSize, maxSaltSize)

        'Prepara el array de bytes con el tamaño aleatorio del codigo, donde se almacenará este. 
        saltBytes(saltSize) = New Byte

        'Inicia un generardor de numeros aleatorios cifrados.
        Dim rng As New RNGCryptoServiceProvider()

        'Rellena el codigo aletario con un valor de bytes criptograficamente seguro. 
        rng.GetNonZeroBytes(saltBytes)

        Return saltBytes
    End Function

    '<summary> 
    'Obtiene un valor hash de un texto usando un codigo aleatorio 
    '</summary> 
    '<param name="texto">Texto a cifrar</param> 
    '<param name="algoritmo">Algoritmo de cifrado</param> 
    '<returns> 
    'Un codigo hash que contiene la informacion necesaria 
    'para poder ser verificado (unicamente con la funcion adecuada) 
    '</returns> 
    Public Function ObtenerValor(ByVal texto As String, ByVal algoritmo As ListaAlgoritmo) As String
        'Llamamos a la sobrecarga de la funcion, pasandole un nuevo codigo aleatorio
        Return ObtenerValor(texto, algoritmo, GenerarCodigoAletario())
    End Function

    '<summary> 
    'Obtiene un valor hash de un texto usando un codigo prefijado 
    '</summary> 
    '<param name="texto">Texto a cifrar</param> 
    '<param name="algoritmo">Algoritmo de cifrado</param> 
    '<param name="codigoAleatorio">Codigo criptograficamente seguro</param> 
    '<returns> 
    'Un codigo hash que contiene la informacion necesaria 
    'para poder ser verificado (unicamente con la funcion adecuada) 
    '</returns> 
    Public Function ObtenerValor(ByVal texto As String, ByVal algoritmo As ListaAlgoritmo, ByVal codigoAleatorio() As Byte) As String
        'Convierte el texto plano en un array de bytes. 
        Dim plainTextBytes() As Byte = Encoding.UTF8.GetBytes(texto)

        'Prepara el array de bytes con el tamaño del texto y sumando el tamaño del codigo aleatorio. 
        Dim plainTextWithSaltBytes(plainTextBytes.Length + codigoAleatorio.Length) As Byte

        'Copia el texto en el array. 
        For i As Int32 = 0 To plainTextBytes.Length - 1
            plainTextWithSaltBytes(i) = plainTextBytes(i)
        Next i

        'Agrega el codigo aletario despues del texto en el array. 
        For i As Int32 = 0 To codigoAleatorio.Length - 1
            plainTextWithSaltBytes(plainTextBytes.Length + i) = codigoAleatorio(i)
        Next i

        'Como soporta multiples tipos de algoritmos hash, se debe definir 
        'un objeto hash comun (abstracto) para la clase base. En el que 
        'especificaremos más tarde, en la creacion del objeto el tipo espeficico. 
        Dim hash As HashAlgorithm = Nothing

        'Iniciamos el algoritmo hash apropiado..
        Select Case algoritmo
            Case ListaAlgoritmo.SHA1
                hash = New SHA1Managed()

            Case ListaAlgoritmo.SHA256
                hash = New SHA256Managed()

            Case ListaAlgoritmo.SHA384
                hash = New SHA384Managed()

            Case ListaAlgoritmo.SHA512
                hash = New SHA512Managed()

            Case ListaAlgoritmo.MD5
                hash = New MD5CryptoServiceProvider()
        End Select

        'Generamos el codigo hash del valor de nuestro texto unido al codigo aletorio.
        Dim hashBytes() As Byte = hash.ComputeHash(plainTextWithSaltBytes)

        'Crea un array que contendrá el codigo hash y el codigo aleatorio.
        Dim hashWithSaltBytes(hashBytes.Length + codigoAleatorio.Length) As Byte

        'Copia el codigo hash al array. 
        For i As Int32 = 0 To hashBytes.Length - 1
            hashWithSaltBytes(i) = hashBytes(i)
        Next i

        'Agrega el codigo aleatorio al array.
        For i As Int32 = 0 To codigoAleatorio.Length - 1
            hashWithSaltBytes(hashBytes.Length + i) = codigoAleatorio(i)
        Next i

        'Convierte el resultado a un string de codificacion en base 64 bits.
        Dim hashValue As String = Convert.ToBase64String(hashWithSaltBytes)

        'Remplaza posibles carateres problematicos en URLs
        hashValue = HacerRemplazoParaURL(hashValue)

        'Devuelve el resultado.
        Return hashValue
    End Function

    '<summary>
    'Obtiene un valor hash de un texto 
    '</summary> 
    '<param name="texto">Texto a cifrar</param> 
    '<param name="algoritmo">Algoritmo de cifrado</param> 
    '<returns> Un codigo hash </returns>
    Public Function ObtenerValorUnico(ByVal texto As String, ByVal algoritmo As ListaAlgoritmo) As String
        'Convierte el texto plano en un array de bytes.
        Dim plainTextBytes() As Byte = Encoding.UTF8.GetBytes(texto)

        'Como soporta multiples tipos de algoritmos hash, se debe definir 
        'un objeto hash comun (abstracto) para la clase base. En el que 
        'especificaremos más tarde, en la creacion del objeto el tipo espeficico. 
        Dim hash As HashAlgorithm = Nothing

        'Iniciamos el algoritmo hash apropiado.. 
        Select Case algoritmo
            Case ListaAlgoritmo.SHA1
                hash = New SHA1Managed()

            Case ListaAlgoritmo.SHA256
                hash = New SHA256Managed()

            Case ListaAlgoritmo.SHA384
                hash = New SHA384Managed()

            Case ListaAlgoritmo.SHA512
                hash = New SHA512Managed()

            Case ListaAlgoritmo.MD5
                hash = New MD5CryptoServiceProvider()
        End Select

        'Generamos el codigo hash del valor de nuestro texto 
        Dim hashBytes() As Byte = hash.ComputeHash(plainTextBytes)

        'Convierte el resultado a un string de codificacion en base 64 bits. 
        Dim hashValue As String = Convert.ToBase64String(hashBytes)

        'Remplaza posibles carateres problematicos en URLs
        hashValue = HacerRemplazoParaURL(hashValue)

        'Devuelve el resultado. 
        Return hashValue
    End Function

    '<summary> 
    'Verifica la validez de un codigo hash que contiene un codigo de 
    'cifrado criptograficamente seguro 
    '</summary> 
    '<param name="texto">Texto a validar</param> 
    '<param name="algoritmo">Algoritmo de cifrado</param> 
    '<param name="valorHash">Codigo hash a validar con el texto</param> 
    '<returns>Verdadero si coincide</returns> 
    Public Function VerificarValor(ByVal texto As String, ByVal algoritmo As ListaAlgoritmo, ByVal valorHash As String) As Boolean
        'Remplaza posibles carateres problematicos en URLs
        Dim valorHashCorrecto As String = DesHacerRemplazoParaURL(valorHash)

        'Convierte el codigo hash codificado en base 64 bits en un array de bytes.
        Dim hashWithSaltBytes As Byte() = Convert.FromBase64String(valorHashCorrecto)

        'Debemos conocer el tamaño del hash sin el codigo aleatorio. 
        Dim hashSizeInBits, hashSizeInBytes As Int32

        hashSizeInBits = 0

        'El tamaño del hash depende del algoritmo especificado. 
        Select Case algoritmo
            Case ListaAlgoritmo.SHA1
                hashSizeInBits = 160

            Case ListaAlgoritmo.SHA256
                hashSizeInBits = 256

            Case ListaAlgoritmo.SHA384
                hashSizeInBits = 384

            Case ListaAlgoritmo.SHA512
                hashSizeInBits = 512

            Case ListaAlgoritmo.MD5
                hashSizeInBits = 128
        End Select

        'Convierte el tamaño del hash de bits a bytes.
        hashSizeInBytes = CInt(hashSizeInBits / 8)

        'Nos aseguramos del que el tamaño del hash es el correcto y no es demasiado largo. 
        If (hashWithSaltBytes.Length < hashSizeInBytes) Then Return False

        'Praparamos el array para alojar el codigo aletario original del valor hash. 
        Dim saltBytes(hashWithSaltBytes.Length - hashSizeInBytes) As Byte

        'Copia el codigo aleatorio del final del hash en el array. 
        For i As Int32 = 0 To saltBytes.Length - 1
            saltBytes(i) = hashWithSaltBytes(hashSizeInBytes + i)
        Next i

        'Obtiene el valor hash del texto especificado. 
        Dim expectedHashString As String = ObtenerValor(texto, algoritmo, saltBytes)

        'Si el valor hash obtenido coincide con el hash especificado, 
        'el texto entonces debe ser correcto 
        Return (valorHash = expectedHashString)
    End Function

    '<summary>
    'Verifica la validez de un codigo hash
    '</summary>
    '<param name="texto">Texto a validar</param>
    '<param name="algoritmo">Algoritmo de cifrado</param>
    '<param name="valorHashUnico">Codigo hash a validar con el texto</param>
    '<returns>Verdadero si coincide</returns>
    Public Function VerificarValorUnico(ByVal texto As String, ByVal algoritmo As ListaAlgoritmo, ByVal valorHashUnico As String) As Boolean
        'Obtiene el valor hash del texto especificado. 
        Dim expectedHashString As String = ObtenerValorUnico(texto, algoritmo)

        'Si el valor hash obtenido coincide con el hash especificado,
        'el texto entonces debe ser correcto
        Return (valorHashUnico = expectedHashString)
    End Function

    '<summary>
    'Remplaza los caracteres que pueden dar problemas en una URL
    '</summary>
    '<param name="valorHash">Texto a remplezar</param>
    '<returns> Texto seguro en una URL </returns>
    Private Function HacerRemplazoParaURL(ByVal valorHash As String) As String
        valorHash = valorHash.Replace("/", "@")
        valorHash = valorHash.Replace("+", "$")
        Return valorHash
    End Function

    '<summary>
    'Deshace el remplazo de los caracteres seguros en una URL
    '</summary>
    '<param name="valorHash">Texto a remplezar</param>
    '<returns>Texto original</returns>
    Private Function DesHacerRemplazoParaURL(ByVal valorHash As String) As String
        valorHash = valorHash.Replace("@", "/")
        valorHash = valorHash.Replace("$", "+")
        Return valorHash
    End Function
End Class
