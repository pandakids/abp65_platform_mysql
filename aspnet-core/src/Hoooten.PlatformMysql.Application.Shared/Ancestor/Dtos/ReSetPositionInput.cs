using System;
using System.Collections.Generic;
using System.Text;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class ReSetPositionInput
    {
        /// <summary>
        /// 经度
        /// </summary>
        public string Lon { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat { get; set; }

        /// <summary>
        /// 先祖Id
        /// </summary>
        public int ForeFather { get; set; }
    }
}
