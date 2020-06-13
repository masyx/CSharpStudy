using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait_TimCorey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<string> Prepdata()
        {
            var output = new List<string>();
            resultsWindow.Text = "";

            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.stackoverflow.com");
            output.Add("https://news.ycombinator.com/");
            output.Add("https://www.pluralsight.com/");
            output.Add("https://softwareengineeringdaily.com/");
            output.Add("https://www.google.com/maps/@37.6,-95.665,4z");

            return output;
        }

        private void RunDownLoadSync()
        {
            List<string> websites = Prepdata();

            foreach (var site in websites)
            {
                WebsiteDataModel result = DownloadWebsite(site);
                ReportWebsiteInfo(result);
            }
        }

        private async Task RunDownLoadASync()
        {
            List<string> websites = Prepdata();

            foreach (var site in websites)
            {
                WebsiteDataModel result = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(result);
            }
        }

        private async Task RunDownLoadAsyncInParallel()
        {
            var websites = Prepdata();
            var tasks = websites.Select(site => Task.Run(() => DownloadWebsite(site))).ToList();

            // This foreach loop converted to LINQ expression by ReSharper
            //foreach (var site in websites)
            //{
            //    tasks.Add(Task.Run(() => DownloadWebsite(site)));
            //}

            var results =  await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                ReportWebsiteInfo(result);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;

        }

        private void ReportWebsiteInfo(WebsiteDataModel website)
        {
            resultsWindow.Text += $"{website.WebsiteUrl} downloaded: {website.WebsiteData.Length} characters long.{Environment.NewLine}";
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownLoadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time: {elapsedMs}";
        }


        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownLoadASync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time: {elapsedMs}";
        }

        private async void executeAsyncInParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownLoadAsyncInParallel();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Total execution time: {elapsedMs}";
        }
        private void clearTextBlock_Click(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = "";
        }
    }
}
