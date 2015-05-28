using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer httpServer = new MyHttpServer(8080);
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
        }
    }
}
