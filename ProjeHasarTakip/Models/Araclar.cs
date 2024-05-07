using ProjeHasarTakip.Models.IsEmri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeHasarTakip.Models.Arac
{
    public class Araclar
    {
        public Araclar()
        {
            this.Listekart = new HashSet<Listeicerikler>();
        }
        [Key]
        public int AracId { get; set; }
        [DisplayName("Araç Kodu")]
        [StringLength(6, ErrorMessage = "Maximim Uzunlluk 6 Karakterden Fazla Olamaz.")]
        public string Arackod { get; set; }

        [DisplayName("Araç Plaka")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string AracPlaka { get; set; }

        [DisplayName("Araç Model")]
        [StringLength(4, ErrorMessage = "Maximim Uzunlluk 4 Karakterden Fazla Olamaz.")]
        public string AracModel { get; set; }

        [DisplayName("Araç Marka")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string AracMarka { get; set; }

        [DisplayName("Araç Tipi")]
        [StringLength(8, ErrorMessage = "Maximim Uzunlluk 8 Karakterden Fazla Olamaz.")]
        public string AracTip { get; set; }

        [DisplayName("Araç Durum")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string AracDurum { get; set; }

        [DisplayName("Araç Konum")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string AracKonum { get; set; }

        [DisplayName("Muayene Bitiş")]
        
        public DateTime? AracMuayene { get; set; }
        [DisplayName("Araç Resim")]
        public string AracResim { get; set; }
        public virtual ICollection<IsEmirleri> IsEmirleris { get; set; }
        public virtual ICollection<HasarKayitlar> HasarKayitlars { get; set; }
        public virtual ICollection<Listeicerikler> Listekart { get; set; }
    }
}