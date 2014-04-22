using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalFantasy.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int SiteID { get; set; }
        public string Comment { get; set; }
    }
}