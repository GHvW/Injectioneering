using System;
using System.Collections.Generic;
using System.Text;


namespace Injectioneering {

    public class Handler {

        private readonly Func<string, MyData> deserialize;

        public Handler(Func<string, MyData> deserialize) {
            this.deserialize = deserialize;
        }

        public int Handle(string message) => 
            // JsonConvert.DeserializeObject<MyData>(message).Message.Length;
            deserialize(message).Message.Length;
    }
}
