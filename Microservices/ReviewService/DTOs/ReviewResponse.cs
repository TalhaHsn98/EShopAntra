namespace ReviewService.DTOs
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; } = string.Empty;
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public byte Rating_value { get; set; }
        public string? Comment { get; set; }
        public DateTime Review_Date { get; set; }
    }
}
