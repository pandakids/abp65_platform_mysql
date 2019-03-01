using System;
using System.Collections.Generic;
using System.Text;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class SendGiftInput
    {
        public int TheGiftType { get; set; }

        public int GiftNumber { get; set; }

        public int ForeFatherId { get; set; }
    }
}
