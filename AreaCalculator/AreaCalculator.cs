using AreaCalculator.Shapes;

namespace AreaCalculator;

public class AreaCalculator : IAreaCalculator{
    public double CalculateArea(IShape targetShape) {
        return targetShape.CalculateArea();
    }

    [Obsolete("Use CalculateArea(IShape targetShape) instead")]
    public double CalculateArea(params float[] sideLength) {
        if (sideLength.Length == 1)
            return new Circle(sideLength[0]).CalculateArea();
        if (sideLength.Length == 3)
            return new Triangle(sideLength[0], sideLength[1], sideLength[2]).CalculateArea();
        
        throw new NotImplementedException("Such shape is unknown so area calculation is not implemented yet");
    }
}