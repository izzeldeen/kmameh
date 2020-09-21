using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface IProductSpecification : IService<Core.ProductSpecification>
    {
        void Update(Core.ProductSpecification productSpecification);
    }
}
