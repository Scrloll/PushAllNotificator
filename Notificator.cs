using PushAll.Notifications;
using PushAll.Types;
using System;
using System.Collections.Specialized;
using System.Net;

namespace PushAll
{
    /// <summary>
    ///     Класс для отправки уведомлений пользователю.
    /// </summary>
    public class Notificator
    {
        readonly WebClient Client;
        readonly Uri ServiceUri;

        public Notificator()
        {
            Client = new WebClient();
            ServiceUri = new Uri("https://pushall.ru/api.php");
        }

        /// <summary>
        ///     Отправить уведомление.
        /// </summary>
        /// <param name="notification">Отправляемое уведомление.</param>
        public void Send(Notification notification)
        {
            NameValueCollection parameters = new NameValueCollection
            {
                { "type", notification.type.ToString().ToLower() },
                { "id", notification.ID },
                { "key", notification.Key },
                { "title", notification.Tittle },
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

            if (notification is UnicastNotification)
            {
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOn) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());
                parameters.Add("uid", ((UnicastNotification)notification).UserID);
            }
            if (notification is MulticastNotification)
            {
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOff) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());

                string uids = "[";
                foreach (string uid in ((MulticastNotification)notification).UsersIDs)
                    uids += uid + ",";
                uids = uids.Remove(uids.Length - 1) + "]";
                parameters.Add("uids", uids);
            }
            if (notification is BroadcastNotification)
                if (notification.Filter.HasValue && ((notification.Filter == FilterType.ForcedOff) || (notification.Filter == FilterType.NotForced)))
                    parameters.Add("filter", notification.Filter.ToString());

            Client.UploadValuesAsync(ServiceUri, parameters);
        }
    }
}