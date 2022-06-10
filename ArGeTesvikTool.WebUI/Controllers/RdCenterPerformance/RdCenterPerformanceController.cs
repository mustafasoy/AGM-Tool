using ArGeTesvikTool.Business.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.RdCenterPerformance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.RdCenterPerformance
{
    [Authorize]
    public class RdCenterPerformanceController : BaseController
    {
        private readonly IRdCenterPerformanceProjectService _projectService;
        private readonly IRdCenterPerformanceDecisionService _decisionService;
        private readonly IRdCenterTechIntellectualPropertyService _propertyService;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterTechProjectService _projectTechService;

        public RdCenterPerformanceController(IRdCenterPerformanceProjectService projectService, IRdCenterPerformanceDecisionService decisionService, IRdCenterTechIntellectualPropertyService propertyService, IRdCenterPersonInfoService infoService, IRdCenterTechProjectService projectTechManagementService)
        {
            _projectService = projectService;
            _decisionService = decisionService;
            _propertyService = propertyService;
            _infoService = infoService;
            _projectTechService = projectTechManagementService;
        }

        #region Project CRUD
        [Route("ticari-rapor")]
        public IActionResult Project()
        {
            List<RdCenterPerformanceProjectDto> projectList = _projectService.GetAllByYear(GetSelectedYear());

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
        [Route("ticari-rapor")]
        public IActionResult Project(RdCenterPerformanceProjectViewModel projectViewModel)
        {
            var project = _projectService.GetById(projectViewModel.NewProjectInfo.Id);
            if (project == null)
            {
                projectViewModel.NewProjectInfo.Year = GetSelectedYear();
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

            return RedirectToAction("Project");
        }
        #endregion

        [Route("degerlendirme-toplantı")]
        public IActionResult Decision()
        {
            RdCenterPerformanceDecisionDto decisionText = _decisionService.GetByYear(GetSelectedYear());

            RdCenterPerformanceDecisionViewModel decisionViewModel = new()
            {
                DecisionInfo = decisionText
            };

            return View(decisionViewModel);
        }

        [HttpPost]
        [Route("degerlendirme-toplantı")]
        public IActionResult Decision(RdCenterPerformanceDecisionViewModel decisionViewModel)
        {
            var intro = _decisionService.GetByYear(decisionViewModel.DecisionInfo.Year);
            if (intro == null)
            {
                decisionViewModel.DecisionInfo.Year = GetSelectedYear();
                decisionViewModel.DecisionInfo.CreatedDate = DateTime.Now;
                decisionViewModel.DecisionInfo.CreatedUserName = User.Identity.Name;
                _decisionService.Add(decisionViewModel.DecisionInfo);

                AddSuccessMessage("Değerlendirme toplantısında alınan kararlara ilişkin çalışma bilgisi eklendi.");

                return RedirectToAction("Index", "Home");
            }

            decisionViewModel.DecisionInfo.Id = intro.Id;
            decisionViewModel.DecisionInfo.Year = intro.Year;
            decisionViewModel.DecisionInfo.CreatedDate = intro.CreatedDate;
            decisionViewModel.DecisionInfo.CreatedUserName = intro.CreatedUserName;
            decisionViewModel.DecisionInfo.ModifiedDate = DateTime.Now;
            decisionViewModel.DecisionInfo.ModifedUserName = User.Identity.Name;

            _decisionService.Update(decisionViewModel.DecisionInfo);

            AddSuccessMessage("Değerlendirme toplantısında alınan kararlara ilişkin çalışma bilgisi güncellendi.");

            return RedirectToAction("Index", "Home");
        }

        [Route("performans-kriter")]
        public IActionResult Criteria()
        {
            var propertyList = _propertyService.GetAllByYear(GetSelectedYear());
            var prePropertyList = _propertyService.GetAllByYear(GetSelectedYear() - 1);

            var projectList = _projectTechService.GetAllByYear(GetSelectedYear());
            var preProjectList = _projectTechService.GetAllByYear(GetSelectedYear() - 1);

            var personnelInfo = _infoService.GetAllByYear(GetSelectedYear());
            var prePersonnelInfo = _infoService.GetAllByYear(GetSelectedYear() - 1);

            int masterPersonnelNumber;
            int preMasterPersonnelNumber;
            int totalPersonnelNumber;
            int preTotalPersonnelNumber;
            int totalResearcherNumber;
            int preTotalResearcherNumber;

            masterPersonnelNumber = personnelInfo.Where(x => x.EducationStatu == EducationStatu.YuksekLisans).Count();
            totalPersonnelNumber = personnelInfo.Count();

            preMasterPersonnelNumber = prePersonnelInfo.Where(x => x.EducationStatu == EducationStatu.YuksekLisans).Count();
            preTotalPersonnelNumber = prePersonnelInfo.Count();

            totalResearcherNumber = personnelInfo.Where(x => x.PersonPosition == PersonPosition.Arastirmaci).Count();
            preTotalResearcherNumber = prePersonnelInfo.Where(x => x.PersonPosition == PersonPosition.Arastirmaci).Count();

            RdCenterPerformanceCriteriaDto criteriaInfo = new()
            {
                Year = GetSelectedYear(),
                PreYear = GetSelectedYear() - 1,
                RegistiredPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Patent && x.Statu == Statu.Tescil).Count(),
                PreRegistiredPatentNumber = prePropertyList.Where(x => x.ProperyType == ProperyType.Patent && x.Statu == Statu.Tescil).Count(),
                IntSupportedrojectNumber = projectList.Where(x => !string.IsNullOrEmpty(x.IntSupportProgram) && x.ProjectStatu != ProjectStatu.Iptal).Count(),
                PreIntSupportedrojectNumber = preProjectList.Where(x => !string.IsNullOrEmpty(x.IntSupportProgram) && x.ProjectStatu != ProjectStatu.Iptal).Count(),
                MasterPersonnelRatio = totalPersonnelNumber != 0 ? masterPersonnelNumber / totalPersonnelNumber : 0,
                PreMasterPersonnelRatio = preTotalPersonnelNumber != 0 ? preMasterPersonnelNumber / preTotalPersonnelNumber : 0,
                TotalPersonnelRatio = totalPersonnelNumber != 0 ? totalResearcherNumber / totalPersonnelNumber : 0,
                PreTotalPersonnelRatio = preTotalPersonnelNumber != 0 ? preTotalPersonnelNumber / preTotalPersonnelNumber : 0
            };

            RdCenterPerformanceCriteriaViewModel criteriaViewModel = new()
            {
                CriteriaInfo = criteriaInfo
            };

            return View(criteriaViewModel);
        }
    }
}
