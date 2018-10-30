namespace Fuzion.UI.Core.Models
{
    public class Note : BaseModel
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public Hardware Hardware { get; set; }
    }
}