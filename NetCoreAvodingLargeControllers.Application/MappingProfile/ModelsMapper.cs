using AutoMapper;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.CreateApplicant;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Commands.UpdateApplicant;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantDetails;
using NetCoreAvodingLargeControllers.Application.Command_Query.TestApplicant.Queries.GetApplicantsList;
using NetCoreAvoidingLargeControllers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAvodingLargeControllers.Application.MappingProfile
{
    public class ModelsMapper : Profile
    {
        public ModelsMapper()
        {
            CreateMap<TestApplicant, CreateApplicantDto>().ReverseMap();
            CreateMap<TestApplicant, CreateApplicantCommand>().ReverseMap();
            CreateMap<TestApplicant, UpdateApplicantCommand>().ReverseMap();
            CreateMap<TestApplicant, TestApplicantVm>().ReverseMap();
            CreateMap<TestApplicant, TestApplicantListVm>().ReverseMap();
            CreateMap<TestInfo, TestInfoDto>().ReverseMap();
        }
    }
}
