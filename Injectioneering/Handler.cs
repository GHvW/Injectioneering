using Newtonsoft.Json;

namespace Injectioneering {

    public class Handler {

        public Handler() { }

        public int Handle(string message) =>
             JsonConvert
                .DeserializeObject<MyData>(message)
                .Message
                .Length;
    }
}
