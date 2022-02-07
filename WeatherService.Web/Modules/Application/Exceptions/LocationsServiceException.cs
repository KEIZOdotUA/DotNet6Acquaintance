namespace WeatherService.Web.Modules.Application.Exceptions
{
    /// <summary>
    /// Locations service exception.
    /// </summary>
    /// <seealso cref="WeatherService.Web.Modules.Application.Exceptions.ExternalServiceException" />
    public class LocationsServiceException : ExternalServiceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsServiceException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public LocationsServiceException(string errorMessage) : base(errorMessage) { }
    }
}
