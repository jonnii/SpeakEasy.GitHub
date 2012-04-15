using System;

namespace SpeakEasy.GitHub.Models
{
    public class NewMilestone
    {
        public string Title { get; set; }

        public string State { get; set; }

        public string Description { get; set; }

        public DateTime DueOn { get; set; }
    }
}