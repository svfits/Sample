using AutoMapper;
using SF.DAL;
using SF.WebApi.BL.Request;
using SF.WebApi.BL.Response;

namespace SF.WebApi.BL;

public class MapBL : Profile
{
    public MapBL()
    {
        CreateMap<User, UserResponse>();

        CreateMap<UserRequest, User>()
            .ForMember(d => d.Key, m => m.Ignore());
    }
}
