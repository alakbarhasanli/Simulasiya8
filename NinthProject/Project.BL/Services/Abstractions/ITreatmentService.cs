using Project.BL.DTOs;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface ITreatmentService
    {
        public Task<ICollection<Treatment>> GetAllAsync();
        public Task<Treatment> GetOneByIdAsync(int id);
        public Task CreateAsync(TreatmentCreateDto dto);
        public Task UpdateAsync(int id, TreatmentCreateDto dto);
        public Task DeleteAsync(int id);
    }
}
