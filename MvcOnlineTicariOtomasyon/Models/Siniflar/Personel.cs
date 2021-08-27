using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelAd { get; set; }

        [Display(Name ="Personel Soyad")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelSoyad { get; set; }

        [Display(Name ="Personel Hakkında")]
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelHakkinda { get; set; }

        [Display(Name = "Personel Adres")]
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelAdres { get; set; }

        [Display(Name = "Personel Telefon")]
        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelTelefon { get; set; }

        [Display(Name = "Personel Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string PersonelGorsel { get; set; }
        public int departmanid { get; set; }
        public virtual Departman Departman { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}