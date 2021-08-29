using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string loginDb =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\login.pass");

        public bool validateAuthentication(string username, string password)
        {
            string[] loginData = File.ReadAllLines(loginDb);
            byte[] data = Convert.FromBase64String(loginData[1]);
            string decodedPassword = Encoding.UTF8.GetString(data);
            return username == loginData[0] && password == decodedPassword;
        }
    }
}
