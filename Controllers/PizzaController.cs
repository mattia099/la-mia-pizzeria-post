using la_mia_pizzeria_razor_layout.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_razor_layout.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizza.ToList();
                return View(pizzas);
            }
        }
        public IActionResult Detail(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza pizzaFound = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();
                if(pizzaFound == null)
                {
                    return View("Error");
                }
                else
                {
                return View("Detail",pizzaFound);
                }
            }
        }
    }
}
