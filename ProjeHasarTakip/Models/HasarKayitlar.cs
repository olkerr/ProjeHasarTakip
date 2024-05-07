using ProjeHasarTakip.Models.Arac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeHasarTakip.Models
{
    public class HasarKayitlar
    {
        [Key]
        public int HasarKayitlarId { get; set; }
        public int AracId { get; set; }
        [DisplayName("Başlık")]
        [StringLength(60, ErrorMessage = "Maximim Uzunlluk 60 Karakterden Fazla Olamaz.")]
        public string Baslik { get; set; }
        
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string HasarDurumu { get; set; }
        public string HasarResim { get; set; }
        public virtual Araclar Araclars { get; set; }

    }
}