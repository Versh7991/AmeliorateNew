using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Data.Services.Regional.Budget
{
    public class BudgetService
    {
        private readonly ApplicationDbContext _context;
        public BudgetService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
