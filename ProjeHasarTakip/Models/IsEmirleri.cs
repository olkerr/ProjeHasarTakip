using ProjeHasarTakip.Models.Arac;
using ProjeHasarTakip.Models.Personel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjeHasarTakip.Models.IsEmri
{
    public class IsEmirleri
    {
        public IsEmirleri() 
        {
            this.Personellers=new HashSet<Personeller>();   
        } 
        [Key]
        public int IsEmriId { get; set; }
        [DisplayName("Araç Kod")]
        public int AracId { get; set; }
        [DisplayName("Başlık")]
        [StringLength(60, ErrorMessage = "Maximim Uzunlluk 60 Karakterden Fazla Olamaz.")]
        public string Baslik { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(300, ErrorMessage = "Maximim Uzunlluk 300 Karakterden Fazla Olamaz.")]
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string OncelikDurumu { get; set; }
        public int TamamlanmaOranı { get; set; }
        public string TamamlanmaDurumu { get; set; }
        public DateTime? TamamlanmaTarihi { get; set; }

        public virtual ICollection<Personeller> Personellers { get; set; }
        public virtual Araclar Araclars { get; set; }



    }
}