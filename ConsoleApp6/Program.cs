using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace ConsoleApp6
{
    /// <summary>
    /// Install-Package System.DirectoryServices.AccountManagemen 
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var ctx = new PrincipalContext(ContextType.Domain, "MyDomain"))
                {
                    var myDomainUsers = new List<string>();
                    var userPrinciple = new UserPrincipal(ctx);
                    using (var search = new PrincipalSearcher(userPrinciple))
                    {
                        foreach (var domainUser in search.FindAll())
                        {
                            if (domainUser.DisplayName != null)
                            {
                                myDomainUsers.Add(domainUser.DisplayName);
                            }
                        }
                    }

                    foreach (var item in myDomainUsers)
                    {
                        Console.WriteLine(item);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            Console.ReadLine();
        }
    }
}
