using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Project.BL.DTOs;
using Project.BL.Helpers;
using Project.BL.Services.Abstractions;
using Project.DAL.Entities;
using Project.DAL.Exceptions;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IGenericRepository<Treatment> _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public TreatmentService(IGenericRepository<Treatment> repo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(TreatmentCreateDto dto)
        {
            Treatment? treatment=_mapper.Map<Treatment>(dto)??throw new BaseException("Treatment not found");
            treatment.CreatedAt=DateTime.Now;
            if (treatment.TreatmentPhoto != null)
            {
                string root=_env.WebRootPath;
                string filename = await  treatment.TreatmentPhoto.ImageUpload(Path.Combine(root, "Upload", "Images"));
                treatment.TreatmentImageUrl = filename;
            }
            await _repo.CreateAsync(treatment);
            await _repo.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var oldTreament = await _repo.GetOneAsync(id) ?? throw new BaseException("Treatment Not Found");
            _repo.DeleteAsync(oldTreament);
            await _repo.SaveChangesAsync();
        }

        public async Task<ICollection<Treatment>> GetAllAsync()
        {
          return await _repo.GetAllAsync();
        }

        public async Task<Treatment> GetOneByIdAsync(int id)
        {
            var oneTreatment=await _repo.GetOneAsync(id) ?? throw new BaseException();
            return oneTreatment;
        }

        public async Task UpdateAsync(int id, TreatmentCreateDto dto)
        {
            var oldTreament=await _repo.GetOneAsync(id)??throw new BaseException("Treatment Not Found");
            Treatment? treatment = _mapper.Map<Treatment>(dto) ?? throw new BaseException("Treatment not found");
            treatment.UpdatedAt = DateTime.Now;
            treatment.Id = id;
            if (treatment.TreatmentPhoto != null)
            {
                string root = _env.WebRootPath;
                string filename = await treatment.TreatmentPhoto.ImageUpload(Path.Combine(root, "Upload", "Images"));
                treatment.TreatmentImageUrl = filename;
            }
            _repo.UpdateAsync(treatment);
            await _repo.SaveChangesAsync();

        }
    }
}
