using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Domain.Entities;

public class Languages : BaseEntity
{
    [Required]
    [StringLength(100)]
    [DisplayName("Başlık")]
    public string Title { get; set; }

    [Required]
    [StringLength(50)]
    [DisplayName("Ülke Kodu")]
    public string CountryCode { get; set; }

    [Required]
    [StringLength(30)]
    [DisplayName("Kültür Kodu")]
    public string Culture { get; set; }

    [Required]
    [StringLength(50)]
    [DisplayName("Bayrak")]
    public string Flag { get; set; }

    [Required]
    [DisplayName("Sıralama")]
    public int Sort { get; set; }

    [DisplayName("Ana Dil")]
    public int? IsRoot { get; set; }

    [DisplayName("Para Birimi")]
    public string? Currency { get; set; }

}
