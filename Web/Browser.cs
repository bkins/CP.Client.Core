using System.Diagnostics;

namespace CP.Client.Core.Web
{
    public static class Browser
    {
        public static void OpenUrl(string url)
        {
            var psi = new ProcessStartInfo
                      {
                              FileName        = url,
                              UseShellExecute = true
                      };

            Process.Start(psi);
        }
    }
}