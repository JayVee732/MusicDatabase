using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;

namespace MusicDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageResponse<LastAlbum> response;
        LastFmClient client;
        private BackgroundWorker backgroundWorker;

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker = (BackgroundWorker)FindResource("backgroundWorker");
        }

        private async void BtnSearch_ClickAsync(object sender, RoutedEventArgs e)
        {
            var search = txbSearch.Text;
            lbxResults.Items.Clear();
            client = new LastFmClient();
            response = await client.GetAlbumSearch(search);

            foreach (var item in response.Content)
            {
                lbxResults.Items.Add(item.ArtistName + "-" + item.Name);
            }
        }

        private async void LbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = lbxResults.SelectedValue.ToString();
            string[] info = selected.Split('-');
            string artist = info[0];
            string album = info[1];

            client = new LastFmClient();
            var albumInfo = await client.GetAlbumInfo(artist, album);
            if (albumInfo == null)
            {
                txtTest.Text += "No album info available!\n";
            }
            else
            {
                txtTest.Text = $"{albumInfo.ArtistName} - {albumInfo.Name}\n";
                imgAlbum.Source = new BitmapImage(new Uri(albumInfo.Images.Large.ToString()));

                var tracks = albumInfo.Tracks.ToList();

                foreach (var item in tracks)
                {
                    if (tracks.Count() != 0)
                    {
                        txtTest.Text += $"{item.Rank}: {item.Name}\n";
                    }
                    else
                    {
                        txtTest.Text += "No track info available!\n";
                    }
                }
            }
        }
    }
}
