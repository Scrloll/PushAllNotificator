using PushAll.Types;
using System;

namespace PushAll.Notifications
{
    /// <summary>
    ///     Класс, представляющий общие для всех типов уведомлений поля.
    /// </summary>
    public abstract class Notification
    {
        /// <summary>
        ///     Тип уведомления.
        /// </summary>
        internal NotificationType type;

        /// <summary>
        ///     В случае с SelfAPI это ID вашего аккаунта, в случае с другими типами - ID вашего канала.
        /// </summary>
        public long ID;

        /// <summary>
        ///     В случае с SelfAPI это ключ вашего аккаунта, в случае с другими типами - ключ вашего канала.
        /// </summary>
        public string Key;

        /// <summary>
        ///     Заголовок Push-уведомления. Рекомендуется 15-80 символов, не более.
        /// </summary>
        public string Title;

        /// <summary>
        ///     Основной текст Push-уведомления. Рекомендуется 100-500 символов, не более.
        /// </summary>
        public string Text;

        /// <summary>
        ///     Иконка уведомления.
        ///     Не рекомендуется использовать, по-умолчанию используется иконка канала, которая кэшируется на устройстве.
        /// </summary>
        public string Icon;

        /// <summary>
        ///     Адрес по которому будет осуществлен переход по клику.
        ///     Вводить с "http://" или "https://".
        ///     При желании можно использовать адреса вида tel: или mailto:
        /// </summary>
        public string Url;

        /// <summary>
        ///     Скрыть уведомление.
        /// </summary>
        public HideType? Hidden;

        /// <summary>
        ///     Ваша кодировка. (не обязательно).
        /// </summary>
        /// <example>cp1251</example>
        public string Encode;

        /// <summary>
        ///     Приоритет. Это очень важный параметр, которому надо уделить внимание.
        ///     По возможности используйте <see cref="PriorityType.NotImportant"/>,
        ///     иногда можно <see cref="PriorityType.Default"/>,
        ///     используйте <see cref="PriorityType.Important"/> в случае крайней необходимости.
        ///     Скорее всего в будущем для broadcast и/или multicast высокий приоритет будет запрещен.
        /// </summary>
        public PriorityType? Priority;

        /// <summary>
        ///     Время жизни в секундах.
        ///     По-умолчанию 25 дней - 2160000 секунд, или тот что выбран у вас в настройке канала, или тот что указан в ограничениях вашей категории канала.
        ///     Выбирайте TTL с умом - чем ближе TTL к времени актуальности информации, чем ниже навязчивость оповещений.
        /// </summary>
        public int? TTL;

        /// <summary>
        ///     Управление фильтрацией.
        ///     Этот параметр ведет себя по разному для разных типов уведомлений.
        ///     Для SelfAPI не работает.
        ///     Для Broadcast и Multicast можно передать filter=<see cref="FilterType.ForcedOff"/>.
        ///     Не используйте этот метод слишком часто, т.к. пользователи рассчитывают на то, что фильтры будут всегда работать.
        ///     Это можно использовать, например если вам нужно отправить всем важное сообщение о технических работах, или изменении в настройках вашего канала.
        ///     Для Unicast можно передать filter=<see cref="FilterType.ForcedOn"/> и принудительно включить фильтрацию, полезно, если вы используете множественные Unicast и хотите при этом задействовать встроенную фильтрацию PushAll.
        /// </summary>
        public FilterType? Filter;
    }
}
