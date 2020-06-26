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
    public class PatientDoctorController : Controller
    {
        private readonly ApplicationDbContext context;

        public PatientDoctorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(Int32? doctorId)
        {
            if (doctorId == null)
            {
                return this.NotFound();
            }
            var doctor = await this.context.Doctors.SingleOrDefaultAsync(x => x.Id == doctorId);

            if (doctor == null)
            {
                return this.NotFound();
            }

            var items = await this.context.DoctorPatients
                .Include(h => h.Doctor)
                .Include(h => h.Patient)
                .Where(x => x.DoctorId == doctor.Id)
                .ToListAsync();
            this.ViewBag.doctor = doctor;
            return this.View(items);

        }
        public async Task<IActionResult> Create(Int32? doctorId)
        {
            if (doctorId == null)
            {
                return this.NotFound();
            }

            var doctor = await this.context.Doctors
                .SingleOrDefaultAsync(x => x.Id == doctorId);

            if (doctor == null)
            {
                return this.NotFound();
            }

            this.ViewBag.Doctor = doctor;
            this.ViewData["DoctorId"] = new SelectList(this.context.Doctors, "Id", "Name");
            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Name");
            return this.View(new DoctorPatient());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Int32? DoctorId, DoctorPatientVM model)
        {
            if (DoctorId == null)
            {
                return this.NotFound();
            }

            var doctor = await this.context.Doctors
                .SingleOrDefaultAsync(x => x.Id == DoctorId);

            if (doctor == null)
            {
                return this.NotFound();
            }

            if (ModelState.IsValid)
            {
                var doctorPatient = new DoctorPatient
                {

                    DoctorId = doctor.Id,
                    PatientId = model.PatientId

                };

                this.context.Add(doctorPatient);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Index", new { DoctorId = doctor.Id });
            }



            this.ViewBag.Doctor = doctor;
            this.ViewData["DoctorId"] = new SelectList(this.context.Doctors, "Id", "Name", doctor.Id);
            this.ViewData["PatientId"] = new SelectList(this.context.Patients, "Id", "Name",model.PatientId);

            return this.View(model);


        }
        // GET: HospitalLabs/Delete/5
        public async Task<IActionResult> Delete(Int32? patientId, Int32? doctorId)
        {
            if (patientId == null || doctorId == null)
            {
                return this.NotFound();
            }

            var doctorPatient = await this.context.DoctorPatients
                .Include(h => h.Patient)
                .Include(h => h.Doctor)
                .SingleOrDefaultAsync(m => m.PatientId == patientId && m.DoctorId == doctorId);

            if (doctorPatient == null)
            {
                return this.NotFound();
            }

            return this.View(doctorPatient);
        }

        // POST: HospitalLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 patientId, Int32 doctorId)
        {
            var doctorPatient = await this.context.DoctorPatients.SingleOrDefaultAsync(m => m.PatientId == patientId && m.DoctorId == doctorId);
            this.context.DoctorPatients.Remove(doctorPatient);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction("Index", new { patientId = patientId });
        }
    }

}
