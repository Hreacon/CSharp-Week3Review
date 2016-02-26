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
    public void SetName(string name) { _name = name; }
    
    public void Save()
    {
      List<SqlParameter> parameters = new List<SqlParameter> { new SqlParameter("@"+NameColumn, GetName())};
      int id = base.Save(Stylist.Table, _columns, parameters, _id);
      if(_id == 0)
        _id = id;
    }
    public void Delete()
    {
      if(_id > 0)
      {
        DBHandler.Delete(Stylist.Table, _id);
      }
    }
    public static Stylist Find(int id)
    {
      string query = "WHERE id = @id";
      List<SqlParameter> parameters = new List<SqlParameter> { new SqlParameter("@id", id) };
      return (Stylist) DBHandler.GetObjectFromDB(Stylist.Table, query, MakeObject, parameters);
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
      DBHandler.DeleteAll(Stylist.Table);
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
