using System.Reflection.Metadata;

namespace fishSight_API.Models
{
    public class Fish_complete
    {
        public int Id { get; set; }
        public string Scientific_name { get; set; }
        public string Fish_name { get; set; }
        public string Fish_Description { get; set; }
        public string Fish_biology { get; set; }
        public byte[] fish_img { get; set; }


        public string Lifecycle { get; set; }

        public string length_maturity { get; set; }

        public string length_maxLength { get; set; }

        public string other { get; set; }

        public List<LocalName> LocalNAMES { get; set; }
        public class LocalName 
        {
            public string localName { get; set; }
        }
    }
}
