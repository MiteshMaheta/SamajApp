using System;
using SQLite;

namespace SamajApp.Data
{

    [Table("info")]
    public class Info
    {
        public string key { get; set; }
        public string value { get; set; }
    }

}
