using BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntegratie.Models
{
   public class DeelplatformModel
   {
      public List<Deelplatform> MijnDeelplatformen { get; set; }
      public List<Deelplatform> AndereDeelplatformen { get; set; }
   }
}