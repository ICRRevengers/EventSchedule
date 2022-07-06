using System.Runtime.InteropServices;

namespace EventProjectSWP.Models
{
    public class Response<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }

        public Response([Optional] T data, [Optional] string message)
        {
            isSuccess = true;
            this.data = data;
        }

        public Response(string message)
        {
            this.message = message;
            isSuccess = false;
        }
    }
}
