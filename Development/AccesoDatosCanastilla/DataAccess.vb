Imports Microsoft.Practices.EnterpriseLibrary.data
Imports System.Data.Common

Public Class SqlServer

  
    Public Function RecuperarProductoConsumoCanastilla(ByVal codigo As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProductoConsumoCanastilla"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Codigo", DbType.Int32, codigo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

  
   
    Public Function ValidarTurnoPorEmpleado(ByVal empleado As String, ByVal clave As String) As Int32
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ValidarTurnoPorEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, empleado)
        DB.AddOutParameter(DatabaseCommand, "IdTurnoE", DbType.Int32, 4)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CType(DB.GetParameterValue(DatabaseCommand, "IdTurnoE"), Int32)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ValidarTurnoPorEmpleado(ByVal empleado As String, ByVal clave As String, ByVal codigoKiosco As String) As Int32
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ValidarTurnoPorEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, empleado)
        DB.AddInParameter(DatabaseCommand, "CodigoKiosco", DbType.String, codigoKiosco)
        DB.AddOutParameter(DatabaseCommand, "IdTurnoE", DbType.Int32, 4)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CType(DB.GetParameterValue(DatabaseCommand, "IdTurnoE"), Int32)
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function ValidarCredenciales(ByVal empleado As String, ByVal clave As String) As Boolean
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ValidarCredenciales"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, empleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CBool(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarTurnoAbiertoPorEmpleado(ByVal cedula As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarTurnoAbiertoPorEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Dim oReader As IDataReader = DB.ExecuteReader(DatabaseCommand)

                If oReader.Read Then
                    Return oReader.Item(0).ToString
                Else
                    Return ""
                End If
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    
#Region "Factura"
    
    Public Function InsertarFactura(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFactura"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, usuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)



        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarFactura(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal esModificada As Boolean) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFactura"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, usuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddInParameter(DatabaseCommand, "FueModificada", DbType.Boolean, esModificada)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)



        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarFacturaTerpel(ByVal total As Double, ByVal usuario As String, ByVal clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal esModificada As Boolean) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFactura"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, usuario)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddInParameter(DatabaseCommand, "FueModificada", DbType.Boolean, esModificada)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)



        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarVentaTerpel"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)
        DB.AddInParameter(DatabaseCommand, "Cliente", DbType.String, Cliente)
        DB.AddInParameter(DatabaseCommand, "TipoIdentificacion", DbType.Int32, tipoIdentificacion)
        DB.AddInParameter(DatabaseCommand, "Identificacion", DbType.String, Identificacion)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                'DB.ExecuteNonQuery(DatabaseCommand)
                'Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, ByVal IdFormaPagoPredefinida As Int16) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarVentaTerpel"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)
        DB.AddInParameter(DatabaseCommand, "Cliente", DbType.String, Cliente)
        DB.AddInParameter(DatabaseCommand, "TipoIdentificacion", DbType.Int32, tipoIdentificacion)
        DB.AddInParameter(DatabaseCommand, "Identificacion", DbType.String, Identificacion)
        DB.AddInParameter(DatabaseCommand, "IdFormaPagoPredefinida", DbType.Int16, IdFormaPagoPredefinida)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                'DB.ExecuteNonQuery(DatabaseCommand)
                'Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, ByVal IdFormaPagoPredefinida As Int16, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarVentaTerpel"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)
        DB.AddInParameter(DatabaseCommand, "Cliente", DbType.String, Cliente)
        DB.AddInParameter(DatabaseCommand, "TipoIdentificacion", DbType.Int32, tipoIdentificacion)
        DB.AddInParameter(DatabaseCommand, "Identificacion", DbType.String, Identificacion)
        DB.AddInParameter(DatabaseCommand, "IdFormaPagoPredefinida", DbType.Int16, IdFormaPagoPredefinida)
        DB.AddInParameter(DatabaseCommand, "IdImpresora", DbType.Int32, IdImpresora)
        DB.AddInParameter(DatabaseCommand, "TipoDocumento", DbType.Int32, TipoDocumento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                'DB.ExecuteNonQuery(DatabaseCommand)
                'Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function




    Public Function InsertarVentaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String, ByVal IdFormaPagoPredefinida As Int16, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer, ByVal IdFranquicia As Int32, ByVal Vaucher As String) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarVentaTerpel"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdFactura", DbType.Int32, 4)
        DB.AddInParameter(DatabaseCommand, "Cliente", DbType.String, Cliente)
        DB.AddInParameter(DatabaseCommand, "TipoIdentificacion", DbType.Int32, tipoIdentificacion)
        DB.AddInParameter(DatabaseCommand, "Identificacion", DbType.String, Identificacion)
        DB.AddInParameter(DatabaseCommand, "IdFormaPagoPredefinida", DbType.Int16, IdFormaPagoPredefinida)
        DB.AddInParameter(DatabaseCommand, "IdImpresora", DbType.Int32, IdImpresora)
        DB.AddInParameter(DatabaseCommand, "TipoDocumento", DbType.Int32, TipoDocumento)
        DB.AddInParameter(DatabaseCommand, "IdFranquicia", DbType.Int32, IdFranquicia)
        DB.AddInParameter(DatabaseCommand, "Vaucher", DbType.String, Vaucher)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                'DB.ExecuteNonQuery(DatabaseCommand)
                'Return CInt(DB.GetParameterValue(DatabaseCommand, "IdFactura"))
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Function InsertarFacturaTerpel(ByVal total As Double, ByVal Cedula As String, ByVal Clave As String, ByVal nomEquipoActual As String, ByVal guidFactura As String, ByVal fecha As DateTime, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal Identificacion As String) As Integer
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaTerpel"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        If fecha = Nothing Then
            fecha = Now
        End If

        DB.AddInParameter(DatabaseCommand, "Total", DbType.Double, total)
        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, Cedula)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, Clave)
        DB.AddInParameter(DatabaseCommand, "NomEquipoActual", DbType.String, nomEquipoActual)
        DB.AddInParameter(DatabaseCommand, "GUIDFactura", DbType.String, guidFactura)
        DB.AddInParameter(DatabaseCommand, "Fecha", DbType.DateTime, fecha)
        DB.AddOutParameter(DatabaseCommand, "IdDocumento", DbType.Int32, 4)
        DB.AddInParameter(DatabaseCommand, "Cliente", DbType.String, Cliente)
        DB.AddInParameter(DatabaseCommand, "TipoIdentificacion", DbType.Int32, tipoIdentificacion)
        DB.AddInParameter(DatabaseCommand, "Identificacion", DbType.String, Identificacion)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

  
    Public Function RecuperarDescuentoProducto(ByVal idProducto As Integer, ByVal cantidad As Integer, ByVal precio As Decimal, ByVal descuento As Decimal) As Decimal
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDescuentoProducto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Decimal, precio)
        DB.AddInParameter(DatabaseCommand, "Descuento", DbType.Decimal, descuento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function



    Public Function RecuperarDescuentoProducto(ByVal idProducto As Integer, ByVal cantidad As Integer, ByVal precio As Decimal, ByVal descuento As Decimal, ByVal CantidadAutorizadaCDC As Integer) As Decimal
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDescuentoProducto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Decimal, precio)
        DB.AddInParameter(DatabaseCommand, "Descuento", DbType.Decimal, descuento)
        DB.AddInParameter(DatabaseCommand, "CantidadAutorizadaCDC", DbType.Int32, CantidadAutorizadaCDC)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CInt(DB.ExecuteScalar(DatabaseCommand))

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Overloads Function RecuperarConsecutivoFactura(ByVal idFactura As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarConsecutivoFactura"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdFactura", DbType.Int32, idFactura)
        DB.AddInParameter(DatabaseCommand, "IncluirPrefijo", DbType.Int16, 1)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand).ToString()
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Overloads Function RecuperarConsecutivoFactura(ByVal idFactura As Int32, ByVal incluirPrefijo As Boolean) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarConsecutivoFactura"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdFactura", DbType.Int32, idFactura)
        DB.AddInParameter(DatabaseCommand, "IncluirPrefijo", DbType.Int16, IIf(incluirPrefijo, 1, 0))

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand).ToString()
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProductoPorCodigo(ByVal codigo As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProductoPorCodigo"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoProducto", DbType.Int32, codigo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
    Public Function RecuperarProductoPorCodigo(ByVal codigo As Int32, ByVal idEstacion As Int16) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProductoPorCodigo"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoProducto", DbType.Int32, codigo)
        DB.AddInParameter(DatabaseCommand, "IdEstacion", DbType.Int16, idEstacion)
        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarProductoPorCodigoTerpel(ByVal codigo As Int32) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProductoPorCodigo"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoProducto", DbType.Int32, codigo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function


    Public Function RecuperarProductoPorCodigoTerpel(ByVal codigo As Int32, ByVal IdIsla As Integer) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarProductoPorCodigo"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoProducto", DbType.Int32, codigo)
        DB.AddInParameter(DatabaseCommand, "IdIsla", DbType.Int32, IdIsla)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarIdProducto(ByVal codigo As Int32) As Int32
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarIdProducto"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "CodigoProducto", DbType.Int32, codigo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CInt(DB.ExecuteScalar(DatabaseCommand))
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region
#Region "FacturaDetalle"
    Public Sub InsertarFacturaTarjetaTmp(ByVal nomEquipo As String, ByVal codigoTarjeta As String, ByVal numeroSeguridad As String, ByVal idTipoLecturaTarjeta As Int32, ByVal clasificacionCliente As String, ByVal identificacionCliente As String)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaTarjetaTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "CodigoTarjeta", DbType.String, codigoTarjeta)
        DB.AddInParameter(DatabaseCommand, "NumeroSeguridad", DbType.String, numeroSeguridad)
        DB.AddInParameter(DatabaseCommand, "IdTipoLecturaTarjeta", DbType.String, idTipoLecturaTarjeta)
        DB.AddInParameter(DatabaseCommand, "ClasificacionCliente", DbType.String, clasificacionCliente)
        DB.AddInParameter(DatabaseCommand, "IdentificacionCliente", DbType.String, identificacionCliente)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaTarjetaTmpTerpel(ByVal nomEquipo As String, ByVal codigoTarjeta As String, ByVal numeroSeguridad As String, ByVal idTipoLecturaTarjeta As Int32, ByVal clasificacionCliente As String, ByVal identificacionCliente As String)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaTarjetaTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "CodigoTarjeta", DbType.String, codigoTarjeta)
        DB.AddInParameter(DatabaseCommand, "NumeroSeguridad", DbType.String, numeroSeguridad)
        DB.AddInParameter(DatabaseCommand, "IdTipoLecturaTarjeta", DbType.String, idTipoLecturaTarjeta)
        DB.AddInParameter(DatabaseCommand, "ClasificacionCliente", DbType.String, clasificacionCliente)
        DB.AddInParameter(DatabaseCommand, "IdentificacionCliente", DbType.String, identificacionCliente)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

   
    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal borrarTemporal As Boolean, ByVal valorDescuento As Decimal)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)
        DB.AddInParameter(DatabaseCommand, "ValorDescuento", DbType.Decimal, valorDescuento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "PorcentajeDescuento", DbType.Decimal, porcentajeDescuento)
        DB.AddInParameter(DatabaseCommand, "CantidadAutorizadaDescuento", DbType.Int32, cantAutorizadaDescuento)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaDetalleTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, ByVal ValorDescuento As Decimal)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "PorcentajeDescuento", DbType.Decimal, porcentajeDescuento)
        DB.AddInParameter(DatabaseCommand, "CantidadAutorizadaDescuento", DbType.Int32, cantAutorizadaDescuento)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)
        DB.AddInParameter(DatabaseCommand, "ValorDescuento", DbType.Decimal, ValorDescuento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaDetalleTmpTerpel(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, ByVal ValorDescuento As Decimal)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "PorcentajeDescuento", DbType.Decimal, porcentajeDescuento)
        DB.AddInParameter(DatabaseCommand, "CantidadAutorizadaDescuento", DbType.Int32, cantAutorizadaDescuento)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)
        DB.AddInParameter(DatabaseCommand, "ValorDescuento", DbType.Decimal, ValorDescuento)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub











