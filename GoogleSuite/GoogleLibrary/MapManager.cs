using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using Google.Api.Maps.Service.Geocoding;
using Google.Api.Maps.Service.StaticMaps;

namespace GoogleLibrary
{
    public class MapManager
    {
        public Bitmap SearchAndGenerateMap(string address)
        {
            GeocodingResult geocodingResult = GeocodeSearch(address);
            if (geocodingResult.IsNotNull())
            {
                Uri staticMapUrl = GenerateStaticMapUrl(geocodingResult);
                return DownloadBitmap(staticMapUrl);
            }
            else
            {
                return null;
            }
        }

        public GeocodingResult GeocodeSearch(string address)
        {

            GeocodingRequest request = new GeocodingRequest();
            request.Address = address;
            request.Region = "AU";
            request.Sensor = "true";
            GeocodingResponse response = new GeocodingResponse();
            response = GeocodingService.GetResponse(request);

            if (response.Results.FirstOrDefault().IsNotNull())
            {
                return response.Results.First();
            }
            else
            {
                //MessageBox.Show(@"No Results Found for Term: " + address, @"No Results");
                return null;
            }
        }

        public Uri GenerateStaticMapUrl(GeocodingResult searchResult)
        {
            var map = new StaticMap();
            map.Center = searchResult.FormattedAddress; // or a lat/lng coordinate
            //map.Path = searchResult.FormattedAddress + "|" + "9 Snowball Place Wanniassa";
            map.Zoom = "14";
            map.Size = "400x400";
            map.Sensor = "true";
            map.Markers = searchResult.FormattedAddress;
            Uri url = map.ToUri();

            return url;
        }

        public Bitmap DownloadBitmap(Uri imageUrl)
        {
            Bitmap bitmap = null;
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                bitmap = new Bitmap(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return bitmap;
        }
    }


}
