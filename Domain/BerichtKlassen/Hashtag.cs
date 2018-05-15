using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Domain.BerichtKlassen
{
    public class Hashtag : IComparable
    {
        [Key]
        public int ID { get; set; }
        public string Tekst { get; set; }

        public virtual ICollection<Bericht> Berichten { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            Hashtag hashtag = (Hashtag)obj;

            if (hashtag.Tekst.Equals(Tekst))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Tekst;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) { return 1; }
            Hashtag tag = obj as Hashtag;

            if (tag != null)
            {
                return this.Berichten.Count().CompareTo(tag.Berichten.Count());
            }
            else throw new ArgumentException("Dit is geen hashtag");
        }
    }
}
