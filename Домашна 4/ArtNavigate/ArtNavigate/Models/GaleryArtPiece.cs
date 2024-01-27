using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtNavigate.Models
{
    public class GaleryArtPiece
    {
        public int artPieceId { get; set; }
        public int artGaleriyId { get; set; }
        public ArtPieces artPieces { get; set; }
        public List<ArtGalery> artGalery { get; set; }
        public GaleryArtPiece()
        {
            artGalery = new List<ArtGalery>();
        }
    }
}