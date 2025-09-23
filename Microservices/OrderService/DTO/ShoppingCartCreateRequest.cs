namespace OrderService.DTO
{
    public class ShoppingCartCreateRequest
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<ShoppingCartItemRequest> Items { get; set; } = new();
    }
}
