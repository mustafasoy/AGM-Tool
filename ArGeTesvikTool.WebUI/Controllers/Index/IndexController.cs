using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.Business.Abstract.Index;
using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using ArGeTesvikTool.WebUI.Controllers.Authentication;
using ArGeTesvikTool.WebUI.Models.Index;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.WebUI.Controllers.Index
{
    public class IndexController : BaseController
    {
        private readonly INewDataService _newDataService;
        private readonly IRdCenterPersonInfoService _infoService;
        private readonly IRdCenterTechProjectService _projectService;
        private readonly IRdCenterDiscountService _discountService;
        private readonly IBusinessFinancialInfoService _financialService;
        private readonly IRdCenterTechAttendedEventService _attendedEventService;
        private readonly IRdCenterTechIntellectualPropertyService _propertyService;
        private readonly IRdCenterInfoService _rdCenterInfoService;

        public IndexController(IRdCenterPersonInfoService infoService, INewDataService newDataService, IRdCenterTechProjectService projectService, IBusinessFinancialInfoService financialService, IRdCenterTechAttendedEventService attendedEventService, IRdCenterTechIntellectualPropertyService propertyService, IRdCenterDiscountService discountService, IRdCenterInfoService rdCenterInfoService)
        {
            _newDataService = newDataService;
            _infoService = infoService;
            _projectService = projectService;
            _financialService = financialService;
            _attendedEventService = attendedEventService;
            _propertyService = propertyService;
            _discountService = discountService;
            _rdCenterInfoService = rdCenterInfoService;
        }

        [Route("yeni-giris")]
        public IActionResult NewData()
        {
            var newData = _newDataService.GetByYear(GetSelectedYear());

            NewDataViewModel newDataViewModel = new()
            {
                NewData = newData
            };

            return View(newDataViewModel);
        }

        [HttpPost]
        [Route("yeni-giris")]
        public IActionResult NewData(NewDataViewModel newDataViewModel)
        {
            var newData = _newDataService.GetByYear(newDataViewModel.NewData.Year);
            if (newData == null)
            {
                newDataViewModel.NewData.Year = GetSelectedYear();
                newDataViewModel.NewData.CreatedDate = DateTime.Now;
                newDataViewModel.NewData.CreatedUserName = User.Identity.Name;

                _newDataService.Add(newDataViewModel.NewData);

                AddSuccessMessage("Bilgiler eklendi.");
                return RedirectToAction("Index", "Home");
            }

            newDataViewModel.NewData.Id = newData.Id;
            newDataViewModel.NewData.Year = newData.Year;
            newDataViewModel.NewData.CreatedDate = newData.CreatedDate;
            newDataViewModel.NewData.CreatedUserName = newData.CreatedUserName;
            newDataViewModel.NewData.ModifiedDate = DateTime.Now;
            newDataViewModel.NewData.ModifedUserName = User.Identity.Name;

            _newDataService.Update(newDataViewModel.NewData);

            AddSuccessMessage("Bilgiler güncellendi.");
            return RedirectToAction("Index", "Home");
        }

        [Route("istihdam-bilgi")]
        public IActionResult Employment()
        {
            List<RdCenterPersonInfoDto> personInfoList = _infoService.GetAllByYear(GetSelectedYear());
            var rdCenterInfo = _rdCenterInfoService.GetByYear(GetSelectedYear());

            EmploymentDto employmentData = new()
            {
                DocReceiptDate = rdCenterInfo != null ? rdCenterInfo.DocReceiptDate.ToString("dd.MM.yyyy") : string.Empty,
                GraduateDoctoralNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.Doktora && x.PersonPosition == PersonPosition.Arastirmaci).Count(),
                GraduateMasterDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.YuksekLisans && x.PersonPosition == PersonPosition.Arastirmaci).Count(),
                GraduateBachelorDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.Lisans && x.PersonPosition == PersonPosition.Arastirmaci).Count(),
                CurrentDoctoralNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.DoktoraOgrenci).Count(),
                CurrentMasterDegreeNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.YuksekLisansOgrenci).Count(),
                GraduateBasicScienceNumber = personInfoList.Where(x => x.EducationStatu == EducationStatu.OnLisans).Count(),
                TechnicianNumber = personInfoList.Where(x => x.PersonPosition == PersonPosition.Teknisyen).Count(),
                //NewPersonTotalNumber = personInfoList.Where(x => x.EducationStatu == "Teknisyen").Count(),
                TotalResearcherNumber = personInfoList.Where(x => x.PersonPosition == PersonPosition.Arastirmaci).Count(),
                TotalRDNumber = personInfoList.Count(),
                //WomenPersonNumber = personInfoList.Where(x => x.EducationStatu == "Teknisyen").Count(),
                InternNumber = personInfoList.Where(x => x.PersonPosition == PersonPosition.Stajyer).Count(),
                //OverSeasPersonNumber = personInfoList.Where(x => x.EducationStatu == "Teknisyen").Count()
            };

            EmploymentViewModel indexInfoViewModel = new()
            {
                EmploymentInfo = employmentData
            };

            return View(indexInfoViewModel);

        }

        [Route("harcama-yogunlugu")]
        public IActionResult SpendingIntensity()
        {
            List<RdCenterDiscountDto> discount = _discountService.GetAllByYear(GetSelectedYear());
            List<RdCenterDiscountDto> preDiscount = _discountService.GetAllByYear(GetSelectedYear() - 1);

            SpendingIntensityDto spendingIntensity = new()
            {
                CashSupport = discount.Select(x => Convert.ToDecimal(x.TotalExpenditure)).Sum().ToString(),
                PreviousYearCashSupport = preDiscount.Select(x => Convert.ToDecimal(x.TotalExpenditure)).Sum().ToString(),
                DesignExpense = discount.Select(x => Convert.ToDecimal(x.IncentiveAmount)).Sum().ToString()
            };

            SpendingIntensityViewModel spendingIntensityInfoViewModel = new()
            {
                SpendingIntensityInfo = spendingIntensity
            };

            return View(spendingIntensityInfoViewModel);
        }

        [Route("proje-kapasite")]
        public IActionResult ProjectCapacity()
        {
            List<RdCenterTechProjectDto> projectList = _projectService.GetAllByYear(GetSelectedYear());
            NewDataDto newData = _newDataService.GetByYear(GetSelectedYear());

            decimal periodProjectExpense = 0;
            foreach (var item in projectList)
            {
                periodProjectExpense += item.TotalProjectIncome != null ? Convert.ToDecimal(item.TotalProjectIncome) : 0
                                        + item.EquityAmount != null ? Convert.ToDecimal(item.EquityAmount) : 0
                                        + item.SupportAmount != null ? Convert.ToDecimal(item.SupportAmount) : 0
                                        + item.ServiceProcurementAmount != null ? Convert.ToDecimal(item.ServiceProcurementAmount) : 0
                                        + item.NatServiceProcurementAmount != null ? Convert.ToDecimal(item.NatServiceProcurementAmount) : 0
                                        + item.IntServiceProcurementAmount != null ? Convert.ToDecimal(item.IntServiceProcurementAmount) : 0;
            }
            ProjectCapacityDto projectCapacity = new()
            {
                PeriodProjectExpense = periodProjectExpense.ToString(),
                IntSupportedProjectNumber = newData != null ? newData.InternationalProjectNumber.ToString() : "0",
                NationalAcceptedProjectNumber = newData != null ? newData.NationalProjectNumber.ToString() : "0"
            };

            ProjectCapacityViewModel projectCapacityViewModel = new()
            {
                ProjectCapacityInfo = projectCapacity
            };

            return View(projectCapacityViewModel);
        }

        [Route("isbirligi")]
        public IActionResult Cooperation()
        {
            NewDataDto newData = _newDataService.GetByYear(GetSelectedYear());

            List<RdCenterTechProjectDto> ongoingList = _projectService.GetAllByYearStatu(GetSelectedYear(), ProjectStatu.Devam.ToString());
            List<RdCenterTechProjectDto> completeList = _projectService.GetAllByYearStatu(GetSelectedYear(), ProjectStatu.Tamam.ToString());

            int totalProjectNumber = ongoingList.Count;
            totalProjectNumber += completeList.Count;

            int orderBaseProjectNumber = ongoingList.Where(x => !string.IsNullOrEmpty(x.OrderBase)).Count();
            orderBaseProjectNumber += completeList.Where(x => !string.IsNullOrEmpty(x.OrderBase)).Count();

            CooperationDto cooperation = new()
            {
                TotalProjectNumber = totalProjectNumber,
                PeriodicExpenditure = newData != null ? newData.PeriodicExpenditure.ToString() : "0",
                PublicPeriodicExpenditure = newData != null ? newData.PublicPeriodicExpenditure.ToString() : "0",
                ProjectPeriodicExpenditure = newData != null ? newData.ProjectPeriodicExpenditure.ToString() : "0",
                OrderBaseProjectNumber = orderBaseProjectNumber.ToString()
            };

            CooperationViewModel cooperationViewModel = new()
            {
                CooperationInfo = cooperation
            };

            return View(cooperationViewModel);
        }

        [Route("ticarilestirme")]
        public IActionResult Commercialization()
        {
            NewDataDto newData = _newDataService.GetByYear(GetSelectedYear());
            BusinessFinancialInfoDto financialInfo = _financialService.GetByYear(GetSelectedYear());

            CommercializationDto commercialization = new()
            {
                TotalTurnoverAmount = financialInfo != null ? financialInfo.GrossSales.ToString() : "0",
                DomesticSalesRevenue = newData != null ? newData.DomesticSalesRevenue.ToString() : "0",
                OverseasSalesRevenue = newData != null ? newData.OverseasSalesRevenue.ToString() : "0",
            };

            CommercializationViewModel commercializationViewModel = new()
            {
                CommercializationInfo = commercialization
            };

            return View(commercializationViewModel);
        }

        [Route("mulkiyet-yeterliligi")]
        public IActionResult PropertyCompetence()
        {
            var propertyList = _propertyService.GetAllByYear(GetSelectedYear());
            var attendedEventList = _attendedEventService.GetAllByYear(GetSelectedYear());
            var preAttendedEventList = _attendedEventService.GetAllByYear(GetSelectedYear() - 1);

            PropertyCompetenceDto propertyCompetence = new()
            {
                RegIntPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Patent && x.International == International.Uluslararası && x.Statu == Statu.Tescil).Count(),
                RegNationalPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Patent && x.International == International.Ulusal && x.Statu == Statu.Tescil).Count(),
                ApplyIntPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Patent && x.International == International.Uluslararası && x.Statu == Statu.Başvuru).Count(),
                ApplyNationalPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Patent && x.International == International.Ulusal && x.Statu == Statu.Başvuru).Count(),
                RegModelNumber = propertyList.Where(x => x.ProperyType == ProperyType.FaydaliModel && x.Statu == Statu.Tescil).Count(),
                RegIntDesignNumber = propertyList.Where(x => x.ProperyType == ProperyType.Tasarım && x.Statu == Statu.Tescil).Count(),
                RegSoftwareNumber = propertyList.Where(x => x.ProperyType == ProperyType.Yazılım && x.Statu == Statu.Tescil).Count(),
                TriadicPatentNumber = propertyList.Where(x => x.ProperyType == ProperyType.Triadik && x.Statu == Statu.Tescil).Count(),
                NationalIssueNumber = propertyList.Where(x => x.ProperyType == ProperyType.YayınMakaleBildiri && x.International == International.Ulusal && x.Statu == Statu.Tescil).Count(),
                IntIssueNumber = propertyList.Where(x => x.ProperyType == ProperyType.YayınMakaleBildiri && x.International == International.Uluslararası && x.Statu == Statu.Tescil).Count(),
                DomesticExpoNumber = attendedEventList.Where(x => x.Location == ConferenceLocation.Yurtici).Count(),
                OverseasExpoNumber = attendedEventList.Where(x => x.Location == ConferenceLocation.Yurtdisi).Count(),
                PreYearDomesticExpoNumber = preAttendedEventList.Where(x => x.Location == ConferenceLocation.Yurtici).Count(),
                PreYearOverseasExpoNumber = preAttendedEventList.Where(x => x.Location == ConferenceLocation.Yurtdisi).Count()
            };


            PropertyCompetenceViewModel propertyCompetenceViewModel = new()
            {
                PropertyCompetence = propertyCompetence
            };

            return View(propertyCompetenceViewModel);
        }

        [Route("diger")]
        public IActionResult Other()
        {
            string iso14001 = string.Empty;
            string iso9001 = string.Empty;

            NewDataDto newData = _newDataService.GetByYear(GetSelectedYear());
            if (newData != null)
            {
                iso14001 = newData.IsIso14001 ? "Evet" : "Hayır";
                iso9001 = newData.IsIso9001 ? "Evet" : "Hayır";
            }

            OtherDto other = new()
            {
                Iso14001 = iso14001,
                Iso9001 = iso9001
            };

            OtherViewModel otherViewModel = new()
            {
                OtherInfo = other
            };

            return View(otherViewModel);
        }
    }
}
