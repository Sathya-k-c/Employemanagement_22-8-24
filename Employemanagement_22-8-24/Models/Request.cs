using Employemanagement_22_8_24.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employemanagement_22_8_24.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        
        public string UserId { get; set; }

        [Required(ErrorMessage = "Edit request is required.")]
        
        public string EditRequest { get; set; }


        public DateTime RequestDate { get; set; }



        public Isprocessed isprocessed{ get; set; }
        [ForeignKey(nameof(UserId))]    
        public virtual User User { get; set; }

    }
}
