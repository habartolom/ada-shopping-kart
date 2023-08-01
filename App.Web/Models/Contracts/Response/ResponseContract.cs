using App.Web.Models.Enums;

namespace App.Web.Models.Contracts.Response
{
    /// <summary>
    /// Model to return a simple response
    /// </summary>
    public class ResponseContract
    {
        /// <summary>
        /// Header that allows to identify an internal API error
        /// </summary>
        public HeaderContract Header { get; set; }

        /// <summary>
        /// Constructor - Creates a default response header.
        /// </summary>
        public ResponseContract()
        {
            Header = new HeaderContract();
            Header.Code = HttpCodeEnum.Ok;
        }
    }
}
