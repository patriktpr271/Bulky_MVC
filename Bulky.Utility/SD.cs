using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Utility
{
    //Constants for the application
    public static class SD
    {
        //Constants for the roles in the application
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        //Constants for the status of the order
        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_InProcess = "Processing";
        public const string Status_Shipped = "Shipped";
        public const string Status_Cancelled = "Cancelled";
        public const string Status_Refunded = "Refunded";

        //Constants for the payment status
        public const string PaymentStatus_Pending = "Pending";
        public const string PaymentStatus_Approved = "Approved";
        public const string PaymentStatus_Rejected = "Rejected";
        public const string PayementStatusDelayedPayyment = "ApprovedForDelayedPayment";

        //constants for sessions
        public const string SessionShoppingCart = "SessionShoppingCart";

    }
}
