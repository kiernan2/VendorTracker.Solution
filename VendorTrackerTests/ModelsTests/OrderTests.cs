using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorTracker.Models;

namespace VendorTracker.Models
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetDetails_ReturnsDetails_String()
    {
      string details = "Walk the dog.";
      Order newOrder = new Order(details);
      string result = newOrder.Details;
      Assert.AreEqual(details, result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order>();
      List<Order> result = Order.GetAll();
      foreach (Order thisOrder in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisOrder.Details);
      }
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetId_OrderInstantiateWithAnIdAndGetterReturns_Int()
    {
      string details = "Walk the dog.";
      Order newOrder = new Order(details);
      int result = newOrder.Id;
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void SetDetail_SetDescription_String()
    {
      string details = "Walk the dog.";
      Order newOrder = new Order(details);
      string updatedDetails = "Do the dishes";
      newOrder.Details = updatedDetails;
      string result = newOrder.Details;
      Assert.AreEqual(updatedDetails, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      string details01 = "Walk the dog";
      string details02 = "Wash the dishes";
      Order newOrder1 = new Order(details01);
      Order newOrder2 = new Order(details02);
      Order result = Order.Find(2);
      Assert.AreEqual(newOrder2, result);
    }
    [TestMethod]
    public void GetAll_Returns_OrderList()
    {
      string details01 = "Walk the dog";
      string details02 = "Wash the dishes";
      Order newOrder1 = new Order(details01);
      Order newOrder2 = new Order(details02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      List<Order> result = Order.GetAll();
      foreach(Order thisOrder in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisOrder.Details);
      }
    CollectionAssert.AreEqual(newList, result);
    }
  }
}