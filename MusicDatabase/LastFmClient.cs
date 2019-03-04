using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System.Threading.Tasks;

namespace MusicDatabase
{
    class LastFmClient
    {
        public async Task<PageResponse<LastAlbum>> Get(string search)
        {
            var client = new LastfmClient("2bc24890053b55f27e991f944c448586", "a0bba8ca5ee7f334ea353e95422c7356");
            var response = await client.Album.SearchAsync(search);
            return response;
        }

        public async Task<LastAlbum> GetAlbumInfo(string artist, string album)
        {
            var client = new LastfmClient("2bc24890053b55f27e991f944c448586", "a0bba8ca5ee7f334ea353e95422c7356");
            var response = await client.Album.GetInfoAsync(artist, album);
            LastAlbum albumInfo = response.Content;
            return albumInfo;
        }
    }
}
