namespace IdentityApp.Models
{
    public class Invoice
    {

        public int Id { get; set; }

        public double InvoiceAmount { get; set; }

        public string InvoiceMonth { get; set; }

        public string InvioceOwner { get; set; }

        public string CreatorId{ get; set; }

        public InvoiceStatus Status{ get; set; }
    }

    public enum InvoiceStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
