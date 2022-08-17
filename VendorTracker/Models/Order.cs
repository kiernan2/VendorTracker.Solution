using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace VendorTracker.Models
{
  public class VenOrder
  {
    public string Details { get; set; }
    public int Id { get; set; }
    
    public VenOrder (string details)
    {
      Details = details;
    }

    public VenOrder (string details, int id)
    {
      Details = details;
      Id = id;
    }
    
    public static VenOrder Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM Orders WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = searchId;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int orderId = 0;
      string orderDetails = "";
      while (rdr.Read())
      {
        orderId = rdr.GetInt32(0);
        orderDetails = rdr.GetString(1);
      }
      VenOrder foundOrder = new VenOrder(orderDetails, orderId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundOrder;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO orders (details) VALUES (@OrderDetails);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@OrderDetails";
      param.Value = this.Details;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherOrder)
    {
      if (!(otherOrder is VenOrder))
      {
        return false;
      }
      else
      {
        VenOrder newOrder = (VenOrder) otherOrder;
        // bool idEquality = (this.Id == newOrder.Id);
        bool descriptionEquality = (this.Details == newOrder.Details);
        return (descriptionEquality);
      }
    }

    public static void ClearAll()
    {
      Debug.WriteLine("In ClearAll");
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM orders;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<VenOrder> GetAll()
    {
      List<VenOrder> allOrders = new List<VenOrder>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM orders;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int orderId = rdr.GetInt32(0);
        string orderDetails = rdr.GetString(1);
        VenOrder newOrder = new VenOrder(orderDetails, orderId);
        allOrders.Add(newOrder);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allOrders;
    }
  }
}