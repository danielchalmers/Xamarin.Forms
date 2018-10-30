using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Xamarin.Forms.Internals;
using AView = Android.Views.View;
using static System.String;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.FastRenderers;
using MButton = Android.Support.Design.Button.MaterialButton;
using Xamarin.Forms.Platform.Android.Material;
using Android.Content.Res;
using Android.Support.V4.Widget;

[assembly: ExportRenderer(typeof(Button), typeof(MaterialButtonRenderer), new[] { typeof(Visual.MaterialVisual) })]
namespace Xamarin.Forms.Platform.Android.Material
{
	internal sealed class MaterialButtonRenderer : ViewRenderer<Button, MButton>
	{
		public MaterialButtonRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			SetNativeControl(new MButton(Context));
			Control.Text = Element.Text;

			ColorStateList colorStateList = new ColorStateList(
						new int[][]{
								new int[]{-global::Android.Resource.Attribute.StateEnabled}
                               // new int[]{android.R.attr.state_checked} , // checked
                        },
						new int[]{
								Element.BackgroundColor.ToAndroid(),
								//Color.parseColor("##cccccc"),
						}
				);

			

			var stateList = global::Android.Support.V4.View.ViewCompat.GetBackgroundTintList(Control);
			global::Android.Support.V4.View.ViewCompat.SetBackgroundTintList(Control, colorStateList);

			Control.SetBackgroundColor(Color.Transparent.ToAndroid());
			//AppCompatButton.set
			// CompoundButtonCompat.SetButtonTintList(Control, colorStateList);

			//Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());

		}
	}
}
