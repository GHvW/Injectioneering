using System;
using Microsoft.Extensions.DependencyInjection;

namespace Injectioneering {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection()
                .AddTransient<Handler>()
                .AddTransient<Application>()
                .BuildServiceProvider();

            var app = services.GetRequiredService<Application>();

            var myData = @"{ id: 1337, message: ""some randome message i might receive"", funFact: ""this might be cool""}";
            Console.WriteLine(app.Run(myData));
        }
    }
}
