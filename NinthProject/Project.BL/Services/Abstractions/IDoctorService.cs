using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IDoctorService
    {
        public Task<ICollection<Doctor>> GetAllAsync();
        public Task<Doctor> GetOneByIdAsync(int id);
        public Task CreateAsync(DoctorCreateDto dto);
        public Task UpdateAsync(int id, DoctorCreateDto dto);
        public Task DeleteAsync(int id);

    }
}
