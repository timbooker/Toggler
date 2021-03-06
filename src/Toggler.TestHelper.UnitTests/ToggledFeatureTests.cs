﻿using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using Toggler.TestHelper.UnitTests.TestSetup;

namespace Toggler.TestHelper.UnitTests
{
    [TestFixture]
    public class ToggledFeatureTests
    {
        [Test]
        public void ShouldReturnOneWhenToggledFeatureIsOn()
        {
            var toggledFeature = new ToggledFeature();

            using (ShimsContext.Create())
            {
                Fakes.ShimToggledExtensions.IsOnIToggled = toggled => true;
                Assert.That(toggledFeature.SomeProcessing(), Is.EqualTo(1));
            }
        }

        [Test]
        public void ShouldReturnTwoWhenToggledFeatureIsOff()
        {
            var toggledFeature = new ToggledFeature();

            using (ShimsContext.Create())
            {
                Fakes.ShimToggledExtensions.IsOnIToggled = toggled => false;
                Assert.That(toggledFeature.SomeProcessing(), Is.EqualTo(2));
            }
        }
    }
}
