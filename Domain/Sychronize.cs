using BL.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class Synchronize
   {
      [Key]
      public int ID { get; set; }
      public DateTime LaatsteSync { get; set; }
   }
}