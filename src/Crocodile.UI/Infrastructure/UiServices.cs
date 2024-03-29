﻿namespace Crocodile.UI.Infrastructure
{
	using System;
	using System.Windows;
	using System.Windows.Input;
	using System.Windows.Threading;

	/// <summary>
	///   Contains helper methods for UI, so far just one for showing a waitcursor
	/// </summary>
	public static class UiServices
	{

		/// <summary>
		///   A value indicating whether the UI is currently busy
		/// </summary>
		private static bool _isBusy;

		private static DispatcherTimer _dispatcherTimer;

		/// <summary>
		/// Sets the busystate as busy.
		/// </summary>
		public static void SetBusyState()
		{
			SetBusyState(true);
		}

		/// <summary>
		/// Sets the busystate to busy or not busy.
		/// </summary>
		/// <param name="busy">if set to <c>true</c> the application is now busy.</param>
		private static void SetBusyState(bool busy)
		{
			if (busy == _isBusy) return;

			_isBusy = busy;
			Mouse.OverrideCursor = busy ? Cursors.Wait : null;

			if (!_isBusy) return;

			_dispatcherTimer = new DispatcherTimer(
				TimeSpan.FromSeconds(0), 
				DispatcherPriority.ApplicationIdle, 
				DispatcherTimerTick, 
				Application.Current.Dispatcher);

			_dispatcherTimer.Start();
		}

		/// <summary>
		/// Handles the Tick event of the dispatcherTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private static void DispatcherTimerTick(object sender, EventArgs e)
		{
			var dispatcherTimer = sender as DispatcherTimer;
			if (dispatcherTimer == null) return;
			SetBusyState(false);
			dispatcherTimer.Stop();
		}
	}
}