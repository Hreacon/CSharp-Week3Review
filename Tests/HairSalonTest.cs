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
       Stylist.DeleteAll();
     }
     
     [Fact]
     public void StylistHoldsName()
     {
       Stylist tamra = new Stylist("Tamra");
     }
     [Fact]
     public void StylistDBIsEmptyAtStart()
     {
       Assert.Equal(0, Stylist.GetAll().Count);
     }
  }
}
