using Nancy;
using HairSalonNS.Objects;
using System.Collections.Generic;
namespace HairSalonNS
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
      Get["/stylist/{id}"] = x => {
        return View["viewStylist.cshtml", Stylist.Find(int.Parse(x.id))];
      };
      Post["/addStylist"] = _ => {
        new Stylist(Request.Form["name"]).Save();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
    }
  }
}
