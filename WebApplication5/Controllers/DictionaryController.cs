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
        static public Dictionary<int, string> DictList = new Dictionary<int, string>();
        public ActionResult Index()
        {
            return View();
        }
        //add stuff to the dictionary
        public ActionResult Add2Dictionary()
        {
            string Tstring = "New Entry " + (DictList.Count + 1);
            DictList.Add(DictList.Count, Tstring);
            Tstring = "New Entry " + DictList.Count;
            ViewBag.localButton = Tstring;
            return View("Index");
        }
        //add a big list to the dictionary
        public ActionResult AddBiglist()
        {
            int bigBumber = 1000;
            string Bstring = bigBumber + " items were added.";
            for (int i = 0; i <= bigBumber; i++)
            {
                Add2Dictionary();
            };
            ViewBag.localButton = Bstring;
            return View("Index");
        }
        //displays the dictionary on the webpage
        public ActionResult Display()
        {
            string Bstring = 1000 + "Dictionary...";
            if (DictList.Count > 0)
            {
                foreach (var item in DictList)
                {
                    Bstring += "Key: " + item.Key + " Value: " + item.Value;
                };
            }
            else
            {
                Bstring = "EMPTY DICTIONARY!!!";
            }
            ViewBag.localButton = Bstring;
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
                DictList.Remove(1);
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

                Hole = "You found a Dictionary!" + DictList[0];
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