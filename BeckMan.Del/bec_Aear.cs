//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeckMan.Del
{
    using System;
    using System.Collections.Generic;
    
    public partial class bec_Aear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bec_Aear()
        {
            this.bec_AssInformation = new HashSet<bec_AssInformation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remak { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bec_AssInformation> bec_AssInformation { get; set; }
    }
}