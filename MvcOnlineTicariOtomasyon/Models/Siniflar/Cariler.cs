using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter giriniz")]
        [Required(ErrorMessage ="Bu alanı boş geçmeyin")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "En fazla 25 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}