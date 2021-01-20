using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Movie.modal
{
    public class User_Details
    {
        public int imdbID { get; set; }
        public string Title {get; set;}
        public string Year { get; set; }
        public string Type { get; set; }

       public string Poster{ get; set; }
       


    }
}
