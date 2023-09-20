using Application.DTOs;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Common;
using Infrastructure.Repositories.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Patients
{
	public class PatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepository;
		private readonly IMapper _mapper;

		public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
			_patientRepository = patientRepository;
			_mapper = mapper;
		}
		public async Task<List<PatientsDto>> GetAllPatients()
		{
			var patients = await _patientRepository.GetAllPatients();
			return _mapper.Map<List<PatientsDto>>(patients);
		}

		public async Task<PatientsDto> GetPatientById(int id)
		{
			var patient = await _patientRepository.GetPatientById(id);
			return _mapper.Map<PatientsDto>(patient);
		}
		public async Task Add(PatientsDto patientsDto)
		{
			var patientAdd = _mapper.Map<Patient>(patientsDto);
			await _patientRepository.Add(patientAdd);
		}
		public async Task Update(PatientsDto patientsDto)
		{
			var patientUpdate = _mapper.Map<Patient>(patientsDto);
			await _patientRepository.Update(patientUpdate);
		}

		public async Task Delete(int id)
		{
			await _patientRepository.Delete(id);	
		}

		public Task<PagedResult<PatientsDto>> GetAllPaging(PagingDto pagingDto)
		{
			throw new NotImplementedException();
		}
	}
}
