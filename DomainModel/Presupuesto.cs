using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Presupuesto : Entity
    {
        public enum PropertyEnum { Id, Estado, Importe, Cliente, Vehiculo};
        public enum StatusEnum {New , Created,Acepted,Closed};

        private StatusEnum estado;
        private float importe;
        private Cliente cliente;
        private Vehiculo vehiculo;
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }

        public Presupuesto(int id): base(id)
        {
        }
        public Presupuesto(Cliente cliente, Vehiculo vehiculo, float importe): this(0,cliente,vehiculo,importe, StatusEnum.New)
        {
        }
        public Presupuesto(Cliente cliente, Vehiculo vehiculo, float importe, StatusEnum estado): this(0, cliente, vehiculo, importe, estado)
        {
        }
        public Presupuesto(int id, Cliente cliente, Vehiculo vehiculo, float importe, StatusEnum estado):base(id)
        {
            this.estado = estado;
            this.importe = importe;
            this.cliente = cliente;
            this.vehiculo = vehiculo;

        }


        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
            set { vehiculo = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public StatusEnum Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        

        public float Importe
        {
            get { return importe; }
            set { importe = value; }
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
