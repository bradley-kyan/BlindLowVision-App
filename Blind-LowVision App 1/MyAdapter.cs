using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

//https://www.youtube.com/watch?v=xlHQv2150wU&ab_channel=EDMTDev
//https://github.com/mohibsheth/CarouselView
namespace Blind_LowVision_App_1
{
    public class MyAdapter : PagerAdapter
    {
        List<int> listImages;
        Context context;
        LayoutInflater layoutInflater;

        public MyAdapter(List<int> listImages, Context context)
        {
            this.listImages = listImages;
            this.context = context;
            layoutInflater = LayoutInflater.From(context);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = layoutInflater.Inflate(Resource.Layout.Card_Layout, container, false);
            ImageView imgView = view.FindViewById<ImageView>(Resource.Id.imageView2);

            container.AddView(view);
            return view;
        }

        public override int Count => listImages.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view.Equals(@object);
        }
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((View)@object);
        }
    }
}