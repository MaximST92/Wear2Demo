using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WearDemo
{
    public class SimpleRow
    {
        List<SimplePage> _pages = new List<SimplePage>();

        public void AddPages(SimplePage page)
        {
            _pages.Add(page);
        }

        public SimplePage GetPages(int index)
        {
            return _pages[index];
        }

        public int Size()
        {
            return _pages.Count;
        }
    }
}