﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace Phoneword
{
    [Activity(Label = "@string/translationHistory")]
    [Obsolete]
    public class TranslationHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);
        }
    }
}