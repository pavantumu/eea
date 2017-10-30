using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Models
{
    public class ViewDocument
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DocumentStatusId { get; set; }
        public int RepresentativeId { get; set; }
        public int EVerifyStatusId { get; set; }
        public byte[] DateUpdated { get; set; }

        public string UserEmail { get; set; }
        public string DocumentStatusName { get; set; }
        public string EverifyStatusName { get; set; }
        public string RepresentativeName { get; set; }
    }
}
