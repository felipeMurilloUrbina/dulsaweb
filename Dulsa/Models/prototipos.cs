//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dulsa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class prototipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prototipos()
        {
            this.ListaVenta = new HashSet<ListaVenta>();
        }
    
        public int Id { get; set; }
        public string Prototipo { get; set; }
        public Nullable<decimal> M2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListaVenta> ListaVenta { get; set; }
    }
}