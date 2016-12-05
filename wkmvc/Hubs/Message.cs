using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wkmvc.Hubs
{
    public class Message
    {

        public string ConnectId { get; set; }
        public string MessageContent { get; set; }

        public string MessageDate { get; set; }

        public string MessageType { get; set; }

        public string UserFace { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}