#End Region
#Region "FacturaDetallePrepago"
 
    Public Sub InsertarFacturaDetalleTarjetaTmp(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal valorCarga As Double, ByVal nroCodigoBarraPrepago As String, ByVal nroTarjetaPrepago As String, ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTarjetaTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "ValorCarga", DbType.Decimal, valorCarga)
        DB.AddInParameter(DatabaseCommand, "NroCodigoBarraPrepago", DbType.String, nroCodigoBarraPrepago)
        DB.AddInParameter(DatabaseCommand, "NroTarjetaPrepago", DbType.String, nroTarjetaPrepago)
        DB.AddInParameter(DatabaseCommand, "NroConfirmacion", DbType.String, nroConfirmacion)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaDetalleTarjetaTmpTerpel(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal valorCarga As Double, ByVal nroCodigoBarraPrepago As String, ByVal nroTarjetaPrepago As String, ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTarjetaTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "ValorCarga", DbType.Decimal, valorCarga)
        DB.AddInParameter(DatabaseCommand, "NroCodigoBarraPrepago", DbType.String, nroCodigoBarraPrepago)
        DB.AddInParameter(DatabaseCommand, "NroTarjetaPrepago", DbType.String, nroTarjetaPrepago)
        DB.AddInParameter(DatabaseCommand, "NroConfirmacion", DbType.String, nroConfirmacion)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
