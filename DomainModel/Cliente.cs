using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Cliente : Entity
    {
        public enum PropertyEnum { Id, Nombre, Apellidos, Telefono, Vip, Presupuestos, DetalleCompleto }; 

        private string nombre;
        private string apellidos;
        private string telefono;
        private bool vip;
        public virtual ICollection<Presupuesto> Presupuesto { get; set; }

        public Cliente() { }

        public Cliente(string nombre, string apellidos, string telefono, bool vip) : this(0,nombre, apellidos, telefono,  vip)
        {
            
        }
        public Cliente(int id, string nombre, string apellidos, string telefono, bool vip): base(id)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.vip = vip;
        }
        public Cliente(int id): base(id)
        {
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public bool Vip
        {
            get { return vip; }
            set { vip = value; }
        }

        public string DetalleCompleto
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return apellidos + ", " + nombre + " (" + Id + ")"; ;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
