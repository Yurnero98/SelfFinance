using AutoMapper;
using SelfFinance.Application.DTOs.TransactionType;
using SelfFinance.Domain.Entities;

namespace SelfFinance.Application.MappingProfiles;

public class TransactionTypeProfile : Profile
{
    public TransactionTypeProfile()
    {
        CreateMap<TransactionTypeCreateDto, TransactionType>();
        CreateMap<TransactionTypeUpdateDto, TransactionType>();
        CreateMap<TransactionType, TransactionTypeDto>();
    }
}