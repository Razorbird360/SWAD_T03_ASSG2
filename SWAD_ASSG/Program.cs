// See https://aka.ms/new-console-template for more information
using SWAD_ASSG;

// create Chicken Rice Stall
FoodStall chickenRiceStall = new FoodStall("Chicken Rice Stall", "Serving authentic chicken rice and related dishes.", "9876-5432", "Food Court, Stall #5", "chicken_rice.jpg", StallStatus.Active);
// add Menu Items
chickenRiceStall.Menu.Add(new MenuItem("Hainanese Chicken Rice", "Steamed chicken with fragrant rice, chili & ginger paste.", 5.50f, 5));
chickenRiceStall.Menu.Add(new MenuItem("Roasted Chicken Rice", "Crispy roasted chicken with aromatic rice and special sauce.", 6.00f, 3));
chickenRiceStall.Menu.Add(new MenuItem("Shredded Chicken Noodle", "Noodles topped with tender shredded chicken.", 3.50f, 2));
chickenRiceStall.Menu.Add(new MenuItem("Chicken Drumstick Rice", "Tender chicken drumstick served with fragrant rice.", 6.50f, 4));
chickenRiceStall.Menu.Add(new MenuItem("Chicken Set", "Chicken rice set with soup and side dishes.", 4.00f, 0));
chickenRiceStall.Menu.Add(new MenuItem("Braised Egg", "Soy sauce braised egg, a perfect side.", 1.00f, 10));

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
    string? option = Console.ReadLine();
    if (option == "3")
    {
        ManageMenuItems();
    }
    Console.WriteLine();
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
string? userOption = Console.ReadLine();
Console.WriteLine(userOption);

