using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    public class RendererTest
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly ICamera mCamera;
        private readonly IGraphics mGraphics;

        public RendererTest()
        {
            mAlgorithms = new Algorithms();
            mCamera = MockRepository.GenerateStub<ICamera>();
            mGraphics = MockRepository.GenerateMock<IGraphics>();
        }

        [Fact]
        public void DrawGrid_RequestsCalculationForEachTile()
        {
            var renderer = new Renderer(mAlgorithms);

            mCamera.Stub(_ => _.GetHexesInView())
                .Return(new Coordinate(3, 5));

            renderer.DrawGrid(mGraphics, mCamera);

            var fillPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Point[]>.Is.Anything));
            var drawPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Point[]>.Is.Anything));

            Assert.Equal(15, fillPolyCalls.Count);
            Assert.Equal(15, drawPolyCalls.Count);
        }

        #region Helpers

        private void SetupGraphicsDependencies()
        {
        }

        #endregion
    }
}
