namespace App.Web.Models.Constants
{
    public partial class Constants
    {
        public struct Roles
        {
            public static Guid AdminId { get; } = new Guid("EC8367A7-E178-41C5-A2A4-882545E026EC");
            public static Guid RegularId { get; } = new Guid("A013C111-A455-4B0F-8ADF-E40C04922ABB");
            
            public const string Admin = "Administrator";
            public const string Regular = "Regular";
        }
    }
}
