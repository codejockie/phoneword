namespace Phoneword
{
    public static class Constants
    {
        public const int DELAY_BETWEEN_LOG_MESSAGES = 5000; // milliseconds
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        public const string SERVICE_STARTED_KEY = "has_service_been_started";
        public const string BROADCAST_MESSAGE_KEY = "broadcast_message";
        public const string NOTIFICATION_BROADCAST_ACTION = "ForegroundService.Notification.Action";

        public const string ACTION_START_SERVICE = "ForegroundService.action.START_SERVICE";
        public const string ACTION_STOP_SERVICE = "ForegroundService.action.STOP_SERVICE";
        public const string ACTION_RESTART_TIMER = "ForegroundService.action.RESTART_TIMER";
        public const string ACTION_MAIN_ACTIVITY = "ForegroundService.action.MAIN_ACTIVITY";
        public const string CHANNEL_ID = "ForegroundService.channel";
    }
}