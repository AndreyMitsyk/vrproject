namespace VRA.Dto
{
    public class WorksInGalleryDto
    {
        public int Id { get; set; }
        public WorkDto Work { get; set; }
        public ArtistDto Artist { get; set; }
        public decimal? AskingPrice { get; set; }
    }
}

    