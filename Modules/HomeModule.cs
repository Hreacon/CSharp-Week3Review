using Nancy;
using HairSalonNS.Objects;
using System.Collections.Generic;
using System;
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
        int id = int.Parse(x.id);
        Console.WriteLine("Viewing stylist: id " + id);
        Stylist s = Stylist.Find(id);
        Console.WriteLine(s.GetName());
      return View["viewStylist.cshtml", s];
      };
      Get["/stylist/{id}/client/{cid}/delete"] = x => {
        Client delete = Client.Find(int.Parse(x.cid));
        delete.Delete();
        return View["viewStylist.cshtml", Stylist.Find(int.Parse(x.id))];
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
      Get["/nuke"] = _ => {
        Stylist.DeleteAll();
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
      Post["/client/find"] = _ => {
        try {
          string name = Request.Form["name"];
          int id = Client.Find(name).GetStylistId();
          Console.WriteLine("ID " + id);
          if(id > 0)
            return View["viewStylist.cshtml", Stylist.Find(id)];
        } catch(Exception e) {}
        
        return View["viewStylists.cshtml", Stylist.GetAll()];
      };
    }
  }
}
