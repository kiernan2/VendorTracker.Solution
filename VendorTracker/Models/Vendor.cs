using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public int Id { get; }
    private static List<Vendor> _instances = new List<Vendor>();
    public List<Order> Orders { get; set; }

    public Vendor(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}