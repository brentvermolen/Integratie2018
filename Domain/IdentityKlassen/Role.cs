using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.IdentityKlassen
{
    public class Role : IComparable<Role>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discriminator { get; set; }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != this.GetType())
            {
                return false;
            }

            Role role = (Role)obj;

            if (role.Name.Equals(this.Name))
            {
                return true;
            }
            else return false;
           

        }

        public override string ToString()
        {
            return Name;
        }


        public int CompareTo(Role other)
        {
            throw new NotImplementedException();
        }
    }
}
