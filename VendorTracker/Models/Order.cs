using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Details { get; set; }
    public int Id { get; set; }
    
    public Order (string details)
    {
      Details = details;
    }

    public Order (string details, int id)
    {
      Details = details;
      Id = id;
    }
    
    public static Order Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items WHERE id = @ThisId;";

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
      Order foundOrder = new Order(orderDetails, orderId);

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

      cmd.CommandText = "INSERT INTO Orders (Details) VALUES (@OrderDetails);";
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
      if (!(otherOrder is Order))
      {
        return false;
      }
      else
      {
        Order newOrder = (Order) otherOrder;
        bool idEquality = (this.Id == newOrder.Id);
        bool descriptionEquality = (this.Details == newOrder.Details);
        return (idEquality && descriptionEquality);
      }
    }

    public static void ClearAll()
    {
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

    public static List<Order> GetAll()
    {
      List<Order> allOrders = new List<Order>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM orders;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int orderId = rdr.GetInt32(0);
        string orderDetails = rdr.GetString(1);
        Order newOrder = new Order(orderDetails, orderId);
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