using Rolls.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rolls.Controllers
{
    public class RollsController : Controller
    {
        private RollsContext _dbContext;
        
        public RollsController(RollsContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Index()
        {
            List<Roll> rolls;
            rolls = _dbContext.Rolls.ToList();
            return View(rolls);
        }
        
        public IActionResult Store()
        {
            var name = Request.Form["name"];
            var random = new Random();
            var value = random.Next(0, 100);
            
            var roll = new Roll
            {
                Name = name,
                Value = value
            };
            
           _dbContext.Rolls.Add(roll);
           _dbContext.SaveChanges();
           
           return RedirectToAction("Index");
        }
    }
}