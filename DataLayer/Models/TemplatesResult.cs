namespace SendGridAPI.DataLayer.Models
{
    public class TemplatesResult
    {
        public List<Template> templates { get; set; }
    }

    public class Template
    {
        public string id { get; set; }
        public string name { get; set; }
        public string generation { get; set; }
        public string updated_at { get; set; }
        public List<Version> versions { get; set; }
    }

    public class Version
    {
        public string id { get; set; }
        public string template_id { get; set; }
        public int active { get; set; }
        public string name { get; set; }
        public bool generate_plain_content { get; set; }
        public string subject { get; set; }
        public string updated_at { get; set; }
        public string editor { get; set; }
        public string thumbnail_url { get; set; }
    }
}
