using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using ProjeHasarTakip.Models.Arac;

namespace ProjeHasarTakip.Models
{
    public partial class Listeicerikler
    {
        [Key]
        public int ListeicerikId { get; set; }
        public int ListeId { get; set; }
        public int AracId { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(50, ErrorMessage = "Maximim Uzunlluk 50 Karakterden Fazla Olamaz.")]
        public string Aciklama { get; set; }

        public virtual Araclar Araclar { get; set; }
        public virtual Listeler Listeler { get; set; }
    }
}