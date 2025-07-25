namespace QuestApp.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int AccessLinkId { get; set; }
        public AccessLink AccessLink { get; set; } 

        public string StripePaymentId { get; set; }     
        public DateTime PaidAt { get; set; }            
        public decimal Amount { get; set; }             
        public bool IsConfirmed { get; set; }          
    }
}
