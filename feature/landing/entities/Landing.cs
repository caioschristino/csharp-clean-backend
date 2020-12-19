using System.Collections.Generic;

namespace clean_sharp {
    public class Landing
    {
        public Landing(int count, string next, List<Pokemon> results){
            this.count = count;
            this.next = next;
            this.results = results;
        }
        public int count { get; set; }

        public string next { get; set; }

        public List<Pokemon> results { get; set; }
    }
}