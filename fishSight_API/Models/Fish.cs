namespace fishSight_API.Models
{
    public class Fish
    {
        public int FishId { get; set; }

        public string ScientificName { get; set; } = null!;

        public string GeneralName { get; set; } = null!;

        public byte[] FishImg { get; set; } = null!;
    }
}
