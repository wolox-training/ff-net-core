namespace MvcMovie.Models.Views
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public MovieViewModel Movie { get; set; }
    }
}
