using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Twitterizer
{
    public class CoordinateCollection
    {
        [DataMember, JsonProperty(PropertyName = "coordinates")]
        public Collection<float> coordinates { get; set; }

        [DataMember, JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
