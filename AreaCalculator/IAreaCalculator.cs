using AreaCalculator.Shapes;

namespace AreaCalculator;

public interface IAreaCalculator{
    double CalculateArea(IShape targetShape);

    double CalculateArea(params float[] sideLength);
}