using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Details { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order>();
    
    public Order (string details)
    {
      Details = details;
      _instances.Add(this);
      Id = _instances.Count;
    }
    
    public static Order Find(int searchId)
    {
      return _instances[searchId -  1];
    }
    public static List<Order> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}