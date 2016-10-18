using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Security.AccessControl;


namespace RansomTest
{
    public class CurrentUserSecurity
    {
        WindowsIdentity _currentUser;
        WindowsPrincipal _currentPrincipal;

        public CurrentUserSecurity()
        {
            _currentUser = WindowsIdentity.GetCurrent();
            _currentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        }

        public bool HasAccess(DirectoryInfo directory, FileSystemRights right)
        {
            // Get the collection of authorization rules that apply to the directory.
            AuthorizationRuleCollection acl = directory.GetAccessControl()
                .GetAccessRules(true, true, typeof(SecurityIdentifier));
            return HasFileOrDirectoryAccess(right, acl);
        }

        public bool HasAccess(FileInfo file, FileSystemRights right)
        {
            // Get the collection of authorization rules that apply to the file.
            AuthorizationRuleCollection acl = file.GetAccessControl()
                .GetAccessRules(true, true, typeof(SecurityIdentifier));
            return HasFileOrDirectoryAccess(right, acl);
        }

        public bool HasDamagingPermissions(DirectoryInfo file)
        {
            AuthorizationRuleCollection acl;

            try
            {
                acl = file.GetAccessControl()
                    .GetAccessRules(true, true, typeof(SecurityIdentifier));
            }
            catch (UnauthorizedAccessException unauth_ex)
            {
                return false; //Is this always false though, just because we cant list security permissions?
            }
            catch
            {
                return false; //Misc Error reading
            }

            if (
                HasFileOrDirectoryAccess(FileSystemRights.AppendData, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Write, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Modify, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Delete, acl))
            {
                return true;
            }
            return false;
        }
        public bool HasDamagingPermissions(FileInfo file)
        {
            AuthorizationRuleCollection acl;
            try
            {
                acl = file.GetAccessControl()
                    .GetAccessRules(true, true, typeof(SecurityIdentifier));
            }
            catch(UnauthorizedAccessException unauth_ex)
            {
                return false; //Is this always false though, just because we cant list security permissions?
            }
            catch
            {
                return false; //Misc Error reading
            }

            if(
                HasFileOrDirectoryAccess(FileSystemRights.AppendData, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Write, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Modify, acl) ||
                HasFileOrDirectoryAccess(FileSystemRights.Delete, acl))
            {
                return true;
            }
            return false;
        }

        private bool HasFileOrDirectoryAccess(FileSystemRights right,
                                              AuthorizationRuleCollection acl)
        {
            bool allow = false;
            bool inheritedAllow = false;
            bool inheritedDeny = false;

            for (int i = 0; i < acl.Count; i++)
            {
                FileSystemAccessRule currentRule = (FileSystemAccessRule)acl[i];
                // If the current rule applies to the current user.
                if (_currentUser.User.Equals(currentRule.IdentityReference) ||
                    _currentPrincipal.IsInRole(
                                    (SecurityIdentifier)currentRule.IdentityReference))
                {

                    if (currentRule.AccessControlType.Equals(AccessControlType.Deny))
                    {
                        if ((currentRule.FileSystemRights & right) == right)
                        {
                            if (currentRule.IsInherited)
                            {
                                inheritedDeny = true;
                            }
                            else
                            { // Non inherited "deny" takes overall precedence.
                                return false;
                            }
                        }
                    }
                    else if (currentRule.AccessControlType
                                                    .Equals(AccessControlType.Allow))
                    {
                        if ((currentRule.FileSystemRights & right) == right)
                        {
                            if (currentRule.IsInherited)
                            {
                                inheritedAllow = true;
                            }
                            else
                            {
                                allow = true;
                            }
                        }
                    }
                }
            }

            if (allow)
            { // Non inherited "allow" takes precedence over inherited rules.
                return true;
            }
            return inheritedAllow && !inheritedDeny;
        }
    }
}
