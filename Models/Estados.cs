using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticasJavascriptyAjax.Models
{
    public class Estados
    {
        [Key]
        public int estadoID { get; set; }
        public string nombreEstado { get; set; }

     
        virtual public ICollection<Municipios> municipios { get; set; }
    }
}