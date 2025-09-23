namespace ShippingService.Models
{
    public enum ShippingStatus
    {
        Pending = 0,
        Dispatched = 1,
        InTransit = 2,
        OutForDelivery = 3,
        Delivered = 4,
        Failed = 5,
        Returned = 6,
        Cancelled = 7
    }
}
