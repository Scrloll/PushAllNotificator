namespace PushAll.Notifications
{
    /// <summary>
    ///     Отправка всем подписчикам канала.
    ///     Этот тип требует канал и отправляет уведомление всем подписчикам с учетом их фильтров.
    /// </summary>
    public class BroadcastNotification : Notification
    {
        /// <summary>
        ///     Инициализирует новое уведомление, предназначенное для отправки всем подписчикам канала.
        /// </summary>
        /// <param name="channelID">ID канала.</param>
        /// <param name="channelKey">API-ключ канала.</param>
        /// <param name="tittle">Заголовок уведомления.</param>
        /// <param name="text">Текст уведомления.</param>
        public BroadcastNotification(string channelID, string channelKey, string tittle, string text)
        {
            type = NotificationType.Broadcast;
            ID = channelID;
            Key = channelKey;
            Tittle = tittle;
            Text = text;
        }
    }
}
