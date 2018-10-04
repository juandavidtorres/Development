Imports System.Data
Imports POSstation.AccesoDatos
Imports POSstation.ControlSurtidor
Imports POSstation.Protocolos

Public Class ManagementKardex
#Region "Eventos"
    Public Shared Event ProgramarCambioPrecioKardex(ColManguera As ColMangueras)
#End Region



    Public Shared Sub ConsultarManguerasCambiarProducto(ByVal Manguera As Short)
        Dim oHelper As New Helper()
        Dim oMangueras As New ColMangueras
        Try
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(Manguera)
            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
            'Return oMangueras
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Shared Sub ConsultarManguerasCambiarProductoReciboCombustible(ByVal Documento As String)
        Dim oHelper As New Helper()
        Dim oMangueras As New ColMangueras
        Try
            Dim oTableMangueras As IDataReader = oHelper.RecuperarManguerasCambioPrecioReciboCombustible(Documento)
            If oTableMangueras.Read() Then
                With oMangueras
                    .Add(CShort(oTableMangueras.Item("IdManguera").ToString), CShort(oTableMangueras.Item("IdProducto").ToString), CDec(oTableMangueras.Item("Precio").ToString))
                End With
                While oTableMangueras.Read()
                    With oMangueras
                        .Add(CShort(oTableMangueras.Item("IdManguera").ToString), CShort(oTableMangueras.Item("IdProducto").ToString), CDec(oTableMangueras.Item("Precio").ToString))
                    End With
                End While
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    ''' <summary>
    ''' Permite realizar la consulta del saldo de los tanques existentes en la estacion
    ''' </summary>
    ''' <param name="CodigoTanque">Código con el que se encuentra configurado el tanque en la estación</param>
    ''' <param name="IdProducto">Id del Producto del que se desea obtener su existencia en el tanque, si este no es diligenciado traera el saldo del tanque sin tener en cuenta el producto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RecuperarSaldoTanque(ByVal CodigoTanque As String, Optional ByVal IdProducto As Int16 = -1) As Decimal
        Try
            Dim oHelper As New Helper()
            Return oHelper.RecuperarSaldoTanque(CodigoTanque, IdProducto)
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Realiza los movimientos en inventario originados por una salida de Combustible.
    ''' </summary>
    ''' <param name="Tanque">Código con el que se encuentra el tanque configurado en las estación</param>
    ''' <param name="Cantidad">Cantidad a Transferir</param>
    ''' <param name="EstacionReceptora">Estación a la cual se el hara el envió de la Información</param>
    ''' <remarks></remarks>
    Public Shared Sub InsertarTransferenciadeCombustibles(ByVal Tanque As String, ByVal Cantidad As Decimal, ByVal EstacionReceptora As String)
        Try
            Dim oHelper As New Helper()
            Dim oMangueras As New ColMangueras

            oHelper.InsertarTransferenciadeCombustibles(Tanque, Cantidad, EstacionReceptora)
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Realiza los movimientos en inventario originados por una salida de Combustible.
    ''' </summary>
    ''' <param name="Volumen">Cantidad de combustible a recibir</param>
    ''' <param name="Stock">Cantidad a Combustible actual en el tanque</param>
    ''' <param name="Placa">Placa del cisterna que lleva el combustible</param>
    ''' <param name="NumRemision">Numero del documento del envío</param>
    ''' <param name="IdTanque">Tanque en el que se recibirá el combustible</param>
    ''' <param name="Costo">Costo del tanqueo</param>
    ''' <param name="IdProducto">Id del producto a consumir</param>
    ''' <remarks></remarks>
    Public Shared Sub InsertarRecibodeCombustibles(ByVal Volumen As Decimal, ByVal Stock As Decimal, ByVal Placa As String, ByVal NumRemision As String, ByVal IdTanque As String, ByVal Costo As Decimal, ByVal IdProducto As Integer, ByVal EsLeyFrontera As Boolean)
        Try
            Dim oHelper As New Helper()

            If Stock = 0 Then
                Dim oDatos As IDataReader = oHelper.RecuperarIdTanqueStock(IdTanque)

                If oDatos.Read Then
                    oHelper.InsertarTanqueo(Volumen, CInt(oDatos.Item("Stock")), Placa, NumRemision, CInt(oDatos.Item("IdTanque")), Costo, IdProducto, EsLeyFrontera)
                End If

                oDatos = Nothing
            Else
                oHelper.InsertarTanqueo(Volumen, Stock, Placa, NumRemision, CInt(IdTanque), Costo, IdProducto, EsLeyFrontera)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Sub InsertarRecibodeCombustibles(ByVal Volumen As Decimal, ByVal Stock As Decimal, ByVal Placa As String, ByVal NumRemision As String, ByVal IdTanque As String, ByVal Costo As Decimal, ByVal IdProducto As Integer, ByVal EsLeyFrontera As Boolean, ByVal Ruc As String, ByVal GuiaDespacho As String, ByVal TipoCombustible As Integer)
        Try
            Dim oHelper As New Helper()

            If Stock = 0 Then
                Dim oDatos As IDataReader = oHelper.RecuperarIdTanqueStock(IdTanque)

                If oDatos.Read Then
                    oHelper.InsertarTanqueo(Volumen, CInt(oDatos.Item("Stock")), Placa, NumRemision, CInt(oDatos.Item("IdTanque")), Costo, IdProducto, EsLeyFrontera, Ruc, GuiaDespacho, TipoCombustible)
                End If

                oDatos = Nothing
            Else
                oHelper.InsertarTanqueo(Volumen, Stock, Placa, NumRemision, CInt(IdTanque), Costo, IdProducto, EsLeyFrontera, Ruc, GuiaDespacho, TipoCombustible)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Remarcaciones de Inventario
    ''' </summary>
    ''' <param name="Tanque">Codigo del Tanque según configuración en el cual se realizara la descaraga del producto</param>
    ''' <param name="ProductoBaja">codigo del producto a realizar la baja</param>
    ''' <param name="cantidad">cantidad a ajustar</param>
    ''' <param name="TanqueAlta">codigo del tanque en el cual se realizara el ingreso del producto</param>
    ''' <param name="ProductoAlta">codigo del producto a realizar el Ingreso</param>
    ''' <remarks></remarks>
    Public Shared Sub RemarcarProductosCombustibles(ByVal Tanque As String, ByVal ProductoBaja As Int16, ByVal cantidad As Decimal, ByVal TanqueAlta As String, ByVal ProductoAlta As Int16)
        Try
            Dim oHelper As New Helper()
            Dim oMangueras As New ColMangueras

            oHelper.InsertarRemarcacionKardex(Tanque, ProductoBaja, cantidad, TanqueAlta, ProductoAlta)
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-2)
            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    ''' <summary>
    ''' Ajusta por Operaciones el Kardex correpondiente a un Tanque
    ''' </summary>
    ''' <param name="Tanque">Código del Tanque</param>
    ''' <param name="Producto">Id del Producto</param>
    ''' <param name="EsManual">Si posee ó no dispositivos de medicion</param>
    ''' <remarks></remarks>
    Public Shared Sub AjustePorOperacion(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 0)
                    Next
                End If
            Else
                oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oHelper.RecuperarCantidadporAforo(Tanque, AlturaMaxima, AlturaAgua), 0)
            End If


            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Shared Sub AjustePorOperacionPeru(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 0)
                    Next
                End If
            Else

                If CBool(oHelper.RecuperarParametro("AplicaSolicitudAlturas")) Then
                    oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oHelper.RecuperarCantidadporAforo(Tanque, AlturaMaxima, AlturaAgua), 0)
                Else
                    oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, AlturaMaxima, 0)
                End If
            End If

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Shared Sub AjustePorOperacionChile(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 0)
                    Next
                End If
            Else
                oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, AlturaMaxima, 0)
            End If


            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta por Recibo el Kardex correpondiente a un Tanque
    ''' </summary>
    ''' <param name="Tanque">Código del Tanque</param>
    ''' <param name="Producto">Id del Producto</param>
    ''' <param name="EsManual">Si posee ó no dispositivos de medicion</param>
    ''' <remarks></remarks>
    Public Shared Sub AjustePorRecibo(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 1)
                    Next
                End If
            Else
                oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oHelper.RecuperarCantidadporAforo(Tanque, AlturaMaxima, AlturaAgua), 1)
            End If

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Shared Sub AjustePorReciboPeru(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)

        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 1)
                    Next
                End If
            Else
                If CBool(oHelper.RecuperarParametro("AplicaSolicitudAlturas")) Then
                    oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oHelper.RecuperarCantidadporAforo(Tanque, AlturaMaxima, AlturaAgua), 1)
                Else
                    oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, AlturaMaxima, 1)
                End If
            End If

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Shared Sub AjustePorReciboChile(ByVal Tanque As String, ByVal Producto As Int16, ByVal EsManual As Boolean, Optional ByVal AlturaMaxima As Decimal = -1, Optional ByVal AlturaAgua As Decimal = -1)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            If Not EsManual Then
                Dim IdDispositivo As Int16 = oHelper.RecuperarIdDispositivoporTanque(Tanque)
                Dim oListaVariables As List(Of Variables) = EncuestadorDispositivo.RecuperarVariablesMedicion(IdDispositivo, EncuestadorDispositivo.EnVariables.Stock)

                If oListaVariables.Count > 0 Then
                    For Each oItem As Variables In oListaVariables
                        oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oItem.Valor, 1)
                    Next
                End If
            Else
                ''oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, oHelper.RecuperarCantidadporAforo(Tanque, AlturaMaxima, AlturaAgua), 1)
                oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, AlturaMaxima, 1) '' se modifico para quel ajuste por recibo de chile no busque la cantidad
                ''en la tabla aforo sino que la mande el usuario desde la terminal host
            End If

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta por Operaciones el Kardex correpondiente a un Tanque
    ''' </summary>
    ''' <param name="Tanque">Código del Tanque</param>
    ''' <param name="Producto">Id del Producto</param>
    ''' <param name="Cantidad">Cantidad Medida</param>
    ''' <remarks></remarks>
    Public Shared Sub AjustePorOperacion(ByVal Tanque As String, ByVal Producto As Int16, ByVal Cantidad As Decimal)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, Cantidad, 0)

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta por Recibo el Kardex correpondiente a un Tanque
    ''' </summary>
    ''' <param name="Tanque">Código del Tanque</param>
    ''' <param name="Producto">Id del Producto</param>
    ''' <param name="Cantidad">Cantidad Medida</param>
    ''' <remarks></remarks>
    Public Shared Sub AjustePorRecibo(ByVal Tanque As String, ByVal Producto As Int16, ByVal Cantidad As Decimal)
        Try
            Dim oHelper As New Helper()
            Dim oTableMangueras As DataTable = oHelper.RecuperarManguerasActualizarProducto(-1)
            Dim oMangueras As New ColMangueras

            oHelper.InsertarAjustePorTipoMotivo(Tanque, Producto, Cantidad, 1)

            If oTableMangueras.Rows.Count > 0 Then
                For Each oRow As DataRow In oTableMangueras.Rows
                    With oMangueras
                        .Add(CShort(oRow.Item("IdManguera").ToString), CShort(oRow.Item("IdProducto").ToString), CDec(oRow.Item("Precio").ToString))
                    End With
                Next
                RaiseEvent ProgramarCambioPrecioKardex(oMangueras)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta por Operaciones el Kardex correpondiente a un turno
    ''' </summary>
    ''' <param name="IdTurno">Id del Turno</param>
    ''' <remarks></remarks>
    Public Shared Sub RealizarAjustesPorOperacionTurno(ByVal newId As String, ByVal IdTurno As Int32, ByVal Cedula As String)
        Try
            Dim oHelper As New Helper()
            oHelper.RealizarAjustesPorOperacionTurno(newId, IdTurno, Cedula)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Ajusta por Operaciones el Kardex correpondiente a un dia
    ''' </summary>
    ''' <param name="Dia">Id del Turno</param>
    ''' <remarks></remarks>
    Public Shared Sub RealizarAjustesPorOperacionDia(ByVal newId As String, ByVal Dia As Nullable(Of DateTime), ByVal Cedula As String)
        Try
            Dim oHelper As New Helper()
            oHelper.RealizarAjustesPorOperacionDia(newId, Dia, Cedula)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Para la impresión del ticket de Recibo de Combustible
    ''' </summary>
    ''' <param name="documento"></param>
    ''' <param name="codTanque"></param>
    ''' <param name="codProducto"></param>
    ''' <param name="cantidadDocumento"></param>
    ''' <param name="cantidadPorOperacion"></param>
    ''' <param name="cantidadPorRecibo"></param>
    ''' <remarks></remarks>
    Public Shared Sub ActualizarDistribucionCombustible(ByVal documento As String, ByVal codTanque As String, ByVal codProducto As Int32, ByVal cantidadDocumento As Nullable(Of Decimal), ByVal cantidadPorOperacion As Nullable(Of Decimal), ByVal cantidadPorRecibo As Nullable(Of Decimal))
        Try
            Dim oHelper As New Helper()
            oHelper.ActualizarDistribucionCombustible(documento, codTanque, codProducto, cantidadDocumento, cantidadPorOperacion, cantidadPorRecibo)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Sub ActualizarDistribucionCombustible(ByVal documento As String, ByVal codTanque As String, ByVal codProducto As Int32, ByVal cantidadDocumento As Nullable(Of Decimal), ByVal cantidadPorOperacion As Nullable(Of Decimal), ByVal cantidadPorRecibo As Nullable(Of Decimal), ByVal cantidadPorVentas As Nullable(Of Decimal))
        Try
            Dim oHelper As New Helper()
            oHelper.ActualizarDistribucionCombustible(documento, codTanque, codProducto, cantidadDocumento, cantidadPorOperacion, cantidadPorRecibo, cantidadPorVentas)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Shared Function RealizarCambioTanqueBypass(ByVal codTanque As String, ByVal cedula As String) As String
        Try
            Dim oHelper As New Helper()
            Return oHelper.RealizarCambioTanqueBypass(codTanque, cedula)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class