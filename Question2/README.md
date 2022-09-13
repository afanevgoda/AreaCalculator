# Ответ на второй вопрос

Для примера использовался SQLite.

## Создание таблиц
```
CREATE TABLE Product(
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   name TEXT NOT NULL
);

CREATE TABLE Category(
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   name TEXT NOT NULL
);

CREATE TABLE ProductToCategory(
   id INTEGER PRIMARY KEY AUTOINCREMENT,
   productId INTEGER,
   categoryId INTEGER
);
```
## Добавление записей
```
INSERT INTO Product (name) VALUES 
    ("Alpha"),
	("Beta"),
	("Delta");
INSERT INTO Category (name) VALUES 
    ("CategoryA"),
	("CategoryB");
INSERT INTO ProductToCategory (productId, categoryId) VALUES 
    (1, 1),
    (1, 2),
    (2, 1);
```

## Мой ответ

*запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно*
*выводиться.*

```
SELECT p.name AS ProductName, c.name AS CategoryName 
   FROM ProductToCategory ptc
   JOIN Category c ON c.id = ptc.categoryId
   RIGHT JOIN Product p ON p.id = ptc.productId;
```

![SquareClassCreated](https://github.com/afanevgoda/AreaCalculator/blob/master/Question2/result.png)
