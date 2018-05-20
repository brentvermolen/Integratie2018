using BL.Domain;

namespace MVCIntegratie.Models
{
   public class NieuweGrafiekModel
   {
      public NieuweGrafiekModel()
      {
         IsGewijzigd = false;
         GewijzigdType = "";
      }

      public Grafiek Line { get; set; }
      public Grafiek Bar { get; set; }
      public Grafiek Pie { get; set; }
      public bool IsGewijzigd { get; set; }
      public string GewijzigdType { get; set; }
   }
}
