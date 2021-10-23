using AmeliorateAegis.Areas.Regional.Models;
using AmeliorateAegis.Models.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data.Services.Regional.Visitor
{
    public class VisitorService : IVisitorService
    {
        private readonly ApplicationDbContext _context;

        public VisitorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddVisitor(VisitorDto model)
        {
            try
            {
                _context.ScheduleVisits.Add(new ScheduleVisit
                {
                    //ScheduleVisitID = model.ScheduleVisitID,
                    VisitDescr = model.VisitDescr,
                    Date = model.Date,
                    Time = model.Time,
                    Duration = model.Duration,
                    ReasonForVisit = model.ReasonForVisit,
                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteVisitor(int ScheduleVisitID)
        {
            var visitor = _context.ScheduleVisits.Find(ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {ScheduleVisitID} was not found.");

            _context.ScheduleVisits.Remove(visitor);
            return _context.SaveChanges() > 0;
        }

        public VisitorDto GetVisitor(int ScheduleVisitID)
        {
            var visitor = _context.ScheduleVisits.Find(ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {ScheduleVisitID} was not found.");


            return new VisitorDto
            {
                ScheduleVisitID = visitor.Id,
                VisitDescr = visitor.VisitDescr,
                Date = visitor.Date,
                Time = visitor.Time,
                Duration = visitor.Duration,
                ReasonForVisit = visitor.ReasonForVisit,
            };
        }

        public bool UpdateVisitor(VisitorDto model)
        {
            var visitor = _context.ScheduleVisits.Find(model.ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {model.ScheduleVisitID} was not found.");

            visitor.VisitDescr = model.VisitDescr;
            visitor.Date = model.Date;
            visitor.Time = model.Time;
            visitor.Duration = model.Duration;
            visitor.ReasonForVisit = model.ReasonForVisit;

            return _context.SaveChanges() > 0;
        }
    }
}
