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
      Post["/viewStylist"] = _ => {
        new Stylist(Request.Form["name"]).Save();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
    }
  }
}
