﻿using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterCal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterCal
{
    public class RdCenterCalController : BaseController
    {
        private readonly IRdCenterCalPersonnelService _personnelService;
        private readonly IRdCenterCalProjectService _projectService;
        private readonly IRdCenterCalTimeAwayService _timeAwayService;
        private readonly IRdCenterCalPersAssingService _persAssingService;

        public RdCenterCalController(IRdCenterCalPersonnelService personnelService, IRdCenterCalProjectService projectService, IRdCenterCalTimeAwayService timeAwayService, IRdCenterCalPersAssingService persAssingService)
        {
            _personnelService = personnelService;
            _projectService = projectService;
            _timeAwayService = timeAwayService;
            _persAssingService = persAssingService;
        }

        #region Personnel CRUD
        public IActionResult PersonnelInfo()
        {
            List<RdCenterCalPersonnelInfoDto> personnelList = _personnelService.GetAll();

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                PersonnelList = personnelList
            };

            return View(personnelViewModel);
        }

        public IActionResult PersonnelCreate()
        {
            RdCenterCalPersonnelInfoDto personnel = new();

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                NewPersonnelInfo = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelViewModel);
        }

        public IActionResult PersonnelUpdate(int id)
        {
            var personnel = _personnelService.GetById(id);

            RdCenterCalPersonnelInfoViewModel personnelViewModel = new()
            {
                NewPersonnelInfo = personnel
            };

            return PartialView("PartialView/PersonnelPartialView", personnelViewModel);
        }

        public IActionResult PersonnelDelete(int id)
        {
            _personnelService.Delete(id);

            AddSuccessMessage("Personel bilgisi silindi.");

            return RedirectToAction("PersonnelInfo");
        }

        [HttpPost]
        public IActionResult PersonnelInfo(RdCenterCalPersonnelInfoViewModel personnelViewModel)
        {
            var personnel = _personnelService.GetById(personnelViewModel.NewPersonnelInfo.Id);
            if (personnel == null)
            {
                personnelViewModel.NewPersonnelInfo.CreatedDate = DateTime.Now;
                personnelViewModel.NewPersonnelInfo.CreatedUserName = User.Identity.Name;

                _personnelService.Add(personnelViewModel.NewPersonnelInfo);

                AddSuccessMessage("Personel bilgisi eklendi.");
            }
            else
            {
                personnelViewModel.NewPersonnelInfo.Id = personnel.Id;
                personnelViewModel.NewPersonnelInfo.Year = personnel.Year;
                personnelViewModel.NewPersonnelInfo.CreatedDate = personnel.CreatedDate;
                personnelViewModel.NewPersonnelInfo.CreatedUserName = personnel.CreatedUserName;
                personnelViewModel.NewPersonnelInfo.ModifiedDate = DateTime.Now;
                personnelViewModel.NewPersonnelInfo.ModifedUserName = User.Identity.Name;

                _personnelService.Update(personnelViewModel.NewPersonnelInfo);

                AddSuccessMessage("Personel bilgisi güncellendi.");
            }

            return Redirect("PersonnelInfo");
        }
        #endregion

        #region Project CRUD
        public IActionResult ProjectInfo()
        {
            List<RdCenterCalProjectInfoDto> projectList = _projectService.GetAll();

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                ProjectList = projectList
            };

            return View(projectViewModel);
        }

        public IActionResult ProjectCreate()
        {
            RdCenterCalProjectInfoDto project = new();

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                NewProjectInfo = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectUpdate(int id)
        {
            var project = _projectService.GetById(id);

            RdCenterCalProjectInfoViewModel projectViewModel = new()
            {
                NewProjectInfo = project
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectDelete(int id)
        {
           _projectService.Delete(id);

            AddSuccessMessage("Proje bilgisi silindi.");

            return RedirectToAction("ProjectInfo");
        }

        [HttpPost]
        public IActionResult ProjectInfo(RdCenterCalProjectInfoViewModel projectViewModel)
        {
            var project = _projectService.GetById(projectViewModel.NewProjectInfo.Id);
            if (project == null)
            {
                projectViewModel.NewProjectInfo.CreatedDate = DateTime.Now;
                projectViewModel.NewProjectInfo.CreatedUserName = User.Identity.Name;

                _projectService.Add(projectViewModel.NewProjectInfo);

                AddSuccessMessage("Proje bilgisi eklendi.");
            }
            else
            {
                projectViewModel.NewProjectInfo.Id = project.Id;
                projectViewModel.NewProjectInfo.Year = project.Year;
                projectViewModel.NewProjectInfo.CreatedDate = project.CreatedDate;
                projectViewModel.NewProjectInfo.CreatedUserName = project.CreatedUserName;
                projectViewModel.NewProjectInfo.ModifiedDate = DateTime.Now;
                projectViewModel.NewProjectInfo.ModifedUserName = User.Identity.Name;

                _projectService.Update(projectViewModel.NewProjectInfo);

                AddSuccessMessage("Proje bilgisi güncellendi.");
            }

            return Redirect("ProjectInfo");
        }
        #endregion

        #region TimeAway CRUD
        public IActionResult TimeAway()
        {
            List<RdCenterCalTimeAwayDto> timeAwayList = _timeAwayService.GetAll();

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                TimeAwayList = timeAwayList
            };

            return View(timeAwayViewModel);
        }

        public IActionResult TimeAwayCreate()
        {
            RdCenterCalTimeAwayDto timeAway = new();

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeAway = timeAway
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayUpdate(int id)
        {
            var timeAway = _timeAwayService.GetById(id);

            RdCenterCalTimeAwayViewModel timeAwayViewModel = new()
            {
                NewTimeAway = timeAway
            };

            return PartialView("PartialView/TimeAwayPartialView", timeAwayViewModel);
        }

        public IActionResult TimeAwayDelete(int id)
        {
            _timeAwayService.Delete(id);

            AddSuccessMessage("Dışarıda geçen süre bilgisi silindi.");

            return RedirectToAction("TimeAway");
        }

        [HttpPost]
        public IActionResult TimeAway(RdCenterCalTimeAwayViewModel timeAwayViewModel)
        {
            var timeAway = _timeAwayService.GetById(timeAwayViewModel.NewTimeAway.Id);
            if (timeAway == null)
            {
                timeAwayViewModel.NewTimeAway.CreatedDate = DateTime.Now;
                timeAwayViewModel.NewTimeAway.CreatedUserName = User.Identity.Name;

                _timeAwayService.Add(timeAwayViewModel.NewTimeAway);

                AddSuccessMessage("Dışarıda geçen süre bilgisi eklendi.");
            }
            else
            {
                timeAwayViewModel.NewTimeAway.Id = timeAway.Id;
                timeAwayViewModel.NewTimeAway.Year = timeAway.Year;
                timeAwayViewModel.NewTimeAway.CreatedDate = timeAway.CreatedDate;
                timeAwayViewModel.NewTimeAway.CreatedUserName = timeAway.CreatedUserName;
                timeAwayViewModel.NewTimeAway.ModifiedDate = DateTime.Now;
                timeAwayViewModel.NewTimeAway.ModifedUserName = User.Identity.Name;

                _timeAwayService.Update(timeAwayViewModel.NewTimeAway);

                AddSuccessMessage("Dışarıda geçen süre bilgisi güncellendi.");
            }

            return Redirect("TimeAway");
        }
        #endregion

        #region Personnel Assing CRUD
        public IActionResult PersonnelAssing()
        {
            List<RdCenterCalPersAssingDto> persAssingList = _persAssingService.GetAll();

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                PersAssingList = persAssingList
            };

            return View(persAssingViewModel);
        }

        public IActionResult PersonnelAssingCreate()
        {
            RdCenterCalPersAssingDto persAssing = new();

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                NewPersAssing = persAssing
            };

            return PartialView("PartialView/PersAssingPartialView", persAssingViewModel);
        }

        public IActionResult PersonnelAssingUpdate(int id)
        {
            var persAssing = _persAssingService.GetById(id);

            RdCenterCalPersAssingViewModel persAssingViewModel = new()
            {
                NewPersAssing = persAssing
            };

            return PartialView("PartialView/PersAssingPartialView", persAssingViewModel);
        }

        public IActionResult PersonnelAssingDelete(int id)
        {
            _persAssingService.Delete(id);

            AddSuccessMessage("Personele atanan proje silindi.");

            return RedirectToAction("PersonnelAssing");
        }

        [HttpPost]
        public IActionResult PersonnelAssing(RdCenterCalPersAssingViewModel persAssingViewModel)
        {
            var persAssing = _persAssingService.GetById(persAssingViewModel.NewPersAssing.Id);
            if (persAssing == null)
            {
                persAssingViewModel.NewPersAssing.CreatedDate = DateTime.Now;
                persAssingViewModel.NewPersAssing.CreatedUserName = User.Identity.Name;

                _persAssingService.Add(persAssingViewModel.NewPersAssing);

                AddSuccessMessage("Personele proje bilgisi eklendi.");
            }
            else
            {
                persAssingViewModel.NewPersAssing.Id = persAssing.Id;
                persAssingViewModel.NewPersAssing.Year = persAssing.Year;
                persAssingViewModel.NewPersAssing.CreatedDate = persAssing.CreatedDate;
                persAssingViewModel.NewPersAssing.CreatedUserName = persAssing.CreatedUserName;
                persAssingViewModel.NewPersAssing.ModifiedDate = DateTime.Now;
                persAssingViewModel.NewPersAssing.ModifedUserName = User.Identity.Name;

                _persAssingService.Update(persAssingViewModel.NewPersAssing);

                AddSuccessMessage("Personele atanan proje bilgisi güncellendi.");
            }

            return Redirect("PersonnelAssing");
        }
        #endregion
    }
}