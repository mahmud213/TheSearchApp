using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheSearchApp.DataManager.Models
{
    public class SearchPeople
    {
        public string UserId { get; set; }
        public int person_id { get; set; }

    }
}
