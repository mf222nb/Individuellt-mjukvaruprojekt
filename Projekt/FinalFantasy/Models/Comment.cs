using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalFantasy.Models
{
    [Table("Comment")]
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        public int SiteID { get; set; }
        [Required(ErrorMessage = "Måste ange en bokstav")]
        [StringLength(5000)]
        public string Comment { get; set; }
    }
}