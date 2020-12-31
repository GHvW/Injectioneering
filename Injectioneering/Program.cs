using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Injectioneering {
    class Program {



        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection()
                .AddTransient<Func<string, MyData>>(_ => JsonConvert.DeserializeObject<MyData>)
                .AddTransient<Application>()
                .BuildServiceProvider();

            var app = services.GetRequiredService<Application>();
            app.Run();
        }
    }
}
