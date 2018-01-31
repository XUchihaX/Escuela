using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Escuela
{
    class Validar
    {
        public static bool SoloLetras(string Caracteres)
        {
            //comprueba si en la cadena de caracteres introducida hay algun numero
            // y mientras haya algun numero en Caracteres seguira retornando false
            //el punto (.) es un caracter
            foreach (char Letra in Caracteres)
            {
                if (!Char.IsLetter(Letra) && Letra != 32)
                {
                    return false;
                }
            }
            return true;    
        }
    }
}
