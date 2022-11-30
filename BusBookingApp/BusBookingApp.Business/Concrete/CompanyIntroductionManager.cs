using BusBookingApp.Business.Abstract;
using BusBookingApp.Data.Abstract;
using BusBookingApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingApp.Business.Concrete
{
    public class CompanyIntroductionManager : ICompanyIntroductionService
    {
        private ICompanyIntroductionRepository _companyRepository;

        public CompanyIntroductionManager(ICompanyIntroductionRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task CreateAsync(CompanyIntroduction companyIntroduction)
        {
            await _companyRepository.CreateAsync(companyIntroduction);
        }

        public void Delete(CompanyIntroduction companyIntroduction)
        {
            _companyRepository.Delete(companyIntroduction);
        }

        public async Task<List<CompanyIntroduction>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<CompanyIntroduction> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public void Update(CompanyIntroduction companyIntroduction)
        {
            throw new NotImplementedException();
        }
    }
}
