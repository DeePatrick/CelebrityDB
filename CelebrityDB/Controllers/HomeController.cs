using CelebrityDB.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CelebrityDB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int PageSize = 6;
        // GET: Home
        public ActionResult Index(string searchBy, string search, int page = 1)
        {
            if (searchBy == "Gender")
            {
                return View(db.Celebrities.Where(x => x.Gender == search || search == null)
                    .OrderBy(x => x.StageName)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList());
            }
            else
            {
                return View(db.Celebrities.Where(x => x.StageName.StartsWith(search) || search == null)
                     .OrderBy(x => x.StageName)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList());
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RealName,StageName,Race,AgeCategory,BodyShape,HeightCategory,Hobbies,Quotes,Gender,EmployeePicture,EmployeeFullPicture")] Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Celebrities.Add(celebrity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(celebrity);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RealName,StageName,Race,AgeCategory,BodyShape,HeightCategory,Hobbies,Quotes,Gender,EmployeePicture,EmployeeFullPicture")] Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celebrity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(celebrity);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celebrity celebrity = db.Celebrities.Find(id);
            if (celebrity == null)
            {
                return HttpNotFound();
            }
            return View(celebrity);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Celebrity celebrity = db.Celebrities.Find(id);
            db.Celebrities.Remove(celebrity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
