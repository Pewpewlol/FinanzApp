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

namespace TaschenGeld
{
    public static class Tester
    {
        public static string Eintrag(string raw)
        {
            if (string.IsNullOrEmpty(raw))
                return "";
            else
                return raw;
        }
    }
}