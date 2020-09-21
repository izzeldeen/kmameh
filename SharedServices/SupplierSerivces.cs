using Core;
using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public class SupplierSerivces : Service<Supplier>, ISuplierService
    {
        private readonly StoreContext _context;

        public SupplierSerivces(StoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
