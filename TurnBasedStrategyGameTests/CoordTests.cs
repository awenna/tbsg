using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    [TestClass]
    public class CoordTests
    {
        [TestMethod]
        public void Constructor_Coords_HoldsConstructorValues()
        {
            var coord = new Coords(3, 5);

            Assert.AreEqual(coord.x, 3);
            Assert.AreEqual(coord.y, 5);
        }

        #region Operators

        [TestMethod]
        public void Coords_SupportsAddition()
        {
            var first = new Coords(1, 2);
            var second = new Coords(2, 5);

            var result = first + second;

            var expected = new Coords(3, 7);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Coords_SupportsSubstraction()
        {
            var first = new Coords(1, 2);
            var second = new Coords(2, 5);

            var result = first - second;

            var expected = new Coords(-1, -3);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Coords_SupportsMultiplication()
        {
            var first = new Coords(1, 2);
            var second = new Coords(2, 5);

            var result = first * second;

            var expected = new Coords(2, 10);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Coords_SimpleDivision_SupportsDivision()
        {
            var first = new Coords(10, 20);
            var second = new Coords(2, 5);

            var result = first / second;

            var expected = new Coords(5, 4);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Coords_HasRemainer_SupportsDivision()
        {
            var first = new Coords(1, 22);
            var second = new Coords(3, 5);

            var result = first / second;

            var expected = new Coords(0, 4);

            Assert.AreEqual(result, expected);
        }

        #endregion
    }
}
