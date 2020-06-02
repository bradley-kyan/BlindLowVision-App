using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Gigamole.Infinitecycleviewpager;
using System.Collections.Generic;

namespace Blind_LowVision_App_1
{
    [Activity(Label = "android", MainLauncher = false, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class Carousel : AppCompatActivity
    {
        List<int> listImage = new List<int>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutCarousel);
            InitData();
            HorizontalInfiniteCycleViewPager viewPager = FindViewById<HorizontalInfiniteCycleViewPager>(Resource.Id.horizontal_viewpager);
            MyAdapter adapter = new MyAdapter(listImage, BaseContext);
            viewPager.Adapter = adapter;
        }

        private void InitData()
        {
            listImage.Add(Resource.Drawable.puppygold);
            listImage.Add(Resource.Drawable.puppygold);

        }
    }
}