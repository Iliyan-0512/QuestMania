using QuestApp.Models;
namespace QuestApp.Models;

public class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }                
    public User User { get; set; }

    public string StripePaymentId { get; set; }     
    public DateTime PaidAt { get; set; }            
    public decimal Amount { get; set; }             
    public bool IsConfirmed { get; set; }          
}
