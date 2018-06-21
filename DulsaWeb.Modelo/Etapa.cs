using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulsaWeb.Modelo
{
    [Table("Etapas")]
    public class Etapa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
