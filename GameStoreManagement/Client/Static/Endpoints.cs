namespace GameStoreManagement.Client.Static
{
    public class Endpoints
    {
        private static readonly string Prefix = "api";

        // Use consistent naming for the Prefix field
        public static readonly string GamesEndpoint = $"{Prefix}/games";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
    }
}
