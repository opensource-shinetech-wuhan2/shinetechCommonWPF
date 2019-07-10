
using AutoMapper;
using Business.MapperProfile;

namespace WebApi.Common
{
    /// <summary>
    /// AutoMapper Factory
    /// </summary>
    public class MapperFactory
    {
        public IMapper CreateMapper (IConfigurationProvider configuration = null)
           => new Mapper(configuration ?? CreateConfiguration());

        public IConfigurationProvider CreateConfiguration ()
            => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(BusinessProfile).Assembly);
            });
    }
}
