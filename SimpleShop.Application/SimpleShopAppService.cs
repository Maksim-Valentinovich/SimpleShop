using AutoMapper;
using SimpleShop.Domain;

namespace SimpleShop.Application
{
    public abstract class SimpleShopAppService
    {
        protected SimpleShopContext Context { get; set; }

        protected IMapper Mapper { get; set; }

        protected SimpleShopAppService(SimpleShopContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
