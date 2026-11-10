namespace _027TodoApi.DB
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
