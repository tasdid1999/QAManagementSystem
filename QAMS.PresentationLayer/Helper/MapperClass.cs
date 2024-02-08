using AutoMapper;
using QAMS.DataAccessLayer.DataContext;
using QAMS.DataAccessLayer.Domain;
using QAMS.ServiceLayer.ClientEntity.auth;
using QAMS.ServiceLayer.ClientEntity.comment;
using QAMS.ServiceLayer.ClientEntity.question;

namespace QAMS.PresentationLayer.Helper
{

    public class MapperClass : Profile
        {
            public MapperClass()
            {
                CreateMap<ApplicationUser,RegisterViewModel>().ReverseMap();
                CreateMap<QuestionRequestVm,Question>().ReverseMap();
                CreateMap<CommentRequestVm, Comment>().ReverseMap();
            }
        }
    
}
