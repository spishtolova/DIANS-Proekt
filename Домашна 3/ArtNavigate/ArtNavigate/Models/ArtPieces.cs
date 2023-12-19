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
        public int name { get; set; }
        public int nameEnglish { get; set; }
        public int imageURL { get; set; }
        public int artistName { get; set; }

        public ArtGalery artGalery { get; set; }
    }
}