# **AreaCalculator library**

Для ответа на второй вопрос перейдите [сюда](./Question2/README.md)



## Что может?

Рассчитывать площадь круга по радиусу и треугольника по трем сторонам.

## Как использовать?

После добавления библиотеки в зависимости проекта, необходимо:

1) Создать экземпляры классов `ShapeCreator` и `AreaCalculator`. Оба класса реализуют соответствующие им интерфейсы, поэтому рекомендуется использовать DI.

2) Создать желаемую фигуру через `ShapeCreator`. Доступные на данный момент методы:

- `CreateCircle(double radius)`
- `CreateTriangle(double sideA, double sideB, double sideC)`

3) Отправить созданный объект фигуры в метод `AreaCalculator.CalculateArea(IShape targetShape)`

Примеры использования библиотеки можно посмотреть в проекте `ClientApp`.

## Как добавить новые виды фигур?

Далее для примера будет показан процесс добавления квадрата в качестве новой фигуры.

1) Создайте новый класс для необходимой фигуры в директории `Shapes`.

![SquareClassCreated](https://github.com/afanevgoda/AreaCalculator/blob/master/README_images/SquareClassCreated.png)

2) Реализуйте им метод `IShape`.

- Не забудьте добавить необходимые поля для расчёта площади новой фигуры

* Не забудьте добавить `internal` конструктор для возможности создать в будущем такую фигуру через `ShapeCreator`, но запретить создание фигур вручную. Также не забудьте про заполнение полей в конструкторе, необходимых для расчета площади фигуры.

  ![SquareClassCode](https://github.com/afanevgoda/AreaCalculator/blob/master/README_images/SquareClassCode.png)

3) Добавьте код для создания новой фигуры в `ShapeCreator` и `IShapeCreator`, добавив необходимую валидацию

![IShapeCreatorSquare](https://github.com/afanevgoda/AreaCalculator/blob/master/README_images/IShapeCreatorSquare.png)

![ShapeCreatorSquare](https://github.com/afanevgoda/AreaCalculator/blob/master/README_images/ShapeCreatorSquare.png)

Добавление новой фигуры закончено. Следуйте инструкции выше, чтобы далее использовать новую фигуру и расчитать её площадь. Если всё работает корректно, **не забудьте добавить новые тесты для созданной фигуры**.

## Прочее

- **Почему для того, чтобы использовать проверку на то, является ли треугольник прямоугольным, необходимо явно приводить его к типу `Triangle`?**
  - Несмотря на то, что я старался использовать интерфейс `IShape` по максимуму, если пользователю необходимо проверить, является ли треугольник прямоугольным, он должен знать, что имеет дело именно с треугольником, поэтому я посчитал, что явное приведение допустимо.
- **Для прямоугольных треугольников есть отдельная формула по расчёту площади. Почему она не используется?**
  - Для ее реализации необходимо знать, какая сторона является гипотенузой. Это требует добавление по одному новому полю для каждого катета, к тому же, такой код довольно громоздок. Я допускаю, что такой код будет выполняться быстрее, поскольку требует гораздо меньше мат. вычислений, но, следуя принципу KISS, я решил оставить подобный функционал на дальнейшую оптимизацию, *если она потребуется*.
- **Все итоговые вычисления имеют уродливый вид совсем без округления!**
  - В идеале, точность округлений (как и точность расчётов, которая используется, например, для определения, является ли треугольник прямоугольным) следовало бы вывести в файл конфигурации или конструктор `AreaCalculator` (или в отдельный класс-конфигуратор подобных констант), а оттуда уже использовать его во всех необходимых местах. Но YAGNI.
- **Почему метод `CalculateArea(params float[] sideLength)` помечен как `Oboslete`? / Почему такой метод вообще существует?**
  - Одним из требований являлось *Вычисление площади фигуры без знания типа фигуры в compile-time*. К сожалению я не понял, является ли это требованием к использованию интерфейсов вместо классов или к наличию какого-то абстрактного вычислителя площади, куда можно ввести кучу данных, а он сам всё посчитает, но я добавил такой метод как раз для этого требования помимо использования интерфейсов. Как `Obsolete` он отмечен только потому, что его использование возможно **на данный момент**, когда по количеству параметров мы можем определить фигуру. В будущем, при добавлении таких фигур как трапеция, прямоугольник и квадрат, мы уже не сможем полноценно реализовать функционал для этого метода.
- **Зачем нам `AreaCalculator`, когда метод по расчёту площади у фигур и так является публичным?**
  - На данный момент нет разницы, какой из методов использовать, однако в идеале, следовало бы метод `IShape.CalculateArea()` сделать `Internal`, что невозможно для публичных интерфейсов.
