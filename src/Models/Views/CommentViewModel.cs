namespace MvcMovie.Models.Views
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual MovieViewModel Movie { get; set; }
        public virtual int MovieId { get; set; }
    }
}
