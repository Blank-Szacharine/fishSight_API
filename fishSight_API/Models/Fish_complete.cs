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
        public string Fish_family { get; set; }

        public int? family_id { get; set; }

        public string Lifecycle { get; set; }

        public string length_maturity { get; set; }

        public string length_maxLength { get; set; }

        public string other { get; set; }
        public List<Region_Names> Region_Name { get; set; }

        public List<LocalName> LocalNAMES { get; set; }

        public List<Water_Environments> Water_Environment { get; set; }
        public class LocalName 
        {
            public string localName { get; set; }
        }
        public class Region_Names
        {
            public int Region_Id { get; set; }

            public string Region { get; set; }
        }
        public class Water_Environments
        {
            public int Water_Id { get; set; }

            public string Water { get; set; }
        }
    }
}
