using System;
using Microsoft.Extensions.DependencyInjection;
//using Newtonsoft.Json;
using System.Text.Json;

namespace Injectioneering {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection()
                //.AddTransient<Func<string, MyData>>(_ => JsonConvert.DeserializeObject<MyData>)
                .AddTransient<Func<string, MyData>>(_ => {
                    return (str) => 
                        JsonSerializer
                            .Deserialize<MyData>(
                                str, 
                                new JsonSerializerOptions() { 
                                    PropertyNameCaseInsensitive = true 
                                });
                })
                .AddTransient<Handler>()
                .AddTransient<Func<string, int>>(sp => {
                    return sp.GetRequiredService<Handler>().Handle;
                })
                .AddTransient<Application>()
                .BuildServiceProvider();

            var app = services.GetRequiredService<Application>();

            var myData = @"{ ""id"": 1337, ""message"": ""some randome message i might receive"", ""funFact"": ""this might be cool""}";

            Console.WriteLine(app.Run(myData));
        }
    }
}
