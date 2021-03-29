namespace EasyBus.Data.Models
{
    public class Route
    {
        public int Id { get; set; }

        public Stop SourceStop { get; set; }

        public Stop DestStop { get; set; }
    }
}