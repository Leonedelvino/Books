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

4. Установка модулей. Каждый модуль описывается поочерёдно. Зайти в папку проекта Books и оттуда вызывать командную строку:

Список всех модулей, подлежащих к установке:
1. Material Design full package
2. webpack: Bundles Sass and JavaScript:
3. sass-loader: Webpack loader to preprocess Sass files
4. sass: Sass compiler
5. css-loader: Resolves CSS @import and url() paths:
6. extract-loader: Extracts the CSS into a .css file
7. file-loader: Serves the .css file as a public URL
8. webpack-serve:  A Webpack development server in a plugin
9. @babel/core
10. babel-loader: Compiles JavaScript files using babel
11. @babel/preset-env: Preset for compiling es2015
12. Autoprefixer: PostCSS plugin to parse CSS and add vendor prefixes to CSS rules using values from Can I Use.

Выполняем команду:

```
npm install --save-dev webpack material-components-web webpack-cli webpack-serve css-loader sass-loader sass extract-loader file-loader autoprefixer
```

5. Запуск команды: 

```
npm start
```
