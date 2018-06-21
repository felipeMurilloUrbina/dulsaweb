using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulsaWeb.Modelo
{
    public class Contexto: DbContext
    {
        public Contexto() : base("DefaultConnection")
        {
        }
        public virtual DbSet<Asesor> Asesores { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<ListaVenta> ListaVenta { get; set; }
        public virtual DbSet<Lote> Lotes { get; set; }
        public virtual DbSet<Prototipo> Prototipos { get; set; }
    }
}
