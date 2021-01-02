using System;

namespace Injectioneering {

    public class Application {

        private readonly Handler handler;

        public Application(Handler handler) {
            this.handler = handler;
        } 

        public string Run(string myData) {
            var result = handler.Handle(myData);
            return $"My data Message length is {result}";
        }
    }
}
