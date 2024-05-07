using ProjeHasarTakip.Models.IsEmri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeHasarTakip.Models.Personel
{
    public class Personeller
    {
        public Personeller()
        {
            this.IsEmirleris=new HashSet<IsEmirleri>();
        }
        [Key]
        public int PersonelId { get; set; }
        [DisplayName("Ad Soyad")]
        [StringLength(60,ErrorMessage ="Maximim Uzunlluk 60 Karakterden Fazla Olamaz.")]
        public string AdSoyad { get; set; }
        [DisplayName("Sicil")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string Sicil { get; set; }
        [DisplayName("Yaka")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string Yaka { get; set; }
        [DisplayName("Telefon")]
        [StringLength(11, ErrorMessage = "Maximim Uzunlluk 11 Karakterden Fazla Olamaz.")]
        public string Telefon { get; set; }
        [DisplayName("E mail")]
        [StringLength(50, ErrorMessage = "Maximim Uzunlluk 50 Karakterden Fazla Olamaz.")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [StringLength(20, ErrorMessage = "Maximim Uzunlluk 20 Karakterden Fazla Olamaz.")]
        public string Sifre { get; set; }
        [DisplayName("Yetki")]
        [StringLength(10, ErrorMessage = "Maximim Uzunlluk 10 Karakterden Fazla Olamaz.")]
        public string Yetki { get; set; }
        [DisplayName("Görev")]
        [StringLength(15, ErrorMessage = "Maximim Uzunlluk 15 Karakterden Fazla Olamaz.")]
        public string Gorev { get; set; }
        [DisplayName("Personel Resim")]
        public string PersonelResim { get; set; }
        public virtual ICollection<IsEmirleri> IsEmirleris { get; set; }
        


    }
}