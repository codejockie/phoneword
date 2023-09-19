using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoneword
{
    public static class Extensions
    {
        public static void StartForegroundServiceCompat<T>(this Context context, Bundle args = null) where T : Service
        {
            var intent = new Intent(context, typeof(T));
            if (args != null)
                intent.PutExtras(args);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                context.StartForegroundService(intent);
            else
                context.StartService(intent);
        }

        public static PendingIntent CreatePendingIntentGetActivity(this Context context, int id, Intent intent, PendingIntentFlags flag)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.S)
            {
                return PendingIntent.GetActivity(context, id, intent, PendingIntentFlags.Immutable);
            }
            else
            {
                return PendingIntent.GetActivity(context, id, intent, flag);
            }
        }
    }
}