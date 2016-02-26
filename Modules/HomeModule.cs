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
      Get["/stylist/{id}/client/{cid}/delete"] = x => {
        Client delete = Client.Find(int.Parse(x.cid));
        delete.Delete();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
      Get["/stylist/{id}/delete"] = x => {
        Stylist delete = Stylist.Find(int.Parse(x.id));
        delete.Delete();
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
      Get["/stylist/{id}/edit"] = x => {
        return View["editStylist.cshtml", Stylist.Find(int.Parse(x.id))];
      };
      Get["/stylist/{id}/client/{cid}/edit"] = x => {
        return View["editClient.cshtml", Client.Find(int.Parse(x.cid))];
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
      Post["/stylist/update"] = _ => {
        Stylist edit = Stylist.Find(int.Parse(Request.Form["id"]));
        edit.SetName(Request.Form["name"]);
        edit.Save();
        return View["viewStylist.cshtml", edit];
      };
      Post["/stylist/client/update"] = _ => {
        Client edit = Client.Find(int.Parse(Request.Form["id"]));
        edit.SetName(Request.Form["name"]);
        edit.Save();
        return View["viewStylist.cshtml", Stylist.Find(edit.GetStylistId())];
      };
    }
  }
}
