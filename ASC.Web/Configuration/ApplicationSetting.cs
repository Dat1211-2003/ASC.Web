namespace ASC.Web.Configuration
{
    public class ApplicationSettings
    {
        public string AdminPassword { get; set; }

        public string ApplicationTitle {  get; set; }
        public string EngineerEmail { get;  set; }
        public string AdminEmail { get;  set; }
        public string EngineerName { get; set; }    
        public string EngineerPassword { get; set; }
        public string AdminName { get;  set; }
        public object Roles { get;  set; }
    }
}
