using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdManager.Models;
using DvdManager.Data;
using DvdManager.View;

/* 
    Run() : void
    Private CreateDvd(): void
    Private DisplayDvds(): void
    Private SearchDvds(): void
    Private EditDvd() : void
    Private RemoveDvd() : void
*/

namespace DvdManager.Controllers
{
    public class DvdController
    {
        public DVDList _dvds = new DVDList();        
        

        public void Run()
        {
            List<Dvd> Dvds = _dvds.GetList();

            Dvds.Add(new Dvd(0, "Batman", 2010, "Bruce", 4));
            Dvds.Add(new Dvd(1, "Superman", 2009, "John", 4));
            Dvds.Add(new Dvd(2, "Wonderwoman", 2012, "Omar", 4));

            Console.WriteLine("Welcome To Dvd Manager");
            DvdView view = new DvdView();
           

            var pass = view.GetMenuChoice();

            if (pass == 1)
            {
                CreateDvd();
            }
            else if (pass == 2)
            {
                DisplayDvds();
            }
            else if (pass == 3)
            {
                SearchDvds();
            }
            else if (pass == 4)
            {
                RemoveDvd();
            }
            else if (pass == 5)
            {
                EditDvd();
            }
            else
                Console.WriteLine("Invalid.");            
        }

        private void CreateDvd() //Create
        {
            var myView = new DvdView();
            var dvdInfos = myView.GetNewDvdInfo();

            List<Dvd> Dvds = _dvds.GetList();
            
            Dvds.Add(dvdInfos);            
            DisplayDvds();
        }

        private void DisplayDvds() //Read List<Dvd> dvds
        {
            List<Dvd> Dvds = _dvds.GetList();

            for (int i = 0; i < Dvds.Count; i++)
            {                
                Console.WriteLine(Dvds[i]);
            }
        }

        private void SearchDvds() //Find By Id
        {
            var myIdView = new DvdView();
            var myId = myIdView.SearchDvd();

            List<Dvd> Dvds = _dvds.GetList();

            var _id = Dvds.Single(x => x.Id == myId);

            Console.WriteLine(_id);

        }

        private void EditDvd(int id, Dvd dvd) //Update
        {
            List<Dvd> Dvds = _dvds.GetList();

            for (int i = 0; i < Dvds.Count; i++)
            {
                Console.WriteLine(Dvds[i]);
            }

            var myEditId = new DvdView();
            var myId = myEditId.SearchDvd();
            var newDvd = myEditId.EditDvdInfo(dvd);

            for (int i = 0; i < Dvds.Count; i++)
            {
                Console.WriteLine(Dvds[i]);
            }


        }

        private void RemoveDvd() //Delete int id
        {
            var myRemoveId = new DvdView();
            var myId = myRemoveId.SearchDvd();

            List<Dvd> Dvds = _dvds.GetList();

            Dvds.Remove(Dvds.Single(x => x.Id == myId));

            Console.WriteLine("Removed movie from list:");

            for (int i = 0; i < Dvds.Count; i++)
            {
                Console.WriteLine(Dvds[i]);
            }
        }
    }
}
