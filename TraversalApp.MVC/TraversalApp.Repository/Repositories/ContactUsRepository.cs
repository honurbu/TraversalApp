using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Repository.Context;

namespace TraversalApp.Repository.Repositories
{
    public class ContactUsRepository : GenericRepository<ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(AppDbContext context) : base(context)
        {
        }

        public void ContactUsStatusChangeToFalse(int id)
        {
            var values = _context.ContactUses.Find(id);
            if (values != null)
            {
                values.Status = false;
            }
        }

        public void ContactUsStatusChangeToTrue(int id)
        {
            var values = _context.ContactUses.Find(id);
            if (values != null)
            {
                values.Status = true;
            }
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            return _context.ContactUses.Where(x => x.Status == false).ToList();
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            return _context.ContactUses.Where(x=>x.Status==true).ToList();
        }
    }
}
