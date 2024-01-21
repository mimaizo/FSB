using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace fsb.Models
{
    public class Docs
    {

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string FIO { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }


        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string place { get; set; }

    }
}
