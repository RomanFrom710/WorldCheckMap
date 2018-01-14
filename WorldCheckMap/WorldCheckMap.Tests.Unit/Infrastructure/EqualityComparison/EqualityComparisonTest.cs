using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorldCheckMap.Tests.Unit.Infrastructure.EqualityComparison
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
            Assert.IsTrue(obj1.IsEqual(obj2), "IsEqual should return true for the same objects");
            Assert.IsTrue(obj2.IsEqual(obj1), "IsEqual should return true for the same objects");

            obj2 = GetTestObject();
            Assert.IsFalse(obj1.IsEqual(obj2), "IsEqual should return false for not the same objects");
            Assert.IsFalse(obj2.IsEqual(obj1), "IsEqual should return false for not the same objects");
        }

        [TestMethod]
        public void CollectionEqualityTest()
        {
            var col1 = new List<TestClass> { GetTestObject(), GetTestObject() };
            var col2 = new List<TestClass> { CopyTestObject(col1[1]), CopyTestObject(col1[0]) };
            Assert.IsTrue(col1.IsEqual(col2), "IsEqual should return true for the same collections");
            Assert.IsTrue(col2.IsEqual(col1), "IsEqual should return true for the same collections");

            col2.Add(GetTestObject());
            Assert.IsFalse(col2.IsEqual(col1), "IsEqual should return false for the collections of different sizes");

            var col3 = new List<TestClass> { CopyTestObject(col1[1]), CopyTestObject(col1[1]) };
            Assert.IsFalse(col3.IsEqual(col1), "IsEqual should ignore order of elements in the collections");
        }

        [TestMethod]
        public void IgnoringDatabaseGeneratedStuffTest()
        {
            var testModel1 = new TestModel{ Id = 1, Number = 1 };
            var testModel2 = new TestModel{ Id = 2, Number = 1 };
            Assert.IsTrue(testModel1.IsEqual(testModel2), "IsEqual should ignore Id properties");
            
            var testModel3 = new TestModel{ Id = 2, Number = 2 };
            Assert.IsFalse(testModel1.IsEqual(testModel3), "IsEqual should compare the rest of properties even if it meets Id property");
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

            Assert.IsTrue(col1.IsEqual(col2), "IsEqual should ignore Id properties in the collections");

            col2[0].Number = 2;
            Assert.IsFalse(col1.IsEqual(col2), "IsEqual should compare the rest of the properties in the colleciton even if it meets Id property");
        }

        [TestMethod]
        public void IgnoreCollectionTypesTest()
        {
            var model1 = new TestModel
            {
                Collection = new List<int> { 1, 2 }
            };
            var model2 = new TestModel
            {
                Collection = new HashSet<int> { 1, 2 }
            };

            Assert.IsTrue(model1.IsEqual(model2), "IsEqual should ignore collection types");

            model1.Collection.Add(3);
            Assert.IsFalse(model1.IsEqual(model2), "IsEqual should return false for collections with different content");
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

            public ICollection<int> Collection { get; set; }
        }

        #endregion
    }
}
