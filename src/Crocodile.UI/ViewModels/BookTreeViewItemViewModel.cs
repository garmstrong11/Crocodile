﻿namespace Crocodile.UI.ViewModels
{
	using System.Collections;
	using System.Collections.Generic;
	using Caliburn.Micro;
	using Domain;
	using Infrastructure;

	public class BookTreeViewItemViewModel : TreeViewItemViewModel
	{
		private readonly IEventAggregator _events;

		public BookTreeViewItemViewModel(TreeViewItemViewModel parent)
			: base(parent)
		{
			_events = IoC.Get<IEventAggregator>();
		}
		
		public string Name { get; set; }
		public int ItemId { get; set; }
		public BookType BookType { get; set; }
		public string PageSourcePath { get; set; }
		public IList<ArtFile> ArtFiles { get; set; }

		public override bool IsSelected
		{
			get { return base.IsSelected; }
			set
			{
				base.IsSelected = value;
				var bse = new BookSelectedEvent
					{
					ItemId = ItemId, 
					ProjectPath = PageSourcePath, 
					IsSelected = value,
					ArtFiles = ArtFiles
					};
				_events.Publish(bse);
			}
		}
	}
}