using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OA.Web.Models
{
    public class RateForm
    {
        public int Id { get; set; }
        public int SlefId { get; set; }

        public int Score { get; set; }

        public float avgScore { get; set; }

        public string Upvote { get; set; }
    }
}