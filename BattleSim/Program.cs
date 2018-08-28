using System;
using System.Xml;

namespace BattleSim
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            do
            {


                Console.Out.WriteLine("Do you want to create a new character or load a character?");
                Console.Out.WriteLine("Type 1 to create. Type 2 to load. Type 3 to exit. ");
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.KeyChar != '1' || key.KeyChar != '2' || key.KeyChar != '3')
                {
                    Console.Out.WriteLine("Input not recognized. Please try again.");
                    key = Console.ReadKey();
                }

                if (key.KeyChar == '1')
                {
                    CharacterBase character = new CharacterBase();
                    Console.Out.WriteLine("What is the character`s name? ");
                    string characterName = Console.ReadLine();
                    character.CharacterName = characterName;

                    Console.Out.Write("If this is correct, we will now save your character.");
                    character.Save();
                    Console.Out.WriteLine(characterName + "has been saved into Characters/" + characterName + ".xml");

                }
                else if (key.KeyChar == '2')
                {
                    bool rightCharacterFound = false;
                    do
                    {


                        Console.Out.WriteLine("What is the name of the character you wish to update?");
                        string characterName = Console.ReadLine();
                        CharacterBase character = CharacterBase.Load(characterName);
                        Console.Out.WriteLine("These are the character stats.");
                        Console.Out.WriteLine(character.Serialize());
                        Console.Out.WriteLine("Is the right file to be loaded? Type 1 if yes. Type 2 if no.");
                        while (key.KeyChar != '1' || key.KeyChar != '2')
                        {
                            Console.Out.WriteLine("Input not recognized. Please try again.");
                            key = Console.ReadKey();
                        }
                        if(key.KeyChar == '1')
                        {
                            rightCharacterFound = true; 
                        }
                    }
                    while (rightCharacterFound == false);
                   
                }
                else
                {
                    done = true;
                }
            }
            while (done == false);
            Console.Out.WriteLine("Press any key to exit.");
            Console.ReadKey();
            //CharacterBase character = new CharacterBase();

            /*
            CharacterOccupation occupation = new CharacterOccupation();
            occupation.OccupationName = "Ranger";

            character.CharacterName = "Ranger";
            character.CharacterOccupation = occupation;
            character.Save();
            Console.Out.WriteLine("Ranger has been saved into Ranger.xml");

            Console.Out.WriteLine("Loading Ranger.xml."); 
            CharacterBase characterToLoad = CharacterBase.Load("Ranger");
            Console.Out.WriteLine("Ranger has been loaded.");
          */



        }
    }
}
