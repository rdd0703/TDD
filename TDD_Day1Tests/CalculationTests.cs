using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TDD_Day1.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        private List<ProductModel> _lstProduct;

        public CalculationTests()
        {
            this._lstProduct = GetFakeData();
        }

        [TestMethod()]
        public void GetGroupSumTest_3筆成一組_取得Cost的總和()
        {
            //arrange
            var target = new Calculation(_lstProduct);
            var groupCount = 3;
            var fieldName = "Cost";

            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var actual = target.GetGroupSum(groupCount, fieldName);

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GetGroupSumTest_4筆一組_取得Revenue總和()
        {
            //arrange
            var target = new Calculation(_lstProduct);
            var groupCount = 4;
            var fieldName = "Revenue";

            var expected = new List<int>() { 50, 66, 60 };

            //act
            var actual = target.GetGroupSum(groupCount, fieldName);

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GetGroupSumTest_筆數輸入負數_預期會拋ArgumentException()
        {
            //arrange
            var target = new Calculation(_lstProduct);
            var groupCount = -1;
            var fieldName = "Revenue";

            var expected = new ArgumentException();

            //act
            Action act = () => target.GetGroupSum(groupCount, fieldName);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetGroupSumTest_欄位若不存在_預期會拋ArgumentException()
        {
            //arrange
            var target = new Calculation(_lstProduct);
            var groupCount = 4;
            var fieldName = "NonExistField";

            var expected = new ArgumentException();

            //act
            Action act = () => target.GetGroupSum(groupCount, fieldName);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void GetGroupSumTest_筆數若輸入為0_則傳回0()
        {
            //arrange
            var target = new Calculation(_lstProduct);
            var groupCount = 0;
            var fieldName = "Any";

            var expected = new List<int>() { 0 };

            //act
            var actual = target.GetGroupSum(groupCount, fieldName);

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }


        private List<ProductModel> GetFakeData()
        {
            var ret = new List<ProductModel>();

            ret.Add(new ProductModel() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            ret.Add(new ProductModel() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            ret.Add(new ProductModel() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            ret.Add(new ProductModel() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            ret.Add(new ProductModel() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            ret.Add(new ProductModel() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            ret.Add(new ProductModel() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            ret.Add(new ProductModel() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            ret.Add(new ProductModel() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            ret.Add(new ProductModel() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            ret.Add(new ProductModel() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });

            return ret;
        }
    }
}