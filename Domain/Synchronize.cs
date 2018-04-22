using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Synchronize
   {
      [Key]
      public int ID { get; set; }
      public DateTime Latest { get; set; }
   }
}
