using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public interface Item
   {
      [Key]
      string Naam { get; set; }
   }
}
