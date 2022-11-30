using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Abstract
{
    public interface ICompanyIntroductionService
    {
        Task CreateAsync(CompanyIntroduction companyIntroduction);
        Task<CompanyIntroduction> GetByIdAsync(int id);
        Task<List<CompanyIntroduction>> GetAllAsync();
        void Update(CompanyIntroduction companyIntroduction);
        void Delete(CompanyIntroduction companyIntroduction);
    }
}
