namespace SEP3ClientLATEST.Data.dto
{
    public class RequestDTO
    {
        public string title { get; set; }

        public RequestDTO()
        {
            
        }
        
        public RequestDTO(string title)
        {
            this.title = title;
        }
    }
}