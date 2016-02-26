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
        return View["header.cshtml"];
      };
    }
  }
}
