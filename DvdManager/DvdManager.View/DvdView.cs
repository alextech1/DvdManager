using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdManager.Models;

/* 
    GetMenuChoice() : int
    GetNewDvdInfo(): Dvd
    DisplayDvd(Dvd dvd) : void
    EditDvdInfo(Dvd dvd) : Dvd
    SearchDvd() : int
    ConfirmRemoveDvd(Dvd) : boolean
*/

namespace DvdManager.View
{
    public class DvdView
    {
        public int GetMenuChoice()
        {
            string input;
            int choice;

            Console.Clear();
            Console.WriteLine("Press 1 to add movie");
            Console.WriteLine("Press 2 to display movies");
            Console.WriteLine("Press 3 to find by ID");
            Console.WriteLine("Press 4 to remove DVD");
            Console.WriteLine("Press 5 to edit movie");
            input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:                        
                        break;
                    default:
                        break;
                }
                
            }
            return choice;


        }

        public Dvd GetNewDvdInfo()
        {
            string inputReleaseYear;
            string inputRating;

            int id = 3;
            string readTitle;            
            int readReleaseYear;
            string readDirector;            
            float readRating;

            Console.WriteLine("What is the Title of the DVD?");
            readTitle = Console.ReadLine();

            Console.WriteLine("What is the Release Year of the DVD?");
            inputReleaseYear = Console.ReadLine();
            int.TryParse(inputReleaseYear, out readReleaseYear);

            Console.WriteLine("Who is the Director of the DVD?");
            readDirector = Console.ReadLine();

            Console.WriteLine("What is the star rating of the DVD?");
            inputRating = Console.ReadLine();
            float.TryParse(inputRating, out readRating);

            
            var dvd = new Dvd(id, readTitle, readReleaseYear, readDirector, readRating);
            return dvd;
        }

        public void DisplayDvd(Dvd dvd)
        {

        }

        public Dvd EditDvdInfo(Dvd dvd)
        {
            string inputReleaseYear;
            string inputRating;
            string inputId;

            int readId;
            string readTitle;
            int readReleaseYear;
            string readDirector;
            float readRating;

            Console.WriteLine("What is the Id of the movie to edit?");
            inputId = Console.ReadLine();
            int.TryParse(inputId, out readId);

            Console.WriteLine("What is the new Title of the DVD?");
            readTitle = Console.ReadLine();

            Console.WriteLine("What is the new Release Year of the DVD?");
            inputReleaseYear = Console.ReadLine();
            int.TryParse(inputReleaseYear, out readReleaseYear);

            Console.WriteLine("Who is the new Director of the DVD?");
            readDirector = Console.ReadLine();

            Console.WriteLine("What is the new star rating of the DVD?");
            inputRating = Console.ReadLine();
            float.TryParse(inputRating, out readRating);

            dvd = new Dvd(readId, readTitle, readReleaseYear, readDirector, readRating);
            return dvd;
        }

        public int SearchDvd()
        {
            string inputId;
            int outputId;

            Console.WriteLine("What is the Id of the Dvd?");
            inputId = Console.ReadLine();
            int.TryParse(inputId, out outputId);

            return outputId;
        }

        public Boolean ConfirmRemoveDvd(Dvd dvd)
        {
            string input;

            bool confirm = false;
            Console.WriteLine("Are you sure you want to remove this dvd? Type: y/n");
            input = Console.ReadLine();
            if (input == "y")
                confirm = true;
            else if (input == "n")
                confirm = false;
            else
                confirm = false;

            return confirm;
        }
    }
}
