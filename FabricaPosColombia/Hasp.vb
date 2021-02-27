Imports System.Text
Imports Aladdin.HASP

Public Class gasolutionsHasp
    Public Shared Sub IsHasp()
        Try


            Dim feature As HaspFeature = HaspFeature.ProgNumDefault
            feature.SetOptions(FeatureOptions.NotRemote, FeatureOptions.Default)

            Dim vendorCode As String = _
            "t1EiZnM5IbIL0oK3T3Bfq2RCrv7oArlYtjW4Ik8XA7mYqfueB8LJE5kDIP9I1bpXdDU5BalBT5CRNlXU" + _
            "iQ1g+hSaawis4bXk+yh1BQ262Gqy1LykWO/VQuxp9FfC6JDA9sCdb0dJKW3dMNSYquWNy4mnBs//+ON3" + _
            "FQS1azTiHf43k59YzJHDDLjUvBTm417GESlmYmrcrVUERTlWcx2Shi3azf8ULfrGmnLK+F5FwFLd4Wx+" + _
            "woV9hsRLOSNJ093PpIOfUqojCYVCXyU2pGP89gb1Kuj8gk1GjAoMBuxojANB9DBrRo+1unqxgKaRjcip" + _
            "u7pHUOEUgAKFjonvSTDLv8fcTjjEG+0F87eHkUuK7yihhApKPB6Rxg+w6GlYZ6CGKNITeO+yWKe+EauK" + _
            "2tvetEk2SO2op8liTLpvCEMgWk8YYG+McFXnOZymLVyksmcW+9I1JyvlwXVjY/6X7vg82i5dvPTUJDY1" + _
            "8nMZCvg+SsnkgSPA82uGxczSwpyDdzh4KPevStX/HfNNZ6xACJXSBP2VRa5XuMSycFYk8oZ1+fa/MjyA" + _
            "ngh8xhwwGnOO2/lzXkAqNyI+8CdLsgLtT/KvgqLZ7GuBKHlJg/yRNQhiprpYajK4udRYDTxYpfSDdlYo" + _
            "WiUYLT8AVNHlzKqytVRZAxUdw5sF/M+WLvKMmMgOTKTCzwzTVoaku/cbxDDqqu88jpX5naNVptgOFYk6" + _
            "lc9AtneZTeMoDg=="

            Dim hasp As Aladdin.HASP.Hasp = New Aladdin.HASP.Hasp(feature)
            Dim status As HaspStatus = hasp.Login(UTF8Encoding.Default.GetBytes(vendorCode))

            If (HaspStatus.StatusOk <> status) Then
                status = hasp.Logout()
                Throw New GasolutionsHaspException()
            Else
                status = hasp.Logout()
            End If
        Catch ex As System.Exception
            Throw
        End Try
    End Sub

    Public Shared Function IniciarSessionHasp() As Aladdin.HASP.Hasp
        Dim feature As HaspFeature = HaspFeature.ProgNumDefault
        feature.SetOptions(FeatureOptions.NotRemote, FeatureOptions.Default)

        Dim vendorCode As String = _
        "t1EiZnM5IbIL0oK3T3Bfq2RCrv7oArlYtjW4Ik8XA7mYqfueB8LJE5kDIP9I1bpXdDU5BalBT5CRNlXU" + _
        "iQ1g+hSaawis4bXk+yh1BQ262Gqy1LykWO/VQuxp9FfC6JDA9sCdb0dJKW3dMNSYquWNy4mnBs//+ON3" + _
        "FQS1azTiHf43k59YzJHDDLjUvBTm417GESlmYmrcrVUERTlWcx2Shi3azf8ULfrGmnLK+F5FwFLd4Wx+" + _
        "woV9hsRLOSNJ093PpIOfUqojCYVCXyU2pGP89gb1Kuj8gk1GjAoMBuxojANB9DBrRo+1unqxgKaRjcip" + _
        "u7pHUOEUgAKFjonvSTDLv8fcTjjEG+0F87eHkUuK7yihhApKPB6Rxg+w6GlYZ6CGKNITeO+yWKe+EauK" + _
        "2tvetEk2SO2op8liTLpvCEMgWk8YYG+McFXnOZymLVyksmcW+9I1JyvlwXVjY/6X7vg82i5dvPTUJDY1" + _
        "8nMZCvg+SsnkgSPA82uGxczSwpyDdzh4KPevStX/HfNNZ6xACJXSBP2VRa5XuMSycFYk8oZ1+fa/MjyA" + _
        "ngh8xhwwGnOO2/lzXkAqNyI+8CdLsgLtT/KvgqLZ7GuBKHlJg/yRNQhiprpYajK4udRYDTxYpfSDdlYo" + _
        "WiUYLT8AVNHlzKqytVRZAxUdw5sF/M+WLvKMmMgOTKTCzwzTVoaku/cbxDDqqu88jpX5naNVptgOFYk6" + _
        "lc9AtneZTeMoDg=="

        Dim hasp As Aladdin.HASP.Hasp = New Aladdin.HASP.Hasp(feature)
        Dim status As HaspStatus = hasp.Login(UTF8Encoding.Default.GetBytes(vendorCode))

        If (HaspStatus.StatusOk <> status) Then
            Throw New System.Exception("LLave Hash no encontrada")
        End If
        Return hasp
    End Function

    Public Shared Sub WriterMemory()
        Try
            Dim offset As Int32 = 0
            Dim status As HaspStatus

            Dim data() As Byte = New Byte() { _
                &H67, &H32, &H73, &H30, &H74, &H30, &H37, &H2E, _
                &H67, &H61, &H73, &H6F, &H6C, &H75, &H74, &H69, _
                &H6F, &H6E, &H73, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}


            Dim hasp As Aladdin.HASP.Hasp = IniciarSessionHasp()

            Dim file As HaspFile = hasp.GetFile(HaspFiles.Main)

            If (Not file.IsLoggedIn()) Then
                Throw New System.Exception("Falla en Validacion Hash")
            End If

            file.FilePos = offset
            status = file.Write(data, 0, data.Length)

            If (HaspStatus.StatusOk <> status) Then
                Throw New System.Exception("Falla en Validacion Hash")
            Else
                status = hasp.Logout()
            End If
        Catch ex As System.Exception
            Throw ex
        End Try

    End Sub

    Public Shared Function ReadMemory() As String
        Dim Resultado As New System.Text.ASCIIEncoding
        Try
            Dim offset As Int32 = 0
            Dim status As HaspStatus

            Dim data() As Byte = New Byte() { _
                &H67, &H32, &H73, &H30, &H74, &H30, &H37, &H2E, _
                &H67, &H61, &H73, &H6F, &H6C, &H75, &H74, &H69, _
                &H6F, &H6E, &H73, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}

            Dim hasp As Aladdin.HASP.Hasp = IniciarSessionHasp()


            Dim file As HaspFile = hasp.GetFile(HaspFiles.Main)

            If (Not file.IsLoggedIn()) Then
                Throw New System.Exception("Falla en Validacion Hash")
            End If

            file.FilePos = offset
            status = file.Read(data, 0, data.Length)

            If (HaspStatus.StatusOk <> status) Then
                Throw New System.Exception("Falla en Validacion Hash")
            Else
                status = hasp.Logout()
            End If

            Return Resultado.GetString(data, 0, data.Length)

        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateHash() As Boolean
        Dim Resultado As New System.Text.ASCIIEncoding
        Try
            Dim offset As Int32 = 0
            Dim status As HaspStatus

            Dim Data() As Byte = New Byte() { _
                &H67, &H32, &H73, &H30, &H74, &H30, &H37, &H2E, _
                &H67, &H61, &H73, &H6F, &H6C, &H75, &H74, &H69, _
                &H6F, &H6E, &H73, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0, _
                &H0, &H0, &H0, &H0, &H0, &H0, &H0, &H0}

            Dim DataMemory(Data.Length - 1) As Byte

            Dim hasp As Aladdin.HASP.Hasp = IniciarSessionHasp()

            Dim file As HaspFile = hasp.GetFile(HaspFiles.Main)

            If (Not file.IsLoggedIn()) Then
                Throw New System.Exception("Falla en Validacion Hash")
            End If

            file.FilePos = offset
            status = file.Read(DataMemory, 0, DataMemory.Length)

            If (HaspStatus.StatusOk <> status) Then
                Throw New System.Exception("Falla en Validacion Hash")
            Else
                hasp.Logout()
            End If

            Return Resultado.GetString(Data, 0, Data.Length).Equals(Resultado.GetString(DataMemory, 0, DataMemory.Length))

        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

End Class
