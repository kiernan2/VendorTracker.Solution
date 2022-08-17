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
      VenOrder.ClearAll();
    }

    public OrderTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=vendor_tracker_tests;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_OrderList()
    {
      List<VenOrder> newList = new List<VenOrder>();
      List<VenOrder> result = Order.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Order()
    {
      VenOrder firstOrder = new VenOrder("Mow the lawn");
      VenOrder secondOrder = new VenOrder("Mow the lawn");

      Assert.AreEqual(firstOrder, secondOrder);
    }

    [TestMethod]
    public void GetAll_Returns_OrderList()
    {
      string details01 = "Walk the dog";
      string details02 = "Wash the dishes";
      VenOrder newOrder1 = new VenOrder(details01);
      newOrder1.Save();
      VenOrder newOrder2 = new VenOrder(details02);
      newOrder2.Save();
      List<VenOrder> newList = new List<VenOrder> { newOrder1, newOrder2 };
      List<VenOrder> result = Order.GetAll();
      foreach(VenOrder thisOrder in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisOrder.Details);
      }
    CollectionAssert.AreEqual(newList, result);
    }
    
    [TestMethod]
    public void GetId_OrderInstantiateWithAnIdAndGetterReturns_Int()
    {
      string details = "Walk the dog.";
      VenOrder newOrder = new VenOrder(details);
      newOrder.Save();
      VenOrder foundOrder = Order.Find(newOrder.Id);
      Assert.AreEqual(foundOrder.Id, newOrder.Id);
    }

    // [TestMethod]
    // public void OrderConstructor_CreatesInstanceOfOrder_Order()
    // {
    //   Order newOrder = new Order("test");
    //   Assert.AreEqual(typeof(Order), newOrder.GetType());
    // }
    // [TestMethod]
    // public void GetDetails_ReturnsDetails_String()
    // {
    //   string details = "Walk the dog.";
    //   Order newOrder = new Order(details);
    //   string result = newOrder.Details;
    //   Assert.AreEqual(details, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_OrderList()
    // {
    //   List<Order> newList = new List<Order>();
    //   List<Order> result = Order.GetAll();
    //   foreach (Order thisOrder in result)
    //   {
    //     Console.WriteLine("Output from empty list GetAll test: " + thisOrder.Details);
    //   }
    //   CollectionAssert.AreEqual(newList, result);
    // }
    // [TestMethod]
    // public void SetDetail_SetDescription_String()
    // {
    //   string details = "Walk the dog.";
    //   Order newOrder = new Order(details);
    //   string updatedDetails = "Do the dishes";
    //   newOrder.Details = updatedDetails;
    //   string result = newOrder.Details;
    //   Assert.AreEqual(updatedDetails, result);
    // }
    // [TestMethod]
    // public void Find_ReturnsCorrectOrder_Order()
    // {
    //   string details01 = "Walk the dog";
    //   string details02 = "Wash the dishes";
    //   Order newOrder1 = new Order(details01);
    //   Order newOrder2 = new Order(details02);
    //   Order result = Order.Find(2);
    //   Assert.AreEqual(newOrder2, result);
    // }
  }
}