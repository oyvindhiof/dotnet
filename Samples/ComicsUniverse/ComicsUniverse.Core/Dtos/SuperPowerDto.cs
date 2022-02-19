namespace ComicsUniverse.Core.Dtos
{
    public class SuperPowerDto
    {
        public int SuperPowerId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
