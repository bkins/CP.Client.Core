namespace CP.Client.Core.Web
{
    public class ApiEnvironmentDescriptor
    {
        public string Name      { get; }
        public string BaseUrl   { get; }
        public string OllamaUrl { get; }

        public ApiEnvironmentDescriptor(string name, string baseUrl, string ollamaUrl)
        {
            Name      = name;
            BaseUrl   = baseUrl.TrimEnd('/');
            OllamaUrl = ollamaUrl.TrimEnd('/');
        }
    }
}
