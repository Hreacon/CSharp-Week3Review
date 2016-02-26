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
    private List<string> _columns;
    public static string Table = "stylists";
    private static string NameColumn = "name";
    
    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
      _columns = new List<string> { NameColumn };
    }
    
    public int GetId() { return _id; }
    public string GetName() { return _name; }
    
    public void Save()
    {
      List<SqlParameter> parameters = new List<SqlParameter> { new SqlParameter("@"+NameColumn, GetName())};
      base.Save(Stylist.Table, _columns, parameters, _id);
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
    public override bool Equals(System.Object other)
    {
      bool output = false;
      if(!(other is Stylist))
      {
        output = false;
      } else {
        Stylist otherStylist = (Stylist) other;
        output = GetName() == otherStylist.GetName();
      }
      return output;
    }
  } // end class
} // end namespace
