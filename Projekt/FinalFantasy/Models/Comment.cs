using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //Gör att jag får en textarea av EditorFor istället för ett vanligt input fält
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}