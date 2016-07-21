﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.Augmentators;
using System;

namespace SharpLearning.CrossValidation.Test.Augmentors
{
    [TestClass]
    public class NominalMungeAugmentorTest
    {
        [TestMethod]
        public void NominalMunchAugmentor_Augment()
        {
            var random = new Random(2342);
            var data = new F64Matrix(10, 2);
            data.Initialize(() => random.Next(2));

            var sut = new NominalMungeAugmentator(0.5);
            var actual = sut.Agument(data);

            var expected = new F64Matrix(new double[] { 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 },
                10, 2);

            Assert.AreNotEqual(data, actual);
            Assert.AreEqual(expected.GetNumberOfRows(), actual.GetNumberOfRows());
            Assert.AreEqual(expected.GetNumberOfColumns(), actual.GetNumberOfColumns());

            var expectedData = expected.GetFeatureArray();
            var actualData = expected.GetFeatureArray();

            for (int i = 0; i < expectedData.Length; i++)
            {
                Assert.AreEqual(expectedData[i], actualData[i], 0.00001);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NominalMunchAugmentor_Constructor_Probability_Too_Low()
        {
            new NominalMungeAugmentator(-0.1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NominalMunchAugmentor_Constructor_Probability_Too_High()
        {
            new NominalMungeAugmentator(1.1);
        }
    }
}
