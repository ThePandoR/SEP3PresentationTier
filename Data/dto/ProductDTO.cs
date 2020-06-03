namespace SEP3ClientLATEST.Data.dto
{
    public class ProductDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public ProductDTO()
        {
            
        }
        
        public ProductDTO(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }
}