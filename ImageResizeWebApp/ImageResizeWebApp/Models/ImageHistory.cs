using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageResizeWebApp.Models
{
    public class ImageHistory
    {
        public int ID { get; set; }
        public string imageURL { get; set; }
        public string IP { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class ImageHistoryContext :DbContext
    {
        public DbSet<ImageHistory> SQLConnectionString { get; set; }
    }
}
