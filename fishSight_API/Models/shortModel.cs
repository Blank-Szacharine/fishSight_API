namespace fishSight_API.Models
{
    public class shortModel
    {
        public int fish_id { get; set; }
        public string Scientific_name { get; set; }
        public string Fish_name { get; set; }
        public string Fish_Description { get; set; }
        public byte[] fish_img { get; set; }

    }
}
