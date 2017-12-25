using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        ContactDBController _db = new ContactDBController();

        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Contacts = _db.Get();

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                string[] ids = collection["contactIDs"].Split(new char[] { ',' });

                foreach (string id in ids)
                {
                    _db.Delete(Convert.ToInt32(id));
                }
            }

            catch(NullReferenceException) {}

            return RedirectToAction("Index");
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            SelectList sexes = new SelectList(Sexes.Get());

            ViewBag.Sexes = sexes;

            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Models.Contact contact)
        {
            try
            {
                _db.Post(contact);

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Models.Contact contact = _db.Get(id);

            if (contact == null)
            {
                return HttpNotFound();

            }

            SelectList sexes = new SelectList(Sexes.Get());

            ViewBag.Sexes = sexes;

            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.Contact contact)
        {
            try
            {
                _db.Put(contact, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
