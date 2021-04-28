using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConsommiTounsiDotNet.Models
{
    public class Ray
    {
        public long idRay { get; set; }
        
        [Required(ErrorMessage = "Name of ray Required")]
        [StringLength(10, ErrorMessage = "Must be less than 10 characters")]
        public String nom_rayon { get; set; }
       
        public int capacity { get; set; }

       




    }
}