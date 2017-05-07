using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Wearable.Views;
using Android.Views;
using Android.Widget;

namespace WearDemo
{
    public class SampleGridPagerAdapter: FragmentGridPagerAdapter
    {
        private Context _context;
        private List<SimpleRow> _pages;
        public SampleGridPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SampleGridPagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public SampleGridPagerAdapter(Context context,FragmentManager fm) : base(fm)
        {
            _context = context;
            InitPages();
        }

        private void InitPages()
        {
            _pages = new List<SimpleRow>();

            var row1 = new SimpleRow();
            row1.AddPages(new SimplePage{Title = "Title1", Text = "Text1", Color = Color.Blue});
            row1.AddPages(new SimplePage{Title = "Title2", Text = "Text2", Color = Color.Yellow });

            var row2 = new SimpleRow();
            row2.AddPages(new SimplePage { Title = "Title3", Text = "Text3", Color = Color.Green });
            row2.AddPages(new SimplePage { Title = "Title4", Text = "Text4", Color = Color.Red });

            var row3 = new SimpleRow();
            row3.AddPages(new SimplePage { Title = "Title5", Text = "Text5", Color = Color.Azure });
            row3.AddPages(new SimplePage { Title = "Title6", Text = "Text6", Color = Color.Orange });

            var row4 = new SimpleRow();
            row4.AddPages(new SimplePage { Title = "Title7", Text = "Text7", Color = Color.Fuchsia });
            row4.AddPages(new SimplePage { Title = "Title8", Text = "Text8", Color = Color.Violet });

            _pages.Add(row1);
            _pages.Add(row2);
            _pages.Add(row3);
            _pages.Add(row4);
        }

        public override int GetColumnCount(int p0)
        {
            return _pages[p0].Size();
        }

        public override int RowCount => _pages.Count;

        public override Fragment GetFragment(int p0, int p1)
        {
            var page = _pages[p0].GetPages(p1);
            var fragment = CardFragment.Create(page.Title,page.Text);
            return fragment;
        }

        public override Drawable GetBackgroundForPage(int row, int column)
        {
            var page = _pages[row].GetPages(column);
            return new ColorDrawable(page.Color);
        }
    }
}