using ArGeTesvikTool.Business.Abstract.RdCenterTech;
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
        private readonly IRdCenterTechSoftwareService _softwareService;
        private readonly IRdCenterTechMentorInfoService _mentorInfoService;
        private readonly IRdCenterTechIntellectualPropertyService _propertyService;
        private readonly IRdCenterTechProjectService _projectService;

        public RdCenterTechController(IRdCenterTechCollaborationService collaborationService, IRdCenterTechAcademicLibraryService academicLibraryService, IRdCenterTechAttendedEventService attendedEventService, IRdCenterTechSoftwareService softwareService, IRdCenterTechMentorInfoService mentorInfoService, IRdCenterTechIntellectualPropertyService propertyService, IRdCenterTechProjectService projectService)
        {
            _collaborationService = collaborationService;
            _academicLibraryService = academicLibraryService;
            _attendedEventService = attendedEventService;
            _softwareService = softwareService;
            _mentorInfoService = mentorInfoService;
            _propertyService = propertyService;
            _projectService = projectService;
        }

        public IActionResult CompletedProject()
        {
            return View();
        }

        #region Project CRUD
        public IActionResult OngoingProject(int year)
        {
            List<RdCenterTechOngoingProjectDto> projectList = _projectService.GetAllByYear(year);

            RdCenterTechOngoingProjectViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }

        public IActionResult ProjectCreate()
        {
            RdCenterTechOngoingProjectDto project = new();

            RdCenterTechOngoingProjectViewModel projectViewModel = new()
            {
                NewProject = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectUpdate(int id)
        {
            var project = _projectService.GetById(id);

            RdCenterTechOngoingProjectViewModel projectViewModel = new()
            {
                NewProject = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectDelete(int id)
        {
            _projectService.Delete(id);

            AddSuccessMessage("Proje kaydı silindi.");

            return RedirectToAction("OngoingProject");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OngoingProject(RdCenterTechOngoingProjectViewModel projectViewModel)
        {
            var project = _projectService.GetById(projectViewModel.NewProject.Id);
            if (project == null)
            {
                projectViewModel.NewProject.CreatedDate = DateTime.Now;
                projectViewModel.NewProject.CreatedUserName = User.Identity.Name;

                _projectService.Add(projectViewModel.NewProject);

                AddSuccessMessage("Yeni proje kaydı eklendi.");
            }
            else
            {
                projectViewModel.NewProject.Id = project.Id;
                projectViewModel.NewProject.Year = project.Year;
                projectViewModel.NewProject.CreatedDate = project.CreatedDate;
                projectViewModel.NewProject.CreatedUserName = project.CreatedUserName;
                projectViewModel.NewProject.ModifiedDate = DateTime.Now;
                projectViewModel.NewProject.ModifedUserName = User.Identity.Name;

                _projectService.Update(projectViewModel.NewProject);

                AddSuccessMessage("Proje kaydı güncelledi.");
            }

            return Redirect("OngoingProject");
        }
        #endregion

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

        public IActionResult AcademicLibrary(int year)
        {
            var academicLibrary = _academicLibraryService.GetByYear(year);

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

        #region Software CRUD
        public IActionResult Software()
        {
            List<RdCenterTechSoftwareDto> softwareList = _softwareService.GetAll();

            RdCenterTechSoftwareViewModel softwareViewModel = new()
            {
                SoftwareList = softwareList
            };

            return View(softwareViewModel);
        }

        public IActionResult SoftwareCreate()
        {
            RdCenterTechSoftwareDto software = new();

            RdCenterTechSoftwareViewModel softwareViewModel = new()
            {
                NewSoftware = software
            };

            return PartialView("PartialView/SoftwarePartialView", softwareViewModel);
        }

        public IActionResult SoftwareUpdate(int id)
        {
            var software = _softwareService.GetById(id);

            RdCenterTechSoftwareViewModel softwareViewModel = new()
            {
                NewSoftware = software
            };

            return PartialView("PartialView/SoftwarePartialView", softwareViewModel);
        }

        public IActionResult SoftwareDelete(int id)
        {
            _softwareService.Delete(id);

            AddSuccessMessage("Yazılım kaydı silindi.");

            return RedirectToAction("Software");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Software(RdCenterTechSoftwareViewModel softwareViewModel)
        {
            var software = _softwareService.GetById(softwareViewModel.NewSoftware.Id);
            if (software == null)
            {
                softwareViewModel.NewSoftware.CreatedDate = DateTime.Now;
                softwareViewModel.NewSoftware.CreatedUserName = User.Identity.Name;

                _softwareService.Add(softwareViewModel.NewSoftware);

                AddSuccessMessage("Yeni yazılım kaydı eklendi.");
            }
            else
            {
                softwareViewModel.NewSoftware.Id = software.Id;
                softwareViewModel.NewSoftware.Year = software.Year;
                softwareViewModel.NewSoftware.CreatedDate = software.CreatedDate;
                softwareViewModel.NewSoftware.CreatedUserName = software.CreatedUserName;
                softwareViewModel.NewSoftware.ModifiedDate = DateTime.Now;
                softwareViewModel.NewSoftware.ModifedUserName = User.Identity.Name;

                _softwareService.Update(softwareViewModel.NewSoftware);

                AddSuccessMessage("Yazılım kaydı güncelledi.");
            }

            return Redirect("Software");
        }
        #endregion

        #region Mentor Info CRUD
        public IActionResult MentorInfo(int year)
        {
            List<RdCenterTechMentorInfoDto> mentorInfoList = _mentorInfoService.GetAllByYear(year);

            RdCenterTechMentorInfoViewModel mentorInfoViewModel = new()
            {
                MentorInfoList = mentorInfoList
            };

            return View(mentorInfoViewModel);
        }

        public IActionResult MentorInfoCreate()
        {
            RdCenterTechMentorInfoDto mentorInfo = new();

            RdCenterTechMentorInfoViewModel mentorInfoViewModel = new()
            {
                NewMentorInfo = mentorInfo
            };

            return PartialView("PartialView/MentorInfoPartialView", mentorInfoViewModel);
        }

        public IActionResult MentorInfoUpdate(int id)
        {
            var mentorInfo = _mentorInfoService.GetById(id);

            RdCenterTechMentorInfoViewModel mentorInfoViewModel = new()
            {
                NewMentorInfo = mentorInfo
            };

            return PartialView("PartialView/MentorInfoPartialView", mentorInfoViewModel);
        }

        public IActionResult MentorInfoDelete(int id)
        {
            _mentorInfoService.Delete(id);

            AddSuccessMessage("Mentörülük kaydı silindi.");

            return RedirectToAction("MentorInfo", new { year = 2022 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MentorInfo(RdCenterTechMentorInfoViewModel mentorInfoViewModel)
        {
            var mentorInfo = _mentorInfoService.GetById(mentorInfoViewModel.NewMentorInfo.Id);
            if (mentorInfo == null)
            {
                mentorInfoViewModel.NewMentorInfo.CreatedDate = DateTime.Now;
                mentorInfoViewModel.NewMentorInfo.CreatedUserName = User.Identity.Name;

                _mentorInfoService.Add(mentorInfoViewModel.NewMentorInfo);

                AddSuccessMessage("Mentörlük kaydı eklendi.");
            }
            else
            {
                mentorInfoViewModel.NewMentorInfo.Id = mentorInfo.Id;
                mentorInfoViewModel.NewMentorInfo.Year = mentorInfo.Year;
                mentorInfoViewModel.NewMentorInfo.CreatedDate = mentorInfo.CreatedDate;
                mentorInfoViewModel.NewMentorInfo.CreatedUserName = mentorInfo.CreatedUserName;
                mentorInfoViewModel.NewMentorInfo.ModifiedDate = DateTime.Now;
                mentorInfoViewModel.NewMentorInfo.ModifedUserName = User.Identity.Name;

                _mentorInfoService.Update(mentorInfoViewModel.NewMentorInfo);

                AddSuccessMessage("Mentörlük kaydı güncellendi.");
            }

            return RedirectToAction("MentorInfo", new { year = 2022 });
        }
        #endregion

        #region Intellectual Property CRUD
        public IActionResult IntellectualProperty()
        {
            List<RdCenterTechIntellectualPropertyDto> propertyInfoList = _propertyService.GetAll();

            RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel = new()
            {
                PropertyList = propertyInfoList
            };

            return View(propertyInfoViewModel);
        }

        public IActionResult IntellectualPropertyCreate()
        {
            RdCenterTechIntellectualPropertyDto propertyInfo = new();

            RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel = new()
            {
                NewProperty = propertyInfo
            };

            return PartialView("PartialView/IntellectualPropertyPartialView", propertyInfoViewModel);
        }

        public IActionResult IntellectualPropertyUpdate(int id)
        {
            var propertyInfo = _propertyService.GetById(id);

            RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel = new()
            {
                NewProperty = propertyInfo
            };

            return PartialView("PartialView/IntellectualPropertyPartialView", propertyInfoViewModel);
        }

        public IActionResult IntellectualPropertyDelete(int id)
        {
            _propertyService.Delete(id);

            AddSuccessMessage("Fikri ve Sinai mülkiyet kaydı silindi.");

            return RedirectToAction("MentorInfo", new { year = 2022 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IntellectualProperty(RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel)
        {
            var propertyInfo = _propertyService.GetById(propertyInfoViewModel.NewProperty.Id);
            if (propertyInfo == null)
            {
                propertyInfoViewModel.NewProperty.CreatedDate = DateTime.Now;
                propertyInfoViewModel.NewProperty.CreatedUserName = User.Identity.Name;

                _propertyService.Add(propertyInfoViewModel.NewProperty);

                AddSuccessMessage("Fikri ve Sinai mülkiyet kaydı eklendi.");
            }
            else
            {
                propertyInfoViewModel.NewProperty.Id = propertyInfo.Id;
                propertyInfoViewModel.NewProperty.Year = propertyInfo.Year;
                propertyInfoViewModel.NewProperty.CreatedDate = propertyInfo.CreatedDate;
                propertyInfoViewModel.NewProperty.CreatedUserName = propertyInfo.CreatedUserName;
                propertyInfoViewModel.NewProperty.ModifiedDate = DateTime.Now;
                propertyInfoViewModel.NewProperty.ModifedUserName = User.Identity.Name;

                _propertyService.Update(propertyInfoViewModel.NewProperty);

                AddSuccessMessage("Fikri ve Sinai mülkiyet kaydı güncellendi.");
            }

            return RedirectToAction("IntellectualProperty");
        }
        #endregion
    }
}
