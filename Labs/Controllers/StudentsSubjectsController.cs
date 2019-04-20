using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Labs;

namespace Labs.Controllers
{
    public class StudentsSubjectsController : Controller
    {
        private BookstoreEntities db = new BookstoreEntities();

        // GET: StudentsSubjects
        public async Task<ActionResult> Index()
        {
            var studentsSubject = db.StudentsSubject.Include(s => s.Students).Include(s => s.Subjects);
            return View(await studentsSubject.ToListAsync());
        }

        // GET: StudentsSubjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSubject studentsSubject = await db.StudentsSubject.FindAsync(id);
            if (studentsSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsSubject);
        }

        // GET: StudentsSubjects/Create
        public ActionResult Create()
        {
            ViewBag.id_student = new SelectList(db.Students, "id", "firstName");
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name");
            return View();
        }

        // POST: StudentsSubjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,id_student,id_subject")] StudentsSubject studentsSubject)
        {
            if (ModelState.IsValid)
            {
                db.StudentsSubject.Add(studentsSubject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_student = new SelectList(db.Students, "id", "firstName", studentsSubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name", studentsSubject.id_subject);
            return View(studentsSubject);
        }

        // GET: StudentsSubjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSubject studentsSubject = await db.StudentsSubject.FindAsync(id);
            if (studentsSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_student = new SelectList(db.Students, "id", "firstName", studentsSubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name", studentsSubject.id_subject);
            return View(studentsSubject);
        }

        // POST: StudentsSubjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,id_student,id_subject")] StudentsSubject studentsSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsSubject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_student = new SelectList(db.Students, "id", "firstName", studentsSubject.id_student);
            ViewBag.id_subject = new SelectList(db.Subjects, "id", "name", studentsSubject.id_subject);
            return View(studentsSubject);
        }

        // GET: StudentsSubjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsSubject studentsSubject = await db.StudentsSubject.FindAsync(id);
            if (studentsSubject == null)
            {
                return HttpNotFound();
            }
            return View(studentsSubject);
        }

        // POST: StudentsSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentsSubject studentsSubject = await db.StudentsSubject.FindAsync(id);
            db.StudentsSubject.Remove(studentsSubject);
            await db.SaveChangesAsync();
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
