using System.Net;
using System.Text;

namespace server_computer_craft
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:4546/");
            listener.Start();
            Console.WriteLine("Servidor rodando em http://localhost:4546/ ...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string filePath = "/home/ubuntu/fileupdate.lua";
                string content = File.ReadAllText(filePath, Encoding.UTF8);

                response.StatusCode = 200;
                response.ContentType = "text/html";
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                response.ContentLength64 = buffer.Length;

                using (Stream output = response.OutputStream)
                {
                    output.Write(buffer, 0, buffer.Length);
                }
                response.Close();
            }
        }
    }
}
