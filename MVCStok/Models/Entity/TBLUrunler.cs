//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUrunler()
        {
            this.TBLSatislar = new HashSet<TBLSatislar>();
        }
    
        public int id { get; set; }
        public string ad { get; set; }
        public string marka { get; set; }
        public Nullable<short> stok { get; set; }
        public Nullable<decimal> alisfiyat { get; set; }
        public Nullable<decimal> satisfiyat { get; set; }
        public Nullable<int> kategori { get; set; }
    
        public virtual TBLKategori TBLKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSatislar> TBLSatislar { get; set; }
    }
}