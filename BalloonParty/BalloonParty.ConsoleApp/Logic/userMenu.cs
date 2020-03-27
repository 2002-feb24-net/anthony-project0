using System;

namespace BalloonParty.ConsoleApp
{
    public class userMenu
    {
        public static int MenuInterface()
        {
            int[] selections = {1, 2, 3, 4, 5, 6};
            bool status = true;
            int userSelection = 0;
            do
            {
                System.Console.WriteLine("Please Select Your Option (press the corrisponding number for that option)\n\n 1. Add New Customer\n 2. Add New Store\n 3. Add New Product\n\n 4. See Store Inventory and Place Order\n 5. See Customer Order (Not Available)\n 6. See Store Locations\n\n 7. Exit Program");
                //System.Console.WriteLine("1. Add New Customer\n 2. Add New Store\n 3. Add New Product");
                userSelection = int.Parse(Console.ReadLine());
                for(int i = 0; i < selections.Length; i++)
                {
                    if(selections[i] == userSelection)
                    {
                        status = false;
                    }
                    if(userSelection == 7)
                    {
                        Environment.Exit(-1);
                    }

                }
            } while(status);
            return userSelection;
            
        }
    }
}