using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Services
{
    public interface IGuideService : IGenericService<Guide>
    {
        void ChangeToFalseByGuid(int id);
        void ChangeToTrueByGuid(int id);

    }
}
