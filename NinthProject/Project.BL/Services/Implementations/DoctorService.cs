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
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public DoctorService(IGenericRepository<Doctor> repo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _mapper = mapper;
            _env = env;
        }
        public async Task CreateAsync(DoctorCreateDto dto)
        {
            Doctor? doctor = _mapper.Map<Doctor>(dto) ?? throw new BaseException("Doctor not found");
            doctor.CreatedAt = DateTime.Now;
            if (doctor.DoctorPhoto != null)
            {
                string root = _env.WebRootPath;
                string filename = await doctor.DoctorPhoto.ImageUpload(Path.Combine(root, "Upload", "Images"));
                doctor.DoctorImageUrl = filename;
            }
            await _repo.CreateAsync(doctor);
            await _repo.SaveChangesAsync();
        }

        public async  Task DeleteAsync(int id)
        {
            var oldDoctor = await _repo.GetOneAsync(id) ?? throw new BaseException("Doctor Not Found");
            _repo.DeleteAsync(oldDoctor);
            await _repo.SaveChangesAsync();
        }

        public async Task<ICollection<Doctor>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Doctor> GetOneByIdAsync(int id)
        {
            var oneDoctor = await _repo.GetOneAsync(id)??throw new BaseException();
            return oneDoctor;
        }

        public async Task UpdateAsync(int id, DoctorCreateDto dto)
        {

            var oldDoctor = await _repo.GetOneAsync(id) ?? throw new BaseException("Doctor Not Found");
            Doctor? doctor = _mapper.Map<Doctor>(dto) ?? throw new BaseException("Doctor not found");
            doctor.UpdatedAt = DateTime.Now;
            doctor.Id = id;
            if (doctor.DoctorPhoto != null)
            {
                string root = _env.WebRootPath;
                string filename = await doctor.DoctorPhoto.ImageUpload(Path.Combine(root, "Upload", "Images"));
                doctor.DoctorImageUrl = filename;
            }
            _repo.UpdateAsync(doctor);
            await _repo.SaveChangesAsync();
        }
    }
}
