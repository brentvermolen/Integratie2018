﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class Chart
   {
      [JsonProperty("type")]
      public string Type { get; set; }
      public bool PlotShadow { get; set; }
   }
}
