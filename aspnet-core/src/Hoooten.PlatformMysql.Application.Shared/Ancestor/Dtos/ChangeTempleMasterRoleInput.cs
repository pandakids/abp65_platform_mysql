using System;
using System.Collections.Generic;
using System.Text;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class ChangeTempleMasterRoleInput
    {
        public long? ToUserId { get; set; }

        public int TempleId { get; set; }
    }
}
