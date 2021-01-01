using System;
using System.Collections.Generic;
using System.Text;

namespace Injectioneering {

    public class Application {

        private readonly Func<string, int> handler;

        public Application(Func<string, int> handler) {
            this.handler = handler;
        } 

        public void Run() {
            var myData = @"{ id: 1337, message: ""some randome message i might receive"", funFact: ""this might be cool""}";
            var result = handler(myData);
            Console.WriteLine($"My data Message length is {result}");
        }
    }
}
