using AmeliorateAegis.Areas.Regional.Models;
using AmeliorateAegis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data.Services.Regional.Centres
{
    public class CentreService : ICentreService
    {
        private readonly ApplicationDbContext _context;
        public CentreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCenter(CentreDto model)
        {
            try
            {
                _context.Centres.Add(new Centre
                {
                    Code = model.CentreCode,
                    Name = model.CentreName,
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    City = model.City,
                    Province = model.Province,
                    Suburb = model.Suburb

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCentre(CentreDto model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCentre(int CenterID)
        {
            var center = _context.Centres.Find(CenterID);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {CenterID} was not found.");

            _context.Centres.Remove(center);
            return _context.SaveChanges() > 0;
        }

        public CentreDto GetCentre(int CenterID)
        {
            var center = _context.Centres.Find(CenterID);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {CenterID} was not found.");


            CentreDto model = new CentreDto
            {
                CentreId = center.Id,
                CentreCode = center.Code,
                CentreName = center.Name,
                AddressLine1 = center.AddressLine1,
                AddressLine2 = center.AddressLine2,
                City = center.City,
                Province = center.Province,
                Suburb = center.Suburb
            };
            return model;
        }

        public List<CentreDto> List()
        {
            return _context.Centres.Select(s => new CentreDto
            {
                CentreId = s.Id,
                CentreCode = s.Code,
                CentreName = s.Name,
                AddressLine1 = s.AddressLine1,
                AddressLine2 = s.AddressLine2,
                City = s.City,
                Province = s.Province,
                Suburb = s.Suburb
            }).ToList();
        }

        public List<CentreDto> ListByCity(int cityID)
        {
            throw new NotImplementedException();
        }

        public List<CentreDto> ListByRegionalManger(int regionalID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCentre(CentreDto model)
        {
            var center = _context.Centres.Find(model.CentreId);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {model.CentreId} was not found.");

            center.Code = model.CentreCode;
            center.Name = model.CentreName;
            center.AddressLine1 = model.AddressLine1;
            center.AddressLine2 = model.AddressLine2;
            center.City = model.City;
            center.Province = model.Province;
            center.Suburb = model.Suburb;
            return _context.SaveChanges() > 0;
        }
    }
}
