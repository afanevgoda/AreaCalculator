using System;
using AreaCalculator;
using NUnit.Framework;

namespace AreaCalculatorTests;

public class ShapeCreatorTests{
    private readonly ShapeCreator _shapeCreator = new();

    [Test]
    public void BasicCreationIsOk() {
        Assert.DoesNotThrow(() => _shapeCreator.CreateCircle(5));
        Assert.DoesNotThrow(() => _shapeCreator.CreateTriangle(3, 5, 7));
    }

    [Test]
    public void NegativeOrZeroInputsAreForbidden() {
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateCircle(0));
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateCircle(-1));
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateCircle(-99999999));
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateTriangle(0, 1, 1));
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateTriangle(-1, -1, -1));
        Assert.Throws<ArgumentException>(() => _shapeCreator.CreateTriangle(3, 5, -9));
    }
}