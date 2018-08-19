using System;
using System.Xml;

namespace BattleSim
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.Out.WriteLine("New Character with name of Ranger being created.");

            CharacterBase character = new CharacterBase();

            CharacterOccupation occupation = new CharacterOccupation();
            occupation.OccupationName = "Ranger";

            character.CharacterName = "Ranger";
            character.CharacterOccupation = occupation;
            character.Save();
            Console.Out.WriteLine("Ranger has been saved into Ranger.xml");

            Console.Out.WriteLine("Loading Ranger.xml."); 
            CharacterBase characterToLoad = CharacterBase.Load("Ranger");
            Console.Out.WriteLine("Ranger has been loaded.");
          
            Console.Out.WriteLine("Press any key to exit."); 
            Console.ReadKey(); 
            
        }
    }
}
