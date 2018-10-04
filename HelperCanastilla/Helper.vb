Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports POSstation.Fabrica
Imports POSstation.AccesoDatosCanastilla
Imports System.Data

Public Class Helper
    Dim ODatos As New SqlServer
    Dim LogFallas As New EstacionException


#Region "Factura"


    Public Function RecuperarDescuentoProducto(ByVal idProducto As Integer, ByVal cantidad As Integer, ByVal precio As Decimal, ByVal descuento As Decimal) As Decimal
        Try
            Return ODatos.RecuperarDescuentoProducto(idProducto, cantidad, precio, descuento)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarDescuentoProducto", "idProducto: " & idProducto & " , Cantidad: " & cantidad & " , Precio: " & precio & " , Descuento: " & descuento, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarDescuentoProducto", "idProducto: " & idProducto & " , Cantidad: " & cantidad & " , Precio: " & precio & " , Descuento: " & descuento, "FallaStoredProcedure")
            Throw
        End Try
    End Function


    Public Function RecuperarDescuentoProducto(ByVal idProducto As Integer, ByVal cantidad As Integer, ByVal precio As Decimal, ByVal descuento As Decimal, ByVal CantidadAutorizadaCDC As Integer) As Decimal
        Try
            Return ODatos.RecuperarDescuentoProducto(idProducto, cantidad, precio, descuento, CantidadAutorizadaCDC)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarDescuentoProducto", "idProducto: " & idProducto & " , Cantidad: " & cantidad & " , Precio: " & precio & " , Descuento: " & descuento & " , CantidadAutorizadaCDC: " & CantidadAutorizadaCDC.ToString, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarDescuentoProducto", "idProducto: " & idProducto & " , Cantidad: " & cantidad & " , Precio: " & precio & " , Descuento: " & descuento & " , CantidadAutorizadaCDC: " & CantidadAutorizadaCDC.ToString, "FallaStoredProcedure")
            Throw
        End Try
    End Function



    Public Function RecuperarProductoPorCodigo(ByVal codigo As Int32, Optional isla As Integer = -1) As IDataReader
        Try
            Return ODatos.RecuperarProductoPorCodigo(codigo, isla)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigo", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigo", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function
    Public Function RecuperarProductoPorCodigo(ByVal codigo As Int32, ByVal idEstacion As Int16) As IDataReader
        Try
            Return ODatos.RecuperarProductoPorCodigo(codigo, idEstacion)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigo", "IdEstacion: " & idEstacion & "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigo", "IdEstacion: " & idEstacion & "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarProductoPorCodigoTerpel(ByVal codigo As Int32) As IDataReader
        Try
            Return ODatos.RecuperarProductoPorCodigoTerpel(codigo)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigoTerpel", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigoTerpel", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function



    Public Function RecuperarProductoPorCodigoTerpel(ByVal codigo As Int32, ByVal IdIsla As Integer) As IDataReader
        Try
            Return ODatos.RecuperarProductoPorCodigoTerpel(codigo, IdIsla)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigoTerpel", "Codigo: " & codigo & "IdIsla: " & IdIsla, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarProductoPorCodigoTerpel", "Codigo: " & codigo & "IdIsla: " & IdIsla, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarProductoConsumoCanastilla(ByVal codigo As Int32) As IDataReader
        Try
            Return ODatos.RecuperarProductoConsumoCanastilla(codigo)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarProductoConsumoCanastilla", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarProductoConsumoCanastilla", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarIdProducto(ByVal codigo As Int32) As Int32
        Try
            Return ODatos.RecuperarIdProducto(codigo)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarIdProducto", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarIdProducto", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarFactura(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, Optional ByVal fecha As DateTime = Nothing) As Int32
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarFactura(total, usuario, clave, nomEquipoActual, guidFactura, fecha)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFactura", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFactura", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarFactura(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal esModificada As Boolean, Optional ByVal fecha As DateTime = Nothing) As Int32
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarFactura(total, usuario, clave, nomEquipoActual, guidFactura, fecha, esModificada)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFactura", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFactura", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarFacturaTerpel(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal esModificada As Boolean, Optional ByVal fecha As DateTime = Nothing) As Int32
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarFacturaTerpel(total, usuario, clave, nomEquipoActual, guidFactura, fecha, esModificada)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaTerpel", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaTerpel", "Total: " & total & ", Usuario: " & usuario & ", Clave: " & clave & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Integer
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarVentaTerpel(total, Cedula, Clave, nomEquipoActual, guidFactura, fecha, Cliente, tipoIdentificacion, Identificacion, IdFormaPagoPredefinida)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Integer
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarVentaTerpel(total, Cedula, Clave, nomEquipoActual, guidFactura, fecha, Cliente, tipoIdentificacion, Identificacion, IdFormaPagoPredefinida, TipoDocumento, IdImpresora)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion & ", TipoDocumento: " & TipoDocumento.ToString & ", IdImpresora: " & IdImpresora.ToString, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion & ", TipoDocumento: " & TipoDocumento.ToString & ", IdImpresora: " & IdImpresora.ToString, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer, ByVal IdFormaPagoPredefinida As Int16, ByVal IdFranquicia As Int32, ByVal Vaucher As String) As Integer
        Try
            Dim IdFactura As Integer
            IdFactura = ODatos.InsertarVentaTerpel(total, Cedula, Clave, nomEquipoActual, guidFactura, fecha, Cliente, tipoIdentificacion, Identificacion, IdFormaPagoPredefinida, TipoDocumento, IdImpresora, IdFranquicia, Vaucher)
            Return IdFactura
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion & ", TipoDocumento: " & TipoDocumento.ToString & ", IdImpresora: " & IdImpresora.ToString & ", IdFranquicia: " & IdFranquicia.ToString & ", Vaucher: " & Vaucher.ToString, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarVentaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion & ", TipoDocumento: " & TipoDocumento.ToString & ", IdImpresora: " & IdImpresora.ToString & ", IdFranquicia: " & IdFranquicia.ToString & ", Vaucher: " & Vaucher.ToString, "FallaStoredProcedure")
            Throw
        End Try
    End Function
    Public Function InsertarFacturaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String) As Integer
        Try
            Dim IdDocumento As Integer
            IdDocumento = ODatos.InsertarFacturaTerpel(total, Cedula, Clave, nomEquipoActual, guidFactura, fecha, Cliente, tipoIdentificacion, Identificacion)
            Return IdDocumento
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaTerpel", "Total: " & total & ", Nombre Equipo: " & nomEquipoActual & ", GUID Factura: " & guidFactura & ", TipoIdentificacion: " & tipoIdentificacion & ", Identificacion: " & Identificacion, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Sub InsertarFacturaTarjetaTmp(ByVal nomEquipo As String, ByVal codigoTarjeta As String, ByVal numeroSeguridad As String, ByVal idTipoLecturaTarjeta As Int32, ByVal clasificacionCliente As String, ByVal identificacionCliente As String)
        Try
            ODatos.InsertarFacturaTarjetaTmp(nomEquipo, codigoTarjeta, numeroSeguridad, idTipoLecturaTarjeta, clasificacionCliente, identificacionCliente)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaTarjetaTmp", "Nombre Equipo: " & nomEquipo & ", Codigo Tarjeta: " & codigoTarjeta & ", Num Seguridad: " & numeroSeguridad & ", IdTipoLecturaTarjeta: " & idTipoLecturaTarjeta & ", Clasif. Cliente: " & clasificacionCliente & ", Id. Cliente: " & identificacionCliente, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaTarjetaTmp", "Nombre Equipo: " & nomEquipo & ", Codigo Tarjeta: " & codigoTarjeta & ", Num Seguridad: " & numeroSeguridad & ", IdTipoLecturaTarjeta: " & idTipoLecturaTarjeta & ", Clasif. Cliente: " & clasificacionCliente & ", Id. Cliente: " & identificacionCliente, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaTarjetaTmpTerpel(ByVal nomEquipo As String, ByVal codigoTarjeta As String, ByVal numeroSeguridad As String, ByVal idTipoLecturaTarjeta As Int32, ByVal clasificacionCliente As String, ByVal identificacionCliente As String)
        Try
            ODatos.InsertarFacturaTarjetaTmpTerpel(nomEquipo, codigoTarjeta, numeroSeguridad, idTipoLecturaTarjeta, clasificacionCliente, identificacionCliente)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaTarjetaTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Codigo Tarjeta: " & codigoTarjeta & ", Num Seguridad: " & numeroSeguridad & ", IdTipoLecturaTarjeta: " & idTipoLecturaTarjeta & ", Clasif. Cliente: " & clasificacionCliente & ", Id. Cliente: " & identificacionCliente, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaTarjetaTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Codigo Tarjeta: " & codigoTarjeta & ", Num Seguridad: " & numeroSeguridad & ", IdTipoLecturaTarjeta: " & idTipoLecturaTarjeta & ", Clasif. Cliente: " & clasificacionCliente & ", Id. Cliente: " & identificacionCliente, "FallaStoredProcedure")
            Throw
        End Try
    End Sub


    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal borrarTemporal As Boolean, ByVal ValorDescuento As Decimal)
        Try
            ODatos.InsertarFacturaDetalleTmp(nomEquipo, idProducto, cantidad, precio, borrarTemporal, ValorDescuento)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", Borrar Temporal: " & borrarTemporal & ", ValorDescuento: " & ValorDescuento, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", Borrar Temporal: " & borrarTemporal & ", ValorDescuento: " & ValorDescuento, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal borrarTemporal As Boolean)
        Try
            ODatos.InsertarFacturaDetalleTmp(nomEquipo, idProducto, cantidad, precio, borrarTemporal)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    'TODO: OJO se comenta porque el metodo nuevo que se creo permite hacer exactamente lo mismo, pero posee un valorm adicional
    'Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean)
    '    Try
    '        ODatos.InsertarFacturaDetalleTmp(nomEquipo, idProducto, cantidad, precio, porcentajeDescuento, cantAutorizadaDescuento, borrarTemporal)
    '    Catch ex As SqlClient.SqlException
    '        LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
    '        Throw 
    '    Catch ex As System.Exception
    '        LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
    '        Throw 
    '    End Try
    'End Sub

    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, Optional ByVal ValorDescuento As Decimal = 0)
        Try
            ODatos.InsertarFacturaDetalleTmp(nomEquipo, idProducto, cantidad, precio, porcentajeDescuento, cantAutorizadaDescuento, borrarTemporal, ValorDescuento)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaDetalleTmpTerpel(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, Optional ByVal ValorDescuento As Decimal = 0)
        Try
            ODatos.InsertarFacturaDetalleTmpTerpel(nomEquipo, idProducto, cantidad, precio, porcentajeDescuento, cantAutorizadaDescuento, borrarTemporal, ValorDescuento)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub


    Public Sub InsertarFacturaDetalleTmpFullStation(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, ByVal ValorDescuento As Decimal, ByVal IdIsla As Integer)
        Try
            ODatos.InsertarFacturaDetalleTmpFullStation(nomEquipo, idProducto, cantidad, precio, porcentajeDescuento, cantAutorizadaDescuento, borrarTemporal, ValorDescuento, IdIsla)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmpFullStation", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal & "IdIsla: " & IdIsla, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTmpFullStation", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Cantidad: " & cantidad & ", Precio: " & precio & ", PorcentajeDesc: " & porcentajeDescuento & ", Cant. Autorizada Descuento: " & cantAutorizadaDescuento & ", Borrar Temporal: " & borrarTemporal & "IdIsla: " & IdIsla, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaDetalleTarjetaTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal valorCarga As Double, ByVal nroCodigoBarraPrepago As String, ByVal nroTarjetaPrepago As String, ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        Try
            ODatos.InsertarFacturaDetalleTarjetaTmp(nomEquipo, idProducto, valorCarga, nroCodigoBarraPrepago, nroTarjetaPrepago, nroConfirmacion, borrarTemporal)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTarjetaTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Valor Carga: " & valorCarga & ", Nro Codigo Barras: " & nroCodigoBarraPrepago & ", Nro Tarjeta Prepago: " & nroTarjetaPrepago & " , NroComfirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTarjetaTmp", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Valor Carga: " & valorCarga & ", Nro Codigo Barras: " & nroCodigoBarraPrepago & ", Nro Tarjeta Prepago: " & nroTarjetaPrepago & " , NroComfirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaDetalleTarjetaTmpTerpel(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal valorCarga As Double, ByVal nroCodigoBarraPrepago As String, ByVal nroTarjetaPrepago As String, ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        Try
            ODatos.InsertarFacturaDetalleTarjetaTmpTerpel(nomEquipo, idProducto, valorCarga, nroCodigoBarraPrepago, nroTarjetaPrepago, nroConfirmacion, borrarTemporal)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTarjetaTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Valor Carga: " & valorCarga & ", Nro Codigo Barras: " & nroCodigoBarraPrepago & ", Nro Tarjeta Prepago: " & nroTarjetaPrepago & " , NroComfirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaDetalleTarjetaTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Producto: " & idProducto & ", Valor Carga: " & valorCarga & ", Nro Codigo Barras: " & nroCodigoBarraPrepago & ", Nro Tarjeta Prepago: " & nroTarjetaPrepago & " , NroComfirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaFormaPagoTmp(ByVal nomEquipo As String, ByVal idFormaPago As Int16, ByVal valor As Double, ByVal referencia As String, ByVal tipoLectura As Nullable(Of Int32), ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        Try
            ODatos.InsertarFacturaFormaPagoTmp(nomEquipo, idFormaPago, valor, referencia, tipoLectura, nroConfirmacion, borrarTemporal)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaFormaPagoTmp", "Nombre Equipo: " & nomEquipo & ", Id Forma Pago: " & idFormaPago & ", Valor: " & valor & ", Referencia: " & referencia & ", Tipo Lectura: " & tipoLectura.ToString() & ", Nro Confirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaFormaPagoTmp", "Nombre Equipo: " & nomEquipo & ", Id Forma Pago: " & idFormaPago & ", Valor: " & valor & ", Referencia: " & referencia & ", Tipo Lectura: " & tipoLectura.ToString() & ", Nro Confirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Sub InsertarFacturaFormaPagoTmpTerpel(ByVal nomEquipo As String, ByVal idFormaPago As Int16, ByVal valor As Double, ByVal referencia As String, ByVal tipoLectura As Nullable(Of Int32), ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        Try
            ODatos.InsertarFacturaFormaPagoTmpTerpel(nomEquipo, idFormaPago, valor, referencia, tipoLectura, nroConfirmacion, borrarTemporal)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "InsertarFacturaFormaPagoTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Forma Pago: " & idFormaPago & ", Valor: " & valor & ", Referencia: " & referencia & ", Tipo Lectura: " & tipoLectura.ToString() & ", Nro Confirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "InsertarFacturaFormaPagoTmpTerpel", "Nombre Equipo: " & nomEquipo & ", Id Forma Pago: " & idFormaPago & ", Valor: " & valor & ", Referencia: " & referencia & ", Tipo Lectura: " & tipoLectura.ToString() & ", Nro Confirmacion: " & nroConfirmacion & ", Borrar Temporal: " & borrarTemporal, "FallaStoredProcedure")
            Throw
        End Try
    End Sub

    Public Overloads Function RecuperarConsecutivoFactura(ByVal idFactura As Int32) As String
        Try
            Return ODatos.RecuperarConsecutivoFactura(idFactura, True)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarConsecutivoFactura", "Id Factura: " & idFactura, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarConsecutivoFactura", "Id Factura: " & idFactura, "FallaStoredProcedure")
            Throw
        End Try
    End Function
    Public Overloads Function RecuperarConsecutivoFactura(ByVal idFactura As Int32, ByVal incluirPrefijo As Boolean) As String
        Try
            Return ODatos.RecuperarConsecutivoFactura(idFactura, incluirPrefijo)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarConsecutivoFactura", "Id Factura: " & idFactura & "Incluir Prefijo: " & incluirPrefijo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarConsecutivoFactura", "Id Factura: " & idFactura & "Incluir Prefijo: " & incluirPrefijo, "FallaStoredProcedure")
            Throw
        End Try
    End Function

