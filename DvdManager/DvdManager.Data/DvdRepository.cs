using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdManager.Models;

namespace DvdManager.Data
{
    public class DvdRepository
    {
        private static List<Dvd> dvds = new List<Dvd>()
        {
            new Dvd("Batman", 2010, "Bruce", 4 ),
            new Dvd("Superman", 2009, "John", 4),
            new Dvd("Wonderwoman", 2012, "Omar", 4)
        };
        public Dvd Create(Dvd dvd)
        {
            if (dvds.Any(x => x.Title == dvd.Title))
            {
                return null;
            }
            
            else
                dvds.Add(dvd);

            return dvds.FirstOrDefault(d => d.Id == dvd.Id);
        }
        public List<Dvd> ReadAll()
        {
            return dvds;
        }

        public Dvd ReadById(int id) //should be int id
        {
            return dvds.FirstOrDefault(d => d.Id == id); //get first element that exist else null
        }
        public void Update(int id, Dvd dvd)
        {
            var dvdOrig = dvds.FirstOrDefault(d => d.Id == id);
            dvdOrig.Director = dvd.Director;
            dvdOrig.Rating = dvd.Rating;
            dvdOrig.ReleaseYear = dvd.ReleaseYear;
            dvdOrig.Title = dvd.Title;
        }

        public void Delete(int id)
        {
            dvds.Remove(dvds.FirstOrDefault(d => d.Id == id));
        }
    }
}
