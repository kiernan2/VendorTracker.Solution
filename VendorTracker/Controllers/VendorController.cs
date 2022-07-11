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
      Vendor selectedVendor = Vendor.Find(id);
      return View(selectedVendor);
    }

    [HttpPost("/vendor/{vendorId}/order")]
    public ActionResult Create(int vendorId, string orderDescription)
    {
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(orderDescription);
      foundVendor.AddOrder(newOrder);
      return View("Show", foundVendor);
    }
  }
}