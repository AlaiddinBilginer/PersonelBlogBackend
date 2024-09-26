using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task RenewRefreshTokenAsync(string refreshToken, ApplicationUser user, DateTime accessTokenExpiryDate, int addOnAccessTokenDate);
    }
}
