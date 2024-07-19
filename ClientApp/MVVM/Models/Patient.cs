using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.MVVM.Models
{
    public class Patient
    {
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

    }
    public enum GenderType
    {
        Man = 0,
        Woman = 1,
    }
}
