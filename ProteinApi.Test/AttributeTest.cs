using System;

namespace ProteinApi.Test
{

    public class HelpAttribute : Attribute
    {
        string url;
        string topic;

        public HelpAttribute(string url)
        {
            this.url = url;
        }

        public string Url
        {
            get { return url; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
    }

    public class AttributeTest
    {
        [Help("www.google.com", Topic ="to get base url use this method.")]
        private string getBaseUrl()
        {
            return string.Empty;
        }
    }
}