#End Region
#Region "FacturaFormaPago"
    Public Sub InsertarFacturaFormaPagoTmp(ByVal nomEquipo As String, ByVal idFormaPago As Int16, ByVal valor As Double, ByVal referencia As String, ByVal tipoLectura As Nullable(Of Int32), ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaFormaPagoTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdFormaPago", DbType.Int16, idFormaPago)
        DB.AddInParameter(DatabaseCommand, "Valor", DbType.Decimal, valor)
        DB.AddInParameter(DatabaseCommand, "Referencia", DbType.String, referencia)
        DB.AddInParameter(DatabaseCommand, "TipoLectura", DbType.Int32, tipoLectura)
        DB.AddInParameter(DatabaseCommand, "NroConfirmacion", DbType.String, nroConfirmacion)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

    Public Sub InsertarFacturaFormaPagoTmpTerpel(ByVal nomEquipo As String, ByVal idFormaPago As Int16, ByVal valor As Double, ByVal referencia As String, ByVal tipoLectura As Nullable(Of Int32), ByVal nroConfirmacion As String, ByVal borrarTemporal As Boolean)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaFormaPagoTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdFormaPago", DbType.Int16, idFormaPago)
        DB.AddInParameter(DatabaseCommand, "Valor", DbType.Decimal, valor)
        DB.AddInParameter(DatabaseCommand, "Referencia", DbType.String, referencia)
        DB.AddInParameter(DatabaseCommand, "TipoLectura", DbType.Int32, tipoLectura)
        DB.AddInParameter(DatabaseCommand, "NroConfirmacion", DbType.String, nroConfirmacion)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub
#End Region

#Region "Resolucion"

    Public Function ExisteResolucionValida() As Boolean
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "ExisteResolucionValida"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CBool(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarResolucionActivaCanastilla() As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarResolucionActivaCanastilla"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return CStr(DB.ExecuteScalar(DatabaseCommand))
            Catch
                Throw
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region

#Region "Kiosco"
   
    Public Function IniciarSesionKiosco(ByVal empleado As String, ByVal clave As String, ByVal kiosco As String) As Int32
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "AbrirTurno"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        Dim IdTurno As Int32

        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, empleado)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddInParameter(DatabaseCommand, "CodigoKiosco", DbType.String, kiosco)
        DB.AddOutParameter(DatabaseCommand, "IdTurno", DbType.Int32, CInt(IdTurno))

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CInt(DB.GetParameterValue(DatabaseCommand, "IdTurno"))
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function CerrarSesionKiosco(ByVal empleado As String, ByVal clave As String) As Int32
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "CerrarTurno"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)
        Dim IdTurno As Int32

        DB.AddInParameter(DatabaseCommand, "Empleado", DbType.String, empleado)
        DB.AddInParameter(DatabaseCommand, "Clave", DbType.String, clave)
        DB.AddOutParameter(DatabaseCommand, "IdTurno", DbType.Int32, CInt(IdTurno))

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)
                Return CInt(DB.GetParameterValue(DatabaseCommand, "IdTurno"))
            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarDatosSesionAbierta(ByVal empleado As String) As IDataReader
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarDatosTurnoAbiertoPorEmpleado"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Cedula", DbType.String, empleado)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteReader(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region


#Region "Impresora"
    Public Function RecuperarImpresoraPorKiosco(ByVal codigo As String) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarImpresoraPorKiosco"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Codigo", DbType.String, codigo)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarImpresoraPorTurno(ByVal idTurno As Int32) As String
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarImpresoraPorTurno"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdTurno", DbType.String, idTurno)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteScalar(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region
#Region "Turno"
 
    Public Function RecuperarCierreParcialTurno(ByVal codigoKiosco As String) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarCierreParcialTurno"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "Codigo", DbType.String, codigoKiosco)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function

    Public Function RecuperarCierreTurno(ByVal idTurno As Int32) As DataSet
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "RecuperarCierreTurno"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "IdTurno", DbType.Int32, idTurno)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                Return DB.ExecuteDataSet(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Function
#End Region








#Region "Canastilla FullStation"
    ''Ojo este metodo solo se usa para FuelStation para enviar los datos de la venta de canastilla

    Public Sub InsertarFacturaDetalleTmpFullStation(ByVal nomEquipo As String, ByVal idProducto As Int32, ByVal cantidad As Int32, ByVal precio As Double, ByVal porcentajeDescuento As Decimal, ByVal cantAutorizadaDescuento As Int32, ByVal borrarTemporal As Boolean, ByVal ValorDescuento As Decimal, ByVal IdIsla As Integer)
        'Crea el objeto base de datos, esto representa la conexion a la base de datos indicada en el archivo de configuracion
        Dim DB As Database = DatabaseFactory.CreateDatabase()
        'Crea un sqlComand a partir del nombre del procedimiento almacenado
        Dim SqlCommand As String = "InsertarFacturaDetalleTmp"
        Dim DatabaseCommand As DbCommand = DB.GetStoredProcCommand(SqlCommand)

        DB.AddInParameter(DatabaseCommand, "NomEquipo", DbType.String, nomEquipo)
        DB.AddInParameter(DatabaseCommand, "IdProducto", DbType.Int32, idProducto)
        DB.AddInParameter(DatabaseCommand, "Cantidad", DbType.Int32, cantidad)
        DB.AddInParameter(DatabaseCommand, "Precio", DbType.Double, precio)
        DB.AddInParameter(DatabaseCommand, "PorcentajeDescuento", DbType.Decimal, porcentajeDescuento)
        DB.AddInParameter(DatabaseCommand, "CantidadAutorizadaDescuento", DbType.Int32, cantAutorizadaDescuento)
        DB.AddInParameter(DatabaseCommand, "BorrarTemporal", DbType.Boolean, borrarTemporal)
        DB.AddInParameter(DatabaseCommand, "ValorDescuento", DbType.Decimal, ValorDescuento)
        DB.AddInParameter(DatabaseCommand, "IdIsla", DbType.Int32, IdIsla)

        Using connection As DbConnection = DB.CreateConnection()
            connection.Open()

            Try
                'Ejecuta el Procedimiento Almacenado
                DB.ExecuteNonQuery(DatabaseCommand)

            Catch Ex As Exception
                Throw Ex
            Finally
                connection.Close()
            End Try
        End Using
    End Sub

#End Region
End Class