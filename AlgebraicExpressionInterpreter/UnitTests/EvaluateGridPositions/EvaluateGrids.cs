using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FunctionGridView;

namespace FunctionGridViewTest
{
    [TestClass]
    public class EvaluateGridPositions
    {
        [TestMethod]
        public void EvaluateGridPositionsMethodReturnsDeltaGridOf2()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(-0.05,0.05,5);
            List<double> listOfPoints = new List<double>() {0, 2, 4, 6, 8 };
            Assert.AreEqual(5, gridPositions.Count());
            Assert.IsTrue(gridPositions.SequenceEqual(listOfPoints));
        }
        [TestMethod]
        public void EvaluateGridPositionsReturnsDeltaGridOf4()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(-0.05,20.3,5);
            List<double> listOfPoints = new List<double>() {0,4,8,12,16};
            Assert.AreEqual(5, gridPositions.Count());
            Assert.IsTrue(gridPositions.SequenceEqual(listOfPoints));
        }
        [TestMethod]
        public void EvaluateGridPositionsReturnsDeltaGridOf0()
        {
            Assert.ThrowsException<EvaluateGridPositionsException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(0.05,200.3,5));
        }
        [TestMethod]
        public void EvaluateGridPositionsReturnsDeltaGridOf5()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(-200,-175, 5);
            List<double> listOfPoints = new List<double>() { -200,-195,-190,-185,-180};
            Assert.AreEqual(5, gridPositions.Count());
            Assert.IsTrue(gridPositions.SequenceEqual(listOfPoints));
        }
        [TestMethod]
        public void EvaluateGridPositionsMethodReturnsDeltaGridOf2_2()
        {
            var gridPositions = FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(-1,1.5,1);
            List<double> listOfPoints = new List<double>() {-1};
            Assert.AreEqual(1, gridPositions.Count());
            Assert.IsTrue(gridPositions.SequenceEqual(listOfPoints));
        }
        [TestMethod]
        public void EvaluateGridPositionsThrowsAnExceptionForNIs0()
        {
            Assert.ThrowsException<EvaluateGridPositionsException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(-2.0,3.0,0));
        }
        [TestMethod]
        public void EvaluateGridPositionsThrowsAnExceptionForNIsEqualRangeEnd()
        {
            Assert.ThrowsException<EvaluateGridPositionsException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(3.0,3.0,5));
        }
        [TestMethod]
        public void EvaluateGridPositionsThrowsAnExceptionForNIsLessThanRangeEnd()
        {
            Assert.ThrowsException<EvaluateGridPositionsException>(() => FunctionGridView.EvaluateGridPositions.EvaluateVerticalAndHorizontalGridPositions(3.0,2.5,5));
        }
    }
}
