namespace OrderService.DTO
{
    public class ShoppingCartResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<ShoppingCartItemResponse> Items { get; set; } = new();
    }
}
