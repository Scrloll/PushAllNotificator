namespace PushAll.Types
{
    /// <summary>
    ///     Отвечает за принудительную фильтрацию уведомлений.
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        ///     Фильтрация будет выключена принудительно.
        /// </summary>
        ForcedOff = -1,
        /// <summary>
        ///     Фильтрация зависит от настроек получателей.
        /// </summary>
        NotForced = 0,
        /// <summary>
        ///     Принудительно включить фильтрацию.
        ///     Полезно, если вы используете множественные Unicast и хотите при этом задействовать встроенную фильтрацию PushAll.
        /// </summary>
        ForcedOn = 1
    }
}
