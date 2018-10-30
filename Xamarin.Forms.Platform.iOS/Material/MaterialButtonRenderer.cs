using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using SizeF = CoreGraphics.CGSize;
using MButton = MaterialComponents.Button;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(Xamarin.Forms.Platform.iOS.Material.MaterialButtonRenderer), new[] { typeof(Visual.MaterialVisual) })]
namespace Xamarin.Forms.Platform.iOS.Material
{
	public class MaterialButtonRenderer : ViewRenderer<Button, MButton>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			SetNativeControl(new MButton());
			Control.BackgroundColor = Element.BackgroundColor.ToUIColor();
			Control.SetTitle(Element.Text, UIControlState.Normal);
		}
	}
}
