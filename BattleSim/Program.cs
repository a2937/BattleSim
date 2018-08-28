using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace BattleSim
{
    class Program
    {
        private static Dictionary<int,CharacterOccupation> Occupations = new Dictionary<int,CharacterOccupation>();
        static void Main(string[] args)
        {
            bool done = false;
            InitializeOccupations();
            while(done == false)
            {


                Console.Out.WriteLine("Do you want to create a new character or load a character?");

                char loadChoice = HandleStartup(); 
                if (loadChoice == '1')
                {
                    CharacterBase character = new CharacterBase();
                    Console.Out.WriteLine("What is the character`s name? Type the name and hit enter.");
                    string characterName = Console.ReadLine();
                    character.CharacterName = characterName;
                    char classKey = ChooseCharacterOccupation(); 
                    bool worked = Int32.TryParse(classKey.ToString(), out int actualNumber);
                    if (!worked)
                    {
                        Console.Out.WriteLine("Something went wrong with setting the character class. Please alert the developers.");
                    }
                    else
                    {
                        character.CharacterOccupation = Occupations[actualNumber];
                    }
                    Console.Out.WriteLine(character.ToString());

                    int Level = GetDesiredLevel();
                    character.Level = Level;

                    Console.Out.Write("If this is correct, we will now save your character.");

                    character.Save();
                    Console.Out.WriteLine(characterName + "has been saved into Characters/" + characterName + ".xml");

                }
                else if (loadChoice == '2')
                {
                    CharacterBase character;
                    bool rightCharacterFound = false;
                    do
                    {


                        Console.Out.WriteLine("What is the name of the character you wish to update?");
                        string characterName = Console.ReadLine();
                        character = CharacterBase.Load(characterName);
                        Console.Out.WriteLine("These are the character stats.");
                        Console.Out.WriteLine(character.ToString());
                        ConsoleKeyInfo key = Console.ReadKey(); 
                        Console.Out.WriteLine("Is the right file to be loaded? Type 1 if yes. Type 2 if no.");
                        while (key.KeyChar != '1' || key.KeyChar != '2')
                        {
                            Console.Out.WriteLine("Input not recognized. Please try again.");
                            key = Console.ReadKey();
                        }
                        if (key.KeyChar == '1')
                        {
                            rightCharacterFound = true;
                        }
                      
                    }
                    while (rightCharacterFound == false);

                    char classKey = ChooseCharacterOccupation();
                    bool worked = Int32.TryParse(classKey.ToString(), out int actualNumber);
                    if (!worked)
                    {
                        Console.Out.WriteLine("Something went wrong with setting the character class. Please alert the developers.");

                    }
                    else
                    {
                        character.CharacterOccupation = Occupations[actualNumber];
                    }

                    int Level = GetDesiredLevel();
                    character.Level = Level;

                    Console.Out.WriteLine(character.ToString());

                    Console.Out.WriteLine("If this is correct, we will now save your character.");

                    character.Save();
                    Console.Out.WriteLine(character.CharacterName + " has been saved into Characters/" + character.CharacterName + ".xml");

                }
                else
                {
                    done = true;
                }
            }
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

        private static char HandleStartup()
        {
            Console.Out.WriteLine("Type 1 to create. Type 2 to load. Type 3 to exit. ");
            ConsoleKeyInfo key = Console.ReadKey();

            Console.ReadLine();
             while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3')
            {
                Console.Out.WriteLine(key.KeyChar + " was not recognized.");
                Console.Out.WriteLine("Please try again using different input.");
                key = Console.ReadKey();
                Console.ReadLine(); 
            }
            return key.KeyChar;
        }

        private static char ChooseCharacterOccupation()
        {
            Console.Out.WriteLine("What should the character`s class be? Now listing available classes.");
            Console.Out.WriteLine("1) Soldier");
            Console.Out.WriteLine("2) Fighter");
            Console.Out.WriteLine("3) Ranger");
            Console.Out.WriteLine("4) Priest");
            Console.Out.WriteLine("5) Wizard");
            Console.Out.WriteLine("6) BeastMode");
            Console.Out.WriteLine("7) Thief");
            Console.Out.WriteLine("8) DragonLord");
            Console.Out.WriteLine("9) Hexologist");
            Console.Out.WriteLine("Please type the number associated with the desired character then hit enter.");
            ConsoleKeyInfo classKey = Console.ReadKey();
            Console.ReadLine(); 
            while (classKey.KeyChar != '1' && classKey.KeyChar != '2' && classKey.KeyChar != '3' && classKey.KeyChar != '4'
                   && classKey.KeyChar != '5' && classKey.KeyChar != '6'  && classKey.KeyChar != '7'
                   && classKey.KeyChar != '8' && classKey.KeyChar != '9')
            {
                Console.Out.WriteLine("Input not recognized. Please try again.");
                classKey = Console.ReadKey();
                Console.ReadLine(); 
            }
            return classKey.KeyChar;
        }
        
        private static int GetDesiredLevel()
        {
            Console.Out.WriteLine("What should the character's level be? Type a number greater than zero and hit enter.");
            int X;

            String Result = Console.ReadLine();

            while (!Int32.TryParse(Result, out X))
            {
                Console.WriteLine("Not a valid number, try again.");

                Result = Console.ReadLine();
            }

            return X; 
        }

        static void InitializeOccupations()
        {

            CharacterOccupation Soldier = new CharacterOccupation
            {
                OccupationName = "Soldier",
                HpGrowth = 5.5,
                MpGrowth = 1.5,
                StrengthGrowth = 3.5,
                AgilityGrowth = 2.5,
                ResistanceGrowth = 4.5,
                IntelligenceGrowth = 2.5
            };
            Occupations.Add(1, Soldier);

            CharacterOccupation Fighter  = new CharacterOccupation
            {
                OccupationName = "Fighter",
                HpGrowth = 3.5,
                MpGrowth = 1.5,
                StrengthGrowth = 4.5,
                AgilityGrowth = 4.5,
                ResistanceGrowth = 3.5,
                IntelligenceGrowth = 2.5
            };
            Occupations.Add(2, Fighter);

            CharacterOccupation Ranger = new CharacterOccupation
            {
                OccupationName = "Ranger",
                HpGrowth = 4.5,
                MpGrowth = 2.5,
                StrengthGrowth = 3.5,
                AgilityGrowth = 3.5,
                ResistanceGrowth = 4.5,
                IntelligenceGrowth = 4.5
            };
            Occupations.Add(3, Ranger);

            CharacterOccupation Priest = new CharacterOccupation
            {
                OccupationName = "Priest",
                HpGrowth = 4.5,
                MpGrowth = 3.5,
                StrengthGrowth = 3.5,
                AgilityGrowth = 2.5,
                ResistanceGrowth = 4.5,
                IntelligenceGrowth = 3.5
            };
            Occupations.Add(4, Priest);


            CharacterOccupation Wizard = new CharacterOccupation
            {
                OccupationName = "Wizard",
                HpGrowth = 3.5,
                MpGrowth = 3.5,
                StrengthGrowth = 2.5,
                AgilityGrowth = 3.5,
                ResistanceGrowth = 2.5,
                IntelligenceGrowth = 4.5
            };
            Occupations.Add(5, Wizard);

            CharacterOccupation BeastMode = new CharacterOccupation
            {
                OccupationName = "BeastMode",
                HpGrowth = 6.5,
                MpGrowth = 4.5,
                StrengthGrowth = 9.5,
                AgilityGrowth = 4.5,
                ResistanceGrowth = 7.5,
                IntelligenceGrowth = 17.5
            };
            Occupations.Add(6, BeastMode);

            CharacterOccupation Thief = new CharacterOccupation
            {
                OccupationName = "Thief",
                HpGrowth = 3.5,
                MpGrowth = 1.5,
                StrengthGrowth = 3.5,
                AgilityGrowth = 4.5,
                ResistanceGrowth = 2.5,
                IntelligenceGrowth = 3.5
            };
            Occupations.Add(7, Thief);

            CharacterOccupation Dragonlord = new CharacterOccupation
            {
                OccupationName = "Dragonlord",
                HpGrowth = 5.5,
                MpGrowth = 3.5,
                StrengthGrowth = 4.5,
                AgilityGrowth = 4.5,
                ResistanceGrowth = 4.5,
                IntelligenceGrowth = 4.5
            };
            Occupations.Add(8, Dragonlord);

            CharacterOccupation Hexologist = new CharacterOccupation
            {
                OccupationName = "Hexologist",
                HpGrowth = 3.5,
                MpGrowth = 5.5,
                StrengthGrowth = 3.5,
                AgilityGrowth = 5.5,
                ResistanceGrowth = 4.5,
                IntelligenceGrowth = 10
            };
            Occupations.Add(9, Hexologist);
        }

    }
}
