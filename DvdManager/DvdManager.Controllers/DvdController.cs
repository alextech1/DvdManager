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
        public DvdRepository _dvds = new DvdRepository();

        public void Run() //TO DO: use while loop
        {
            List<Dvd> Dvds = _dvds.ReadAll();

            Dvds.Add(new Dvd("Batman", 2010, "Bruce", 4));
            Dvds.Add(new Dvd("Superman", 2009, "John", 4));
            Dvds.Add(new Dvd("Wonderwoman", 2012, "Omar", 4));

            Console.WriteLine("Welcome To Dvd Manager");

            bool inChoice = false;

            while (!inChoice)
            {
                DvdView view = new DvdView();
                int pass = view.GetMenuChoice();

                if (pass == 1)
                {
                    inChoice = true;
                    string readKey;
                    CreateDvd();
                    Console.WriteLine("Press b to go back.");
                    readKey = Console.ReadLine();
                    if (readKey == "b")
                        inChoice = false;
                    else
                        inChoice = true;
                }
                else if (pass == 2)
                {
                    inChoice = true;
                    string readKey;
                    DisplayDvds();
                    Console.WriteLine("Press b to go back.");
                    readKey = Console.ReadLine();
                    if (readKey == "b")
                        inChoice = false;
                    else
                        inChoice = true;
                }
                else if (pass == 3)
                {
                    inChoice = true;
                    string readKey2;
                    SearchDvds();
                    Console.WriteLine("Press b to go back.");
                    readKey2 = Console.ReadLine();
                    if (readKey2 == "b")
                        inChoice = false;
                    else
                        inChoice = true;
                }
                else if (pass == 4)
                {
                    inChoice = true;
                    string readKey3;
                    var myEditId = new DvdView();
                    var myId = myEditId.SearchDvd();
                    var id = _dvds.ReadById(myId); //search in list repo

                    if (Dvds.Contains(id) == false)
                        Console.WriteLine("Not in list");
                    else
                    {
                        var getDvd = view.EditDvdInfo(Dvds[myId]);
                        EditDvd(myId, getDvd);
                    }

                    Console.WriteLine("Press b to go back.");
                    readKey3 = Console.ReadLine();
                    if (readKey3 == "b")
                        inChoice = false;
                    else
                        inChoice = true;
                }
                else if (pass == 5)
                {
                    inChoice = true;
                    string readKey;
                    RemoveDvd();
                    Console.WriteLine("Press b to go back.");
                    readKey = Console.ReadLine();
                    if (readKey == "b")
                        inChoice = false;
                    else
                        inChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                }
            }
        }

        private void CreateDvd() //Create
        {
            var myView = new DvdView();
            var dvdInfos = myView.GetNewDvdInfo();

            List<Dvd> Dvds = _dvds.ReadAll();

            if (Dvds.Contains(dvdInfos) == true)
                Console.WriteLine("Already in list");
            else
            {               
                _dvds.Create(dvdInfos);
                DisplayDvds();
            }
        }

        private void DisplayDvds() //Read List<Dvd> dvds
        {
            List<Dvd> Dvds = _dvds.ReadAll();

            for (int i = 0; i < Dvds.Count; i++)
            {
                Console.WriteLine(Dvds[i]);
            }
        }

        private void SearchDvds() //Find By Id
        {
            var myIdView = new DvdView();
            var myId = myIdView.SearchDvd();

            List<Dvd> Dvds = _dvds.ReadAll();

            var id = _dvds.ReadById(myId);

            if (Dvds.Contains(id) == false)
                Console.WriteLine("Not in list");
            else
            {
                myIdView.DisplayDvd(Dvds[myId]);
                //Console.WriteLine(id);
            }
        }

        private void EditDvd(int id, Dvd dvd) //Update
        {
            List<Dvd> Dvds = _dvds.ReadAll();

            _dvds.Update(id, dvd);

            DisplayDvds();
        }

        private void RemoveDvd() //Delete int id
        {
            List<Dvd> Dvds = _dvds.ReadAll();

            var myRemoveId = new DvdView();
            var myId = myRemoveId.SearchDvd();
            var id = _dvds.ReadById(myId);

            if (Dvds.Contains(id) == false)
                Console.WriteLine("Not in list");
            else
            {
                var confirmDel = myRemoveId.ConfirmRemoveDvd(Dvds[myId]);

                if (confirmDel == true)
                    _dvds.Delete(myId);
                else
                    Console.WriteLine("Nothing removed.");

                Console.WriteLine("Updated movie list:");
                DisplayDvds();
            }
        }
    }
}
