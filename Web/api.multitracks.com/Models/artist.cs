using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.multitracks.com.Models
{
    // This class is for inserting new artists into the Artist table 
    public class artist
    {
       public int artistID { get; set; }
       public string dateCreation { get; set; }
       public string title { get; set; }
       public string biography { get; set; }
       public string imageURL { get; set; }
       public string heroURL { get; set; }
    }
}