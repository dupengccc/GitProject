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
    
    public partial class MAIL_INBOX
    {
        public int ID { get; set; }
        public Nullable<int> FK_MailID { get; set; }
        public Nullable<int> MailType { get; set; }
        public Nullable<int> ReadStatus { get; set; }
        public Nullable<System.DateTime> ReceivingTime { get; set; }
        public string Recipient { get; set; }
    }
}