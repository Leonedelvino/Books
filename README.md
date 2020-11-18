# Books - project
## Начало
1. Проверка наличия необходимого софта для работы с проектом:
    - Node.js (last version)
    
2. Публикация базы данных:
    - Переходим в Visual Studio - Solution Explorer - Books.Db (проект базы данных)
    - Двойное нажатие левой кнопкой мыши на Books.Db.publish.xml
    - В открывшимся окне, внизу - слева, нажимаем "Publish"
  
3. Запуск скрипта для авто-заполнения базы данных
    - В проекте базы данных заходим в папку scripts/referenceData/Books.sql
    - В открывшимся файле, сверху от него находим кнопку "Connect".
    - Если произошло автоматическое соединение с базой данных, то заходим "Change Connection".
    - В открывшимся окне Local - MSSQLLocalDB, жмём Connecеt
    - Справа от кнопки "Change Connection" выпадающее окно с возможностью выбора базы данных. Находим Books.Db
    - Находим, в той же строке, где Change Connection, Execute (зелёная стрелка) или прожимаем Ctrl+Shift+E

4. Установка модулей. Каждый модуль описывается поочерёдно, сначала указывается название модуля, потом указывается команда, которую нужно внести в cmd или командную строку. Прежде чем вписывать команду необходимо зайти в папку проекта Books и оттуда выполнять все команды:
    - Сначала выполняем команду: npm init (Создаётся в корневой директории файл package.json)
    - !!! Вы можете установить все модули одной командой в консоли, но перед этим ознакомтесь со всем списком модулей: npm install --save-dev webpack material-components-web webpack-cli webpack-serve css-loader sass-loader sass extract-loader file-loader
    1. Material Design full package: npm i material-components-web
    2. webpack: Bundles Sass and JavaScript: 
    3. sass-loader: Webpack loader to preprocess Sass files:
    4. sass: Sass compiler:
    5. css-loader: Resolves CSS @import and url() paths:
    6. extract-loader: Extracts the CSS into a .css file:
    7. file-loader: Serves the .css file as a public URL:
    8. webpack-serve:  A Webpack development server in a plugin:

5. Запуск команды: npm start
