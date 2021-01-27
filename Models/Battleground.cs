using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowClassicBgCalendar.Models {
    public class Battleground {
        public string name { get; set; }
        public string imageUrl { get; set; }

        public Battleground(string name, string imageUrl) {
            this.name = name;
            this.imageUrl = imageUrl;
        }
    }
}
