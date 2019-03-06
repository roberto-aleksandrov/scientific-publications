namespace ScientificPublications.Application.Common.Models.Mediatr
{
    public class BaseQuery<T> : BaseRequest<T>, IBaseQuery
    {
        public string Include { get; set; }

        //public int? Take { get; set; }

        //public int? Skip { get; set; }        
    }
}
