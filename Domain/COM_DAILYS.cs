//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class COM_DAILYS
    {
        public int ID { get; set; }
        public string DailySubIP { get; set; }
        public string FK_RELATIONID { get; set; }
        public Nullable<int> FK_USERID { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}