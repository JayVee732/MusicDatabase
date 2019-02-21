using DiscogsClient;
using RestSharpHelper.OAuth1;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            // var oAuthConsumerInformation = new OAuthConsumerInformation("zXArRXRplWASePBxIaqD", "zpIIsdnyrJxsjiokxMdlzuzUdsAjzpzJ");
            // var discogsClient = new DiscogsAuthentifierClient(oAuthConsumerInformation);

            // var aouth = discogsClient.Authorize(s => Task.FromResult(GetToken(s))).Result;
        }

        private static string GetToken(string url)
        {
            // Console.WriteLine("Please authourize the application and enter the final key in the console");
            Process.Start(url);
            string tokenKey = Console.ReadLine();
            tokenKey = string.IsNullOrEmpty(tokenKey) ? null : tokenKey;
            return tokenKey;
        }
    }
}
