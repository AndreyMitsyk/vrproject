namespace VRA.Dto
{
    public class WorkDto
    {
        /// <summary>
        /// work's id number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Work's Title (title = name)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Id number of work's autor
        /// </summary> 
        public ArtistDto Artist { get; set; }

        /// <summary>
        /// Work's Description 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Copy of work, may be null
        /// </summary>
        public string Copy { get; set; }
    }
}
