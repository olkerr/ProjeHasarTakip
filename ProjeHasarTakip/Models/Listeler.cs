using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjeHasarTakip.Models
{
    public class Listeler
    {
        public Listeler()
        {
            this.Listekart = new HashSet<Listeicerikler>();
        }
        [Key]
        public int ListeId { get; set; }
        [DisplayName("Liste Adı")]
        [StringLength(60, ErrorMessage = "Maximim Uzunlluk 60 Karakterden Fazla Olamaz.")]
        public string ListeAd { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual ICollection<Listeicerikler> Listekart { get; set; }
    }
}
