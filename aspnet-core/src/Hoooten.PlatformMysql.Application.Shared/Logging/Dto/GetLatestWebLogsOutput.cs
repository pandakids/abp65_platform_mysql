﻿using System.Collections.Generic;

namespace Hoooten.PlatformMysql.Logging.Dto
{
    public class GetLatestWebLogsOutput
    {
        public List<string> LatestWebLogLines { get; set; }
    }
}
