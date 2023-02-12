using AtChalenge.Core.Interfaces;

namespace AtChalenge.Infrastructure.Responses
{

    public class ResponseModel : IResponseModal
        {
            public ResponseModel()
            {
                this.IsSuccessfull = false;
                this.Data = null;
            }

            public bool IsSuccessfull { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
        }
    }
