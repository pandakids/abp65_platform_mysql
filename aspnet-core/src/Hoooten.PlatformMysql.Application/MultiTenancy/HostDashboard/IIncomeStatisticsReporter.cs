﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hoooten.PlatformMysql.MultiTenancy.HostDashboard.Dto;

namespace Hoooten.PlatformMysql.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}