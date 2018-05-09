﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain
{
   public class FAQ
   {
      public int ID { get; set; }
      public string Vraag { get; set; }
      public string Antwoord { get; set; }
      public FAQCategorie Categorie { get; set; }
      public string Voorbeeld { get; set; }
      public bool Beantwoord { get; set; }
   }

   public enum FAQCategorie
   {
      Website = 0,
      Account,
      Notificaties,
      Overig
   }
}