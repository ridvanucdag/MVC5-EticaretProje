using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1, ErrorMessage = "En fazla 1 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "En fazla 10 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60, ErrorMessage = "En fazla 60 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5, ErrorMessage = "En fazla 5 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçmeyin")]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}