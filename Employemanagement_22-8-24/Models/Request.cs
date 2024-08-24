using Employemanagement_22_8_24.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employemanagement_22_8_24.Models
{
    public class Request
    {
        [Key] // This attribute can be used to specify that RequestId is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures SQL Server auto-generates the value
        public int RequestId { get; set; } // Assuming it's an int type


        public string UserId { get; set; }

       
        
        public string EditRequest { get; set; }


        public DateTime RequestDate { get; set; }



        public Isprocessed isprocessed{ get; set; }

      
    }
}
