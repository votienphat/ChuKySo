using System.Collections.Generic;

namespace Common.Model
{
    public class GCMRequest
    {
        public List<string> registration_ids { get; set; }
        public object data { get; set; }
        public int time_to_live { get; set; }
        public bool delay_while_idle { get; set; }
        public bool dry_run { get; set; }
    }

    public class GCMResponse
    {
        public string multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public string Message { get; set; }
    }
}
