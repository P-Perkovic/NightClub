namespace NightClub.Domain
{
    public static class Constants
    {
        public enum ReservationStatus
        {
            Canceled = 1,
            Active = 2,
            Past = 3,
            CanceledByAdmin = 4
        }

        public static string DELETE_FILE_PATH = "NightClub-WebApp\\src";
        public static string UPLOAD_FILE_PATH = "NightClub-WebApp\\src\\assets\\photos";
        public static string FILE_PATH = "assets\\photos";
        public const string ADMIN_POLICY = "IsAdmin";

    }
}
