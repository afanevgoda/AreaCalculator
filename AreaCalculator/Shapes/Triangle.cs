using System.Formats.Asn1;

namespace AreaCalculator.Shapes;

public class Triangle : IShape{
    private double _sideA;
    private double _sideB;
    private double _sideC;
    private double _tolerance = 0.1;

    public double CalculateArea() {
        var semiPerimeter = (_sideA + _sideB + _sideC) / 2;
        var area = Math.Sqrt(semiPerimeter *
                             (semiPerimeter - _sideA) *
                             (semiPerimeter - _sideB) *
                             (semiPerimeter - _sideC));
        return area;
    }

    internal Triangle(double sideA, double sideB, double sideC) {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }


    public bool IsItRightTriangle() {
        var isAHypotenuse = Math.Abs(Math.Pow(_sideA, 2) - (Math.Pow(_sideB, 2) + Math.Pow(_sideC, 2))) < _tolerance;
        var isBHypotenuse = Math.Abs(Math.Pow(_sideB, 2) - (Math.Pow(_sideA, 2) + Math.Pow(_sideC, 2))) < _tolerance;
        var isCHypotenuse = Math.Abs(Math.Pow(_sideC, 2) - (Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2))) < _tolerance;
        return isAHypotenuse || isBHypotenuse || isCHypotenuse;
    }
}