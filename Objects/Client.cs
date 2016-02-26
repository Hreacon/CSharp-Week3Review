using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonNS.Objects
{
  public class Client : DBHandler
  { 
    private int _id;
    private string _name;
    private int _stylistId;
    private List<string> _columns;
    public static string Table = "clients";
    private static string NameColumn = "name";
    private static string StylistIdColumn = "stylist_id";
    
    public Client(string name, int stylistId, int id = 0)
    {
      _name = name;
      _id = id;
      _columns = new List<string> { NameColumn, StylistIdColumn };
    }
    
    public int GetId() { return _id; }
    public string GetName() { return _name; }
    public void SetName(string name) { _name = name; }
    public int GetStylistId() { return _stylistId; }
    public void SetStylistId(int newStylistId) { _stylistId = newStylistId; }
    
    public void Save()
    {
      List<SqlParameter> parameters = new List<SqlParameter> { 
        new SqlParameter("@"+NameColumn, GetName()),
        new SqlParameter("@"+StylistIdColumn, GetStylistId())
        };
      int id = base.Save(Client.Table, _columns, parameters, _id);
      if(_id == 0)
        _id = id;
    }
    public void Delete()
    {
      if(_id > 0)
      {
        DBHandler.Delete(Client.Table, _id);
      }
    }
    public static Client Find(int id)
    {
      string query = "WHERE id = @id";
      List<SqlParameter> parameters = new List<SqlParameter> { new SqlParameter("@id", id) };
      return (Client) DBHandler.GetObjectFromDB(Client.Table, query, MakeObject, parameters);
    }
    public static List<Client> GetAll()
    {
      List<Client> output = new List<Client>{};
      foreach(Object o in DBHandler.GetAll(Client.Table, MakeObject))
      {
        output.Add((Client)o);
      }
      return output;
    }
    public static void DeleteAll()
    {
      DBHandler.DeleteAll(Client.Table);
    }
    // helper functions
    public static Object MakeObject(SqlDataReader rdr)
    {
      return new Client(rdr.GetString(1), rdr.GetInt32(2), rdr.GetInt32(0));
    }
    public override bool Equals(System.Object other)
    {
      bool output = false;
      if(!(other is Client))
      {
        output = false;
      } else {
        Client otherClient = (Client) other;
        output = GetName() == otherClient.GetName();
      }
      return output;
    }
  } // end class
} // end namespace
