using System;
using System.Collections.Generic;
using System.Text;


namespace Injectioneering {

    public class Handler {

        public Handler() {

        }

        public int Handle(string message) => message.Length;
    }
}
