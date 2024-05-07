using ProjeHasarTakip.Models.Arac;
using ProjeHasarTakip.Models.IsEmri;
using ProjeHasarTakip.Models.Personel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjeHasarTakip.Models.DataContext
{
    public class ProjeHasarDbContext:DbContext
    {
        public ProjeHasarDbContext() : base("PROJEHASARDB")
        {

        }
        public DbSet<Araclar> Araclars { get; set; }
        public DbSet<HasarKayitlar> HasarKayitlars { get; set; }
        public DbSet<IsEmirleri> IsEmirleris { get; set; }
        public DbSet<Personeller> Personellers { get; set; }
        public DbSet<Listeler> Listelers { get; set; }
        public DbSet<Listeicerikler> Listeiceriklers { get; set; }
    }
}