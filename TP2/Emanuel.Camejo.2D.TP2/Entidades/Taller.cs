using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
     public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        private Taller()
        {
            vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Retorna un string del metodo Listar con el estado del estacionamiento y todos sus vehiculos</returns>
        public override string ToString()
        {
            return Listar(this,ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Retorno un string con todos los vehiculos del taller pasado por parametro segun el tipo pasado por parametro</returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tenemos {this.vehiculos.Count} lugares ocupados deun total de {this.espacioDisponible} disponibles");
            

            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Todos:
                        sb.AppendLine(v.Mostrar());
                        break;
                    
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorno el taller pasado por parametro agregando el vehiculo pasado por parametro, si es que ya no estaba
        /// en el taller, si estaba en el taller devuelve el mismo taller sin agregar el vehiculo pasado por parametros</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            if (t.espacioDisponible == t.vehiculos.Count)
            {
                return t;
            }
            foreach (Vehiculo v in t.vehiculos)
            {
                    if (v == vehiculo)
                    {
                        return t;
                    }
            }
            t.vehiculos.Add(vehiculo);
            return t;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Retorno el taller pasado por parametro sacando el vehiculo pasado por parametro, si es que estaba
        /// en el taller, si no estaba en el taller devuelve el mismo taller pasado por parametro sin modificaciones</returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(v);
                    return t;
                }
            }
            
            return t;
        }
        #endregion
    }
}
