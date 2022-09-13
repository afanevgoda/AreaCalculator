using System;
using AreaCalculator;
using NUnit.Framework;

namespace AreaCalculatorTests;

public class AreaCalculatorTests{
    private readonly AreaCalculator.AreaCalculator _areaCalculator = new ();
    private readonly ShapeCreator _shapeCreator = new();
    
    [Test]
    public void BasicCalculatorIsOk() {
        var circle = _shapeCreator.CreateCircle(5);
        var triangle = _shapeCreator.CreateTriangle(3, 5, 7);

        Assert.AreEqual(78d, Math.Round(_areaCalculator.CalculateArea(circle), MidpointRounding.ToZero));
        Assert.AreEqual(6d, Math.Round(_areaCalculator.CalculateArea(triangle), MidpointRounding.ToZero));
    }
    
    [Test]
    public void AbstractCalculatorIsOk() {
        Assert.AreEqual(78d, Math.Round(_areaCalculator.CalculateArea(5), MidpointRounding.ToZero));
        Assert.AreEqual(6d, Math.Round(_areaCalculator.CalculateArea(3, 5, 7), MidpointRounding.ToZero));
    }
    
    [Test]
    public void UnknownShapeIsForbidden() {
        Assert.Throws<NotImplementedException>(() => _areaCalculator.CalculateArea(1,2,3,4,5,6));
    }

}