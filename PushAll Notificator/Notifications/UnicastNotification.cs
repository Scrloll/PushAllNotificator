namespace PushAll.Notifications
{
    /// <summary>
    ///     Отправка одному подписчику канала.
    ///     Этот тип требует канал и отправляет уведомление одному подписчику канала без учета фильтров.
    /// </summary>
    class UnicastNotification : Notification
    {
        /// <summary>
        ///     ID пользователя, который получит уведомление.
        /// </summary>
        public string UserID;

        /// <summary>
        ///     Инициализирует новое уведомление, предназначенное для отправки одному подписчику канала.
        /// </summary>
        /// <param name="channelID">ID канала.</param>
        /// <param name="channelKey">API-ключ канала.</param>
        /// <param name="tittle">Заголовок уведомления.</param>
        /// <param name="text">Текст уведомления.</param>
        /// <param name="userID">ID пользователя, который получит уведомление.</param>
        public UnicastNotification(string channelID, string channelKey, string tittle, string text, string userID)
        {
            type = NotificationType.Self;
            ID = channelID;
            Key = channelKey;
            Tittle = tittle;
            Text = text;
            UserID = userID;
        }
    }
}
