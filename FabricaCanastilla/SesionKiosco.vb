Imports POSstation.HelperCanastilla

Public Class SesionKiosco
    Private CedulaEmpleado_ As String = Nothing
    Private NombreEmpleado_ As String = Nothing
    Private CodigoKiosco_ As String = Nothing
    Private NombreKiosco_ As String = Nothing
    Private Clave_ As String = Nothing
    Private FechaInicio_ As DateTime = Nothing
    Private OHelper As New Helper

    Public Property CedulaEmpleado() As String
        Get
            Return CedulaEmpleado_
        End Get
        Set(ByVal value As String)
            CedulaEmpleado_ = value
        End Set
    End Property

    Public Property NombreEmpleado() As String
        Get
            Return NombreEmpleado_
        End Get
        Set(ByVal value As String)
            NombreEmpleado_ = value
        End Set
    End Property

    Public Property CodigoKiosco() As String
        Get
            Return CodigoKiosco_
        End Get
        Set(ByVal value As String)
            CodigoKiosco_ = value
        End Set
    End Property

    Public Property NombreKiosco() As String
        Get
            Return NombreKiosco_
        End Get
        Set(ByVal value As String)
            NombreKiosco_ = value
        End Set
    End Property

    Public Property Clave() As String
        Get
            Return Clave_
        End Get
        Set(ByVal value As String)
            Clave_ = value
        End Set
    End Property

    Public Property FechaInicio() As DateTime
        Get
            Return FechaInicio_
        End Get
        Set(ByVal value As DateTime)
            FechaInicio_ = value
        End Set
    End Property

    Public Function EsSesionAbierta(ByVal empleado As String, ByVal clave As String) As Boolean
        Dim Abierta As Boolean = False

        Try
            If (OHelper.ValidarTurnoPorEmpleado(empleado, clave, Me.CodigoKiosco) > 0) Then
                Abierta = True
            End If
        Catch ex As System.Exception
            Throw
        End Try

        Return Abierta
    End Function

    Public Function IniciarSesion(ByVal empleado As String, ByVal clave As String, ByVal kiosco As String) As Int32
        Dim IdTurno As Int32 = -1
        Try
            IdTurno = OHelper.IniciarSesionKiosco(empleado, clave, kiosco)
            RecuperarSesionAbierta(empleado)
        Catch ex As System.Exception
            LimpiarDatosSesion()
            Throw
        End Try

        Return IdTurno
    End Function

    Public Function CerrarSesion(ByVal empleado As String, ByVal clave As String) As Int32
        Dim IdTurno As Int32 = -1
        Try
            IdTurno = OHelper.CerrarSesionKiosco(empleado, clave)
            LimpiarDatosSesion()
        Catch ex As System.Exception
            LimpiarDatosSesion()
            Throw
        End Try

        Return IdTurno
    End Function

    Public Sub LimpiarDatosSesion()
        Me.CedulaEmpleado = Nothing
        Me.NombreEmpleado = Nothing
        Me.Clave = Nothing
        Me.FechaInicio = Nothing
    End Sub

    Public Function RecuperarSesionAbierta(ByVal empleado As String) As Boolean
        Dim Data As IDataReader
        Dim Existe As Boolean = False

        Try
            Data = OHelper.RecuperarDatosSesionAbierta(empleado)
            If Data.Read() Then
                Me.CedulaEmpleado = Data.Item("CedulaEmpleado").ToString()
                Me.NombreEmpleado = Data.Item("NombreEmpleado").ToString()
                Me.Clave = Data.Item("Clave").ToString()
                Me.FechaInicio = DateTime.Parse(Data.Item("Apertura").ToString())
                Existe = True
            End If

            Data.Close()
        Catch ex As System.Exception
            LimpiarDatosSesion()
            Throw
        End Try

        Return Existe
    End Function
End Class