// Manage Menu Items
void ManageMenuItems()
{
    while (true)
    {
        DisplayMenuItems();
        Console.WriteLine();
        Console.WriteLine("==== Manage Menu Items ====");
        Console.WriteLine("1. Edit Menu Item");
        Console.WriteLine("2. Add New Menu Item");
        Console.WriteLine("0. Exit");
        string? manageOption = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrEmpty(manageOption) || (manageOption != "1" && manageOption != "2" && manageOption != "0"))
        {
            Console.WriteLine("Invalid option! Please choose option between 1-4.");
            continue;
        }
        try
        {
            if (manageOption == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (manageOption == "1")
            {
               EditMenuItems();
            }
            else if (manageOption == "2")
            {
                //AddNewMenuItem();
            }
            else
            {
                Console.WriteLine("Invalid option! Please try again.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

void DisplayMenuItems()
{
    Console.WriteLine($"===== {chickenRiceStall.StallName} Menu =====");
    Console.WriteLine("{0,-25} {1,8}", "Item Name", "Price ($)");
    foreach (var item in chickenRiceStall.Menu)
    {
        Console.WriteLine("{0,-25} {1,8:F2}", item.ItemName, item.ItemPrice);
    }
    Console.WriteLine();
}

void EditMenuItems()
{
    bool continueUpdate = true;
    while (continueUpdate)
    {
        // Select an item to edit
        Console.WriteLine("Select the item to edit by entering the option number: ");
        for (int i = 0; i < chickenRiceStall.Menu.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {chickenRiceStall.Menu[i].ItemName}");
        }
        string? itemOption = Console.ReadLine();
        Console.WriteLine();
        
        if (string.IsNullOrEmpty(itemOption) || Convert.ToInt16(itemOption) < 1 || Convert.ToInt16(itemOption) > chickenRiceStall.Menu.Count)
        {
            Console.WriteLine("Invalid option! Please choose a valid item number.");
            continue;
        }
        int selectedItemIndex = Convert.ToInt32(itemOption);
        MenuItem item = chickenRiceStall.Menu[selectedItemIndex - 1];
        // Display the selected item details
        Console.WriteLine("Editing item:");
        Console.WriteLine("Name: " + item.ItemName);
        Console.WriteLine("Description: " + item.ItemDescription);
        Console.WriteLine("Quantity: " + item.ItemQuantity);
        Console.WriteLine("Price: $" + item.ItemPrice.ToString("F2"));
        Console.WriteLine(); // Blank line between items

        // Ask user if they want to update or delete the item
        Console.WriteLine("Would you like to update or delete this item?");
        Console.WriteLine("1. Update Item");
        Console.WriteLine("2. Delete Item");
        Console.WriteLine("0. Exit");
        string? editOption = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrEmpty(editOption) || (editOption != "1" && editOption != "2" && editOption != "0"))
        {
            Console.WriteLine("Invalid option! Please choose option between 1-2.");
            continue;
        }
        try
        {
            if (editOption == "0")
            {
                Console.WriteLine("Exiting edit menu.");
                continueUpdate = false;
            }
            else if (editOption == "1")
            {
                UpdateMenuItem(item);
            }
            else if (editOption == "2")
            {
                //DeleteMenuItem(item);
            }

            Console.Write("Do you want to continue editing menu items? (yes/no): ");
            string? continueChoice = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrEmpty(continueChoice) || (continueChoice != "yes" && continueChoice != "no"))
            {
                Console.WriteLine("Invalid input! Please enter 'yes' or 'no'.");
                continue;
            }
            if (continueChoice.ToLower() == "no")
            {
                Console.WriteLine("Finished editing. Returning to menu...");
                continueUpdate = false;
            }
            else
            {
                Console.WriteLine("Continuing to edit menu items...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

void UpdateMenuItem(MenuItem item)
{
    bool updating = true;
    while (updating)
    {
        // Display the item details and options to update
        Console.WriteLine($"Updating Item: {item.ItemName}");
        Console.WriteLine("Choose field to update: ");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Description");
        Console.WriteLine("3. Price");
        Console.WriteLine("4. Quantity");
        Console.WriteLine("0. Exit");

        string? fieldChoice = Console.ReadLine();
        Console.WriteLine();

        if (string.IsNullOrEmpty(fieldChoice) || (fieldChoice != "1" && fieldChoice != "2" && fieldChoice != "3" && fieldChoice != "4" && fieldChoice != "0"))
        {
            Console.WriteLine("Invalid option! Please choose a valid field number.");
            continue;
        }
        if (fieldChoice == "0")
        {
            Console.WriteLine("Exiting update menu.");
            updating = false;
            continue;
        }
        if (fieldChoice == "1")
        {
            Console.Write("Enter new name for the item: ");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                item.ItemName = newName;
                Console.WriteLine($"Item name updated to: {item.ItemName}");
            }
            else
            {
                Console.WriteLine("Invalid name. Please try again.");
                break;
            }
        }
        else if (fieldChoice == "2")
        {
            Console.Write("Enter new description for the item: ");
            string? newDescription = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescription))
            {
                item.ItemDescription = newDescription;
                Console.WriteLine($"Item description updated to: {item.ItemDescription}");
            }
            else
            {
                Console.WriteLine("Invalid description. Please try again.");
                break;
            }
        }
        else if (fieldChoice == "3")
        {
            Console.Write("Enter new price for the item: $");
            double priceInput = Convert.ToDouble(Console.ReadLine());
            if (priceInput >= 0)
            {
                item.ItemPrice = priceInput;
                Console.WriteLine($"Item price updated to: ${item.ItemPrice:F2}");
            }
            else
            {
                Console.WriteLine("Invalid price. Please try again.");
                break;
            }
        }
        else if (fieldChoice == "4")
        {
            Console.Write("Enter new quantity for the item: ");
            int quantityInput = Convert.ToInt32(Console.ReadLine());
            if (quantityInput >= 0)
            {
                item.ItemQuantity = quantityInput;
                Console.WriteLine($"Item quantity updated to: {item.ItemQuantity}");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please try again.");
                break;
            }
        }
        Console.WriteLine();
    }
    // Display the updated item details
    Console.WriteLine("\nFinal Updated Menu Item:");
    Console.WriteLine($"Name: {item.ItemName}");
    Console.WriteLine($"Description: {item.ItemDescription}");
    Console.WriteLine($"Quantity: {item.ItemQuantity}");
    Console.WriteLine($"Price: ${item.ItemPrice:F2}");
    Console.WriteLine($"Availability: {item.GetAvailabilityStatus()}");
    Console.WriteLine();
}