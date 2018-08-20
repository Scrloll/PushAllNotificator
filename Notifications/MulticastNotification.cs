namespace PushAll.Notifications
{
    /// <summary>
    ///     Отправка определенным подписчикам канала.
    ///     Этот тип требует канал и отправляет уведомление всем перечисленным подписчикам с учетом их фильтров.
    /// </summary>
    class MulticastNotification : Notification
    {
        /// <summary>
        ///     Массив идентификаторов пользователей, которые получат уведомления.
        /// </summary>
        public string[] UsersIDs;

        /// <summary>
        ///     Инициализирует новое уведомление, предназначенное для отправки перечисленным подписчикам канала.
        /// </summary>
        /// <param name="channelID">ID канала.</param>
        /// <param name="channelKey">API-ключ канала.</param>
        /// <param name="tittle">Заголовок уведомления.</param>
        /// <param name="text">Текст уведомления.</param>
        /// <param name="usersIDs">Массив идентификаторов пользователей, которые получат уведомления.</param>
        public MulticastNotification(string channelID, string channelKey, string tittle, string text, string[] usersIDs)
        {
            type = NotificationType.Multicast;
            ID = channelID;
            Key = channelKey;
            Tittle = tittle;
            Text = text;
            UsersIDs = usersIDs;
        }
    }
}
