using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CinemaApp.Model
{
    public class Movie
    {
        public object id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public int runTime { get; set; }      
        public string plot { get; set; }
        public BitmapImage image { get; set; }
        public byte[] video { get; set; }
        public string country { get; set; }
        //public List<string> genres { get; set; }
        public string genres { get; set; }
        public string studio { get; set; }
        //public List<object> actors { get; set; }
        public string actors { get; set; }

        public Movie(object id, string name, string date, int runTime, string plot,
            BitmapImage image, byte[] video, string country, string genres, string studio, string actors)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.runTime = runTime;
            this.plot = plot;
            this.image = image;
            this.video = video;
            this.country = country;
            this.studio = studio;
            this.genres = genres;
            this.actors = actors;
        }
    }
}
