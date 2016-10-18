using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace RansomTest.Utilities
{
    static class UserPermissions
    {
        internal static string[] GetGroups()
        {
            PrincipalSearchResult<Principal> groups = UserPrincipal.Current.GetGroups();

            return groups.Select(x => x.SamAccountName).ToArray();
        }
    }
}
