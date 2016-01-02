using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Entity
    {
        public enum PropertyEnum { Id }; 

        public int id;

        public Entity()
        {

        }

        public Entity(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return id.ToString();
        }

        public override int GetHashCode()
        {
            return id;
        }

        protected bool Equals(Entity other)
        {
            return id == other.id;
        }
    }

}
