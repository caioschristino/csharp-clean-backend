
namespace clean_sharp {
    public class Pokemon{
        public Pokemon(string name, string url) {
            this.name = name;
            this.url = url;
        }
                
        public string name { get; set; }
        public string url { get;  set;}
        public bool ilike { get;  set;}
    }
}