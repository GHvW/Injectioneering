using System;
using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;
using System.Text.Json;

namespace Injectioneering {
    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection()
                //.AddSingleton<Func<string, MyData>>(_ => JsonConvert.DeserializeObject<MyData>)
                .AddSingleton<Func<string, MyData>>(_ => {
                    return (str) => JsonSerializer.Deserialize<MyData>(str);
                })
                .AddTransient<Handler>()
                .AddTransient<Func<string, int>>(sp => {
                    return sp.GetRequiredService<Handler>().Handle;
                })
                .AddTransient<Application>()
                .BuildServiceProvider();

            var app = services.GetRequiredService<Application>();

            app.Run();
        }
    }
}
