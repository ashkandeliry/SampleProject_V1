namespace ViewModels.Settings
{
    public class SiteSettings
    {
        public string PrefixUrl { get; set; }
        public string FilePath { get; set; }
        public JwtSettings Jwt { get; set; }
    }

    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
