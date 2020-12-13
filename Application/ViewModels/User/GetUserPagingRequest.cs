using Application.ViewModels.Common;

namespace Application.ViewModels.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
