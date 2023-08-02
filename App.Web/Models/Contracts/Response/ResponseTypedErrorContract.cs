namespace App.Web.Models.Contracts.Response
{
    public class ResponseTypedErrorContract<TData, TDataError> : ResponseContract
    {
        public TData Data { get; set; }
        public TDataError DataError { get; set; }
    }
}
