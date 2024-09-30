using PersonelBlogBackend.Application.DTOs;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int accessTokenLifetime, ApplicationUser user);
        string CreateRefreshToken();
    }
}
