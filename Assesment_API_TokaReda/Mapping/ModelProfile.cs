using Assesment_API_TokaReda.DTOs.Application;
using Assesment_API_TokaReda.DTOs.CandidateProfile;
using Assesment_API_TokaReda.DTOs.Company;
using Assesment_API_TokaReda.DTOs.Job;
using Assesment_API_TokaReda.Models;
using AutoMapper;

namespace Assesment_API_TokaReda.Mapping
{
    public class ModelProfile:Profile
    {
        public ModelProfile() {

            CreateMap<CreateJobDTO, Job>();
            CreateMap<Job, GetJobDTO>();

            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<Company, GetCompanyDTO>();

            CreateMap<CreateApplicationDTO, Application>();
            CreateMap<Application, GetApplicationDTO>();


            CreateMap<CandidateProfile, GetCandidateProfileDTO>();
            CreateMap<UpdateCandidateDTO, CandidateProfile>();


        }
    }
}
