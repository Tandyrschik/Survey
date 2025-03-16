
# Запуск. 
1. Открыть консоль в директории, в которую будет скопирован репозиторий проекта, 
   ввести в консоль команду: `git clone https://github.com/Tandyrschik/Survey.git`
2. Запустить проект при помощи команды в консоли `docker-compose up`, 
   дождаться скачивания образов и запуска контейнеров.

# Swagger, pgAdmin.
После запуска контейнеров можно запустить Swagger и pgAdmin в браузере.
1. Swagger: `https://localhost:8081/swagger/index.html`
2. pgAdmin: `http://localhost:5050/` (Для администрирования БД зайти под логином postgres@gmail.com и паролем 12345, 
создать новый сервер с именем: postgres, host name/address: postgres, password: 12345)

# Описание эндпоинтов.
1. /survey(post) - создает новую сущность Survey и возвращает id созданной сущности.
2. /question(post) - создает новую сущность Question и возвращает id созданной сущности.
3. /question(get) - выдаёт сущность Question по его Id.
4. /interview(post) - создаёт новую сущность Interview и возвращает первый вопрос из опроса.
5. /result(post) - создаёт новую сущность Result и возвращает id следующего опроса, либо NoContent.

Скрипт создания базы данных: Survey.API/query.txt