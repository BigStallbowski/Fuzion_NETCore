namespace Fuzion.UI.Core.Models
{
    public class Note : BaseModel
    {
        public string Body { get; set; }

        public Hardware Hardware { get; set; }
    }
}