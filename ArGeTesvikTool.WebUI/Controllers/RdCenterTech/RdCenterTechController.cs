using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Business.Utilities;
using ArGeTesvikTool.Business.ValidationRules.FluentValidation.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterTech;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterTech
{
    [Authorize]
    public class RdCenterTechController : BaseController
    {
        private readonly IRdCenterTechCollaborationService _collaborationService;
        private readonly IRdCenterTechAcademicLibraryService _academicLibraryService;
        private readonly IRdCenterTechAttendedEventService _attendedEventService;
        private readonly IRdCenterTechSoftwareService _softwareService;
        private readonly IRdCenterTechMentorInfoService _mentorInfoService;
        private readonly IRdCenterTechIntellectualPropertyService _propertyService;
        private readonly IRdCenterTechProjectService _projectService;
        private readonly IRdCenterTechProjectManagementService _projectManagementService;

        public RdCenterTechController(IRdCenterTechCollaborationService collaborationService, IRdCenterTechAcademicLibraryService academicLibraryService, IRdCenterTechAttendedEventService attendedEventService, IRdCenterTechSoftwareService softwareService, IRdCenterTechMentorInfoService mentorInfoService, IRdCenterTechIntellectualPropertyService propertyService, IRdCenterTechProjectService projectService, IRdCenterTechProjectManagementService projectManagementService)
        {
            _collaborationService = collaborationService;
            _academicLibraryService = academicLibraryService;
            _attendedEventService = attendedEventService;
            _softwareService = softwareService;
            _mentorInfoService = mentorInfoService;
            _propertyService = propertyService;
            _projectService = projectService;
            _projectManagementService = projectManagementService;
        }

        #region Project CRUD
        [Route("devam-eden-proje")]
        public IActionResult OngoingProject()
        {
            List<RdCenterTechProjectDto> projectList = _projectService.GetAllByYearStatu(GetSelectedYear(), ProjectStatu.Devam.ToString());

            RdCenterTechProjectViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }

        [Route("proje-goruntule")]
        public IActionResult ProjectView(int id)
        {
            var project = _projectService.GetById(id);

            RdCenterTechProjectViewModel projectViewModel = new()
            {
                NewProject = project
            };

            return View(projectViewModel);
        }

        public IActionResult ProjectDelete(int id)
        {
            _projectService.Delete(id);

            AddSuccessMessage("Proje kaydı silindi.");

            return RedirectToAction("OngoingProject");
        }

        [Route("proje-duzenle")]
        public IActionResult ProjectModify(int id)
        {
            var project = _projectService.GetById(id);

            RdCenterTechProjectViewModel projectViewModel = new()
            {
                NewProject = project
            };

            return View(projectViewModel);
        }

        [HttpPost]
        [Route("proje-duzenle")]
        public IActionResult ProjectModify(RdCenterTechProjectViewModel projectViewModel)
        {
            var validate = ValidatorTool.Validate(new RdCenterTechProjectValidator(), projectViewModel.NewProject);
            if (validate.IsValid)
            {
                var project = _projectService.GetById(projectViewModel.NewProject.Id);
                if (project == null)
                {
                    projectViewModel.NewProject.Year = GetSelectedYear();
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

                return RedirectToAction("OngoingProject", new { year = 2022 });
            }

            AddValidatorError(validate);

            return View(projectViewModel);
        }

        [Route("tamamlanan-proje")]
        public IActionResult CompletedProject()
        {
            List<RdCenterTechProjectDto> projectList = _projectService.GetAllByYearStatu(GetSelectedYear(), ProjectStatu.Tamam.ToString());

            RdCenterTechProjectViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }

        [Route("iptal-edilen-proje")]
        public IActionResult CanceledProject()
        {
            List<RdCenterTechProjectDto> projectList = _projectService.GetAllByYearStatu(GetSelectedYear(), ProjectStatu.Iptal.ToString());

            RdCenterTechProjectViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }
        #endregion

        #region Collaboration CRUD
        [Route("isbirilik")]
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
        [Route("isbirilik")]
        public IActionResult Collaboration(RdCenterTechCollabrationViewModel collaborationViewModel)
        {
            var collaboration = _collaborationService.GetById(collaborationViewModel.NewCollaboration.Id);
            if (collaboration == null)
            {
                collaborationViewModel.NewCollaboration.Year = GetSelectedYear();
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

            return RedirectToAction("Collaboration");
        }
        #endregion

        #region Project Management CRUD
        [Route("proje-yonetim")]
        public IActionResult ProjectManagement()
        {
            var projectManagementList = _projectManagementService.GetAllByYear(GetSelectedYear());

            RdCenterTechProjectManagementViewModel projectManagementViewModel = new()
            {
                ProjectManagementList = projectManagementList
            };

            return View(projectManagementViewModel);
        }

        public IActionResult ProjectManagementDelete(int id)
        {
            _projectManagementService.Delete(id);

            AddSuccessMessage("Proje yönetim şeması silindi.");

            return RedirectToAction("ProjectManagement");
        }

        public IActionResult ProjectManagementDownload(int id)
        {
            var projectManagement = _projectManagementService.GetById(id);

            return DownloadFile(projectManagement);
        }

        [HttpPost]
        [Route("proje-yonetim")]
        public IActionResult ProjectManagement(RdCenterTechProjectManagementViewModel projectManagementViewModel, List<IFormFile> formFile)
        {
            if (ModelState.IsValid)
            {
                RdCenterTechProjectManagementDto projectManagement = new();
                foreach (var item in formFile)
                {
                    if (item.Length > 0)
                    {
                        using var stream = new MemoryStream();
                        item.CopyToAsync(stream).Wait();
                        projectManagement.FileName = item.FileName;
                        projectManagement.Content = stream.ToArray();
                        projectManagement.ContentType = item.ContentType;
                    }
                }

                var projectList = _projectManagementService.GetAllByYear(2022);
                foreach (var item in projectList)
                {
                    if (item.FileName == projectManagement.FileName)
                    {
                        ModelState.AddModelError("FormFile", "Dosya mevcut. Farklı dosya seçiniz");

                        projectManagementViewModel.ProjectManagementList = projectList;

                        return View(projectManagementViewModel);
                    }
                }
                projectManagement.Year = GetSelectedYear();
                projectManagement.CreatedDate = DateTime.Now;
                projectManagement.CreatedUserName = User.Identity.Name;

                _projectManagementService.Add(projectManagement);

                AddSuccessMessage("Proje yönetim şeması eklendi.");

                return RedirectToAction("ProjectManagement");
            }

            return View(projectManagementViewModel);
        }
        #endregion

        [Route("uye-olunan-yerler")]
        public IActionResult AcademicLibrary()
        {
            var academicLibrary = _academicLibraryService.GetByYear(GetSelectedYear());

            RdCenterTechAcademicLibraryViewModel academicLibraryViewModel = new()
            {
                AcademicLibrary = academicLibrary
            };

            return View(academicLibraryViewModel);
        }

        [HttpPost]
        [Route("uye-olunan-yerler")]
        public IActionResult AcademicLibrary(RdCenterTechAcademicLibraryViewModel academicLibraryViewModel)
        {
            var contact = _academicLibraryService.GetByYear(academicLibraryViewModel.AcademicLibrary.Year);
            if (contact == null)
            {
                academicLibraryViewModel.AcademicLibrary.Year = GetSelectedYear();
                academicLibraryViewModel.AcademicLibrary.CreatedDate = DateTime.Now;
                academicLibraryViewModel.AcademicLibrary.CreatedUserName = User.Identity.Name;

                _academicLibraryService.Add(academicLibraryViewModel.AcademicLibrary);

                AddSuccessMessage("Ulusal/Uluslararası bilimsel bilgi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            academicLibraryViewModel.AcademicLibrary.Year = contact.Year;
            academicLibraryViewModel.AcademicLibrary.CreatedDate = contact.CreatedDate;
            academicLibraryViewModel.AcademicLibrary.CreatedUserName = contact.CreatedUserName;
            academicLibraryViewModel.AcademicLibrary.ModifiedDate = DateTime.Now;
            academicLibraryViewModel.AcademicLibrary.ModifedUserName = User.Identity.Name;
            academicLibraryViewModel.AcademicLibrary.Id = contact.Id;

            _academicLibraryService.Update(academicLibraryViewModel.AcademicLibrary);

            AddSuccessMessage("Ulusal/Uluslararası bilimsel bilgi güncellendi.");

            return RedirectToAction("Index", "Home");
        }

        #region AttendedEvent CRUD
        [Route("katilinan-etkinlik")]
        public IActionResult AttendedEvent()
        {
            List<RdCenterTechAttendedEventDto> attendedEventList = _attendedEventService.GetAllByYear(GetSelectedYear());

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
        [Route("katilinan-etkinlik")]
        public IActionResult AttendedEvent(RdCenterTechAttendedEventViewModel attendedEventViewModel)
        {
            var attendedEvent = _attendedEventService.GetById(attendedEventViewModel.NewAttendedEvent.Id);
            if (attendedEvent == null)
            {
                attendedEventViewModel.NewAttendedEvent.Year = GetSelectedYear();
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

        #region Software CRUD
        [Route("kullailan-yazilim")]
        public IActionResult Software()
        {
            List<RdCenterTechSoftwareDto> softwareList = _softwareService.GetAllByYear(GetSelectedYear());

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
        [Route("kullailan-yazilim")]
        public IActionResult Software(RdCenterTechSoftwareViewModel softwareViewModel)
        {
            var software = _softwareService.GetById(softwareViewModel.NewSoftware.Id);
            if (software == null)
            {
                softwareViewModel.NewSoftware.Year = GetSelectedYear();
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
        [Route("mentor-bilgi")]
        public IActionResult MentorInfo()
        {
            List<RdCenterTechMentorInfoDto> mentorInfoList = _mentorInfoService.GetAllByYear(GetSelectedYear());

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
        [Route("mentor-bilgi")]
        public IActionResult MentorInfo(RdCenterTechMentorInfoViewModel mentorInfoViewModel)
        {
            var mentorInfo = _mentorInfoService.GetById(mentorInfoViewModel.NewMentorInfo.Id);
            if (mentorInfo == null)
            {
                mentorInfoViewModel.NewMentorInfo.Year = GetSelectedYear();
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
        [Route("mulkiyet-hak")]
        public IActionResult IntellectualProperty()
        {
            var projectList = _projectService.GetAllProjectNameByYear(GetSelectedYear());

            List<RdCenterTechIntellectualPropertyDto> propertyInfoList = _propertyService.GetAll();

            RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel = new()
            {
                PropertyList = propertyInfoList,
                ProjectList = projectList.Select(x => new SelectListItem
                {
                    Value = x.ProjectCode,
                    Text = x.ProjectName
                }).ToList(),
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
        [Route("mulkiyet-hak")]
        public IActionResult IntellectualProperty(RdCenterTechIntellectualPropertyViewModel propertyInfoViewModel)
        {
            var propertyInfo = _propertyService.GetById(propertyInfoViewModel.NewProperty.Id);
            if (propertyInfo == null)
            {
                propertyInfoViewModel.NewProperty.Year = GetSelectedYear();
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
