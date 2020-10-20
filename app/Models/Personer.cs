using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace app.Models
{
    public partial class Personer
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mellem 3 og 50 tegn")]
        public string Fornavn { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mellem 3 og 50 tegn")]
        public string Efternavn { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mellem 3 og 50 tegn")]
        public string Adresse { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mellem 3 og 50 tegn")]
        public string Adresse2 { get; set; }

        [Required]
        [Display(Name = "Post nr.")]
        [RegularExpression("(^[0-9]{4}$)", ErrorMessage = "Skal være præcis 4 tal")]
        public int? Postnr { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mellem 3 og 50 tegn")]
        public string By { get; set; }

        [Required]
        [Display(Name = "Tlf. nr.")]
        [RegularExpression("(^[0-9]{8}$)", ErrorMessage = "Skal være præcis 8 tal")]
        public int? Telefonnr { get; set; }
    }
}
