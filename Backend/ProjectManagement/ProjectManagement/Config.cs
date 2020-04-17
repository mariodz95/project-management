using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ProjectManagement
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "309eeffb-5b13-4e97-ad00-ab1a3d92414c",
                    Username = "mario",
                    Password = "mario123",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "mario"),
                        new Claim("family_name", "dzoic"),
                    }
                },
                new TestUser
                {
                    SubjectId = "ef0e98a5-1aca-494e-ab61-522ad492c201",
                    Username = "adela",
                    Password = "adela123",

                    Claims = new List<Claim>
                    {
                    new Claim("given_name", "adela"),
                    new Claim("family_name", "vinkovic"),
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "Admin",
                    ClientId = "adminclient",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44301/signin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}
