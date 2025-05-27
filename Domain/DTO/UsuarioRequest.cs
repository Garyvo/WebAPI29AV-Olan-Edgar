using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Domain.DTO
    {
    //Modelo resquest de tipo usuario para enviar datos nuevos  
        public class UsuarioRequest
        {
            public string Nombre { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int? FkRol { get; set; }
        }
    }

