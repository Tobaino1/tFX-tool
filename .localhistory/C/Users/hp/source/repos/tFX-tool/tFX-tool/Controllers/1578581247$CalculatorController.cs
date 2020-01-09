using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tFX_tool.Controllers
{
    //    
    // GET: /Home/    
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index(AdditionViewModel model, string command)
    {
        if (command == "add")
        {
            model.Result = model.A + model.B;
        }
        if (command == "sub")
        {
            model.Result = model.A - model.B;
        }
        if (command == "mul")
        {
            model.Result = model.A * model.B;
        }
        if (command == "div")
        {
            model.Result = model.A / model.B;
        }
        return View(model);
    }
}    
        
    
}
