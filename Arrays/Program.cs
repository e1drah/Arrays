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
        static int[] ammo = new int[weaponAmmount];
        static int[] ammoMax = new int[weaponAmmount];
        static void Main(string[] args)
        {
            //Initialization of weapon names
            weaponName[0] = "Pistol";
            weaponName[1] = "shotgun";
            weaponName[2] = "spreader";
            weaponName[3] = "laser";
            weaponName[4] = "rocket luancher";

            //Initialization of max ammo amount
            ammoMax[0] = 6; //Max pistol ammo
            ammoMax[1] = 2; //Max shotgun ammo
            ammoMax[2] = 50; //Max spreader ammo
            ammoMax[3] = 25; //Max laser ammo
            ammoMax[4] = 10; //Max rocket launcher ammo

            //Initial ammo ammount
            ammo[0] = ammoMax[weapon]; //pistol
            ammo[1] = ammoMax[weapon]; //shotgun
            ammo[2] = ammoMax[weapon]; //spreader
            ammo[3] = ammoMax[weapon]; //laser
            ammo[4] = ammoMax[weapon]; //rocket launcher;


            DebugMenu();

            

        }
        static void DebugMenu()
        {

            HUD();
            Console.WriteLine("Fire = 1");
            Console.WriteLine("Reload = 2");
            Console.WriteLine("Preveious weapon = 2");
            Console.WriteLine("Next weapon = 4");
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
                    Reload();
                    break;
                case 3:
                    ChangeWeapons(selectionInput);
                    break;

                case 4:
                    ChangeWeapons(selectionInput);
                    break;
            }
        }

        static void Fire()
        {
            if (ammo[weapon] == 0)
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
                ammo[weapon] -= 1;
            }
            DebugMenu();
        }
        
        static void Reload()
        {
            Console.WriteLine();
            Console.WriteLine("Reloading...");
            Console.WriteLine();
            ammo[weapon] = ammoMax[weapon];
            DebugMenu();
        }

        static void ChangeWeapons(int Nepre)
        {
            if (Nepre == 3)
            {
                if (weapon == 0) weapon = (weaponAmmount - 1);
                else weapon -= 1;
            }
            if (Nepre == 4)
            {
                weapon += 1;
                if (weapon > (weaponAmmount - 1)) weapon = 0;
            }
            DebugMenu();
        }
        static void HUD()
        {
            Console.WriteLine("Weapon equiped: " + weaponName[weapon] + " Ammo: " + ammo[weapon] + "/" + ammoMax[weapon]);
            Console.WriteLine();
        }
    }
}
