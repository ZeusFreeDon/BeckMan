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
    
    public partial class bsc_user
    {
        public int userID { get; set; }
        public string userCode { get; set; }
        public string userName { get; set; }
        public Nullable<int> roleID { get; set; }
        public Nullable<int> regionID { get; set; }
        public string password { get; set; }
        public string tel { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string assistantEMail { get; set; }
        public Nullable<decimal> auditDiscount { get; set; }
        public Nullable<bool> isSaleMan { get; set; }
        public Nullable<int> saleManID { get; set; }
        public Nullable<bool> isDistributor { get; set; }
        public Nullable<int> distributorID { get; set; }
        public Nullable<bool> isSystem { get; set; }
        public Nullable<bool> isAllowed { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> saleTypeID { get; set; }
    }
}
