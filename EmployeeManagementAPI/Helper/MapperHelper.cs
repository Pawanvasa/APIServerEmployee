using AutoMapper;

namespace EmployeeManagement.Helper
{

    public class MyMappingHelper<TSource, TDestination> : Profile
    {
        public MyMappingHelper()
        {
            CreateMap<TSource, TDestination>();
        }
    }
}
