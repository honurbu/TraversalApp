﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Services
{
    public interface ICommentService : IGenericService<Comment>
    {
        IQueryable<Comment> GetDestinationById(int id);
        IQueryable<Comment> GetListCommentWithDestination();
        List<Comment> GetListCommentWithAppUser(int id);
        IQueryable<Comment> GetListCommentWithDestination(int id);

    }
}
