namespace App.Web.Models.Enums
{
    /// <summary>
    /// Http code enumerable
    /// </summary>
    public enum HttpCodeEnum
    {
        /// <summary>
        /// Status Code 200
        /// </summary>
        Ok = 200,

        /// <summary>
        /// Status Code 201
        /// </summary>
        OkExist = 201,

        /// <summary>
        /// Status Code 400
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Status Code 401
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Status Code 404
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Status Code 422
        /// </summary>
        ValidationError = 422,

        /// <summary>
        /// Status Code 500
        /// </summary>
        InternalServerError = 500,
    }
}
