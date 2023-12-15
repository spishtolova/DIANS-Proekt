using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtNavigate.Models
{
    public class ArtGalery
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
        public string NameEnglish { get; set; }
        

        public string AdressEnglish { get; set; }
        public string CityEnglish { get; set; }



    }
}