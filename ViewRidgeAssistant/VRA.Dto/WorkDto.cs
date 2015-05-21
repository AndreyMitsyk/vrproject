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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            WorkDto workItem = obj as WorkDto;
            return workItem != null && workItem.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public string Status { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? AskingPrice { get; set; }
    }
}
