using PegassusBooking.Models;
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
    public interface IHospital
    {
        PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize);
        HospitalViewModel GetHospitalById(int id);
        void UpdateHospital(HospitalViewModel hospital);
        void InsertHospital(HospitalViewModel Hospital);
        void DeleteHospital(int id);
        List<Hospital> GetAll();
        IEnumerable<HospitalViewModel> SearchHospitals(string searchTerm);
        IEnumerable<ApplicationUserViewModel> GetDoctorsByHospitalId(int hospitalId);
    }
}
