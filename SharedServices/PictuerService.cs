using Core;
using DataAccess.Data;
using SharedServices.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices
{
    public class PictuerService : Service<Picture>, IPictuerService
    {
        private readonly StoreContext _context;

        public PictuerService(StoreContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Picture pictuer)
        {
            _context.Pictures.Update(pictuer);
            _context.SaveChanges();
        }
    }
}
