namespace MiniShop.API.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Properties { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
    }
}
