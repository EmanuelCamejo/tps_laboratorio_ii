using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Constructor de la clase para inicializar los atributos
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        private ETamanio Tamanio
        {
            get;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo. Utilizo la sobrecarga explicita.
        /// </summary>
        /// <returns>Retorno el string con los datos del vehiculo</returns>
        public virtual string Mostrar()
        {
            return ((string)this);
        }

        /// <summary>
        /// sobrecarga explicita para que me devuelva un string con los atributos de la instancia pasada por parametro.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CHASIS: {p.chasis}\r");
            sb.AppendLine($"MARCA : {p.marca}\r");
            sb.Append($"COLOR : {p.color}\r");
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de operador ==
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorno una valor boleano si el chasis es igual de los dos vehiculos tomados por parametro</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1 is null || v2 is null)
            {
                return false;
            }
            return v1.GetType()==v2.GetType() && (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Sobrecarga de operador !=
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Retorno una valor boleano si el chasis es distinto de los dos vehiculos tomados por parametro</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Sobreescribo el metodo equals por la sobrecarga del ==  y !=.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorno bool dependiendo del resultado de la evaluación</returns>
        public override bool Equals(object obj)
        {
            Vehiculo v1 = obj as Vehiculo;

            return v1 != null && this == v1;
        }

        /// <summary>
        /// Sobreescribo el metodo GethashCode por la sobrecarga del == y !=.
        /// </summary>
        /// <returns>Retorna un numero entero para luego ser comparado</returns>
        public override int GetHashCode()
        {
            return (chasis).GetHashCode();
        }

    }
}
