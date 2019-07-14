using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//TO DO: 
//    Id : int
//    Title : string
//    ReleaseYear: int
//    Director: string
//    Rating: float


namespace DvdManager.Models
{
    public class Dvd
    {
        public Dvd(string title, int releaseyear, string director, float rating)
        {
            Id = Interlocked.Increment(ref globalId);
            Title = title;
            ReleaseYear = releaseyear;
            Director = director;
            Rating = rating;
        }

        public static int globalId;
        public int Id { get; private set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public float Rating { get; set; }

        public override string ToString() //Display at index
        {
            return string.Format
                ("DVD [Id: {0}; Title: {1}; ReleaseYear: {2}; Director: {3}; Rating: {4}]",
                Id, Title, ReleaseYear, Director, Rating);
        }

    }
}
