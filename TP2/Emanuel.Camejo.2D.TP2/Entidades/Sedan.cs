using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo 
        { 
          CuatroPuertas, CincoPuertas 
        }
        private ETipo tipo;

       
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Sobre carga de constructor de la clase.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo =tipo;
        }


        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }


        /// <summary>
        ///  Sobreescribo el metodo mostrar de la clase base, donde imprimo los datos del Sedan
        /// </summary>
        /// <returns>Retorna un string con los datos del Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine("---------------------");
            sb.AppendLine("");
            sb.AppendLine($"TAMAÑO : {this.Tamanio} TIPO: {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

       
    }
}
