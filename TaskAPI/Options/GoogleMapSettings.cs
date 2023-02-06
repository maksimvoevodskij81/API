namespace TaskAPI.Options
{
    public class GoogleMapSettings
    {
        public const string GoogleMap = "GoogleMap";

        public string GoogleDistanceMatrixApiUrl { get; set; } = string.Empty;
        public string GoogleDistanceMatrixApiKey { get; set; } =string.Empty;
      
    }
}
