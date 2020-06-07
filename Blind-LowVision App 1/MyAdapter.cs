using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using CarouselView;
using Android.Widget;
using System;
using Android.Support.V7.App;
using Android.OS;
using Android.App;

//https://www.youtube.com/watch?v=xlHQv2150wU&ab_channel=EDMTDev
//https://github.com/mohibsheth/CarouselView
namespace Blind_LowVision_App_1
{
	[Activity(Label = "Blind+LowVision", Theme = "@style/AppTheme", MainLauncher = false)]

	public class MyAdapter : AppCompatActivity
	{
		public static int[] Images = { Resource.Drawable.puppygold, Resource.Drawable.puppygold, Resource.Drawable.puppygold };

		CarouselView.CarouselView _carouselView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.layoutCarousel);
			this._carouselView = (CarouselView.CarouselView)FindViewById(Resource.Id.carouselView);
			this._carouselView.SetImageListener(new ImageListener());
			this._carouselView.SetPageCount(Images.Length);
		}
	}

	public class ImageListener : Java.Lang.Object, IImageListener
	{
		public void SetImageForPosition(int position, ImageView imageView)
		{
			imageView.SetImageResource(MyAdapter.Images[position]);
		}
	}
}