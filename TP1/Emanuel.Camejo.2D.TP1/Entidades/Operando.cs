using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region Propiedades

        public string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        #endregion

        #region Constructores
        public Operando() : this(0)
        {

        }

        public Operando(double num1)
        {
            this.numero = num1;
        }

        public Operando(string strNum1)
        {
            Numero = strNum1;//Utilizo la propiedad para validar el string recibido
        }
        #endregion

        #region Metodos
        private double ValidarOperando(string strNumero)
        {
            double resultado, num;
            bool esNumerico = double.TryParse(strNumero, out num);

            if (esNumerico)
            {
                resultado = num;
            }
            else
            {
                resultado = 0;
            }
            return resultado;
        }

        private bool EsBinario(string binario)
        {
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte un número Decimal a Binario.
        /// </summary>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string valorBinario = string.Empty;
            int resultadoDivicion = Math.Abs(((int)double.Parse(numero)));//Obtengo el valor absoluto y entero
            int resto;
            if (resultadoDivicion >= 0)
            {
                do
                {
                    resto = resultadoDivicion % 2;
                    resultadoDivicion /= 2;
                    valorBinario = resto.ToString() + valorBinario;

                } while (resultadoDivicion > 0);
            }
            return valorBinario;
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario
        /// </summary>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = DecimalBinario(numero);
            return valorBinario;
        }

        /// <summary>
        /// Convierte un número Binario a Decimal, utilizo el metodo EsBinario para el parametro recibido.
        /// </summary>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string resultado = "";
            if (EsBinario(binario))
            {
                int cantidadCaracteres = binario.Length;
                foreach (char caracter in binario)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }

        #endregion

        #region Sobrecargas de Operador 
        //Creo las sobrecarga de los operadores para poder hacer las operaciones
        
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator /(Operando num1, Operando num2)
        {
            if (num2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return num1.numero / num2.numero;
            }
        }

        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }
        #endregion
    }
}
