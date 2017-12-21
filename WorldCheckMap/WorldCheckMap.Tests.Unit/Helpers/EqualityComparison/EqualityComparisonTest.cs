using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorldCheckMap.Tests.Unit.Helpers.EqualityComparison
{
    [TestClass]
    public class EqualityComparisonTest
    {
        private readonly Random _random = new Random();

        [TestMethod]
        public void EqualityTest()
        {
            var obj1 = GetTestObject();
            var obj2 = CopyTestObject(obj1);
            Assert.IsTrue(obj1.IsEqual(obj2));
            Assert.IsTrue(obj2.IsEqual(obj1));

            obj2 = GetTestObject();
            Assert.IsFalse(obj1.IsEqual(obj2));
            Assert.IsFalse(obj2.IsEqual(obj1));
        }

        [TestMethod]
        public void CollectionEqualityTest()
        {
            var col1 = new List<TestClass> { GetTestObject(), GetTestObject() };
            var col2 = new List<TestClass> { CopyTestObject(col1[1]), CopyTestObject(col1[0]) };
            Assert.IsTrue(col1.IsEqual(col2));
            Assert.IsTrue(col2.IsEqual(col1));

            col2.Add(GetTestObject());
            Assert.IsFalse(col2.IsEqual(col1));

            var col3 = new List<TestClass> { CopyTestObject(col1[1]), CopyTestObject(col1[1]) };
            Assert.IsFalse(col3.IsEqual(col1));
        }

        [TestMethod]
        public void IgnoringDatabaseGeneratedStuffTest()
        {
            var testModel1 = new TestModel{ Id = 1, Number = 1 };
            var testModel2 = new TestModel{ Id = 2, Number = 1 };
            Assert.IsTrue(testModel1.IsEqual(testModel2));
            
            var testModel3 = new TestModel{ Id = 2, Number = 2 };
            Assert.IsFalse(testModel1.IsEqual(testModel3));
        }

        [TestMethod]
        public void IgnoringDatabaseGeneratedStuffInCollectionTest()
        {
            var col1 = new List<TestModel>
            {
                new TestModel { Id = 1, Number = 1 },
                new TestModel { Id = 2, Number = 2 }
            };
            var col2 = new List<TestModel>
            {
                new TestModel { Id = 0, Number = 1 },
                new TestModel { Id = 0, Number = 2 }
            };
            Assert.IsTrue(col1.IsEqual(col2));

            col2[0].Number = 2;
            Assert.IsFalse(col1.IsEqual(col2));
        }


        #region TestClass

        private class TestClass
        {
            public string String { get; set; }
            public NestedClass Nested { get; set; }
        }

        private class NestedClass
        {
            public int Number { get; set; }
        }

        private TestClass GetTestObject()
        {
            return new TestClass
            {
                String = _random.Next().ToString(),
                Nested = new NestedClass { Number = _random.Next() }
            };
        }

        private TestClass CopyTestObject(TestClass obj)
        {
            return new TestClass
            {
                String = obj.String,
                Nested = new NestedClass { Number = obj.Nested.Number }
            };
        }
        #endregion

        #region TestModel

        private class TestModel
        {
            public int Id { get; set; }

            public int Number { get; set; }
        }

        #endregion
    }
}
