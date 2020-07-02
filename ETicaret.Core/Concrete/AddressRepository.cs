using ETicaret.Core.Base;
using ETicaret.Core.Abstract;
using ETicaret.Domain.Models;
using ETicaret.Domain.Context;

namespace ETicaret.Core.Concrete
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ETicaretContext context) : base(context)
        {
        }
    }
    
}
