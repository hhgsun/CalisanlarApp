namespace FinagotechCalisanlar.Data.App
{
    public class AppResponse<T>
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public T Result { get; set; }

        public AppResponse(T result)
        {
            this.Status = "200";
            this.Description = "";
        }

        public AppResponse()
        {
        }

        public static AppResponse<T> Success(T result, string description = "")
        {
            return new AppResponse<T>()
            {
                Status = "200",
                Description = description,
                Result = result
            };
        }

        public static AppResponse<T> Error(string description, string status = "400")
        {
            return new AppResponse<T>()
            {
                Status = status,
                Description = description,
            };
        }
    }
}
