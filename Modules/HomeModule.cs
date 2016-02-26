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
      Get["/stylist/{id}/delete"] = x => {
        Stylist delete = Stylist.Find(int.Parse(x.id));
        delete.Delete();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
      Post["/stylist/{id}/addClient"] = x => {
        int id = int.Parse(x.id);
        new Client(Request.Form["name"], id).Save();
        return View["viewStylist.cshtml", Stylist.Find(id)];
      };
      Post["/addStylist"] = _ => {
        new Stylist(Request.Form["name"]).Save();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
    }
  }
}
