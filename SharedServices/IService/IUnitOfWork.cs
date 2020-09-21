using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryService Category { get; }

        ICustomerBasketService CustomerBasket {get;}

        IProductService Product { get; }

        IProductPicture ProductPicture { get; }

        ISuplierService Supplier { get; }

        IPictuerService Pictuer { get; }

        IProductSpecification ProductSpecification { get; }

        IOrderService OrderService { get; }

        void Save();


    }
}
