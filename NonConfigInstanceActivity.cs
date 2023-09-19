using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Phoneword
{
    [Activity(Label = "NonConfigInstanceActivity", Theme = "@style/AppTheme")]
    [Obsolete]
    public class NonConfigInstanceActivity : ListActivity
    {
        DogListWrapper _savedInstance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            if (LastNonConfigurationInstance is DogListWrapper dogsWrapper)
            {
                PopulateDogList(dogsWrapper.Dogs);
                Log.Debug(GetType().FullName, "LastNonConfigurationInstance");
            }
            else
            {
                GetDogBreeds();
                Log.Debug(GetType().FullName, "API Call");
            }
        }

        public override Java.Lang.Object OnRetainNonConfigurationInstance()
        {
            base.OnRetainNonConfigurationInstance();
            return _savedInstance;
        }

        public void GetDogBreeds()
        {
            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://dog.ceo/api/"),
            };

            var result = httpClient.GetAsync("breeds/list/all").Result;
            ParseResults(result);
        }

        void ParseResults(HttpResponseMessage httpRes)
        {
            var s = httpRes.Content.ReadAsStringAsync().Result;
            var j = JsonNode.Parse(s);
            var results = JsonSerializer.Deserialize<Dictionary<string, string[]>>(j["message"].ToJsonString()).Keys.ToArray();
            RunOnUiThread(() => {
                PopulateDogList(results);
            });
        }

        void PopulateDogList(string[] results)
        {
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.item_view, results);
            _savedInstance = new DogListWrapper(results);
        }
    }

    class DogListWrapper : Java.Lang.Object
    {
        public string[] Dogs { get; set; }
        public DogListWrapper(string[] dogs)
        {
            Dogs = dogs;
        }
    }
}