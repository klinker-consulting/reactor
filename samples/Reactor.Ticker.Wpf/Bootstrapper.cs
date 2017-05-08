using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Reactor.Ticker.Wpf.General.DependencyInjection;
using Reactor.Ticker.Wpf.Shell.ViewModels;
using Reactor.Ticker.Wpf.Shell.Views;
using StructureMap;

namespace Reactor.Ticker.Wpf
{
    public class Bootstrapper : BootstrapperBase
    {
        private IContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new Container(new ReactorTickerRegistry());
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service).Cast<object>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) 
                ? _container.GetInstance(service) 
                : _container.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
