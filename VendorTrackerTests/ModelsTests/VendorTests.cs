using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorTracker.Models;

namespace VendorTracker.TestTools
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    // [TestMethod]
    // public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    // {
    //   Vendor newVendor = new Vendor("test vendor");
    //   Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    // }
    // [TestMethod]
    // public void GetName_ReturnName_String()
    // {
    //   string name = "Test Category";
    //   Vendor newVendor = new Vendor(name);

    //   int result = newVendor.Id;

    //   Assert.AreEqual(1, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsAllVendorObjects_VendorList()
    // {
    //   string name01 = "Work";
    //   string name02 = "School";
    //   Vendor newVendor1 = new Vendor(name01);
    //   Vendor newVendor2 = new Vendor(name02);
    //   List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

    //   List<Vendor> result = Vendor.GetAll();

    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void Find_ReturnsCorrectVendor_Vendor()
    // {
    //   string name01 = "Work";
    //   string name02 = "School";
    //   Vendor newVendor1 = new Vendor(name01);
    //   Vendor newVendor2 = new Vendor(name02);

    //   Vendor result = Vendor.Find(2);

    //   Assert.AreEqual(newVendor2, result);
    // }
  }
}