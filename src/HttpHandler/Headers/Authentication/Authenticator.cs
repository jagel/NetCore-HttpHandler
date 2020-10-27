using System.Net.Http.Headers;
using System.Text;
using System;

namespace HttpHandler.Headers.Authenticator
{
    public static class Authenticator
    {
        /// <summary>
        /// Set Basic Authentication
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public static AuthenticationHeaderValue Basic(string username, string password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}