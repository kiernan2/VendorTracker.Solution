using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class VendorController : Controller
  {
    
    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor>allVendor = Vendor.GetAll();
      return View(allVendor);
    }

    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendor")]
    public ActionResult Create(string vendorName)
    {
      Vendor newVendor = new Vendor(vendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Console.WriteLine("test7:" + id);
      Vendor selectedVendor = Vendor.Find(id);
      return View(selectedVendor);
    }

    [HttpPost("/vendor/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderDetails)
    {
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderDetails);
      foundVendor.AddOrder(newOrder);
      return View("Show", foundVendor);
    }
  }
}