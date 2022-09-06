using SQLite;

namespace qrReader.Models
{
    public class historyDescription
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string descriptionHistory { get; set; }
    }
}
