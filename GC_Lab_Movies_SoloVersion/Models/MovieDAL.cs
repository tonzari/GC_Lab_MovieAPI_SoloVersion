using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace GC_Lab_Movies_SoloVersion.Models
{
    public class MovieDAL
    {
        // goal: get movie objects from the API
        // steps:
        //   get the data (comes in as JSON)
        //   turn JSON into a string
        //   then
        //   turn string into object (movie object)

        /// <summary>
        /// The Movie API stores its URLs in a system wide Configuration file. This is useful for building image URLs.
        /// </summary>
        private string RetrieveConfigData()
        {
            string url = $@"https://api.themoviedb.org/3/configuration?api_key={Secret.apiKey}";
            return ConvertHttpRequestDataToString(url);
        }

        private string RetrieveMovieDataById(int id)
        {
            string url = $@"https://api.themoviedb.org/3/movie/{id}?api_key={Secret.apiKey}";
            return ConvertHttpRequestDataToString(url);
        }

        private static string ConvertHttpRequestDataToString(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string JSON = streamReader.ReadToEnd();

            return JSON;
        }

        public MovieModel GetMovieById(int id)
        {
            string movieData = RetrieveMovieDataById(id);
            MovieModel movieModel = JsonConvert.DeserializeObject<MovieModel>(movieData);
            return movieModel;
        }

        public ApiConfigModel GetConfigInfo()
        {
            return JsonConvert.DeserializeObject<ApiConfigModel>(RetrieveConfigData());
        }

        public string GetBaseURL()
        {
            ApiConfigModel config = GetConfigInfo();
            return config.images.base_url;
        }

        public string GetImageSizeParamFull()
        {
            ApiConfigModel config = GetConfigInfo();
            string highestResolution = config.images.poster_sizes.Last();
            return highestResolution;
        }
    }
}
