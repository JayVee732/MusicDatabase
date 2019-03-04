using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using IF.Lastfm.Core.Objects;
using IF.Lastfm.Core.Api.Helpers;

namespace MusicDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PageResponse<LastAlbum> response;
        LastFmClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnSearch_ClickAsync(object sender, RoutedEventArgs e)
        {
            var search = txbSearch.Text;
            client = new LastFmClient();
            response = await client.Get(search);

            foreach (var item in response.Content)
            {
                cbxResults.Items.Add(item.ArtistName +"-"+ item.Name);
            }
        }

        private async void CbxResults_SelectionChangedAsync(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selected = cbxResults.SelectedValue.ToString();
            string[] info = selected.Split('-');
            string artist = info[0];
            string album = info[1];

            client = new LastFmClient();
            var albumInfo = await client.GetAlbumInfo(artist, album);
            txtTest.Text = $"{albumInfo.ArtistName} - {albumInfo.Name}\n";
            imgAlbum.Source = new BitmapImage(new Uri(albumInfo.Images.Large.ToString()));

            var tracks = albumInfo.Tracks.ToList();


            foreach (var item in tracks)
            {
                txtTest.Text += $"{item.Rank}: {item.Name}\n";
            }
            if (tracks.Count() == 0)
            {
                txtTest.Text = "No track info available!\n";
            }
        }
    }
}
