using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FlurlDemo
{
    public class RepoModel
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool @private { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
    }
}