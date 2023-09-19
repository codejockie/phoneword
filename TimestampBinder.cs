using Android.OS;

namespace Phoneword.BoundService
{
    public class TimestampBinder : Binder, IGetTimestamp
    {
        TimestampService service;
        public TimestampBinder(TimestampService service)
        {
            this.service = service;
        }

        public string GetFormattedTimestamp()
        {
            return service?.GetFormattedTimestamp();
        }
    }
}