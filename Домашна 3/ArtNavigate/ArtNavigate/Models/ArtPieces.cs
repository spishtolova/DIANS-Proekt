using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtNavigate.Models
{
    public class ArtPieces
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string nameEnglish { get; set; }
        public string imageURL { get; set; }
        public string artistName { get; set; }
        
        public ArtGalery artGalery { get; set; }
    }
}