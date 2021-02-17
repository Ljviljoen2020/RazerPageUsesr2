using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazerPageUsers2.Models
{
    public class User
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(60,MinimumLength = 3)]
        public string Surname { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Fullname { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [RegularExpression(@"[0-9]*$")]
        [StringLength(13,MinimumLength =13)]
        public string IdentificationNuber { get; set; }

    }

}