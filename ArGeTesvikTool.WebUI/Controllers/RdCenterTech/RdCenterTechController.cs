using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterTech;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterTech
{
    public class RdCenterTechController : BaseController
    {
        private readonly IRdCenterTechCollaborationService _collaborationService;
        private readonly IRdCenterTechAcademicLibraryService _academicLibraryService;
        private readonly IRdCenterTechAttendedEventService _attendedEventService;

        public RdCenterTechController(IRdCenterTechCollaborationService collaborationService, IRdCenterTechAcademicLibraryService academicLibraryService, IRdCenterTechAttendedEventService attendedEventService)
        {
            _collaborationService = collaborationService;
            _academicLibraryService = academicLibraryService;
            _attendedEventService = attendedEventService;
        }

        public IActionResult CompletedProject()
        {
            return View();
        }

        public IActionResult OngoingProject()
        {
            return View();
        }

        #region Collaboration CRUD
        public IActionResult Collaboration()
        {
            List<RdCenterTechCollaborationDto> collaborationList = _collaborationService.GetAll();

            RdCenterTechCollabrationViewModel collaborationViewModel = new()
            {
                CollaborationList = collaborationList
            };

            return View(collaborationViewModel);
        }
        public IActionResult CollaborationCreate()
        {
            RdCenterTechCollaborationDto collaboration = new();

            RdCenterTechCollabrationViewModel collaborationViewModel = new()
            {
                NewCollaboration = collaboration
            };

            return PartialView("PartialView/CollaborationPartialView", collaborationViewModel);
        }

        public IActionResult CollaborationUpdate(int id)
        {
            var collaboration = _collaborationService.GetById(id);

            ViewBag.Country = collaboration.CountryCode;

            RdCenterTechCollabrationViewModel collaborationViewModel = new()
            {
                NewCollaboration = collaboration
            };

            return PartialView("PartialView/CollaborationPartialView", collaborationViewModel);
        }

        public IActionResult CollaborationDelete(int id)
        {
            _collaborationService.Delete(id);

            AddSuccessMessage("Ulusal/Uluslararası işbirliği kaydı silindi.");

            return RedirectToAction("Collaboration");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Collaboration(RdCenterTechCollabrationViewModel collaborationViewModel)
        {
            var collaboration = _collaborationService.GetById(collaborationViewModel.NewCollaboration.Id);
            if (collaboration == null)
            {
                collaborationViewModel.NewCollaboration.CreatedDate = DateTime.Now;
                collaborationViewModel.NewCollaboration.CreatedUserName = User.Identity.Name;

                _collaborationService.Add(collaborationViewModel.NewCollaboration);

                AddSuccessMessage("Ulusal/Uluslararası işbirliği kaydı eklendi.");
            }
            else
            {
                collaborationViewModel.NewCollaboration.Id = collaboration.Id;
                collaborationViewModel.NewCollaboration.Year = collaboration.Year;
                collaborationViewModel.NewCollaboration.CreatedDate = collaboration.CreatedDate;
                collaborationViewModel.NewCollaboration.CreatedUserName = collaboration.CreatedUserName;
                collaborationViewModel.NewCollaboration.ModifiedDate = DateTime.Now;
                collaborationViewModel.NewCollaboration.ModifedUserName = User.Identity.Name;

                _collaborationService.Update(collaborationViewModel.NewCollaboration);

                AddSuccessMessage("Ulusal/Uluslararası işbirliği kaydı güncellendi.");
            }

            return Redirect("Collaboration");
        }
        #endregion

        public IActionResult AcademicLibrary(int id)
        {
            var academicLibrary = _academicLibraryService.GetByYear(id);

            RdCenterTechAcademicLibraryViewModel academicLibraryViewModel = new()
            {
                AcademicLibrary = academicLibrary
            };

            return View(academicLibraryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcademicLibrary(RdCenterTechAcademicLibraryViewModel academicLibraryViewModel)
        {
            var contact = _academicLibraryService.GetByYear(academicLibraryViewModel.AcademicLibrary.Year);
            if (contact == null)
            {
                academicLibraryViewModel.AcademicLibrary.CreatedDate = DateTime.Now;
                academicLibraryViewModel.AcademicLibrary.CreatedUserName = User.Identity.Name;

                _academicLibraryService.Add(academicLibraryViewModel.AcademicLibrary);

                AddSuccessMessage("Bilgi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            academicLibraryViewModel.AcademicLibrary.Year = contact.Year;
            academicLibraryViewModel.AcademicLibrary.CreatedDate = contact.CreatedDate;
            academicLibraryViewModel.AcademicLibrary.CreatedUserName = contact.CreatedUserName;
            academicLibraryViewModel.AcademicLibrary.ModifiedDate = DateTime.Now;
            academicLibraryViewModel.AcademicLibrary.ModifedUserName = User.Identity.Name;
            academicLibraryViewModel.AcademicLibrary.Id = contact.Id;

            _academicLibraryService.Update(academicLibraryViewModel.AcademicLibrary);

            AddSuccessMessage("Bilgi güncellendi.");

            return RedirectToAction("Index", "Home");
        }

        #region AttendedEvent CRUD
        public IActionResult AttendedEvent()
        {
            List<RdCenterTechAttendedEventDto> attendedEventList = _attendedEventService.GetAll();

            RdCenterTechAttendedEventViewModel attendedEventViewModel = new()
            {
                AttendedEventList = attendedEventList
            };

            return View(attendedEventViewModel);
        }

        public IActionResult AttendedEventCreate()
        {
            RdCenterTechAttendedEventDto attendedEvent = new();

            RdCenterTechAttendedEventViewModel attendedEventViewModel = new()
            {
                NewAttendedEvent = attendedEvent
            };

            return PartialView("PartialView/AttendedEventPartialView", attendedEventViewModel);
        }

        public IActionResult AttendedEventUpdate(int id)
        {
            var attendedEvent = _attendedEventService.GetById(id);

            RdCenterTechAttendedEventViewModel attendedEventViewModel = new()
            {
                NewAttendedEvent = attendedEvent
            };

            return PartialView("PartialView/AttendedEventPartialView", attendedEventViewModel);
        }

        public IActionResult AttendedEventDelete(int id)
        {
            _attendedEventService.Delete(id);

            AddSuccessMessage("Katılım sağlanan kongre,konferans kaydı silindi.");

            return RedirectToAction("AttendedEvent");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AttendedEvent(RdCenterTechAttendedEventViewModel attendedEventViewModel)
        {
            var attendedEvent = _attendedEventService.GetById(attendedEventViewModel.NewAttendedEvent.Id);
            if (attendedEvent == null)
            {
                attendedEventViewModel.NewAttendedEvent.CreatedDate = DateTime.Now;
                attendedEventViewModel.NewAttendedEvent.CreatedUserName = User.Identity.Name;

                _attendedEventService.Add(attendedEventViewModel.NewAttendedEvent);

                AddSuccessMessage("Katılım sağlanan kongre,konferans kaydı eklendi.");
            }
            else
            {
                attendedEventViewModel.NewAttendedEvent.Id = attendedEvent.Id;
                attendedEventViewModel.NewAttendedEvent.Year = attendedEvent.Year;
                attendedEventViewModel.NewAttendedEvent.CreatedDate = attendedEvent.CreatedDate;
                attendedEventViewModel.NewAttendedEvent.CreatedUserName = attendedEvent.CreatedUserName;
                attendedEventViewModel.NewAttendedEvent.ModifiedDate = DateTime.Now;
                attendedEventViewModel.NewAttendedEvent.ModifedUserName = User.Identity.Name;

                _attendedEventService.Update(attendedEventViewModel.NewAttendedEvent);

                AddSuccessMessage("Katılım sağlanan kongre,konferans kaydı güncelledi.");
            }

            return Redirect("AttendedEvent");
        }
        #endregion

        public IActionResult Property()
        {
            return View();
        }

        public IActionResult Software()
        {
            return View();
        }
    }
}
