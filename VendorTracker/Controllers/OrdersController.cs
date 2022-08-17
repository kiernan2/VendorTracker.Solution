using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VendorTracker.Controllers
{
  public class OrdersController : Controller
  {

    [HttpPost("/vendor/{vendorId}")]
    public ActionResult Create(int vendorId, string orderDetails)
    {
      Vendor vendor = Vendor.Find(vendorId);
      VenOrder order = new VenOrder(orderDetails);
      vendor.AddOrder(order);
      order.Save();
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
      VenOrder order = VenOrder.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> myDictionary = new Dictionary<string, object>();
      myDictionary.Add("order", order);
      myDictionary.Add("vendor", vendor);
      return View(myDictionary);
    }

    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Debug.WriteLine("in the route");
      VenOrder.ClearAll();
      return View();
    }
  }
}