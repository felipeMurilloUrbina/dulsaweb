using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulsaWeb.Modelo
{
    [Table("Pagos")]
    public class Pago
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PrototipoId { get; set; }
        public int EtapaId { get; set; }
        public int LoteId { get; set; }
        public string Concepto { get; set; }
        public string Estatus { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Prototipo Prototipo { get; set; }
        public virtual Etapa Etapa { get; set; }
        public virtual Lote Lote { get; set; }
    }
}
