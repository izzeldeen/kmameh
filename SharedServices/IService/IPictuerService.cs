using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface IPictuerService : IService<Picture>
    {
        void Update(Picture picture);

    }
}
