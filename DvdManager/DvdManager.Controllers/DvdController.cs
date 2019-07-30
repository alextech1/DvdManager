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
            Console.WriteLine("Welcome To Dvd Manager");

            bool inChoice = false;

            while (!inChoice)
            {
                DvdView view = new DvdView();
                int pass = view.GetMenuChoice();

                if (pass == 1)
                {
                    
                    inChoice = true;
                    CreateDvd();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    inChoice = false;
                }
                else if (pass == 2)
                {
                    inChoice = true;
                    DisplayDvds();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    inChoice = false;
                }
                else if (pass == 3)
                {
                    inChoice = true;
                    SearchDvds();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    inChoice = false;
                }
                else if (pass == 4)
                {
                    inChoice = true;
                    var myEditId = new DvdView();
                    var myId = myEditId.SearchDvd();
                    var id = _dvds.ReadById(myId); //search in list repo

                    if (id == null)
                    {
                        Console.WriteLine("Not in list.");
                    }
                    else
                    {
                        var getDvd = view.EditDvdInfo(id);
                        EditDvd(myId, getDvd);
                    }
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    inChoice = false;
                }
                else if (pass == 5)
                {
                    inChoice = true;
                    RemoveDvd();
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    inChoice = false;
                } 
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadKey();
                }
            }
        }

        private void CreateDvd() //Create
        {
            var myView = new DvdView();
            var dvdInfos = myView.GetNewDvdInfo();
            var createDvd = _dvds.Create(dvdInfos);

            if (createDvd == null)
            {
                Console.WriteLine("Already in list.");
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
            var id = _dvds.ReadById(myId);

            if (id == null)
            {
                Console.WriteLine("Not in list");
            }
            else
                myIdView.DisplayDvd(id);
            //Console.WriteLine(id);

        }

        private void EditDvd(int id, Dvd dvd) //Update
        {
            _dvds.Update(id, dvd);
            DisplayDvds();
        }

        private void RemoveDvd() //Delete int id
        {
            var myRemoveId = new DvdView();
            var myId = myRemoveId.SearchDvd();
            var id = _dvds.ReadById(myId);
            var confirmDel = myRemoveId.ConfirmRemoveDvd(id);

            if (id == null)
            {
                Console.WriteLine("Not in list");
            }
            else
            {
                if (confirmDel == true)
                    _dvds.Delete(myId);
                else
                    Console.WriteLine("Nothing removed.");
            }

            Console.WriteLine("Updated movie list:");
            DisplayDvds();
        }
    }
}
