using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Config
    {
        /// <summary>
        /// 这个ApiResource参数就是我们Api
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetSoluction()
        {
            return new[]
            {
               new ApiResource("api1", "MY API"),
               new ApiResource("api2", "MY API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256()),
                    },
                    AllowedScopes = {"api1"}
                },
                new Client
                {
                    ClientId = "Client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret1".Sha256()),
                    },
                    AllowedScopes = {"api1", "api2" }
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api2" }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "123"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "121"
                }
            };
        }
    }
}
