namespace OrderService.DTO
{
    public class CustomerAddressSaveRequest
    {
        public int UserId { get; set; }
        public AddressRequest Address { get; set; } = new AddressRequest();
        public bool IsDefaultAddress { get; set; }
    }
}
