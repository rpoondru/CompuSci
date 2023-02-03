using Utility;

namespace UtilityTest
{
    [TestClass]
    public class VectorTests
    {

        [TestMethod]
        public void TestConstructor()
        {
            Vector v = new Vector(1.5, -2.0, 0);
            Assert.AreEqual(1.5, v.X);
            Assert.AreEqual(-2.0, v.Y);
            Assert.AreEqual(0, v.Z);
        }

        [TestMethod]
        public void TestVectorAddition()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);
            Vector v2 = new Vector(-0.5, -1, 2);

            // Act
            Vector result = v1 + v2;

            // Assert
            Assert.AreEqual(0.5, result.X);
            Assert.AreEqual(-3, result.Y);
            Assert.AreEqual(2.5, result.Z);
        }

        [TestMethod]
        public void TestVectorSubtraction()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);
            Vector v2 = new Vector(-0.5, -1, 2);

            // Act
            Vector result = v1 - v2;

            // Assert
            Assert.AreEqual(1.5, result.X);
            Assert.AreEqual(-1, result.Y);
            Assert.AreEqual(-1.5, result.Z);
        }

        [TestMethod]
        public void TestVectorScalarMultiplication()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);
            double scalar = 4.2;

            // Act
            Vector result = v1 * scalar;
            
            // Assert
            Assert.AreEqual(4.2, result.X);
            Assert.AreEqual(-8.4, result.Y);
            Assert.AreEqual(2.1, result.Z);
        }

        [TestMethod]
        public void TestVectorScalarDivision()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);
            double scalar = 4.2;

            // Act
            Vector result = v1 / scalar;

            // Assert
            Assert.AreEqual(0.238, result.X, 0.001);
            Assert.AreEqual(-0.476, result.Y, 0.001);
            Assert.AreEqual(0.119, result.Z, 0.001);
        }

        [TestMethod]
        public void TestVectorLength()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);

            // Act
            double result = v1.Magnitude;

            // Assert
            Assert.AreEqual(2.29128784747792, result, 0.0000001);
        }

        [TestMethod]
        public void TestVectorLengthSquared()
        {
            // Arrange
            Vector v1 = new Vector(1, -2, 0.5);

            // Act
            double result = v1.MagnitudeSquared;

            // Assert
            Assert.AreEqual(5.25, result);
        }

        [TestMethod]
        public void TestNormalize()
        {
            Vector v1 = new Vector(1, -2, 0.5);
            Vector expected = new Vector(1 / v1.Magnitude, -2 / v1.Magnitude, 0.5 / v1.Magnitude);
            Vector actual = v1.Normalize();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDotProduct()
        {
            Vector v1 = new Vector(1, -2, 0.5);
            Vector v2 = new Vector(-0.5, -1, 2);
            double expected = 1 * -0.5 + -2 * -1 + 0.5 * 2;
            double actual = Vector.DotProduct(v1, v2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCrossProduct()
        {
            Vector v1 = new Vector(1, -2, 0.5);
            Vector v2 = new Vector(-0.5, -1, 2);
            Vector expected = new Vector(-3.5, -2.25, -2);
            Vector actual = Vector.CrossProduct(v1, v2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAngleBetween()
        {
            Vector v1 = new Vector(1, -2, 0.5);
            Vector v2 = new Vector(-0.5, -1, 2);
            double expected = 0.34201727695 * Math.PI;
            double actual = Vector.AngleBetween(v1, v2);
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void TestAngleOfVector()
        {
            Vector v1 = new Vector(1, -2, 0.5);
            Vector expected = new Vector(Math.Atan(-2 / 1), Math.Atan(0.5 / 1), Math.Atan(0.5 / -2));
            Vector actual = Vector.AngleOfVector(v1);
            double tolerance = 0.000000001;
            Assert.AreEqual(expected.X, actual.X, tolerance);
        }

        [TestMethod]
        public void TestToString()
        {
            Vector v1 = new Vector(1, 2, 3);
            string expected = "(1, 2, 3)";
            string actual = v1.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}


