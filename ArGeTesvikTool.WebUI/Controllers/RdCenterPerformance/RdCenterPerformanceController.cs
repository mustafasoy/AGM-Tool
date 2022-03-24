using ArGeTesvikTool.Business.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterPerformance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterPerformance
{
    public class RdCenterPerformanceController : BaseController
    {
        private readonly IRdCenterPerformanceProjectService _projectService;

        public RdCenterPerformanceController(IRdCenterPerformanceProjectService projectService)
        {
            _projectService = projectService;
        }

        #region Project CRUD
        public IActionResult Project(int year)
        {
            List<RdCenterPerformanceProjectDto> projectList = _projectService.GetAllByYear(year);

            RdCenterPerformanceProjectViewModel projectViewModel = new()
            {
                ProjectInfoList = projectList
            };

            return View(projectViewModel);
        }

        public IActionResult ProjectCreate()
        {
            RdCenterPerformanceProjectDto projectInfo = new();

            RdCenterPerformanceProjectViewModel projectViewModel = new()
            {
                NewProjectInfo = projectInfo
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectUpdate(int id)
        {
            var projectInfo = _projectService.GetById(id);

            RdCenterPerformanceProjectViewModel projectViewModel = new()
            {
                NewProjectInfo = projectInfo
            };

            return PartialView("PartialView/ProjectPartialView", projectViewModel);
        }

        public IActionResult ProjectDelete(int id)
        {
            _projectService.Delete(id);

            AddSuccessMessage("Personel kaydı silindi.");

            return RedirectToAction("Project");
        }

        [HttpPost]
        public IActionResult PersonInfo(RdCenterPerformanceProjectViewModel projectViewModel)
        {
            var project = _projectService.GetById(projectViewModel.NewProjectInfo.Id);
            if (project == null)
            {
                projectViewModel.NewProjectInfo.CreatedDate = DateTime.Now;
                projectViewModel.NewProjectInfo.CreatedUserName = User.Identity.Name;

                _projectService.Add(projectViewModel.NewProjectInfo);

                AddSuccessMessage("Ticarileşen proje kaydı eklendi.");
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

                AddSuccessMessage("Ticarileşen proje kaydı güncellendi.");
            }

            return RedirectToAction("Projec", new { year = 2022 });
        }
        #endregion
    }
}
