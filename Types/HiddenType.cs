namespace PushAll.Types
{
    /// <summary>
    ///     Отвечает за сокрытие уведомления.
    /// </summary>
    public enum HideType
    {
        /// <summary>
        ///     Сразу скрыть уведомление из истории пользователей.
        /// </summary>
        Immediately = 1,
        /// <summary>
        ///     Скрыть только из ленты.
        /// </summary>
        FromTape = 2,
        /// <summary>
        ///      Не скрывать (по-умолчанию 0).
        /// </summary>
        Not = 0,
    }
}
