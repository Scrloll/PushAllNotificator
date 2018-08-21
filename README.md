# PushAll Notificator
Описание.
---
.Net Standard 2.0 библиотека для отправки уведомлений через сервис PushAll.

Установка.
---
Install-Package PushAllNotificator

Использование.
---
1. [Зарегистрируйтесь в сервисе PushAll](https://pushall.ru/)
2. [Создайте канал](https://pushall.ru/admin)
3. Инициализируйте переменную Notificator.
```C#
Notificator notificator = new Notificator();
```
4. Инициализируйте переменную необходимого уведомления
```C#
UnicastNotification notif = new UnicastNotification("1", "0077f8aba41b8f6e0030e9b2b0b23f7b", "Заголовок", "Текст", "2")
{
	Url = "mailto:Example@mail.ru",
	Priority = Types.PriorityType.Important
};
```
5. Отправляйте уведомления через метод SendAsync
```C#
await notificator.SendAsync(notif);
```
