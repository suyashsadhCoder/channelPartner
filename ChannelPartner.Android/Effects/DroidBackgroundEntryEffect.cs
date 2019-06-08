using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using ChannelPartner.Droid.Effects;
using ChannelPartner.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Venkys")]
[assembly: ExportEffect(typeof(DroidBackgroundEntryEffect), "BackgroundEffect")]
namespace ChannelPartner.Droid.Effects
{
	public class DroidBackgroundEntryEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				var nativeEditText = (global::Android.Widget.EditText)Control;
            float[] radious = new float[] { 8, 8, 8, 8, 8, 8, 8, 8 };
            RectF inset = new RectF(8, 8, 8, 8);
                var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RoundRectShape(radious, null,radious));
                shape.Paint.Color = Xamarin.Forms.Color.LightGray.ToAndroid();
            shape.Paint.SetStyle(Paint.Style.Fill);

           
                nativeEditText.SetBackground(shape);

           
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{

		}
	}
}
