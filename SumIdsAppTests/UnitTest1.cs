using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumIdsApp;

namespace SumIdsAppTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Is_File_Path_Valid_Should_Return_False_For_Bad_Path()
        {
            bool result = HelperMethods.IsFilePathValid("@C:\\asdf");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Is_File_Path_Valid_Should_Return_False_For_Bad_Path_2()
        {
            bool result = HelperMethods.IsFilePathValid("#$@)*");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Load_Data_Should_Return_False_For_Bad_File_1()
        {
            RootObject testRootObject = new RootObject();
            bool result = HelperMethods.LoadData("#$@)*", testRootObject);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Load_Data_Should_Return_2_As_Sum()
        {
            RootObject testRootObject = new RootObject();
            RootObject.MenuHolder tempMenuHolder = new RootObject.MenuHolder();
            testRootObject.Property1 = new RootObject.MenuHolder[1];
            testRootObject.Property1[0] = tempMenuHolder;
            testRootObject.Property1[0].Menu = new RootObject.Menu();
            testRootObject.Property1[0].Menu.Header = "Temp Header";
            testRootObject.Property1[0].Menu.Items = new RootObject.Item[2];
            RootObject.Item tempItem = new RootObject.Item();
            tempItem.Label = "Something";
            tempItem.Id = 1;
            RootObject.Item tempItem2 = new RootObject.Item();
            tempItem2.Label = "Something";
            tempItem2.Id = 1;
            testRootObject.Property1[0].Menu.Items[0] = tempItem;
            testRootObject.Property1[0].Menu.Items[1] = tempItem2;


            List<int> result = HelperMethods.CalculateSums(testRootObject);
            Assert.AreEqual(2, result.First());
        }

        [TestMethod]
        public void Load_Data_Should_Return_1_As_Sum()
        {
            RootObject testRootObject = new RootObject();
            RootObject.MenuHolder tempMenuHolder = new RootObject.MenuHolder();
            testRootObject.Property1 = new RootObject.MenuHolder[1];
            testRootObject.Property1[0] = tempMenuHolder;
            testRootObject.Property1[0].Menu = new RootObject.Menu();
            testRootObject.Property1[0].Menu.Header = "Temp Header";
            testRootObject.Property1[0].Menu.Items = new RootObject.Item[2];
            RootObject.Item tempItem = new RootObject.Item();
            tempItem.Label = "Something";
            tempItem.Id = 1;
            RootObject.Item tempItem2 = new RootObject.Item();
            tempItem2.Label = null;
            tempItem2.Id = 1;
            testRootObject.Property1[0].Menu.Items[0] = tempItem;
            testRootObject.Property1[0].Menu.Items[1] = tempItem2;


            List<int> result = HelperMethods.CalculateSums(testRootObject);
            Assert.AreEqual(1, result.First());
        }
    }
}
