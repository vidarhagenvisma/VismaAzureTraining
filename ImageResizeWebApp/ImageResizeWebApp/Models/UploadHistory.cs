using System;
using System.Collections.Generic;

namespace ImageResizeWebApp.Models
{
    public class UploadHistory
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string IP { get; set; }
        public DateTime date { get; set; }

    }
}