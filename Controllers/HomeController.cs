﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "ListeAvis":
                        return View(id, new OpinionList().GetAvis("XlmFile/DataAvis.xml"));
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            if(model.Genre == "Default")
            {
                ModelState.AddModelError("Genre", "Genre requis");
            }

            if (model.CodePostal == null)
            {
                ModelState.AddModelError("CodePostal", "Code postal requis");
            }

            if (model.DateDebut == null)
            {
                ModelState.AddModelError("DateDebut", "La date de début de formation est requise.");
            }

            if (model.TypeFormation == "Default")
            {
                ModelState.AddModelError("TypeFormation", "Sélectionner une formation");
            }

            if (ModelState.IsValid)
            {
                return View(model);

            }
            return View("Form");
        }
    }
}