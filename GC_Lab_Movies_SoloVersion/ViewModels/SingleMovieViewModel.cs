using GC_Lab_Movies_SoloVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_Lab_Movies_SoloVersion.ViewModels
{
    public class SingleMovieViewModel
    {
        public MovieModel MovieModel { get; set; }
        public string BaseURL { get; set; }
        public string ImageSizeParam { get; set; }

        public string BuildImageUrl()
        {
            return $"{BaseURL}{ImageSizeParam}{MovieModel.poster_path}";
        }
    }
}
