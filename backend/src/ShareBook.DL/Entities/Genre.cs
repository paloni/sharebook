namespace ShareBook.DL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Genre Id: {Id}; Name: {Name}";
        }
    }
}