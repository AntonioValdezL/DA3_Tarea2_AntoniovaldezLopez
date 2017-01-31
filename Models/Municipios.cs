using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticasJavascriptyAjax.Models
{
    public class Municipios
    {
        [Key]
        public int municipioID { get; set; }
        public string nombreMunicipio { get; set; }

  
        public virtual Estados estado { get; set; }
        public int estadoID { get; set; }
    }
}