using System;

namespace SchwabenCode.Samples.ASPMVC5_Google2WayAuthentication.Areas.Account.Models
{
    public class SampleUser
    {
        /// <summary>
        /// Username 
        /// </summary>
        public String Username = "Admin";

        /// <summary>
        /// Please use salted passwords! http://en.wikipedia.org/wiki/Salt_(cryptography)
        /// </summary>
        public String Password = "123456";

        /// <summary>
        /// This secret must be created on user create. 10 Chars are required by Google.
        /// The user has to scan the auth-barcore again if you reset or change this code.
        /// You can use <see cref="SchwabenCode.Authentication.GoogleTwoWayAuthenticator.GenerateSecret"/> for secure secret generation.
        /// </summary>
        public String Secret = "hgs3dLwuFn";
    }
}