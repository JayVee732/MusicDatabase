using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace MusicDatabase
{
    class LastFmClient
    {
        LastfmClient client = new LastfmClient("2bc24890053b55f27e991f944c448586", "a0bba8ca5ee7f334ea353e95422c7356");

        public async Task<PageResponse<LastAlbum>> GetAlbumSearch(string search)
        {
            var response = await client.Album.SearchAsync(search);
            Thread.Sleep(5000);
            return response;
        }

        public async Task<LastAlbum> GetAlbumInfo(string artist, string album)
        {
            var response = await client.Album.GetInfoAsync(artist, album);
            Thread.Sleep(5000);
            LastAlbum albumInfo = response.Content;
            return albumInfo;
        }
    }
}
