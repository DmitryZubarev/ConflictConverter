# Conflict Converter

## Приложение разделено на 3 проекта:
- ConflictConverter (Содержит вход для запуска приложения)
- ConflictConverter.Domain (Проект, содержащий бизнес-логику)
- ConflictConverter.Domain.Tests (Тесты для класса ConflictDictionary из проекта Domain)

## Приложение работает с помощью взаимодействия через консоль
- Сначала приложене через консоль запрашивает путь к .json-файлу, из которого будут считываться данные. Путь должен быть полным и не должен содержать в себе кавычки.
- После приложение запрашивает полный путь к выходному .json-файлу, в который запишутся данные. Также не должно быть кавычек.

## Сторонние библиотеки
- Для работы с json используется библиотека Newtonsoft
