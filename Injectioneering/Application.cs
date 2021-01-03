using System;
using System.Collections.Generic;
using System.Text;

namespace Injectioneering {

    public class Application {

        private readonly Func<string, int> handler;

        public Application(Func<string, int> handler) {
            this.handler = handler;
        } 

        public string Run(string myData) {
            var result = handler(myData);
            return $"My data Message length is {result}";
        }
    }
}
