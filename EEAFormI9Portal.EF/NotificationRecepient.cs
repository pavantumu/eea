//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EEAFormI9Portal.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class NotificationRecepient
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int NotificationId { get; set; }
        public bool IsRead { get; set; }
        public byte[] ReadDate { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
