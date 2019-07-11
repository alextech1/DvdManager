using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdManager.Models;

/*
    Create(Dvd dvd) : Dvd
    ReadAll() : List<Dvd>
    ReadById() : Dvd
    Update(int id, Dvd dvd) : void
    Delete(int id) : void
*/

namespace DvdManager.Data
{
    public interface DvdRepository
    {
        

        Dvd Create(Dvd dvd);
        List<Dvd> ReadAll();
        //IEnumerable<Dvd> ReadAll();
        Dvd ReadById();
        void Update(int id, Dvd dvd);
        //Dvd Update(int id, Dvd dvd); //dvd item
        void Delete(int id);
        //Dvd Delete(int id);
    }

    public class DVDList
    {
        private List<Dvd> dvds = new List<Dvd>();

        public List<Dvd> GetList()
        {
            return dvds;
        }
    }
}
