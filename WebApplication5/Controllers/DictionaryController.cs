using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class DictionaryController : Controller
    { 
        // GET: Dictionary
        static public Dictionary<string, int> DictList = new Dictionary<string, int>();
        public ActionResult Index()
        {
            return View();
        }
        //add stuff to the dictionary
        public ActionResult Add2Dictionary()
        {
            string Tstring = "New Entry " + (DictList.Count + 1);
            DictList.Add(Tstring, DictList.Count);
            string displayString = "Added: New Entry " + DictList.Count;
            ViewBag.localButton = displayString;
            return View("Index");
        }
        //add a big list to the dictionary
        public ActionResult AddBiglist()
        {
            int bigNumber = 1000;
            string Bstring = bigNumber + " items were added (Click Display to see your dictionary).";

            for (int iCount = 0; iCount <= bigNumber; iCount++)
            {
                Add2Dictionary();
            };

            ViewBag.localButton = Bstring;
            return View("Index");
        }
        //displays the dictionary on the webpage
        public ActionResult Display()
        {
            string webDisplay = "Your Dictionary Contains:" + "<br>";

            if (DictList.Count > 0)
            { //displays the key and value
                foreach (var item in DictList)
                {
                    webDisplay += "Key: " + item.Key + " Value: " + item.Value + "<br>";
                };
            }
            else
            { //if it's empty displays a message
                webDisplay = "EMPTY DICTIONARY!!!";
            }

            ViewBag.localButton = webDisplay;
            return View("Index");
        }

        public ActionResult DeleteDictionary()
        {
            string Item1 = "An item was deleted, but which one?";
            if (DictList.Count == 0)
            {
                Item1 = "You don't have any items in your dictionary... Please add an item instead of trying to delete from nothing.";
            }
            else
            {
                DictList.Remove("New Entry 1");
            }
            ViewBag.localButton = Item1;
            return View("Index");
        }

        public ActionResult Clear()
        {
            string DictClear = "Your Dictionary is clear now.";

            DictList.Clear();
            ViewBag.localButton = DictClear;
            return View("Index");

        }
        public ActionResult Search()
        {
            string Hole;
            if (DictList.Count > 0)
            {

                Hole = "You found a Dictionary!" + DictList["New Entry 1"];
            }
            else
            {
                Hole = "This is empty. Please add something to the dictionary before trying to search. " + DictList.Count;
            }
            ViewBag.localButton = Hole;
            return View("Index");
        }
        public ActionResult Menu()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}