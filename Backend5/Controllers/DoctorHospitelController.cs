using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Backend5.Models;
using Backend5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Controllers
{
    public class DoctorHospitelController : Controller
    {

        private readonly ApplicationDbContext context;

        public DoctorHospitelController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index(Int32? hospitalId)
        {
            if (hospitalId == null)
            {
                return this.NotFound();
            }

            var hospital = await this.context.Hospitals
                .SingleOrDefaultAsync(x => x.Id == hospitalId);

            if (hospital == null)
            {
                return this.NotFound();
            }

            var items = await this.context.DoctorHospitel
                .Include(h => h.Hospital)
                .Include(h => h.Doctor)
                .Where(x => x.HospitalId == hospital.Id)
                .ToListAsync();
            this.ViewBag.Hospital = hospital;
            return this.View(items);
        }
        //get
        public async Task<IActionResult> Create(Int32? hospitalId)
        {
            if (hospitalId == null)
            {
                return this.NotFound();
            }

            var hospital = await this.context.Hospitals
                .SingleOrDefaultAsync(x => x.Id == hospitalId);

            if (hospital == null)
            {
                return this.NotFound();
            }

            this.ViewBag.Hospital = hospital;
            this.ViewData["DoctorId"] = new SelectList(this.context.Doctors, "Id", "Name");
            this.ViewData["hospitalId"] = new SelectList(this.context.Hospitals, "Id", "Name");
            return this.View(new DoctorHospitel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Int32? hospitalId,DoctorHospitelVM model)
        {
            if (hospitalId == null)
            {
                return this.NotFound();
            }

            var hospital = await this.context.Hospitals
                .SingleOrDefaultAsync(x => x.Id == hospitalId);

            if (hospital == null)
            {
                return this.NotFound();
            }

            if (ModelState.IsValid)
            {
                var doctorhospitel = new DoctorHospitel
                {

                    HospitalId = hospital.Id,
                    DoctorId =model.DoctorId

                };

                this.context.Add(doctorhospitel);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Index", new { hospitalId = hospital.Id });
            }



            this.ViewBag.Hospital = hospital;
            this.ViewData["DoctorId"] = new SelectList(this.context.Doctors, "Id", "Name",model.DoctorId);
            this.ViewData["hospitalId"] = new SelectList(this.context.Hospitals, "Id", "Name",hospital.Id);

            return this.View(model);
          

        }

        // GET: HospitalLabs/Delete/5
        public async Task<IActionResult> Delete(Int32? hospitalId, Int32? doctorId)
        {
            if (hospitalId == null || doctorId == null)
            {
                return this.NotFound();
            }

            var doctorhosptial = await this.context.DoctorHospitel
                .Include(h => h.Hospital)
                .Include(h => h.Doctor)
                .SingleOrDefaultAsync(m => m.HospitalId == hospitalId && m.DoctorId == doctorId);

            if (doctorhosptial == null)
            {
                return this.NotFound();
            }

            return this.View(doctorhosptial);
        }

        // POST: HospitalLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 hospitalId, Int32 doctorId)
        {
            var doctorHospitel = await this.context.DoctorHospitel.SingleOrDefaultAsync(m => m.HospitalId == hospitalId && m.DoctorId == doctorId);
            this.context.DoctorHospitel.Remove(doctorHospitel);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction("Index", new { hospitalId = hospitalId });
        }
    }
}

  