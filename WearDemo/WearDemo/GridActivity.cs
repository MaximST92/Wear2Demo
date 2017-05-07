using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Wearable.Views;
using Android.Views;
using Android.Widget;

namespace WearDemo
{
    [Activity(Label = "GridActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class GridActivity : Activity, View.IOnApplyWindowInsetsListener
    {
        private GridViewPager _pager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Grid);

            _pager = FindViewById<GridViewPager>(Resource.Id.pager);
            _pager.SetOnApplyWindowInsetsListener(this);
            _pager.Adapter = new SampleGridPagerAdapter(this,FragmentManager);
        }


        public WindowInsets OnApplyWindowInsets(View v, WindowInsets insets)
        {
            bool round = insets.IsRound;
            int rowMargin = Resources.GetDimensionPixelOffset(Resource.Dimension.page_row_margin);
            int colMargin = Resources.GetDimensionPixelOffset(
                round ? Resource.Dimension.page_column_margin_round : Resource.Dimension.page_column_margin);
            _pager.SetPageMargins(rowMargin, colMargin);
            return insets;
        }
    }
}