using System;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos

        /// <summary>
        /// Realiza la operación pedida entre los números recibidos por parámetro
        /// </summary>
        /// <param name="num1">Intancia de la clase Operando</param>
        /// <param name="num2">Intancia de la clase Operando</param>
        /// <param name="operador">Un atributo de tipo Char</param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValido = ValidarOperador(operador);
            double res = 0;

            if (operadorValido == '+')
            {
                res = num1 + num2;
            }
            if (operadorValido == '-')
            {
                res = num1 - num2;
            }
            if (operadorValido == '/')
            {
                res = num1 / num2;
            }
            if (operadorValido == '*')
            {
                res = num1 * num2;
            }
            return res;
        }

        /// <summary>
        /// Valida el Operador recibido por parámetro.
        /// </summary>
        /// <param name="operador">Un atributo de tipo Char</param>
        /// <returns>Devuelve un char sengun el operador recibido</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }
            else
            {
                return '+';
            }
        }
        #endregion
    }
}
