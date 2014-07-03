namespace Crocodile.UI.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using Caliburn.Micro;
	using SimpleInjector;
	using ViewModels;

	public class SiBootstrapper : Bootstrapper<IShell>
	{
		private Container _container;

		public SiBootstrapper()
		{
			LogManager.GetLog = type => new DebugLogger(type);
		}

		protected override void Configure()
		{
			_container = new Container();

			_container.Register<IWindowManager, WindowManager>();
			_container.RegisterSingle<IEventAggregator, EventAggregator>();
			_container.Register<IShell, ShellViewModel>();
			_container.Register(typeof(BookConductorViewModel));
			_container.Register(typeof(LibraryViewModel));
		}

		protected override object GetInstance(Type service, string key)
		{
			return _container.GetInstance(service);
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return _container.GetAllInstances(service);
		}

		protected override void BuildUp(object instance)
		{
			_container.InjectProperties(instance);
		}

	}
}