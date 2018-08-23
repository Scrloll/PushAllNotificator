namespace PushAll.Notifications
{
    /// <summary>
    ///     Отправка одному подписчику канала.
    ///     Этот тип требует канал и отправляет уведомление одному подписчику канала без учета фильтров.
    /// </summary>
    public class UnicastNotification : Notification
    {
        /// <summary>
        ///     ID пользователя, который получит уведомление.
        /// </summary>
        public long UserID;

        /// <summary>
        ///     Инициализирует новое уведомление, предназначенное для отправки одному подписчику канала.
        /// </summary>
        /// <param name="channelID">ID канала.</param>
        /// <param name="channelKey">API-ключ канала.</param>
        /// <param name="tittle">Заголовок уведомления.</param>
        /// <param name="text">Текст уведомления.</param>
        /// <param name="userID">ID пользователя, который получит уведомление.</param>
        public UnicastNotification(long channelID, string channelKey, string tittle, string text, long userID)
        {
            type = NotificationType.Unicast;
            ID = channelID;
            Key = channelKey;
            Title = tittle;
            Text = text;
            UserID = userID;
        }
    }
}
