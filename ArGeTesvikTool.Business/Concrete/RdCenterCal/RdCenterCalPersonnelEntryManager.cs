﻿using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersonnelEntryManager : IRdCenterCalPersonnelEntryService
    {
        private readonly IRdCenterCalPersonnelEntryDal _personnelEntry;

        public RdCenterCalPersonnelEntryManager(IRdCenterCalPersonnelEntryDal personnelEntry)
        {
            _personnelEntry = personnelEntry;
        }

        public void Add(RdCenterCalPersonnelEntryDto rdCenterCalManagerEntry)
        {
            _personnelEntry.Add(rdCenterCalManagerEntry);
        }

        public void AddList(List<RdCenterCalPersonnelEntryDto> rdCenterCalPersonnelEntityList)
        {
            _personnelEntry.AddList(rdCenterCalPersonnelEntityList);
        }

        public void Update(RdCenterCalPersonnelEntryDto rdCenterCalManagerEntry)
        {
            _personnelEntry.Update(rdCenterCalManagerEntry);
        }

        public void Delete(int id)
        {
            _personnelEntry.Delete(new RdCenterCalPersonnelEntryDto { Id = id });
        }

        public RdCenterCalPersonnelEntryDto GetById(int id)
        {
            return _personnelEntry.Get(x => x.Id == id);
        }

        public List<RdCenterCalPersonnelEntryDto> GetAllByYear(int year)
        {
            return _personnelEntry.GetList(x => x.Year == year);
        }

        public List<RdCenterCalPersonnelEntryDto> GetAllByMonth(DateTime startDate, DateTime endDate)
        {
            return _personnelEntry.GetList(x => x.StartDate >= startDate && x.EndDate <= endDate);
        }

        public List<RdCenterCalPersonnelEntryDto> GetAllPersonnel()
        {
            var entryList = _personnelEntry.GetList();

            var personnelList = entryList.GroupBy(x => new { x.RegistrationNo})
                .Select(s=> new RdCenterCalPersonnelEntryDto {
                    PersonnelFullName = s.First().PersonnelFullName,
                    RegistrationNo = s.First().RegistrationNo
                })
                .OrderBy(o=>o.PersonnelFullName)
                .ToList();

            return personnelList;
        }

        public List<RdCenterCalPersonnelEntryDto> GetAllByMonthByPersonnel(string regNo, DateTime startDate, DateTime endDate)
        {
            return _personnelEntry.GetList(x => x.RegistrationNo == regNo && x.StartDate >= startDate && x.EndDate <= endDate);
        }
    }
}
