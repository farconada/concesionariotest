using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Vehiculo : Entity
    {
        public enum PropertyEnum { Id, Marca, Modelo, Potencia, Presupuestos, DetalleCompleto }; 
        private string marca;
        private string modelo;
        private int potencia;
        public virtual ICollection<Presupuesto> Presupuesto {get; set;}

        public Vehiculo(string marca, string modelo, int potencia): this(0,marca,modelo,potencia)
        {
            
        }

        public Vehiculo(int id, string marca, string modelo, int potencia): base(id)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.potencia = potencia;
        }
        public Vehiculo(int id): base(id)
        {
        } 

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        

        public int Potencia
        {
            get { return potencia; }
            set { potencia = value; }
        }

        public string DetalleCompleto
        {
            get { return ToString(); }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return marca + "-" + modelo + " (" + potencia + "CV)";;
        }
    }
}
