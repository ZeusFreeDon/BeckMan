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
    
    public partial class bec_AssInformation
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string DisNo { get; set; }
        public string DisName { get; set; }
        public string MYTotal { get; set; }
        public string MYSales { get; set; }
        public string MYApplication { get; set; }
        public string MYCallCenter { get; set; }
        public string MYOperation { get; set; }
        public string SalesState { get; set; }
        public string AppState { get; set; }
        public string CallCenterState { get; set; }
        public string OperationState { get; set; }
        public string AYTotal { get; set; }
        public string AYSales { get; set; }
        public string AYApplication { get; set; }
        public string AYCallCenter { get; set; }
        public string AYOperation { get; set; }
    
        public virtual bec_Partion bec_Partion { get; set; }
        public virtual bec_Aear bec_Aear { get; set; }
    }
}