#End Region
#Region "Productos"
    Public Function ValidarTurnoPorEmpleado(ByVal empleado As String, ByVal clave As String) As Int32
        Try
            Return ODatos.ValidarTurnoPorEmpleado(empleado, clave)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "ValidarTurnoPorEmpleado", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ValidarTurnoPorEmpleado", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function ValidarTurnoPorEmpleado(ByVal empleado As String, ByVal clave As String, ByVal codigoKiosco As String) As Int32
        Try
            Return ODatos.ValidarTurnoPorEmpleado(empleado, clave, codigoKiosco)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "ValidarTurnoPorEmpleado", "Empleado: " & empleado & ", Clave: " & clave & ", Codigo Kiosco: " & codigoKiosco, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ValidarTurnoPorEmpleado", "Empleado: " & empleado & ", Clave: " & clave & ", Codigo Kiosco: " & codigoKiosco, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function ValidarCredenciales(ByVal empleado As String, ByVal clave As String) As Boolean
        Try
            Return ODatos.ValidarCredenciales(empleado, clave)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "ValidarCredenciales", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ValidarCredenciales", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        End Try
    End Function
    Public Function RecuperarTurnoAbiertoPorEmpleado(ByVal cedula As String) As String
        Try
            Return ODatos.RecuperarTurnoAbiertoPorEmpleado(cedula)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarTurnoAbiertoPorEmpleado", "Cedula: " & cedula, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarTurnoAbiertoPorEmpleado", "Cedula: " & cedula, "FallaStoredProcedure")
            Throw
        End Try
    End Function

