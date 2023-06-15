using AutoMapper;
using WalletManagement.Core.Domain.RequestDTO;
using WalletManagement.Core.Domain.ResponseDTO;
using WalletManagement.Infra.Domain.Entity;

namespace NewWalletmanagement.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequestDTO, User>().ForMember(dest => dest.accountDetails, opt => opt.Ignore()).ReverseMap();
            CreateMap<UserResponseDTO, User>().ReverseMap();
        }
    }
}