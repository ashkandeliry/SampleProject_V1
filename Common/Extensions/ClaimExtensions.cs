using System;
using System.Linq;
using System.Security.Claims;

namespace Common.Extensions
{
    public static class ClaimExtensions
    {
        public static string GetId(this ClaimsPrincipal user) { return user?.Claims?.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value; }
    }
}
