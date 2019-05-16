namespace MvcMovie.Models.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Movie Movie { get; set; }
    }
}