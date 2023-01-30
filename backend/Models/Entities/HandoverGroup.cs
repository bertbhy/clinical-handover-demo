
namespace webapi.Models
{
    public class HandoverGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string GroupName { get; set; }
   [MaxLength(4)]
        public string SpecialtyCode { get; set; }

    }
}
