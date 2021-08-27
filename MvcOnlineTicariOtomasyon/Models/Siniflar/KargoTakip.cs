using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter giriniz")]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz")]
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}