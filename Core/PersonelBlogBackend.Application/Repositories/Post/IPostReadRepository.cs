﻿using PersonelBlogBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Repositories
{
    public interface IPostReadRepository : IReadRepository<Post>
    {
    }
}