using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using CarouselView;
using Android.Widget;
using System;
using Android.Support.V7.App;
using Android.OS;

//https://www.youtube.com/watch?v=xlHQv2150wU&ab_channel=EDMTDev
//https://github.com/mohibsheth/CarouselView
namespace Blind_LowVision_App_1
{
	public class MyAdapter : AppCompatActivity
	{
		public static int[] SampleImages = { Resource.Drawable.puppygold, Resource.Drawable.puppygold, Resource.Drawable.puppygold };

		CarouselView.CarouselView _carouselView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.layoutCarousel);
			this._carouselView = (CarouselView.CarouselView)FindViewById(Resource.Id.carouselView);
			this._carouselView.SetImageListener(new SampleImageListener());
			this._carouselView.SetPageCount(SampleImages.Length);
		}

		private void SetContentView(object layoutCarousel)
		{
			throw new NotImplementedException();
		}
	}

	public class SampleImageListener : Java.Lang.Object, IImageListener
	{
		public void SetImageForPosition(int position, ImageView imageView)
		{
			imageView.SetImageResource(MyAdapter.SampleImages[position]);
		}
	}
}