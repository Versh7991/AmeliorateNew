using AmeliorateAegis.Areas.Regional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data.Services.Regional.Budget
{
    public interface IBudgetService
    {
        bool AddCentre(CentreDto model);
        bool UpdateCentre(CentreDto model);
        CentreDto GetCentre(int CentreID);
        bool DeleteCentre(int CentreID);
        List<CentreDto> List();
        List<CentreDto> ListByCity(int cityID);
        List<CentreDto> ListByRegionalManger(int regionalID);
    }
}
