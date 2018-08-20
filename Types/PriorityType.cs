namespace PushAll.Types
{
    /// <summary>
    ///     Типы приоритетов.
    /// </summary>
    public enum PriorityType
    {
        /// <summary>
        ///     По-умолчанию.
        /// </summary>
        Default = 0,
        /// <summary>
        ///     Не важные, менее заметны, не будят устройство.
        /// </summary>
        NotImportant = -1,
        /// <summary>
        ///     Более заметные, быстрее сажают аккумулятор.
        /// </summary>
        Important = 1
    }
}
