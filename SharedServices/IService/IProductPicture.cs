using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface IProductPicture : IService<ProductPicture>
    {
        void Update(ProductPicture productPicture);
    }
}
