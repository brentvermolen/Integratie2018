using BL.Domain.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.GrafiekKlassen
{
   public class As
   {
      public static int Count = 0;

      public As()
      {
         Categorieen = new List<Categorie>();
         IsUsed = false;
         ID = Count++;
      }

      [Key]
      public int ID { get; set; }
      public string Titel { get; set; }
      public bool IsUsed { get; set; }
      public List<Categorie> Categorieen { get; set; }

      public string GetCategorieen()
      {
         string ret = "[";

         for(int i = 0; i < Categorieen.Count; i++)
         {
            Categorie categorie = Categorieen[i];
            ret += "'" + categorie.ToString() + "'";

            if (i != Categorieen.Count - 1)
            {
               ret += ", ";
            }
         }

         return ret + "]";
      }
   }
}
