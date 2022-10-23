# TestWork
# Инструкция по запуску
1) Откройте через консоль папку test.web.api
2) Выполните команду docker-compose build
3) Выполните команду docker-compose up
4) Перейдите на страницу swagger-a http://localhost:8080/swagger/index.html

# Описание api
- /api/Products/AddData - инициализирует БД данными. Кол-во записей задается в аргументах
- /api/Products/GetProductCategories - получение списка категорий
- /api/Products/GetProductsByCategory- получение продуктов по выбранной категории
