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
        [Key]
        public Int64 SearchId { get; set; }
        public string UserId { get; set; }
        public string SearchCategory { get; set; }
        public string SearchCriteria { get; set; }
        public string APIRequest { get; set; }
        public string APIResponse { get; set; }
        public DateTime? RequestDate { get; set; }
    }
}
