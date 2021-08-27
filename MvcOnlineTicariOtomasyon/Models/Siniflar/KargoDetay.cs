using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz")]
        public string Aciklama { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter giriniz")]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "En fazla 25 karakter giriniz")]
        public string Personel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "En fazla 25 karakter giriniz")]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}