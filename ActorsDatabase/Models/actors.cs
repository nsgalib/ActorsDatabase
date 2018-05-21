using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ActorsDatabase.Models
{
    [Table("ActorsTable")]
    public class Actors
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Name cannot be left blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country cannot be left blank.")]
        public string Country { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Gender cannot be left blank.")]
        public string Gender { get; set; }

        public int NetWorth { get; set; }

        [Required(ErrorMessage = "Please insert an image URL.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Fill some info about the actor you are adding.")]
        public string Info { get; set; }
    }
}