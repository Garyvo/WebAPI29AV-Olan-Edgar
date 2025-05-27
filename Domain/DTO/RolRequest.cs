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

    //Para hacer el modelado de los datos a enviar de roles
        public class RolRequest
        {
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }
    }

