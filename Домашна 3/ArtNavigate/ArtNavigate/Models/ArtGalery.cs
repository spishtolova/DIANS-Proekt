using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtNavigate.Models
{
    public class ArtGalery
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string Name { get; set; }
        [DisplayName("Адреса")]
        public string Adress { get; set; }
        [DisplayName("Град")]
        public string City { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }
        [DisplayName("Name")]
        public string NameEnglish { get; set; }
        [DisplayName("Adress")]
        public string AdressEnglish { get; set; }
        [DisplayName("City")]
        public string CityEnglish { get; set; }



    }
}