#End Region



#Region "Kiosco"


    Public Function IniciarSesionKiosco(ByVal empleado As String, ByVal clave As String, ByVal kiosco As String) As Int32
        Try
            Return ODatos.IniciarSesionKiosco(empleado, clave, kiosco)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "IniciarSesionKiosco", "Empleado: " & empleado & ", Clave: " & clave & ", Kiosco: " & kiosco, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "IniciarSesionKiosco", "Empleado: " & empleado & ", Clave: " & clave & ", Kiosco: " & kiosco, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function CerrarSesionKiosco(ByVal empleado As String, ByVal clave As String) As Int32
        Try
            Return ODatos.CerrarSesionKiosco(empleado, clave)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "CerrarSesionKiosco", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "CerrarSesionKiosco", "Empleado: " & empleado & ", Clave: " & clave, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarDatosSesionAbierta(ByVal empleado As String) As IDataReader
        Try
            Return ODatos.RecuperarDatosSesionAbierta(empleado)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarDatosSesionAbierta", "Empleado: " & empleado, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarDatosSesionAbierta", "Empleado: " & empleado, "FallaStoredProcedure")
            Throw
        End Try
    End Function

#End Region







#Region "Impresora"
    Public Function RecuperarImpresoraPorKiosco(ByVal codigo As String) As String
        Try
            Return ODatos.RecuperarImpresoraPorKiosco(codigo)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarImpresoraPorKiosco", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarImpresoraPorKiosco", "Codigo: " & codigo, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarImpresoraPorTurno(ByVal idTurno As Int32) As String
        Try
            Return ODatos.RecuperarImpresoraPorTurno(idTurno)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarImpresoraPorTurno", "IdTurno: " & idTurno, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarImpresoraPorTurno", "IdTurno: " & idTurno, "FallaStoredProcedure")
            Throw
        End Try
    End Function
