using AutoMapper;
using PracticalTest.Core.Dtos;
using PracticalTest.Core.Entities;

namespace PracticalTest.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Loan, LoanDto>().
                ForMember(
                    x => x.ClientUniqueId, 
                    opt => opt.MapFrom(y => y.Client.ClientUniqueId)).
                ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Loan, CalculateLoanDto>().ReverseMap();
            CreateMap<Invoice, InvoicesTableDto>().ReverseMap();
            CreateMap<Loan, LoanInsertDto>().ReverseMap();
            CreateMap<Loan, LoanDetailsDto>().ReverseMap();
        }
    }
}