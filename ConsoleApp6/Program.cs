using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace ConsoleApp6
{
    /// <summary>
    /// Install-Package System.DirectoryServices.AccountManagemen 
    /// Install-Package Novell.Directory.Ldap.NETStandard -Version 2.3.8
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region comment
                //using (var ctx = new PrincipalContext(ContextType.Domain, "MyDomain"))
                //{
                //    var myDomainUsers = new List<string>();
                //    var userPrinciple = new UserPrincipal(ctx);
                //    using (var search = new PrincipalSearcher(userPrinciple))
                //    {
                //        foreach (var domainUser in search.FindAll())
                //        {
                //            if (domainUser.DisplayName != null)
                //            {
                //                myDomainUsers.Add(domainUser.DisplayName);
                //            }
                //        }
                //    }

                //    foreach (var item in myDomainUsers)
                //    {
                //        Console.WriteLine(item);
                //    }

                //}
                #endregion

                var canLogin = ValidateUser("SarakakisDomain", "UserName", "Password");
                Console.WriteLine(canLogin);
            }
            catch (Exception)
            {
                throw;
            }

            Console.ReadLine();
        }

        public static bool ValidateUser(string domainName, string username, string password)
        {
            string userDn = $"{username}@{domainName}";

            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    connection.Connect(domainName, LdapConnection.DEFAULT_PORT);
                    connection.Bind(userDn, password);

                    if (connection.Bound)
                        return true;
                }
            }
            catch (LdapException ex)
            {
                // Log exception
            }
            return false;
        }
    }

}
}
