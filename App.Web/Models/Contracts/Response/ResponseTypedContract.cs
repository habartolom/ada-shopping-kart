namespace App.Web.Models.Contracts.Response
{
    /// <summary>
    /// Model to return a typed response
    /// </summary>
    /// <typeparam name="TContract"></typeparam>
    public class ResponseTypedContract<TContract> : ResponseContract
    {
        /// <summary>
        /// Data that is added as part of the response
        /// </summary>
        public TContract Data { get; set; }
    }
}
