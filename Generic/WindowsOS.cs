//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Security.Principal;


namespace Generic
{

    public static class WindowsOS
    {
        public enum SIL
        {
            SecurityAnonymous = 0,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }

        //Valida el user y password de una cuenta de windows que este creada en este equipo, puede cambiar al usuario actual estableciendo changeUser = true
        public static bool UserAutenticate(string user, string password, bool changeUser = false)
        {
            bool isDuplicate, isValid = false;
            IntPtr ptrExists = IntPtr.Zero, ptrDuplicate = IntPtr.Zero;

            string domain = System.Environment.MachineName;

            try
            {
                int securityLevel = (int)SIL.SecurityImpersonation;
                isValid = WinAPI.LogonUser(user, domain, password, securityLevel, 0, ref ptrExists);
                isDuplicate = WinAPI.DuplicateToken(ptrExists, securityLevel, ref ptrDuplicate);

                if (isValid && changeUser)
                {
                    WindowsIdentity newId = new WindowsIdentity(ptrDuplicate);
                    WindowsImpersonationContext impersonatedUser = newId.Impersonate();
                    isValid = true;
                }
            }
            catch { isValid = false; }

            return isValid;
        }

        public static void ChangePasswordUser(string userName, string oldPassword, string newPassword)
        {
            try
            {
                string domain = Environment.UserDomainName;
                WinAPI.NetUserChangePassword(domain, userName, oldPassword, newPassword);
            }
            catch { throw; }
        }

    }
}
