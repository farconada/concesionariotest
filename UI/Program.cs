using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using DomainModel;
namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ConcesionarioContext())
            {
                var query = from c in db.Clientes select c;
                foreach (var item in query)
                {
                    Console.WriteLine(item.Nombre);
                }

                Console.WriteLine("inserta un nuevo cliente Nombre, Apellidos, Telefono, Vip");
                var nombre = Console.ReadLine();
                var apellidos = Console.ReadLine();
                var telefono = Console.ReadLine();
                var vip = true;
                var cliente = new Cliente("nombre", "apellidos", "232323", true);
                db.Clientes.Add(cliente);
                db.SaveChanges();
                Console.WriteLine("Fin");
                Console.ReadKey();

                foreach (var item in query)
                {
                    Console.WriteLine(item.Nombre);
                }
            }

        }
    }
}
