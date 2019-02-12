using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quoting_dojo.Models;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult Add(Quote aquote){
            if(ModelState.IsValid){
                string query = $@"INSERT INTO quotes (author, quote) 
                VALUES ('{aquote.Author}', '{aquote.Content}')";
                Console.WriteLine("QUERY INSERTED " + query);
                DbConnector.Execute(query);

                return RedirectToAction("Quotes");
            }
            else{
                foreach(var error in ModelState)
                {
                    if (error.Value.Errors.Count > 0)
                    {
                        TempData["err"] = error.Value.Errors[0].ErrorMessage;
                        Console.WriteLine("TEMPDATA " + TempData["err"]);
                    }
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet("quotes")]
        public IActionResult Quotes(){
            List<Dictionary<string, object>> allQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.quotes = allQuotes;

            return View("Quotes");
        }
    }
}
