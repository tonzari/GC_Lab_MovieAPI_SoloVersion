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

        public string GetImageSizeParamOriginal()
        {
            ApiConfigModel config = GetConfigInfo();
            string resolutionSelection = config.images.poster_sizes.Last();
            return resolutionSelection;
        }

        public string GetImageSizeParamXXLarge()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount];
            return resolutionSelection;
        }

        public string GetImageSizeParamXLarge()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 1];
            return resolutionSelection;
        }

        public string GetImageSizeParamLarge()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 2];
            return resolutionSelection;
        }

        public string GetImageSizeParamMedium()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 3];
            return resolutionSelection;
        }

        public string GetImageSizeParamSmall()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 4];
            return resolutionSelection;
        }

        public string GetImageSizeParamXSmall()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 5];
            return resolutionSelection;
        }

        public string GetImageSizeParamXXSmall()
        {
            ApiConfigModel config = GetConfigInfo();
            int optionsCount = config.images.poster_sizes.Length;
            string resolutionSelection = config.images.poster_sizes[optionsCount - 6];
            return resolutionSelection;
        }
    }
}
