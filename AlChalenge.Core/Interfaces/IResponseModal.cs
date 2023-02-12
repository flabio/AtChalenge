namespace AtChalenge.Core.Interfaces
{
    public interface IResponseModal
    {
        bool IsSuccessfull { get; set; }

        string Message { get; set; }

        object Data { get; set; }
    }

}
