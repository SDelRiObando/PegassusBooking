using Microsoft.EntityFrameworkCore;
using PegassusBooking.Models;
using PegassusBooking.Repositories;
using PegassusBooking.Repositories.Interfaces;
using PegassusBooking.Utilities;
using PegassusBooking.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Services
{
    public class HospitalService : IHospital
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationDBContext _context;
        public HospitalService(IUnitOfWork unitOfWork, ApplicationDBContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public void DeleteHospital(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            _unitOfWork.GenericRepository<Hospital>().Delete(model);
            _unitOfWork.Save();

        }

        public PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HospitalViewModel();
            int totalCount;
            List<HospitalViewModel> vmList = new List<HospitalViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Hospital>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                
                totalCount = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<HospitalViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;

        }

        public List<Hospital> GetAll()
        {
            var HospiList =  _context.Hospitals.ToList();
            return HospiList;
        }

        public IEnumerable<ApplicationUserViewModel> GetDoctorsByHospitalId(int hospitalId)
        {
            throw new NotImplementedException();
        }

        public HospitalViewModel GetHospitalById(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetById(id);
            var vm = new HospitalViewModel(model);
            return vm;
        }

        public void InsertHospital(HospitalViewModel Hospital)
        {
            var model = new HospitalViewModel().ConvertViewModel(Hospital);
            _unitOfWork.GenericRepository<Hospital>().Add(model);
            _unitOfWork.Save();
        }

        public IEnumerable<HospitalViewModel> SearchHospitals(string searchTerm)
        {
            var modelList = _unitOfWork.GenericRepository<Hospital>()
                        .Where(h => h.Name.Contains(searchTerm))
                        .ToList();

            return ConvertModelToViewModelList(modelList);
        }

        public void UpdateHospital(HospitalViewModel hospital)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospital);
            var modelById = _unitOfWork.GenericRepository<Hospital>().GetById(model.Id);
            modelById.Name = hospital.Name;
            modelById.Street = hospital.Street;
            modelById.City = hospital.City;
            modelById.State = hospital.State;
            modelById.Zipcode = hospital.Zipcode;
            _unitOfWork.GenericRepository<Hospital>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<HospitalViewModel> ConvertModelToViewModelList(List<Hospital> modelList)
        {
            return modelList.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}
