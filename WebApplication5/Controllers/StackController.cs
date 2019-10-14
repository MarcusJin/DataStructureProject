using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class StackController : Controller
    {
        static public Stack<string> MyStack = new Stack<string>();
        string msg = "Success";
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = MyStack;
            return View();
        }
        public ActionResult AddOne()
        {
            MyStack.Push("New Entry " + (MyStack.Count + 1));

            ViewBag.MyStack = msg;
            return View("Index");
        }

        public ActionResult AddHuge()
        {
            MyStack.Clear();

            int i = 0;

            while (i < 2000)
            {
                MyStack.Push("New Entry " + (MyStack.Count + 1));
                i++;
            }
            ViewBag.MyStack = msg;
            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyStack = MyStack;
            return View("Index");

        }

        public ActionResult Delete()
        {
            string stringToFind = "An item was deleted, but which one?";
            if (MyStack.Count == 0)
            {
                stringToFind = "Stack is Empty";
            }
            else
            {
                MyStack.Pop();
            }
            ViewBag.MyStack = stringToFind;
            return View("Index");

        }

        public ActionResult Clear()
        {
            ViewBag.Title = "Stack";
            MyStack.Clear();
            ViewBag.MyStack = MyStack;
            return View("Index");
        }

        public ActionResult Search()
        {
            string line;
            if (MyStack.Count > 0)
            {
                line = "You found the stack!>>" + MyStack.Peek();
            }
            else
            {
                line = "you do not have any Dictionaries Count is.." + MyStack.Count;
            }
            ViewBag.MyStack = line;
            return View("Index");
        }
        public ActionResult Menu()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
