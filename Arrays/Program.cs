using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        //Ints
        static int weapon = 0;
        static int weaponAmmount = 5;

        //Arrays
        static string[] weaponName = new string[weaponAmmount];
        static int[] ammoCurrent = new int[weaponAmmount];
        static int[] ammoMax = new int[weaponAmmount];
        static int[] ammoTotal = new int[weaponAmmount];
        static void Main(string[] args)
        {
            //Initialization of weapon names
            weaponName[0] = "Pistol";
            weaponName[1] = "Shotgun";
            weaponName[2] = "spreader";
            weaponName[3] = "laser";
            weaponName[4] = "rocket luancher";

            //Initialization of max ammoCurrent amount
            ammoMax[0] = 6; //Max pistol ammoCurrent
            ammoMax[1] = 6; //Max Double barrel ammoCurrent
            ammoMax[2] = 32; //Max spreader ammoCurrent
            ammoMax[3] = 25; //Max laser ammoCurrent
            ammoMax[4] = 1; //Max rocket launcher ammoCurrent

            //Initial ammoCurrent ammount
            ammoCurrent[0] = ammoMax[0]; //pistol
            ammoCurrent[1] = ammoMax[1]; //Double barrel
            ammoCurrent[2] = ammoMax[2]; //spreader
            ammoCurrent[3] = ammoMax[3]; //laser
            ammoCurrent[4] = ammoMax[4]; //rocket launcher;

            // Initial of total ammo
            ammoTotal[0] = 24;
            ammoTotal[1] = 24;
            ammoTotal[2] = 128;
            ammoTotal[3] = 100;
            ammoTotal[4] = 4;


            DebugMenu();

            

        }
        static void DebugMenu()
        {
            HUD();
            Console.WriteLine("Fire = 1");
            Console.WriteLine("Reload quick = 2");
            Console.WriteLine("Reload slow = 3");
            Console.WriteLine("Preveious weapon = 4");
            Console.WriteLine("Next weapon = 5");
            Console.WriteLine("Reset = 6");
            Console.WriteLine();

            int selectionInput = 0;
            try
            {
                selectionInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                
                DebugMenu();

            }
            switch (selectionInput)
            {
                case 1:
                    Fire();
                    break;
                case 2:
                    Reload(selectionInput);
                    break;
                case 3:
                    Reload(selectionInput);
                    break;
                case 4:
                    ChangeWeapons(selectionInput);
                    break;

                case 5:
                    ChangeWeapons(selectionInput);
                    break;
                case 6:
                    Reset();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine(selectionInput + " is a not a valid option");
                    Console.WriteLine();
                    DebugMenu();
                    break;
            }
        }

        static void Fire()
        {
            if (ammoCurrent[weapon] == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Click");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("BANG!");
                Console.WriteLine();
                ammoCurrent[weapon] -= 1;
            }
            DebugMenu();
        }
        
        static void Reload(int slick)
        {
            int ammoCal;    
            if (ammoTotal[weapon] <= 0)
            {
                Console.WriteLine("No ammo left");
                DebugMenu();
            }
            if (ammoCurrent[weapon] == ammoMax[weapon])
            {
                Console.WriteLine("No need to Reload");
                DebugMenu();
            }
            Console.WriteLine();
            Console.WriteLine("Reloading...");
            Console.WriteLine();
            if (slick == 2)
            {
                if (weapon == 1)
                {
                    ammoCurrent[weapon] += 1;
                    ammoTotal[weapon] -= 1;
                }
                else
                {
                    ammoCurrent[weapon] = ammoMax[weapon];
                    ammoTotal[weapon] -= ammoMax[weapon];
                }
            }
            if (slick == 3)
            {
                Console.WriteLine("Reloading...");
                Console.WriteLine();
                ammoCal = (ammoMax[weapon] - ammoCurrent[weapon]);
                ammoTotal[weapon] -= ammoCal;
                ammoCurrent[weapon] += ammoCal;

            }


            DebugMenu();
        }

        static void ChangeWeapons(int Neious)
        {
            if (Neious == 4)
            {
                if (weapon == 0) weapon = (weaponAmmount - 1);
                else weapon -= 1;
            }
            if (Neious == 5)
            {
                weapon += 1;
                if (weapon > (weaponAmmount - 1)) weapon = 0;
            }
            DebugMenu();
        }
        static void Reset()
        {
            ammoTotal[0] = 24;
            ammoTotal[1] = 24;
            ammoTotal[2] = 128;
            ammoTotal[3] = 100;
            ammoTotal[4] = 4;

            ammoCurrent[0] = ammoMax[0];
            ammoCurrent[1] = ammoMax[1];
            ammoCurrent[2] = ammoMax[2];
            ammoCurrent[3] = ammoMax[3];
            ammoCurrent[4] = ammoMax[4];

            Console.Clear();
            DebugMenu();
        }
        static void HUD()
        {
            Console.WriteLine("Weapon equiped: " + weaponName[weapon] + " Ammo: " + ammoCurrent[weapon] + "/" + ammoTotal[weapon]);
            Console.WriteLine();
        }
    }
}
