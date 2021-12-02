/*
 * PROG3170 Assignment3
 * Yumi Lee, Nov 19,2021
 */
using ClientApplication.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            LMSServicesClient client = new LMSServicesClient();
            IEnumerable<Genre> genres = client.GetAllGenre().ToList();
            return View(genres);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LMSServicesClient client = new LMSServicesClient();
            Genre genre = client.GetGenre(int.Parse(id));
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LMSServicesClient client = new LMSServicesClient();
            Genre genre = client.GetGenre(int.Parse(id));
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genrePara)
        {
            Genre genre = new Genre();
            genre.GenreID = genrePara.GenreID;

            LMSServicesClient client = new LMSServicesClient();

            if (client.DeleteGenre(genre.GenreID) <= 0)
            {
                return View(genre);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genrePara)
        {
            Genre genre = new Genre();
            //genre.GenreID = genrePara.GenreID;
            genre.GenreName = genrePara.GenreName;

            LMSServicesClient client = new LMSServicesClient();

            if (client.CreateGenre(genre) <= 0)
            {
                return View(genre);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }




        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LMSServicesClient client = new LMSServicesClient();
            Genre genre = client.GetGenre(int.Parse(id));
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genrePara)
        {
            Genre genre = new Genre();
            genre.GenreID = genrePara.GenreID;
            genre.GenreName = genrePara.GenreName;

            LMSServicesClient client = new LMSServicesClient();

            if (client.EditGenre(genre) <= 0)
            {
                return View(genre);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }




    }
}