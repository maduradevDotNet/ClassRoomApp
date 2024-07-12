using AutoMapper;
using FullStack.Services.API.Model;
using FullStack.Services.API.Model.Dto;

namespace FullStack.Services.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<Student, StudentDto>();
            });

            return mappingConfig;
        }
    }
}
