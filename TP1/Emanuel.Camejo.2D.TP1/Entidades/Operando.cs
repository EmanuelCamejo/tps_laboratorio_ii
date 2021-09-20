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

        /// <summary>
        /// Valido que sea un número el parámetro recibido caso contrario devuelve el numero 0
        /// </summary>
        /// <param name="strNumero">un atributo de tipo string</param>
        /// <returns>Devuelve un double con el resultado de la validación</returns>
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

        /// <summary>
        /// Valida si el parametro recibido es un número binario.
        /// </summary>
        /// <param name="binario">Un parametro de tipo String</param>
        /// <returns>Devuelve un valor Bool para saber si es binario o no</returns>
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
        /// Convierte un número decimal pasado por parametro de tipo string
        /// </summary>
        /// <param name="numero">Un parametro de tipo String que converita en Binario</param>
        /// <returns>Devuelve un string con el Binario construido</returns>
        public string DecimalBinario(string numero)
        {
            string valorBinario = string.Empty;
            string resultado;

            if (int.TryParse(numero, out int noEsUnaLetra))
            {
                int resultadoDivicion = Math.Abs(int.Parse(numero));//Obtengo el valor absoluto y entero
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
                resultado=valorBinario;
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario, reutilizo el codigo. 
        /// </summary>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = DecimalBinario(numero.ToString());
            return valorBinario;
        }


        /// <summary>
        /// Convierte un número Binario a Decimal, utilizo el método EsBinario para el parámetro recibido.
        /// </summary>
        /// <param name="binario">Parametro de tipo string</param>
        /// <returns>Retorna un string con el numero Decima si es que se puede sino retorna texoto Valor Invalido</returns>
        public string BinarioDecimal(string binario)
        {
            double resultado=0;
            string valorRetorno;
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
                valorRetorno = resultado.ToString();
            }
            else
            {
                valorRetorno = "Valor Invalido";
            }
            return valorRetorno;
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
                return double.MinValue;//si la divición es por cero va a devolver el valor minimo permitido
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
