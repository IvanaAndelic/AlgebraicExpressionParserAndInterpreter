using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionGridViewTest
{
    [TestClass]
    public class EvaluateGridPositions
    {
        [TestMethod]
        public void EvaluateGridPositionsMethodReturnsDeltaGridOf2()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-0.05,0.05,5);
            List<double> listOfPoints = new List<double>() { 2, 4, 6, 8 };
            Assert.AreEqual(4, gridPositions.Count());
            Assert.IsTrue(gridPositions.Equals(listOfPoints));
        }
        public void EvaluateGridPositionsReturnsDeltaGridOf4()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-0.05,20.3,5);
            List<double> listOfPoints = new List<double>() {4,8,12,16,20};
            Assert.AreEqual(4, gridPositions.Count());
            Assert.IsTrue(gridPositions.Equals(listOfPoints));
        }
        public void EvaluateGridPositionsReturnsDeltaGridOf400()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-0.05,2000.3,5);
            List<double> listOfPoints = new List<double>() { 0,400,800,1200,1600 };
            Assert.AreEqual(4, gridPositions.Count());
            Assert.IsTrue(gridPositions.Equals(listOfPoints));
        }
        public void EvaluateGridPositionsReturnsDeltaGridOf5()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-200,-175, 5);
            List<double> listOfPoints = new List<double>() { -195,190,185,180,175};
            Assert.AreEqual(4, gridPositions.Count());
            Assert.IsTrue(gridPositions.Equals(listOfPoints));
        }
        public void EvaluateGridPositionsReturnsDeltaGridOf2()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-1,1.5,1);
            List<double> listOfPoints = new List<double>() {1};
            Assert.AreEqual(4, gridPositions.Count());
            Assert.IsTrue(gridPositions.Equals(listOfPoints));
        }
        public void EvaluateGridPositionsThrowsAnExceptionForNIs0()
        {
            Assert.ThrowsException<InvalidOperationException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(-2.0,3.0,0));
        }
        public void EvaluateGridPositionsThrowsAnExceptionForNIsEqualRangeEnd()
        {
            Assert.ThrowsException<InvalidOperationException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(3.0,3.0,5));
        }
        public void EvaluateGridPositionsThrowsAnExceptionForNIsLessThanRangeEnd()
        {
            Assert.ThrowsException<InvalidOperationException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalGridPositions(3.0,2.5,5));
        }
    }
}
