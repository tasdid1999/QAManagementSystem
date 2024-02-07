using AutoMapper;
using QAMS.DataAccessLayer.DataContext;
using QAMS.ServiceLayer.ClientEntity.auth;

namespace QAMS.PresentationLayer.Helper
{

    public class MapperClass : Profile
        {
            public MapperClass()
            {
                CreateMap<ApplicationUser,RegisterViewModel>().ReverseMap();
            }
        }
    
}
