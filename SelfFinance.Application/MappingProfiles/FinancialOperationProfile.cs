using AutoMapper;
using SelfFinance.Application.DTOs.FinancialOperation;
using SelfFinance.Domain.Entities;

namespace SelfFinance.Application.MappingProfiles;

public class FinancialOperationProfile : Profile
{
    public FinancialOperationProfile()
    {
        CreateMap<FinancialOperation, FinancialOperationDto>()
            .ReverseMap()
            .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
            .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionTypeId));
        CreateMap<FinancialOperationCreateDto, FinancialOperation>();
        CreateMap<FinancialOperationUpdateDto, FinancialOperation>();     
    }
}