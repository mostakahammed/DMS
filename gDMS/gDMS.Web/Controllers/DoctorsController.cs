using gDMS.Web.Data;
using gDMS.Web.Models;
using gDMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gDMS.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DmsDbContext _context;

        public DoctorsController()
        {
            _context = new DmsDbContext();
        }
        // GET: Doctors
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDoctors()
        {
            List<DoctorViewModel> docList = _context.Doctors.Select(x => new DoctorViewModel
            {
                DoctorID = x.DoctorID,
                DoctorName = x.DoctorName,
                DoctorDegree = x.DoctorDegree,
                DoctorAddress = x.DoctorAddress,
                DoctorPhone = x.DoctorPhone,
                IsActive = x.IsActive
            }).ToList();
            return Json(docList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateDoctor(DoctorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Doctor objToCreate = new Doctor()
                    {
                        DoctorName = model.DoctorName,
                        DoctorDegree = model.DoctorDegree,
                        DoctorAddress = model.DoctorAddress,
                        DoctorPhone = model.DoctorPhone,
                        IsActive = model.IsActive
                    };

                    _context.Doctors.Add(objToCreate);
                    _context.SaveChanges();
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult DeleteDoctor(int DoctorID)
        {
            try
            {
                var objToDelete = _context.Doctors.Where(x => x.DoctorID == DoctorID).FirstOrDefault();
                _context.Doctors.Remove(objToDelete);
                _context.SaveChanges();

                return Json(objToDelete, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDoctorByID(int DoctorID)
        {
            try
            {
                var doc = _context.Doctors.Where(x => x.DoctorID == DoctorID).FirstOrDefault();

                return Json(doc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult EditDoctor(DoctorViewModel model)
        {
            try
            {
                var objToUpdate = _context.Doctors.Where(x => x.DoctorID == model.DoctorID).FirstOrDefault();

                objToUpdate.DoctorID = model.DoctorID;
                objToUpdate.DoctorName = model.DoctorName;
                objToUpdate.DoctorDegree = model.DoctorDegree;
                objToUpdate.DoctorAddress = model.DoctorAddress;
                objToUpdate.DoctorPhone = model.DoctorPhone;
                objToUpdate.IsActive = model.IsActive;

                _context.SaveChanges();

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}