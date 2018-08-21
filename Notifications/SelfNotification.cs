namespace PushAll.Notifications
{
    /// <summary>
    ///     Отправка самому себе.
    ///     Этот тип не требует создания канала и связан только с вашим аккаунтом. 
    /// </summary>
    public class SelfNotification : Notification
    {
        /// <summary>
        ///     Инициализирует новое уведомление, предназначенное для отправки самому себе.
        /// </summary>
        /// <param name="selfID">ID вашего аккаунта.</param>
        /// <param name="selfKey">API-ключ вашего аккаунта.</param>
        /// <param name="tittle">Заголовок уведомления.</param>
        /// <param name="text">Текст уведомления.</param>
        public SelfNotification(string selfID, string selfKey, string tittle, string text)
        {
            type = NotificationType.Self;
            ID = selfID;
            Key = selfKey;
            Title = tittle;
            Text = text;
        }
    }
}
