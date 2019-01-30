﻿using System;
using System.Threading.Tasks;
using Hoooten.PlatformMysql.Views;
using Xamarin.Forms;

namespace Hoooten.PlatformMysql.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task SetMainPage<TView>(object navigationParameter = null, bool clearNavigationHistory = false) 
            where TView : IXamarinView;

        Task SetDetailPageAsync(Type viewType, object navigationParameter = null, bool pushToStack = false);

        Task<Page> GoBackAsync();
    }
}