using RepoEFCosSQLWeb.Enums;

namespace RepoEFCosSQLWeb.ConfigurationOptions
{
    public class AppSettings
    {
        public List<ConnectionString> ConnectionStrings { get; set; }
    }

    public class ConnectionString
    {
        public string? ConnString { get; set; }

        public CommonEnums.ConnType ConnType { get; set; }
        public bool IsActive { get; set; }
    }
}
