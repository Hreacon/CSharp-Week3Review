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
    
    public static void DeleteAll()
    {
      
    }
  } // end class
} // end namespace
