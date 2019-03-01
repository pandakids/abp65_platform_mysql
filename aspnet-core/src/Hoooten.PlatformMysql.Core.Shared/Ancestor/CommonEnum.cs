using System;
using System.Collections.Generic;
using System.Text;

namespace Hoooten.PlatformMysql.Ancestor
{
    /// <summary>
    /// 礼品类型
    /// </summary>
    public enum GiftType
    {
        Love = 0,
        Flower = 1,
        Money = 2,
        Gold = 3
    }

    /// <summary>
    /// 礼品来源
    /// </summary>
    public enum GiftSource
    {
        /// <summary>
        /// 签到
        /// </summary>
        SignIn = 0,

        /// <summary>
        /// 创建活动
        /// </summary>
        CreateActivity = 1,

        /// <summary>
        /// 参加活动
        /// </summary>
        JoinInActivity = 2,

        /// <summary>
        /// 新建宗堂
        /// </summary>
        CreateTemple = 3,

        /// <summary>
        /// 注册
        /// </summary>
        Register = 4
    }
}
