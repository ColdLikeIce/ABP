using AutoMapper;
using MyDemo.GameUsers;
namespace MyDemo
{
    public class MyDemoApplicationAutoMapperProfile : Profile
    {
        public MyDemoApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
             CreateMap<LoginUserDto, GameUser>();
             CreateMap<RegisterUserDto, GameUser>();
        }
    }
}
