using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthenticationServer
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<Client> Clients = new List<Client>
        {
            new Client()
            {
                ClientId = "MvcClientApp",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = { new Secret("MvcClientAppSecret".ToSha256()) },
                RedirectUris = { "http://localhost:59138/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:59138/signout-callback-oidc" },
                RequireConsent = false,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                }
            }
        };

        public static IEnumerable<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource("api1"),
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            new ApiScope("api1")
        };

        public static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
}