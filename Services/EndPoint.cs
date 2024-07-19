
namespace ClientApp.Services
{
    public class EndPoint
    {
        public static string BaseUrl { get; set; } = "https://localhost:7166/api/MyApp/";

        public static string GetPatientsEndpoint => $"{BaseUrl}GetAllPatient";
        public static string GetPatientByIdEndpoint => $"{BaseUrl}GetById";
        public static string GetPatientByNameEndpoint => $"{BaseUrl}GetByName";
        public static string AddPatientEndpoint => $"{BaseUrl}AddPatient";
        public static string UpdatePatientEndpoint => $"{BaseUrl}UpdatePatientById";
        public static string DeletePatientEndpoint => $"{BaseUrl}DelPatient";
    }
}

