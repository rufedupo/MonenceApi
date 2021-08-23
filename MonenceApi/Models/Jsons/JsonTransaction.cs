using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonenceApi.Models.Jsons
{
    public class JsonTransaction
    {
        public int AccountId { get; set; }

        public decimal Amount { get; set; }
    }
}
