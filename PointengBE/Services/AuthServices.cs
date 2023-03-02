using Microsoft.EntityFrameworkCore;
using PointengBE.Models;
using PointengBE.Models.Auth;
using PointengBE.Models.Context;
using PointengBE.Models.DataBinding;
using PointengBE.Services.Interfaaces;
using System.Security.Claims;

namespace PointengBE.Services
{
    public class AuthServices : AuthInterface
    {
        protected PointingContext? _context;
        public AuthServices(PointingContext context)
        {
            _context = context;


        }
        public async Task<DataWithErros> GetName(ClaimsPrincipal user)
        {
            var name = user.Identity.Name;
            DataWithErros data = new();
            var customClaims = await _context
                                   .CustomClaims
                                   .FirstOrDefaultAsync(x => (x.Username).ToLower() == name.ToLower());
            if (customClaims == null)
            {
                CustomClaims newUser = new(name, null, "license", "User");
                await _context.CustomClaims.AddAsync(newUser);
                await _context.SaveChangesAsync();
                data.Result = newUser;
                data.ErrorMessage = null;
                return data;
            }
            var claim = user.Identity;
            data.Result = customClaims;
            data.ErrorMessage = null;
            return data;
        } 
        //public async Task<DataWithErros> AsignUserToRole(RoleAssignment model, ClaimsPrincipal user)
        //{
        //    DataWithErros data = new();
        //    var name = user.Identity.Name;
        //    var existUser = _context.CustomClaims.FirstOrDefault(x => x.Username == model.Name);
        //  //  var existUserAd = _context.Ads.FirstOrDefault(x => x.Name == model.Name);

        //    if (existUser.Value=="User" || existUser==null)
        //    {
        //        existUser.Value = model.Role;
        //        existUser.Group = existUserAd.Title;
        //       await _context.SaveChangesAsync();
        //    }
        //    data.Result = existUser;
        //    data.ErrorMessage = null;
        //    return data;


        //}
        //public async Task<DataWithErros> GetNameFromAd()
        //{
        //    DataWithErros data = new();
        //    var Names = _context.Ads.OrderBy(x => x.Name).Select(cc=>cc.Name).ToList();
        //    data.Result = Names;
        //    data.ErrorMessage = null;
        //    return data;
        //}

    }

}
