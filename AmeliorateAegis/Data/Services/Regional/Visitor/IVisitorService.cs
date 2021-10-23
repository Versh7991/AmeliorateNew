using AmeliorateAegis.Areas.Regional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data.Services.Regional.Visitor
{
    public interface IVisitorService
    {
        bool AddVisitor(VisitorDto model);
        bool UpdateVisitor(VisitorDto model);
        VisitorDto GetVisitor(int ScheduleVisitID);
        bool DeleteVisitor(int ScheduleVisitID);
    }
}
