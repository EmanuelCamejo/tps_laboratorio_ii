using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Contructor de la clase ciclomotor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Sobreescribo el metodo mostrar de la clase base, donde imprimo los datos del ciclomotor
        /// </summary>
        /// <returns>Retorna un string con los datos del Ciclomotor</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");            
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
