using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Excepciones
{
    class ProtocoloException: System.Exception 
    {

        // Resumen:
        //     Inicializa una nueva instancia de la clase System.Exception.
        public ProtocoloException(){}
        //
        // Resumen:
        //     Inicializa una nueva instancia de la clase SATELITELite.Excepciones.ProtocoloException con el mensaje
        //     de error especificado.
        
        // Parámetros:
        //   message:
        //     Mensaje que describe el error.
        public ProtocoloException(string message): base(message)
        {}
            
        //
        // Resumen:
        //     Inicializa una nueva instancia de la clase SATELITELite.Excepciones.ProtocoloException con un mensaje
        //     de error especificado y una referencia a la excepción interna que representa
        //     la causa de esta excepción.
        //
        // Parámetros:
        //   message:
        //     Mensaje de error que explica la razón de la excepción.
        //
        //   innerException:
        //     La excepción que es la causa de la excepción actual o una referencia nula
        //     (Nothing en Visual Basic) si no se especifica ninguna excepción interna.
        public ProtocoloException(string message, Exception innerException) : base(message)
        { }

      

    
      
     
 
    }
}