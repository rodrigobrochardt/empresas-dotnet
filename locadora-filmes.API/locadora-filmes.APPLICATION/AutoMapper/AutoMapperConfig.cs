using AutoMapper;

namespace locadora_filmes.APPLICATION.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper mapper { get; set; }

        public static void RegisterMapping()
        {
            var mapperConfig = new MapperConfiguration(config => { config.AddProfile<EntityToModel>(); config.AddProfile<ModelToEntity>(); });
            mapper = mapperConfig.CreateMapper();
        }
        
    }
}
