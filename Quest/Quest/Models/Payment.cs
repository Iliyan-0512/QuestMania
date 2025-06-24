<<<<<<< HEAD
﻿using QuestApp.Models;
namespace QuestApp.Models;
=======
﻿namespace QuestApp.Models;
>>>>>>> 8d47a51b3c82628feeba189941b80a5930c85712

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