#End Region
#Region "Turno"

    Public Function RecuperarCierreParcialTurno(ByVal codigoKiosco As String) As DataSet
        Try
            Return ODatos.RecuperarCierreParcialTurno(codigoKiosco)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarCierreParcialTurno", "Codigo Kiosco: " & codigoKiosco, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarCierreParcialTurno", "Codigo Kiosco: " & codigoKiosco, "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarCierreTurno(ByVal idTurno As Int32) As DataSet
        Try
            Return ODatos.RecuperarCierreTurno(idTurno)
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarCierreTurno", "Id Turno: " & idTurno, "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarCierreTurno", "Id Turno: " & idTurno, "FallaStoredProcedure")
            Throw
        End Try
    End Function

#End Region




#Region "Resoluciones"

    Public Function ExisteResolucionValida() As Boolean
        Try
            Return ODatos.ExisteResolucionValida()
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "ExisteResolucionValida", "", "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ExisteResolucionValida", "", "FallaStoredProcedure")
            Throw
        End Try
    End Function

    Public Function RecuperarResolucionActivaCanastilla() As String
        Try
            Return ODatos.RecuperarResolucionActivaCanastilla()
        Catch ex As SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarResolucionActivaCanastilla", "", "FallaStoredProcedure")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarResolucionActivaCanastilla", "", "FallaStoredProcedure")
            Throw
        End Try
    End Function
#End Region












End Class