//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tb_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Category()
        {
            this.Tb_Product = new HashSet<Tb_Product>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string NameVN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Product> Tb_Product { get; set; }
    }
}
