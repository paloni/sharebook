namespace ShareBook.DL.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Language Id: {Id}; Name: {Name}";
        }
    }
}