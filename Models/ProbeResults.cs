﻿using System.Collections.Generic;

namespace ToAC3
{
    public class ProbeResults
    {
        public IEnumerable<Stream> streams { get; set; }
    }

    public class Stream
    {
        public int index { get; set; }
        public string codec_name { get; set; }
        public string codec_long_name { get; set; }
        public string codec_type { get; set; }
        public string codec_time_base { get; set; }
        public string codec_tag_string { get; set; }
        public string codec_tag { get; set; }
        public string sample_fmt { get; set; }
        public string sample_rate { get; set; }
        public int channels { get; set; }
        public string channel_layout { get; set; }
        public int bits_per_sample { get; set; }
        public string dmix_mode { get; set; }
        public string ltrt_cmixlev { get; set; }
        public string ltrt_surmixlev { get; set; }
        public string loro_cmixlev { get; set; }
        public string loro_surmixlev { get; set; }
        public string r_frame_rate { get; set; }
        public string avg_frame_rate { get; set; }
        public string time_base { get; set; }
        public int start_pts { get; set; }
        public string start_time { get; set; }
        public string bit_rate { get; set; }
        public Disposition disposition { get; set; }
        public Tags tags { get; set; }
    }

    public class Disposition
    {
        public int _default { get; set; }
        public int dub { get; set; }
        public int original { get; set; }
        public int comment { get; set; }
        public int lyrics { get; set; }
        public int karaoke { get; set; }
        public int forced { get; set; }
        public int hearing_impaired { get; set; }
        public int visual_impaired { get; set; }
        public int clean_effects { get; set; }
        public int attached_pic { get; set; }
        public int timed_thumbnails { get; set; }
    }

    public class Tags
    {
        public string language { get; set; }
        public string title { get; set; }
        public string ENCODER { get; set; }
        public string DURATION { get; set; }
    }
}

