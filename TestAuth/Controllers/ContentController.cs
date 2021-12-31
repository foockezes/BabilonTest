using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TestAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using DotNetOpenAuth.InfoCard;

namespace TestAuth.Controllers
{
    public class ContentController : Controller
    {
        private readonly DBContext db;

        public ContentController(DBContext context)
        {
            db = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var contents = db.Contents.Include(p => p.User);
            return View(await contents.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Content content)
        {
            Content content1 = new Content()
            {
                Id = Guid.NewGuid(),
            };
            if (ModelState.IsValid)
            {
                db.Add(content1);
                await db.SaveChangesAsync();
                return RedirectToAction(controllerName: "Home", actionName: "index");
            }
            return View(content);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();


            var forEdit = await db.Contents.FindAsync(id);
            if (forEdit == null)
                return NotFound();


            Content content1 = new Content()
            {
                Id = forEdit.Id,

            };

            return View(content1);
        }

        

        [HttpPost]
        public async Task<IActionResult> Edit(Guid? id, Content content)
        {
            if (!ModelState.IsValid)
                return View(content);

            Content content1 = db.Contents.Find(id);

            try
            {
                db.Update(content1);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var forDel = await db.Contents.FindAsync(id);
            if (forDel == null)
            {
                return RedirectToAction("Index");
            }
            db.Contents.Remove(forDel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Adreses()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getById = await db.Contents
                .Include(p => p.User)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (getById == null)
            {
                return NotFound();
            }

            return View(getById);
        }
        private async Task<bool> IsAllowedToChange(string contentId, string userID)
        {
            Content content = await db.Contents.FindAsync(Guid.Parse(contentId));

            if (content == null)
                throw new Exception("Project not found");

            return content.UserId.ToString() == userID || User.IsInRole("admin");
        }
    }
}
