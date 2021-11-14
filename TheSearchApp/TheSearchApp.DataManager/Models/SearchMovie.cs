using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheSearchApp.DataManager.Models
{
    public class SearchMovie
    {
        public string UserId { get; set; }
        public int movie_id { get; set; }

    }
}
