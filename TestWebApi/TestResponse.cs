using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestWebApi
{
    public class TestResponse<TEntity>
    {
        /// <summary>
        /// Gets and sets Data of Response
        /// </summary>
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public TEntity Data { get; set; }

        /// <summary>
        /// Gets or sets the additional info to send with response
        /// </summary>
        [JsonProperty("attrs", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Attrs { get; set; }

        /// <summary>
        /// Gets and sets Error of Response
        /// </summary>
        [JsonProperty(PropertyName = "errors", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Errors { get; set; }

        //public bool ShouldSerializeErrors()
        //{
        //    // don't serialize the errors if data is initilize
        //    return (Errors != null);
        //}

        //public bool ShouldSerializeData()
        //{
        //    // don't serialize the errors if data is initilize
        //    return (Data != null);
        //}

        //public bool ShouldSerializeAttrs()
        //{
        //    // don't serialize the errors if data is initilize
        //    return (Attrs != null);
        //}
    }
}
