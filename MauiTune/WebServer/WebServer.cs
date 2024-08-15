using System.Net;

namespace WebServer
{
    public class WebServer : IWebServer
    {
        private readonly HttpListener _listener = new HttpListener();

        public async Task<String> Start(string[] prefixes)
        {
            var code = String.Empty;

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Error: HTTP Listener not supported on this platform.");
                return code;
            }

            prefixes.ToList().ForEach(p => _listener.Prefixes.Add(p));

            _listener.Start();
            Console.WriteLine("Server started. Listening for requests...");

            await Task.Run(() =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        var context = GetContext(_listener).Result;

                        try
                        {
                            code = context.Request.QueryString["code"];
                            HandleRequest(context); 
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            });

            return code;
        }

        private async Task<HttpListenerContext> GetContext(HttpListener listener) => 
            await Task.Run(() => _listener.GetContext());

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
            Console.WriteLine("Server stopped.");
        }

        private void HandleRequest(HttpListenerContext context)
        {

            string responseString = "<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Login Exitoso</title>\r\n    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css\">\r\n    <style>\r\n        body {\r\n            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;\r\n            background-color: #191414;\r\n            color: #FFFFFF;\r\n            margin: 0;\r\n            padding: 0;\r\n            display: flex;\r\n            justify-content: center;\r\n            align-items: center;\r\n            height: 100vh;\r\n        }\r\n        .container {\r\n            text-align: center;\r\n            padding: 50px;\r\n            border-radius: 10px;\r\n            box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);\r\n            background: linear-gradient(135deg, #1ED760 0%, #191414 100%);\r\n        }\r\n        .success-icon {\r\n            font-size: 64px;\r\n            margin-bottom: 20px;\r\n            color: #FFFFFF;\r\n        }\r\n        .success-message {\r\n            font-size: 24px;\r\n            margin-bottom: 30px;\r\n        }\r\n        .button {\r\n            background-color: #FFFFFF;\r\n            color: #191414;\r\n            border: none;\r\n            padding: 15px 30px;\r\n            font-size: 18px;\r\n            border-radius: 5px;\r\n            cursor: pointer;\r\n            transition: background-color 0.3s;\r\n            text-decoration: none;\r\n        }\r\n        .button:hover {\r\n            background-color: #EEEEEE;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <i class=\"fas fa-check-circle success-icon\"></i>\r\n        <h1>Login Exitoso</h1>\r\n        <p class=\"success-message\">¡Bienvenido a Stasfy! Has iniciado sesión correctamente.</p>\r\n        <a>Ya puedes cerrar esta ventana y regresar a la aplicación.</a>\r\n    </div>\r\n</body>\r\n</html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();

            this.Stop();
        }
    }
}
