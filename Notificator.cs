using PushAll.Notifications;
using PushAll.Types;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PushAll
{
    /// <summary>
    ///     Класс для отправки уведомлений пользователю.
    /// </summary>
    public class Notificator
    {
        readonly HttpClient Client;
        readonly Uri ServiceUri;

        /// <summary>
        ///     Инициализирует новый объект для отправки уведомлений.
        /// </summary>
        public Notificator()
        {
            Client = new HttpClient();
            ServiceUri = new Uri("https://pushall.ru/api.php");
        }

        /// <summary>
        ///     Отправить уведомление.
        /// </summary>
        /// <param name="notification">Отправляемое уведомление.</param>
        public async void SendAsync(Notification notification)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "type", notification.type.ToString().ToLower() },
                { "id", notification.ID },
                { "key", notification.Key },
                { "title", notification.Title },
                { "text", notification.Text },
            };
            if (notification.Icon != null)
                parameters.Add("icon", notification.Icon);
            if (notification.Url != null)
                parameters.Add("url", notification.Url);
            if (notification.Hidden.HasValue)
                parameters.Add("hidden", notification.Hidden.ToString());
            if (notification.Encode != null)
                parameters.Add("encode", notification.Encode);
            if (notification.Priority.HasValue)
                parameters.Add("priority", notification.Priority.ToString());
            if (notification.TTL.HasValue)
                parameters.Add("ttl", notification.TTL.ToString());

            if (notification.type == NotificationType.Unicast)
            {
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOn) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());
                parameters.Add("uid", ((UnicastNotification)notification).UserID);
            }
            if (notification.type == NotificationType.Multicast)
            {
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOff) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());

                string uids = "[";
                foreach (string uid in ((MulticastNotification)notification).UsersIDs)
                    uids += uid + ",";
                uids = uids.Remove(uids.Length - 1) + "]";
                parameters.Add("uids", uids);
            }
            if (notification.type == NotificationType.Broadcast)
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOff) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());

            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);
            HttpResponseMessage response = await Client.PostAsync(ServiceUri, content);
        }
    }
}