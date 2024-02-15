namespace ShortCut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strShortCut=string.Empty;
            UrlShortener shortener = new UrlShortener();

            txtShortCutUrl.Text = shortener.ShortenUrl(txtOriUrl.Text);

            string expandedUrl = shortener.ExpandUrl(txtShortCutUrl.Text);
        }


    }
    class UrlShortener
    {
        private Dictionary<string, string> urlMap;

        public UrlShortener()
        {
            urlMap = new Dictionary<string, string>();
        }

        public string ShortenUrl(string longUrl)
        {
            // Generate a unique short key (you might want to use a more sophisticated method)
            string shortKey = Guid.NewGuid().ToString("N").Substring(0, 8);

            // Add the mapping to the dictionary
            urlMap.Add(shortKey, longUrl);

            // Return the short URL
            return $"https://yourdomain.com/{shortKey}";
        }

        public string ExpandUrl(string shortUrl)
        {
            // Extract the short key from the URL
            string shortKey = shortUrl.Substring(shortUrl.LastIndexOf('/') + 1);

            // Check if the short key exists in the dictionary
            if (urlMap.ContainsKey(shortKey))
            {
                // Return the corresponding long URL
                return urlMap[shortKey];
            }
            else
            {
                return "Short URL not found.";
            }
        }

        private string ExtractShortKey(string shortUrl)
        {
            // Extract the short key from the short URL
            return shortUrl.Substring(shortUrl.LastIndexOf('/') + 1);
        }
    }
}