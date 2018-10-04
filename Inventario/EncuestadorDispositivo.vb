Public Class EncuestadorDispositivo

#Region "   Declaracion de Variables    "
    ''' <summary>
    ''' Permite seleccionar las posibles variables a recuperar por medio del Dispositivo
    ''' </summary>
    ''' <remarks></remarks>
    Enum EnVariables
        Stock = 0
        Temperatura = 1
        Humedad = 2
        Todo = 3
    End Enum

#End Region

    ''' <summary>
    ''' Permite Recuperar el valor de una variable previamente seleccionada de un tanque
    ''' </summary>
    ''' <param name="IdDispositivo">Id Dispositivo segun configuración en la Estación</param>
    ''' <param name="Variable">Variable que se debe encuestar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RecuperarVariablesMedicion(ByVal IdDispositivo As Int16, ByVal Variable As EnVariables) As List(Of Variables)
        Try
            Dim oVariables As New List(Of Variables)
            Dim ItemVariables As Variables

            Select Case Variable
                Case EnVariables.Stock
                    ItemVariables = New Variables()
                    With ItemVariables
                        .Variable = EnVariables.Stock
                        .Valor = 1000
                    End With
                    oVariables.Add(ItemVariables)
                Case EnVariables.Humedad
                    ItemVariables = New Variables()
                    With ItemVariables
                        .Variable = EnVariables.Humedad
                        .Valor = 10
                    End With
                    oVariables.Add(ItemVariables)

                Case EnVariables.Temperatura
                    ItemVariables = New Variables()
                    With ItemVariables
                        .Variable = EnVariables.Temperatura
                        .Valor = 40
                    End With
                    oVariables.Add(ItemVariables)
            End Select
            Return oVariables
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class

Public Class Variables
#Region "   Declaracion de Variables    "
    Private _Variable As EncuestadorDispositivo.EnVariables
    Private _Valor As Decimal
#End Region

#Region "   Declaracion de Propiedades  "

    ''' <summary>
    ''' Tipo de Variable Medida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Variable() As EncuestadorDispositivo.EnVariables
        Get
            Return _Variable
        End Get
        Set(ByVal value As EncuestadorDispositivo.EnVariables)
            _Variable = value
        End Set
    End Property

    ''' <summary>
    ''' Valor de la Variable Medida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property


#End Region

End Class
