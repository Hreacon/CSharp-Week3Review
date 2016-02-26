using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonNS.Objects
{
  public class Stylist : DBHandler
  {
    private int _id;
    private string _name;
    public static string Table = "stylists";
    
    public Stylist(string name, int id = 0)
    {
      _name = name;
    }
    
    public static List<Stylist> GetAll()
    {
      List<Stylist> output = new List<Stylist>{};
      foreach(Object o in DBHandler.GetAll(Stylist.Table, MakeObject))
      {
        output.Add((Stylist)o);
      }
      return output;
    }
    public static void DeleteAll()
    {
      
    }
    // helper functions
    public static Object MakeObject(SqlDataReader rdr)
    {
      return new Stylist(rdr.GetString(1), rdr.GetInt32(0));
    }
  } // end class
} // end namespace
