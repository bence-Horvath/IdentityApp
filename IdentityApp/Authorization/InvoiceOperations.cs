using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace IdentityApp.Authorization
{
    public class InvoiceOperations
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement { Name = Constants.CreateOperation };
        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement { Name = Constants.ReadOperation };
        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement { Name = Constants.UpdateOperation };
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = Constants.DeleteOperation };

        public static OperationAuthorizationRequirement Approved = new OperationAuthorizationRequirement { Name = Constants.ApprovedOperation };
        public static OperationAuthorizationRequirement Rejected = new OperationAuthorizationRequirement { Name = Constants.RejectedOperation };

    }

    public class Constants
    {
        public static readonly string CreateOperation = "Create";
        public static readonly string ReadOperation = "Read";
        public static readonly string UpdateOperation = "Update";
        public static readonly string DeleteOperation = "Delete";

        public static readonly string ApprovedOperation = "Approved";
        public static readonly string RejectedOperation = "Rejected";
    }
}
