using Xunit;
using HairSalonNS.Objects;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonNS
{
  public class HairSalonTest : IDisposable
  {
    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll(); // delete all
    }
    
    [Fact]
    public void StylistHoldsName()
    {
      Stylist tamra = new Stylist("Tamra");
    }
    [Fact]
    public void StylistDBIsEmptyAtStart() // read
    {
      Assert.Equal(0, Stylist.GetAll().Count);
    }
    [Fact]
    public void StylistSavesToDB() // create
    {
      Stylist test = new Stylist("Test");
      test.Save();
      Assert.Equal(test, Stylist.GetAll()[0]);
    }
    [Fact]
    public void StylistUpdatesDatabase() // update
    {
      Stylist test = new Stylist("Test");
      test.Save();
      test.SetName("Tester");
      test.Save();
      Assert.Equal("Tester", Stylist.GetAll()[0].GetName());
    }
    [Fact]
    public void StylistDeletesSingleRow() // delete single
    {
      Stylist test = new Stylist("test");
      test.Save();
      Assert.Equal(1, Stylist.GetAll().Count);
      test.Delete();
      Assert.Equal(0, Stylist.GetAll().Count);
    }
  }
}
