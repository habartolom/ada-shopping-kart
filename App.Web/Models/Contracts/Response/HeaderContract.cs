using App.Web.Models.Enums;

namespace App.Web.Models.Contracts.Response
{
    /// <summary>
    /// Header that allows to identify an internal API error if exist
    /// </summary>
    public class HeaderContract
    {
        /// <summary>
        /// Http code that represents the internal API response status code
        /// </summary>
        public HttpCodeEnum Code { get; set; }

        /// <summary>
        /// Message to identify an internal API error if exist
        /// </summary>
        public string? Message { get; set; }
    }
}
