using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }

    [HttpPost("/vendor/{vendorId}")]
    public ActionResult Create(int vendorId, string orderDetails)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order order = new Order(orderDetails);
      vendor.AddOrder(order);
      return RedirectToAction("Show","Vendor", new { id = vendorId });
    }

    [HttpGet("/vendor/{vendorId}/orders/new")]
    public ActionResult New(int vendorId, string orderDetails)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendor/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> myDictionary = new Dictionary<string, object>();
      myDictionary.Add("order", order);
      myDictionary.Add("vendor", vendor);
      return View(myDictionary);
    }
  }
}