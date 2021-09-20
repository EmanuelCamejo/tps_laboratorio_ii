using System;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos

        /// <summary>
        /// Realiza la operacion pedida entre los números recibidos por parametro
        /// </summary>
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
        /// Valida el Operador recibido por parametro
        /// </summary>
        /// <returns></returns>
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
