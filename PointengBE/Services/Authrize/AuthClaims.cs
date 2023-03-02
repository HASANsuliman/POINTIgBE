using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PointengBE.Models;
using PointengBE.Models.Context;
using System.Security.Claims;

namespace PointengBE.Services.Authrize
{
    public class AuthClaims : IClaimsTransformation
    {
        private readonly PointingContext? _context;
        public AuthClaims(PointingContext? context)
        {
            _context = context;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var customClaims = await _context
                                   .CustomClaims
                                   .Where(x => x.Username == principal.Identity.Name).ToArrayAsync();

            var clone = principal.Clone();
            var identity = (ClaimsIdentity)clone.Identity;
          //  var clones = principal.HasClaim(x=>x.Type== customClaims[0].Group);

            foreach (var customClaim in customClaims)
            {
                var value = customClaim.Value.ToString();
                var type = customClaim.Type.ToString();
                identity.AddClaim(new Claim(type,value));
                //identity.AddClaim(new Claim(type, value));
            }

            return clone;
        }
    

    }
}
