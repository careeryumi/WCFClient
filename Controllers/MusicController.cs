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
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index()
        {
            LMSServicesClient client = new LMSServicesClient();
            IEnumerable<Music> musics = client.GetAllMusic().ToList();
            return View(musics);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LMSServicesClient client = new LMSServicesClient();
            Music music = client.GetMusic(int.Parse(id));
            if (music == null)
            {
                return HttpNotFound();
            }

            return View(music);
        }



        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            LMSServicesClient client = new LMSServicesClient();
            Music music = client.GetMusic(int.Parse(id));
            if (music == null)
            {
                return HttpNotFound();
            }

            return View(music);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Music musicPara)
        {
            Music music = new Music();
            music.MusicID = musicPara.MusicID;

            LMSServicesClient client = new LMSServicesClient();

            if (client.DeleteMusic(music.MusicID) <= 0)
            {
                return View(music);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }





        // GET: Create
        public ActionResult Create()
        {
            LMSServicesClient client = new LMSServicesClient();
            IEnumerable<Genre> genre = client.GetAllGenre().ToList();

            ViewBag.genreSelection = new SelectList(genre, "GenreID", "GenreName");

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Music musicPara)
        {
            Music music = new Music();
            music.MusicName = musicPara.MusicName;
            music.GenreID = musicPara.GenreID;

            LMSServicesClient client = new LMSServicesClient();

            if (client.CreateMusic(music) <= 0)
            {
                return View(music);
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
            Music music = client.GetMusic(int.Parse(id));
            if (music == null)
            {
                return HttpNotFound();
            }


            IEnumerable<Genre> genre = client.GetAllGenre().ToList();
            ViewBag.genreSelectionListInEdit = new SelectList(genre, "GenreID", "GenreName", music.GenreID);
            //ViewBag.genreSelectionListInEdit = new SelectList(genre, "GenreID", "GenreName");

            return View(music);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Music musicPara)
        {
            Music music = new Music();
            music.MusicName = musicPara.MusicName;
            music.MusicID = musicPara.MusicID;
            music.GenreID = musicPara.GenreID;

            LMSServicesClient client = new LMSServicesClient();

            if (client.EditMusic(music) <= 0)
            {
                return View(music);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


    }
}