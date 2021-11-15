using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheSearchApp.DataManager.Models
{
    [Table("SearchHistory")]
    public class SearchHistory
    {
        [Column("SearchId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Int64 SearchId { get; set; }

        [Column("UserId")]
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Column("SearchCategory")]
        [StringLength(50)]
        public string SearchCategory { get; set; }

        [Column("SearchCriteria")]
        [StringLength(500)]
        public string SearchCriteria { get; set; }

        [Column("APIRequest")]
        [MaxLength]
        public string APIRequest { get; set; }

        [Column("APIResponse")]
        [MaxLength]
        public string APIResponse { get; set; }

        [Column("RequestDate")]
        public DateTime? RequestDate { get; set; }
    }
}
