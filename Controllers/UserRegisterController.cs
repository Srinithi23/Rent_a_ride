using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_a_ride.Controllers
{
    public class UserRegisterController : Controller
    {

        RentaRidedbEntities2 db = new RentaRidedbEntities2();

        // GET: UserRegister
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Register(Register reg)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Registers.Add(reg);
                    db.SaveChanges();
                    return View("Login");
                }
                catch (Exception)
                {
                    ViewBag.Messageone("Registration not successful");
                    // Response.Write("<script>alert(\"an error occur while registration\")</script>");
                    return RedirectToAction("Register", "UserController");
                }
            }

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }





        [HttpPost]
        public ActionResult Login(Register ui)
        {
          
                try
                {
                    Register u = db.Registers.Where(x => x.Username == ui.Username && x.Userpassword == ui.Userpassword).SingleOrDefault();
                    Session["UserID"] = u.UserID;
                    if (u.role == "Admin")
                    {
                        //  Session["UserID"] = u.UserID;

                        //if (Session["UserID"] == null)
                        //{
                        //    return RedirectToAction("Login");
                        //}
                        return RedirectToAction("Index", "Customers");
                    }
                    else
                    {
                        return RedirectToAction("Index", "CarRegisters");
                        //ViewBag.Message = "Invalid Password or Email Id";
                    }

                }

                catch (Exception e)
                {
                    ViewBag.ErrorMessage = "Please select an option" + e.Message;
                    return RedirectToAction("Register");
                }


        }


            public ActionResult Logout()
            {
                Session.Abandon();
                Session.RemoveAll();
                return RedirectToAction("Register");
            }

        }
    }
