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
    
    public partial class COM_WORKATTENDANCE
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> EarlyOutAMMinutes { get; set; }
        public Nullable<int> EarlyOutPMMinutes { get; set; }
        public Nullable<int> FK_UserId { get; set; }
        public Nullable<bool> Is_SiginAM { get; set; }
        public Nullable<bool> Is_SiginPM { get; set; }
        public Nullable<bool> Is_SigOutAM { get; set; }
        public Nullable<bool> Is_SigOutPM { get; set; }
        public Nullable<bool> IsEarlyOutAM { get; set; }
        public Nullable<bool> IsEarlyOutPM { get; set; }
        public Nullable<bool> IsLatePM { get; set; }
        public Nullable<bool> IsLateAM { get; set; }
        public Nullable<int> LateAMMinutes { get; set; }
        public Nullable<int> LatePMMinutes { get; set; }
        public Nullable<System.DateTime> SiginAMDate { get; set; }
        public Nullable<System.DateTime> SiginPM { get; set; }
        public string SigIP { get; set; }
        public Nullable<System.DateTime> SigOutAMDate { get; set; }
        public Nullable<System.DateTime> SigOutPM { get; set; }
        public Nullable<decimal> WorkHours { get; set; }
    }
}
