using System;

namespace Inferis.API.Vimeo.Advanced.Responses
{
    public class VideoSummary
    {
        public VideoSummary()
        {
            EmbedPrivacy = "anybody";
            Privacy = "anyone";

            IsHd = false;
            IsTranscoding = false;
        }

        public string Id { get; set; }
        public string Owner { get; set; }

        public string Title { get; set; }
        
        public string EmbedPrivacy { get; set; }
        public string Privacy { get; set; }

        public bool IsHd { get; set; }
        public bool IsTranscoding { get; set; }
        public DateTime UploadDate { get; set; } 
    }
}
