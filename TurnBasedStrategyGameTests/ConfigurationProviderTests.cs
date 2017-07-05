﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    [TestClass]
    public class ConfigurationProviderTests
    {
        [TestMethod]
        public void GetValue_ReturnsCorrectValue()
        {
            var provider = new ConfigurationProvider();

            var result = provider.GetValue<string>("TestKey");

            Assert.AreEqual("True", result);
        }
    }
}
