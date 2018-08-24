using MTechneTeste.Domain.Entities.Base;
using MTechneTeste.Domain.Interfaces.Services.Base;

namespace MTechneTeste.Domain.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
    }
}
