﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.iOS
{
	public class CarouselViewRenderer
	{
	}

	// TODO hartez 2018/05/31 16:29:30 Implement dispose override	
	// TODO hartez 2018/05/30 08:58:42 This follows the same basic scheme as RecyclerView.Adapter; you should be able to reuse the same wrapper class for the IEnumerable	
	//// TODO hartez 2018/05/30 09:05:38 Think about whether this Controller and/or the new Adapter should be internal or public
	public class CollectionViewRenderer : ViewRenderer<CollectionView, UIView>
	{
		CollectionViewController _collectionViewController;
		ItemsViewLayout _layout;

		public override UIViewController ViewController => _collectionViewController;

		public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			return Control.GetSizeRequest(widthConstraint, heightConstraint, 0, 0);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<CollectionView> e)
		{
			if (e.NewElement != null)
			{
				_layout = SelectLayout(e.NewElement.ItemsLayout);
				_collectionViewController = new CollectionViewController(e.NewElement.ItemsSource, _layout, e.NewElement);
				SetNativeControl(_collectionViewController.View);
				_collectionViewController.CollectionView.BackgroundColor = UIColor.Clear;
			}

			base.OnElementChanged(e);
		}

		protected virtual ItemsViewLayout SelectLayout(IItemsLayout layoutSpecification)
		{
			if (layoutSpecification is ListItemsLayout listItemsLayout)
			{
				return listItemsLayout.Orientation == ItemsLayoutOrientation.Horizontal
					? new ListViewLayout(UICollectionViewScrollDirection.Horizontal)
					: new ListViewLayout(UICollectionViewScrollDirection.Vertical);
			}

			// TODO hartez 2018/06/01 11:07:36 Handle Grid	

			// Fall back to vertical list
			return new ListViewLayout(UICollectionViewScrollDirection.Vertical);
		}
	}
}