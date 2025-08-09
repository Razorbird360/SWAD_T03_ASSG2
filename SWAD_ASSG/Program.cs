// See https://aka.ms/new-console-template for more information
using SWAD_ASSG;

Console.WriteLine("Welcome to Order-al-Ready Food Ordering! ");
Console.WriteLine("==============================================");
Console.WriteLine("         Order-al-Ready Food Ordering         ");
Console.WriteLine("==============================================");
Console.WriteLine();
String userType = "";
while(true)
{
    Console.WriteLine("== Login Or Register ==");
    Console.WriteLine("  1. Login as Student");
    Console.WriteLine("  2. Login as Staff");
    Console.WriteLine("  3. Login as Admin");
    Console.WriteLine("  4. Register as a User");
    Console.WriteLine();
    Console.Write("Select an option (1-4): ");
    String userInput = Console.ReadLine();
    Console.WriteLine();
    if (userInput == "1")
    {
        Console.WriteLine("Enter your Student ID");
        Console.Write("Student ID: ");
        String studentID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        String password = Console.ReadLine();
        userType = "Student";
        break;
    }
    else if (userInput == "2")
    {
        Console.WriteLine("Enter your Staff ID");
        Console.Write("Staff ID: ");
        String staffID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        String password = Console.ReadLine();
        userType = "Staff";
        break;
    }
    else if (userInput == "3")
    {
        Console.WriteLine("Enter your Admin ID");
        Console.Write("Admin ID: ");
        String staffID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        String password = Console.ReadLine();
        userType = "Admin";
        break;
    }
    else if (userInput == "4")
    {

        Console.WriteLine("Enter your Name");
        Console.Write("Name: ");
        String name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Email");
        Console.Write("Email: ");
        String email = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        String password = Console.ReadLine();
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine("Reconfirm your password");
            Console.Write("Reconfirm Password: ");
            String confirmPassword = Console.ReadLine();
            if (password == confirmPassword)
            {
                Console.WriteLine("Registration successful!");
                Console.WriteLine("You can now login with your credentials.");
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine("Passwords do not match. Please try again.");
            }
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid input");
    }
}
Console.WriteLine();
if(userType == "Student")
{
    // change the options accordingly these are fake example ones
    Console.WriteLine("Welcome Student!");
    Console.WriteLine();
    Console.WriteLine("  1. Register & Login with school credentials");
    Console.WriteLine("  2. Browse food stalls & menus");
    Console.WriteLine("  3. Place orders & choose pick-up time");
    Console.WriteLine("  4. Pay digitally & receive QR code");
    Console.WriteLine("  5. Real-time menu updates");
    Console.WriteLine("  6. Priority user perks (extra limits, VIP pick-up)");
}
else if (userType == "Staff")
{
    // change the options accordingly these are fake example ones
    Console.WriteLine("Welcome Staff!");
    Console.WriteLine();
    Console.WriteLine("  1. Manage stall profile");
    Console.WriteLine("  2. View & track incoming orders");
    Console.WriteLine("  3. Manage Menu Items");
    Console.WriteLine("  4. Handle feedback & report inappropriate reviews");
    Console.WriteLine("  5. Cancel orders & manage no-shows");
    Console.WriteLine("  6. Track sales performance");
}
else if (userType == "Admin")
{
    // change the options accordingly these are fake example ones
    Console.WriteLine("Welcome Admin!");
    Console.WriteLine();
    Console.WriteLine("  1. Manage student & staff accounts");
    Console.WriteLine("  2. Review & moderate content");
    Console.WriteLine("  3. Manage policy configurations");
    Console.WriteLine("  4. Resolve disputes");
    Console.WriteLine("  5. View analytics & reports");
}
Console.WriteLine();
Console.WriteLine("==============================================");
Console.WriteLine("  Press any key to continue...");
Console.WriteLine("==============================================");
String userOption = Console.ReadLine();
Console.WriteLine(userOption);


//Create Chicken Rice Stall
FoodStall chickenRiceStall = new FoodStall("Chicken Rice Stall", "Serving authentic chicken rice and related dishes.", "9876-5432", "Food Court, Stall #5", "chicken_rice.jpg", StallStatus.Active);
// Add Menu Items
chickenRiceStall.Menu.Add(new MenuItem("Hainanese Chicken Rice", "Steamed chicken with fragrant rice, chili & ginger paste.", 5.50f, 5));
chickenRiceStall.Menu.Add(new MenuItem("Roasted Chicken Rice", "Crispy roasted chicken with aromatic rice and special sauce.", 6.00f, 3));
chickenRiceStall.Menu.Add(new MenuItem("Shredded Chicken Noodle", "Noodles topped with tender shredded chicken.", 3.50f, 2));
chickenRiceStall.Menu.Add(new MenuItem("Chicken Drumstick Rice", "Tender chicken drumstick served with fragrant rice.", 6.50f, 4));
chickenRiceStall.Menu.Add(new MenuItem("Chicken Set", "Chicken rice set with soup and side dishes.", 4.00f, 0));
chickenRiceStall.Menu.Add(new MenuItem("Braised Egg", "Soy sauce braised egg, a perfect side.", 1.00f, 10));