using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using tFX_tool.Models;

namespace tFX_tool.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Register() // add view for registration (create)
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult SaveRegistrationDetails(User registerUser) // class that has all the ppties/data (eg get set) in the db and the parameter n can be found in model.tt
        {
            if (ModelState.IsValid)  //If the model state is valid i.e the form values passed the validation then we are storing d user's details in DB
            {
                using (tfxConstringWebConfig db = new tfxConstringWebConfig()) //constring to web config set in the model, d class can be found in model.contxt.cs

                {
                    //save all the details in registeruser object
                    db.Users.Add(registerUser); //Users is the table name in d DB n registeruser is d object used to save it in d db
                    db.SaveChanges();
                }
                ViewBag.Message = "You have successfully register with us, use the login link to continue on the tFX Tool";
                return View("SuccessSaveRegistrationDetails"); // add this view page for redirect  (successful registration)
            }
            else
            {
                //if the validation fails, we are returning the model object with errors to d view, whc will dislay error msgs.
                return View("Register", registerUser);
            }
        }

        public ActionResult Login() //add this view
        {
            return View();
        }

        //The login form is posted to this method
        [HttpPost]
        public ActionResult Login(User theuser)
        {
            //checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {
                // validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(theuser);

                //if useris valid n present in db, we are redirecting it to welcome page
                if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(theuser.Email, false);
                    return RedirectToAction("index");
                }
                else
                {
                    //ifthe username n password combination is not present indb then error msg is shown
                    ModelState.AddModelError("Faiure", "Wrong Username and Password Combination !");
                    return View();
                }
            }
            else
            {
                //if model state is not valid, the model with error message is returned to the view
                return View(theuser);
            }
        }
    
        //function to check if user is valid or not
        public User IsValidUser(User theuser)
        {
            using (var dataContext = new tfxConstringWebConfig())
            {
                //Retrieving the user details from db based on username and password enetered by the user
                User user = dataContext.Users.Where(query => query.Username.Equals(theuser.Username) && query.Password.Equals(theuser.Password)).SingleOrDefault();

                //if user is present, then true is returned.
                if (user == null)
                    return null;
                //if user is not present false is returned.
                else
                    return user;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); //it will clear the session at the end of request
            return RedirectToAction("Index");
        }
        // GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: User/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
