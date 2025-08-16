// See https://aka.ms/new-console-template for more information
using SWAD_ASSG;
using System.Reflection.Metadata.Ecma335;

// Create Chicken Rice Stall
FoodStall chickenRiceStall = new FoodStall("Chicken Rice Stall", "Serving authentic chicken rice and related dishes.", "9876-5432", "Food Court, Stall #5", "chicken_rice.jpg", StallStatus.Active);
// Add Menu Items
chickenRiceStall.AddMenuItem("Hainanese Chicken Rice", "Steamed chicken with fragrant rice, chili & ginger paste.", 5.50f, 5);
chickenRiceStall.AddMenuItem("Roasted Chicken Rice", "Crispy roasted chicken with aromatic rice and special sauce.", 6.00f, 3);
chickenRiceStall.AddMenuItem("Shredded Chicken Noodle", "Noodles topped with tender shredded chicken.", 3.50f, 2);
chickenRiceStall.AddMenuItem("Chicken Drumstick Rice", "Tender chicken drumstick served with fragrant rice.", 6.50f, 4);
chickenRiceStall.AddMenuItem("Chicken Set", "Chicken rice set with soup and side dishes.", 4.00f, 0);
chickenRiceStall.AddMenuItem("Braised Egg", "Soy sauce braised egg, a perfect side.", 1.00f, 10);

// Add Feedbacks
chickenRiceStall.Feedbacks.Add(new Feedback(1, "Small Portion", "The chicken rice portion is too small.", "101", "Alice Tan", DateTime.Now.AddDays(-2)));
chickenRiceStall.Feedbacks.Add(new Feedback(1, "More Veggie Options", "Please add more vegetarian dishes to the menu.", "102", "Ben Wong", DateTime.Now.AddDays(-1)));
chickenRiceStall.Feedbacks.Add(new Feedback(1, "Hygiene Concerns", "Please improve cleanliness at the stall.", "103", "Daniel Lim", DateTime.Now.AddDays(-5)));
chickenRiceStall.Feedbacks.Add(new Feedback(1, "Staff", "I HATE YOUR STAFF", "104", "John Doe", DateTime.Now.AddDays(-4)));

FoodStall pizzaStall = new FoodStall("Mario's Pizza Corner", "Authentic Italian pizzas and pasta dishes.", "9876-5433", "Food Court, Stall #3", "pizza.jpg", StallStatus.Active);
pizzaStall.AddMenuItem("Margherita Pizza", "Classic pizza with tomato, mozzarella, and basil.", 12.90f, 8);
pizzaStall.AddMenuItem("Pepperoni Pizza", "Pizza topped with spicy pepperoni slices.", 15.90f, 5);
pizzaStall.AddMenuItem("Spaghetti Carbonara", "Creamy pasta with bacon and parmesan.", 11.50f, 6);

FoodStall burgerStall = new FoodStall("Burger Haven", "Juicy burgers and crispy fries for burger lovers.", "9876-5434", "Food Court, Stall #7", "burger.jpg", StallStatus.Active);
burgerStall.AddMenuItem("Classic Beef Burger", "Beef patty with lettuce, tomato, and special sauce.", 8.90f, 10);
burgerStall.AddMenuItem("Chicken Burger", "Grilled chicken breast with fresh vegetables.", 7.90f, 12);
burgerStall.AddMenuItem("Cheese Fries", "Crispy fries topped with melted cheese.", 4.50f, 15);  

List<FoodStall> allStalls = new List<FoodStall> { chickenRiceStall, pizzaStall, burgerStall };



// Time Slot
var timeSlot = new TimeSlot(
    timeSlotID: 7,
    stallID: chickenRiceStall.StallID,
    startTime: DateTime.Today.AddHours(11),
    endTime: DateTime.Today.AddHours(12),
    isAvailable: true,
    isExclusive: false,
    maxOrders: 50
);

// Create Order 
var order1 = new Order(1001, 501, chickenRiceStall, 7.50m, DateTime.Now, timeSlot.TimeSlotID, DateTime.Now.AddMinutes(30));
var order2 = new Order(1002, 502, chickenRiceStall, 12.00m, DateTime.Now, timeSlot.TimeSlotID, DateTime.Now.AddMinutes(15));

// Create Order items
var orderItem1 = new OrderItem(1, order1, chickenRiceStall.Menu[0], 1); // 1 Hainanese Chicken Rice
var orderItem2 = new OrderItem(2, order1, chickenRiceStall.Menu[1], 1); // 2 Roasted Chicken Rice
var orderItem3 = new OrderItem(3, order2, chickenRiceStall.Menu[2], 2); // 3 Shredded Chicken Noodle
var orderItem4 = new OrderItem(4, order2, chickenRiceStall.Menu[3], 1); // 4 Chicken Drumstick Rice

// Add order items to Order
order1.AddOrderItem(orderItem1);
order1.AddOrderItem(orderItem2);
order2.AddOrderItem(orderItem3);
order2.AddOrderItem(orderItem4);



// QR Code
var qrCode = new QRCode(
    qrCodeID: 1,
    orderID: order1.OrderID,
    generatedTime: DateTime.Now,
    expiryTime: DateTime.Now.AddHours(2),
    collectionStatus: CollectionStatus.NotCollected
)
{
    Order = order1
};

var qrCode2 = new QRCode(
       qrCodeID: 2,
          orderID: order2.OrderID,
             generatedTime: DateTime.Now,
                expiryTime: DateTime.Now.AddHours(2),
                   collectionStatus: CollectionStatus.NotCollected
                   )
{
    Order = order2
};

// Link QRCode and TimeSLot to Order
order1.QRCode = qrCode;
order1.TimeSlot = timeSlot;
order2.QRCode = qrCode2;
order2.TimeSlot = timeSlot;

// Add Order to Food Stall
chickenRiceStall.AddOrder(order1);
chickenRiceStall.AddOrder(order2);


// Add admin of the system
Administrator admin = new Administrator(
    contactDetails: "9123 4567",
    permissionLevel: "SuperAdmin",
    department: "IT",
    userID: "101",
    name: "Alice Tan",
    email: "test@gmail.com",
    password: "123"
);

// Add FoodStallStaff
var staff = new FoodStallStaff(
    userID: "1",
    name: "John",
    email: "john@example.com",
    password: "pass123",
    staffContact: "12345678",
    dateOfEmployment: DateTime.Now.AddYears(-1),
    emergencyContactNumber: "87654321",
    stallAffiliation: chickenRiceStall
);

chickenRiceStall.AddStaffMember(staff);

// Display the welcome message and options
Console.WriteLine("Welcome to Order-al-Ready Food Ordering! ");
Console.WriteLine("==============================================");
Console.WriteLine("         Order-al-Ready Food Ordering         ");
Console.WriteLine("==============================================");
Console.WriteLine();
string userType = "";
string userID = "";
while (true)
{
    Console.WriteLine("== Login Or Register ==");
    Console.WriteLine("  1. Login as Student");
    Console.WriteLine("  2. Login as Staff");
    Console.WriteLine("  3. Login as Admin");
    Console.WriteLine("  4. Register as a User");
    Console.WriteLine();
    Console.Write("Select an option (1-4): ");
    string? userInput = Console.ReadLine();
    Console.WriteLine();
    if (userInput == "1")
    {
        Console.WriteLine("Enter your Student ID");
        Console.Write("Student ID: ");
        userID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        userType = "Student";
        break;
    }
    else if (userInput == "2")
    {
        Console.WriteLine("Enter your Staff ID");
        Console.Write("Staff ID: ");
        userID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        userType = "Staff";
        if(userID != "1")
        {
            staff = new FoodStallStaff(
                userID: "2",
                name: "John",
                email: "john@example.com",
                password: "pass123",
                staffContact: "12345678",
                dateOfEmployment: DateTime.Now.AddYears(-1),
                emergencyContactNumber: "87654321",
                stallAffiliation: pizzaStall
            );
            pizzaStall.AddStaffMember(staff);
        }
        break;
    }
    else if (userInput == "3")
    {
        Console.WriteLine("Enter your Admin ID");
        Console.Write("Admin ID: ");
        userID = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        userType = "Admin";
        break;
    }
    else if (userInput == "4")
    {

        Console.WriteLine("Enter your Name");
        Console.Write("Name: ");
        string? name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Email");
        Console.Write("Email: ");
        string? email = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Password");
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine("Reconfirm your password");
            Console.Write("Reconfirm Password: ");
            string? confirmPassword = Console.ReadLine();
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
while (true)
{
    Console.WriteLine();
    if (userType == "Student")
    {
        // change the options accordingly these are fake example ones
        Console.WriteLine("Welcome Student!");
        Console.WriteLine();
        Console.WriteLine("  1. Browse food stalls & menus");
        Console.WriteLine("  2. Place an order");
        Console.WriteLine("  3. Real-time menu updates");
        Console.WriteLine("  4. Priority user perks (extra limits, VIP pick-up)");
        Console.WriteLine();
        Console.Write("Select an option: ");
        string? option = Console.ReadLine();
        if (option == "1")
        {
            BrowseFoodStalls();
        }
        else if (option == "2")
        {
            PlaceFoodOrder(allStalls);
        }
        else
        {
            Console.WriteLine("Please enter a valid input or that feature you have selected has not been implemented. Please try again");
        }
    }
    else if (userType == "Staff")
    {
        // change the options accordingly these are fake example ones
        Console.WriteLine("Welcome Staff!");
        Console.WriteLine();
        Console.WriteLine("  1. Manage stall profile");
        Console.WriteLine("  2. View & track incoming orders");
        Console.WriteLine("  3. Manage Menu Items");
        Console.WriteLine("  4. Response to feedback");
        Console.WriteLine("  5. Cancel orders & manage no-shows");
        Console.WriteLine("  6. Track sales performance");
        Console.WriteLine();
        Console.Write("Select an option: ");
        string? option = Console.ReadLine();
        if (option == "2")
        {
            ViewIncomingOrders();
        }
        else if (option == "3")
        {
            ManageMenuItems();
        }
        else if (option == "4")
        {
            RespondToFeedback();
        }
        else
        {
            Console.WriteLine("Please enter a valid input or that feature you have selected has not been implemented. Please try again");
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
}


// Manage Menu Items
void DisplayMenuItems(FoodStall stall)
{
    Console.WriteLine();
    Console.WriteLine($"===== {stall.StallName} Menu =====");
    Console.WriteLine("{0,-8} {1,-25} {2,8}", "Item ID", "Item Name", "Price ($)");
    List<MenuItem> menuList = stall.GetMenuItems();
    foreach (var item in menuList)
    {
        Console.WriteLine("{0,-8} {1,-25} {2,8:F2}", item.ItemID, item.ItemName, item.ItemPrice);
    }
    Console.WriteLine();
}

void DisplayMenuItemDetails(MenuItem item)
{
    string? availabilityStatus = item.GetAvailabilityStatus();
    Console.WriteLine($"Item ID: {item.ItemID}");
    Console.WriteLine($"Name: {item.ItemName}");
    Console.WriteLine($"Description: {item.ItemDescription}");
    Console.WriteLine($"Price: ${item.ItemPrice:F2}");
    Console.WriteLine($"Quantity: {item.ItemQuantity}");
    Console.WriteLine($"Availability: {availabilityStatus}");
    Console.WriteLine();
}
void ManageMenuItems()
{
    while (true)
    {
        FoodStall stall = staff.StallAffiliation;
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
               EditMenuItems(stall);
            }
            else if (manageOption == "2")
            {
                AddNewMenuItem(stall);
            }
            else
            {
                Console.WriteLine("Invalid option! Please try again.");
            }
            Console.WriteLine("Final Menu Items:");
            DisplayMenuItems(stall);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

void EditMenuItems(FoodStall stall)
{
    bool continueUpdate = true;
    while (continueUpdate)
    {
        DisplayMenuItems(stall);
        Console.WriteLine();
        // Select an item to edit
        Console.Write("Enter the Item ID to select the item: ");
        string? itemOption = Console.ReadLine();
        int itemId = Convert.ToInt32(itemOption);
        if (string.IsNullOrEmpty(itemOption) || itemId <= 0)
        {
            Console.WriteLine("Invalid Item ID! Please enter a valid Item ID from the menu.");
            continue;
        }
        MenuItem? item = stall.GetMenuItemById(itemId);
        if (item == null)
        {
            Console.WriteLine("Item not found with the provided Item ID. Please try again.");
            continue;
        }
        Console.WriteLine();
        
        // Display the selected item details
        Console.WriteLine("Editing item:");
        DisplayMenuItemDetails(item);

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
                UpdateMenuItem(stall, item);
            }
            else if (editOption == "2")
            {
                DeleteMenuItem(stall, item);
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
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

void UpdateMenuItem(FoodStall stall, MenuItem item)
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
            if (!validateFieldValue(stall, "name", newName, item))
            {
                Console.WriteLine("Invalid name. Please try again. The name must be unique and not empty.");
                break;
            }
            stall.UpdateField(item, "name", newName);
            Console.WriteLine($"Item name updated to: {newName}");
        }
        else if (fieldChoice == "2")
        {
            Console.WriteLine("Enter new description for the item: ");
            string? newDescription = Console.ReadLine();
            if (!validateFieldValue(stall, "description", newDescription, item))
            {
                Console.WriteLine("Invalid description. Please try again. The description cannot be empty.");
                break;
            }
            stall.UpdateField(item, "description", newDescription);
            Console.WriteLine($"Item description updated to: {newDescription}");
        }
        else if (fieldChoice == "3")
        {
            Console.Write("Enter new price for the item: $");
            float priceInput = float.Parse(Console.ReadLine());
            if (!validateFieldValue(stall, "price", priceInput, item))
            {
                Console.WriteLine("Invalid price. Please try again. The price cannot be negative.");
                break;
            }
            stall.UpdateField(item, "price", priceInput);
            Console.WriteLine($"Item price updated to: ${priceInput:F2}");
        }
        else if (fieldChoice == "4")
        {
            Console.Write("Enter new quantity for the item: ");
            int quantityInput = Convert.ToInt32(Console.ReadLine());
            if (!validateFieldValue(stall, "quantity", quantityInput, item))
            {
                Console.WriteLine("Invalid quantity. Please try again. The quantity cannot be negative.");
                break;
            }
            stall.UpdateField(item, "quantity", quantityInput);
            Console.WriteLine($"Item quantity updated to: {quantityInput}");
        }
        Console.WriteLine();
    }
    // Display the updated item details
    Console.WriteLine("\nFinal Updated Menu Item:");
    DisplayMenuItemDetails(item);
    LogMenuItemChange("UPDATE", item);
    Console.WriteLine();
}

void DeleteMenuItem(FoodStall stall, MenuItem item)
{
    while (true)
    {
        // Confirm deletion
        Console.WriteLine($"Are you sure you want to delete the item: {item.ItemName}? (yes/no)");
        string? confirmDelete = Console.ReadLine()?.Trim().ToLower();
        if (string.IsNullOrEmpty(confirmDelete) || (confirmDelete != "yes" && confirmDelete != "no"))
        {
            Console.WriteLine("Invalid input! Please enter 'yes' or 'no'.");
        }
        else if (confirmDelete == "yes")
        {
            stall.RemoveMenuItemById(item.ItemID);
            Console.WriteLine($"Item '{item.ItemName}' has been deleted successfully.");
            Console.WriteLine();
            LogMenuItemChange("DELETE", item);
            break;
        }
        else if (confirmDelete == "no")
        {
            Console.WriteLine("Deletion cancelled.");
            break;
        }
    }
}

void AddNewMenuItem(FoodStall stall)
{
    Console.WriteLine("Adding a new menu item:");
    Console.Write("Enter item name: ");
    string? newItemName = Console.ReadLine();
    if (!validateFieldValue(stall, "name", newItemName))
    {
        Console.WriteLine("Invalid item name. Please try again. The name must be unique and not empty.");
        return;
    }

    Console.Write("Enter item description: ");
    string? newItemDescription = Console.ReadLine();
    if (!validateFieldValue(stall, "description", newItemDescription))
    {
        Console.WriteLine("Invalid item description. Please try again. The description cannot be empty.");
        return;
    }

    Console.Write("Enter item price: $");
    float newItemPrice = float.Parse(Console.ReadLine());
    if (!validateFieldValue(stall, "price", newItemPrice))
    {
        Console.WriteLine("Invalid item price. Please try again. The price cannot be negative.");
        return;
    }

    Console.Write("Enter item quantity: ");
    int newItemQuantity = Convert.ToInt32(Console.ReadLine());
    if (!validateFieldValue(stall, "quantity", newItemQuantity))
    {
        Console.WriteLine("Invalid item quantity. Please try again. The quantity cannot be negative.");
        return;
    }

    MenuItem newItem = stall.AddMenuItem(newItemName, newItemDescription, newItemPrice, newItemQuantity);
    Console.WriteLine($"New item '{newItem.ItemName}' added successfully.");
    LogMenuItemChange("ADD", newItem);
    Console.WriteLine();
}

void LogMenuItemChange(string action, MenuItem item)
{
    File.AppendAllText("menuItemLogs.txt",
        $"Action: {action}, \n" +
        $"Item ID: {item.ItemID}, Name: {item.ItemName}, \n" +
        $"Description: {item.ItemDescription}, Price: {item.ItemPrice}, \n" +
        $"Quantity: {item.ItemQuantity}, Availability: {item.GetAvailabilityStatus()}, \n" +
        $"Time of change: {DateTime.Now} \n");
}

bool validateFieldValue(FoodStall stall, string field, object value, MenuItem currentItem = null)
{
    if (field.ToLower() == "name")
    {
        string name = Convert.ToString(value).Trim().ToLower();
        if (string.IsNullOrEmpty(name))
        {
            return false; // Name cannot be empty
        }
        foreach (var item in stall.Menu)
        {
            if (item.ItemName.Trim().ToLower() == name)
            {
                if (currentItem == null || item.ItemID != currentItem.ItemID)
                {
                    return false; // Name already exists and is not the current item
                }
                else
                {
                    return true; // Name exists but is the current item, so it's valid
                }
            }
        }
    }
    if (field.ToLower() == "description")
    {
        string description = Convert.ToString(value).Trim();
        if (string.IsNullOrEmpty(description))
        {
            return false; // Description cannot be empty
        }
    }
    if (field.ToLower() == "price")
    {
        if (float.TryParse(value.ToString(), out float price))
        {
            if (price < 0)
            {
                return false; // Price cannot be negative
            }
        }
        else
        {
            return false; // Invalid price format
        }
    }
    if (field.ToLower() == "quantity")
    {
        if (int.TryParse(value.ToString(), out int quantity))
        {
            if (quantity < 0)
            {
                return false; // Quantity cannot be negative
            }
        }
        else
        {
            return false; // Invalid quantity format
        }
    }
    return true;
}


void RespondToFeedback()
{
    FoodStall foodstall = staff.StallAffiliation;
    while (true)
    {
        var (unreplied, replied, reported) = foodstall.getListOfFeedback();
        // Unreplied Feedback Section
        Console.WriteLine("=== Unreplied Feedback ===");
        if (unreplied.Count == 0)
        {
            Console.WriteLine("No feedback available to respond to.");
            Console.WriteLine();
        }
        else
        {
            foreach (var f in unreplied)
            {
                Console.WriteLine($"ID: {f.feedbackID}");
                Console.WriteLine($"Customer: {f.customerName}");
                Console.WriteLine($"Comment: {f.comment}");
                Console.WriteLine($"Date: {f.timestamp}");
                Console.WriteLine();
            }
        }

        // Replied Feedback Section 
        Console.WriteLine("=== Replied Feedback ===");
        if (replied.Count == 0)
        {
            Console.WriteLine("No replied feedback yet.");
            Console.WriteLine();
        }
        else
        {
            foreach (var f in replied)
            {
                Console.WriteLine($"ID: {f.feedbackID}");
                Console.WriteLine($"Customer: {f.customerName}");
                Console.WriteLine($"Comment: {f.comment}");
                Console.WriteLine($"Reply: {f.response}");
                Console.WriteLine($"Date: {f.timestamp}");
                Console.WriteLine();
            }
        }
        
        // Reported Feedback Section
        Console.WriteLine("=== Reported Feedback ===");
        if (reported.Count == 0)
        {
            Console.WriteLine("No reported feedback yet.");
            Console.WriteLine();
        }
        else
        {
            foreach (var f in reported)
            {
                Console.WriteLine($"ID: {f.feedbackID}");
                Console.WriteLine($"Customer: {f.customerName}");
                Console.WriteLine($"Comment: {f.comment}");
                Console.WriteLine($"Date: {f.timestamp}");
                Console.WriteLine();
            }
        }
        // If no feedback at all, exit
        if (replied.Count == 0 && unreplied.Count == 0)
        {
            Console.WriteLine("The food stall currently does not have any feedback. Check again later");
            break;
        }

        // Only allow reply if unreplied feedback exists
        if (unreplied.Count > 0)
        {
            Console.Write("Please enter the feedback ID you want to reply to: ");
            string feedbackID = Console.ReadLine();

            Feedback feedbackToReply = foodstall.getFeedbackByID(feedbackID);
            if (feedbackToReply == null || feedbackToReply.replied)
            {
                Console.WriteLine("Invalid or already replied feedback ID.");
                continue;
            }

            Console.WriteLine($"Responding to feedback {feedbackToReply.feedbackID}");
            Console.WriteLine($"Customer: {feedbackToReply.customerName}");
            Console.WriteLine($"Comment: {feedbackToReply.comment}");
            Console.WriteLine();
            Console.WriteLine("Choose your options: ");
            Console.WriteLine("1. Response to Feedback");
            Console.WriteLine("2. Report as inappropriate feedback");
            Console.Write("Select an option (1-2): ");  
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Enter your response: ");
                string response = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Response cannot be empty, please fill it up before sending");
                    Console.WriteLine();
                    continue;
                }
                feedbackToReply.updateResponse(response);
                // Log the response to a file (Mimicking store to database
                File.AppendAllText("feedbackLogs.txt",
                    $"Responded to Feedback ID: {feedbackToReply.feedbackID}, " +
                    $"Response: {response}, Time of reply: {DateTime.Now}, Staff: {userID} \n");
                Console.WriteLine();
                Console.WriteLine("Reply sent to user successfully!");
                Console.WriteLine();
                Console.WriteLine("Here is the feedback you replied to: ");
                Console.WriteLine($"ID: {feedbackToReply.feedbackID}");
                Console.WriteLine($"Customer: {feedbackToReply.customerName}");
                Console.WriteLine($"Comment: {feedbackToReply.comment}");
                Console.WriteLine($"Reply: {feedbackToReply.response}");
                Console.WriteLine($"Date: {feedbackToReply.timestamp}");
                Console.WriteLine();
            }
            else if (option == "2")
            {
                ReportInappopriateFeedback(feedbackToReply);
            }
            else
            {
                Console.WriteLine("Invalid option selected. Try again");
                continue;
            }
        }
        Console.Write("Would you like to respond to other feedbacks? Y/N: ");
        string continueResponse = Console.ReadLine();
        if (continueResponse.ToUpper() == "N")
        {
            break;
        }
        Console.WriteLine();
    }
}

void ReportInappopriateFeedback(Feedback feedback)
{
    while (true)
    {
        Console.WriteLine("Please enter the subject of your report");
        string? subject = Console.ReadLine();

        Console.WriteLine("Please enter the reason for your report");
        string? reason = Console.ReadLine();

        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(reason))
        {
            Console.WriteLine("Subject and reason cannot be empty. Please try again.");
            Console.WriteLine();
            continue;
        }
        // Log the report to a file (Mimicking store to database)
        File.AppendAllText("reportFeedbackLogs.txt",
            $"Report Subject: {subject}, Reason: {reason}, Time of report: {DateTime.Now}, Staff: {userID} \n");

        admin.ReportFeedback(subject, reason, feedback, userID);
        feedback.reported = true;
        Console.WriteLine();
        Console.WriteLine("Your report has been submitted successfully. Thank you for your feedback.");
        break;
    }
}

void ViewIncomingOrders()
{
    FoodStall fs = staff.StallAffiliation;
    List<Order> incomingOrders = fs.GetIncomingOrders();
    DateTime oneDayAgo = DateTime.Now.AddDays(-1);
    if (incomingOrders.Count == 0)
    {
        DisplayNoOrderMessage();
        return;
    } else
    {
        incomingOrders = incomingOrders.Where(o => o.PickupTime >= oneDayAgo).ToList();
       
        // Sort by PickupTime ascending
        incomingOrders = incomingOrders.OrderBy(o => o.PickupTime).ToList();
    }

    while (true)
    {
        Console.WriteLine($"Incoming Orders for {fs.StallName}:");
        ShowOrderSummaryList(incomingOrders);

        Console.WriteLine("Would you like to view more details of an order? (y/n)");
        string? viewDetailResponse = Console.ReadLine()?.Trim().ToLower();

        if (viewDetailResponse == "y")
        {
            Console.WriteLine("Please enter the Order ID you want to view details for:");
            string? orderIdInput = Console.ReadLine();

            if (int.TryParse(orderIdInput, out int orderId))
            {
                Order? selectedOrder = incomingOrders.FirstOrDefault(o => o.OrderID == orderId);
                if (selectedOrder != null)
                {
                    Console.WriteLine(selectedOrder.RetrieveOrderDetails());

                    Console.WriteLine();
                    Console.WriteLine("Would you like to update the order status? (y/n)");
                    string? updateStatusResponse = Console.ReadLine()?.Trim().ToLower();
                    if (updateStatusResponse == "y")
                    {
                        InitiateUpdateOrderStatus(selectedOrder);
                    }
                }
                else
                {
                    Console.WriteLine("No order found with the provided Order ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Order ID format.");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Would you like to continue viewing incoming orders? (y/n)");
        string? continueResponse = Console.ReadLine()?.Trim().ToLower();
        if (continueResponse != "y")
        {
            break;
        }
    }
}

void ShowOrderSummaryList(List<Order> incomingOrders)
{


    foreach (var order in incomingOrders)
    {

        //foreach (var item in order.Items)
        //{
        //    Console.WriteLine($"- {item.ItemName} (Quantity: {item.Quantity})");
        //}
        Console.WriteLine($"Order Number: {order.OrderID}");
        Console.WriteLine($"Scheduled Pickup Time: {order.PickupTime}");
        Console.WriteLine($"Order Status: {order.OrderStatus}");
        Console.WriteLine();
    }

    Console.WriteLine("==============================================");
}
void DisplayNoOrderMessage()
{
    Console.WriteLine("No incoming orders at the moment.");
}

void InitiateUpdateOrderStatus(Order od)
{
    OrderStatus currentStatus = od.OrderStatus;
    List<OrderStatus> availableStatuses = new List<OrderStatus>();

    if (currentStatus == OrderStatus.Pending)
    {
        availableStatuses.Add(OrderStatus.Preparing);
    }
    else if (currentStatus == OrderStatus.Preparing)
    {
        availableStatuses.Add(OrderStatus.ReadyForPickup);
        availableStatuses.Add(OrderStatus.Completed);  // assuming skipping allowed here
    }
    else if (currentStatus == OrderStatus.ReadyForPickup)
    {
        availableStatuses.Add(OrderStatus.Completed);
    }
    else if (currentStatus == OrderStatus.Completed || currentStatus == OrderStatus.Cancelled)
    {
        Console.WriteLine("Order is already completed or cancelled, no further updates allowed.");
        return;
    }

    while (true)
    {
        Console.WriteLine($"Current Order Status: {currentStatus}");
        Console.WriteLine("Available next status options:");
        for (int i = 0; i < availableStatuses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableStatuses[i]}");
        }
        Console.WriteLine("0. Cancel Update Order Status Process");

        Console.Write("Select the new status by entering the corresponding number: ");
        string? input = Console.ReadLine()?.Trim();

        if (input == "0")
        {
            Console.Write("Are you sure you want to cancel the status update? (y/n): ");
            string? cancelConfirm = Console.ReadLine()?.Trim().ToLower();
            if (cancelConfirm == "y")
            {
                Console.WriteLine("Order status update cancelled.");
                break;
            }
            else
            {
                continue; // back to options prompt
            }
        }

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= availableStatuses.Count)
        {
            OrderStatus selectedStatus = availableStatuses[choice - 1];
            Console.Write($"Confirm update order status to {selectedStatus}? (y/n): ");
            string? confirm = Console.ReadLine()?.Trim().ToLower();

            if (confirm == "y")
            {
                od.UpdateOrderStatus(selectedStatus);
                Console.WriteLine($"Order status updated to: {selectedStatus}");

                File.AppendAllText("orderStatusLogs.txt",
                    $"Order ID: {od.OrderID}, New Status: {selectedStatus}, Time of update: {DateTime.Now}, Staff: {staff.name} \n");

                Console.WriteLine("Order status update completed.");
                Console.WriteLine("==============================================");
                break;
            }
            else
            {
                Console.WriteLine("Status update not confirmed. Please select again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }
}

void BrowseFoodStalls()
{


    while (true)
    {
        Console.WriteLine("=== Browse Food Stalls ===");
        Console.WriteLine();

        // Display all available stalls
        Console.WriteLine("Available Food Stalls:");
        for (int i = 0; i < allStalls.Count; i++)
        {
            var stall = allStalls[i];
            Console.WriteLine($"{i + 1}. {stall.StallName}");
            Console.WriteLine($"   Location: {stall.StallLocation}");
            Console.WriteLine($"   Description: {stall.StalllDescription}");
            Console.WriteLine($"   Status: {stall.Status}");
            Console.WriteLine();
        }

        Console.WriteLine("Options:");
        Console.WriteLine("1. View detailed menu for a stall");
        Console.WriteLine("0. Return to main menu");
        Console.Write("Select an option: ");

        string? choice = Console.ReadLine();

        if (choice == "0")
        {
            break;
        }
        else if (choice == "1")
        {
            ViewStallMenu(allStalls);
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
        Console.WriteLine();
    }
}

void ViewStallMenu(List<FoodStall> stalls)
{
    Console.Write("Enter the stall number to view menu: ");
    string? choice = Console.ReadLine();
    try
    {
        int index = Convert.ToInt32(choice);

        if (index > 0 && index <= stalls.Count)
        {
            FoodStall selectedStall = stalls[index - 1];
            Console.WriteLine();
            DisplayMenuItems(selectedStall);

            Console.WriteLine("Options:");
            Console.WriteLine("1. View item details");
            Console.WriteLine("0. Return to stall browse");
            Console.Write("Select an option: ");

            string? menuChoice = Console.ReadLine();
            if (menuChoice == "1")
            {
                ViewItemDetails(selectedStall);
            }
        }
        else
        {
            Console.WriteLine("Invalid stall number.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid stall number.");
    }
}

void ViewItemDetails(FoodStall stall)
{
    Console.Write("Enter the Item ID to view details: ");
    string? choice = Console.ReadLine();

    try
    {
        int itemId = Convert.ToInt32(choice);

        MenuItem? item = stall.GetMenuItemById(itemId);
        if (item != null)
        {
            Console.WriteLine();
            DisplayMenuItemDetails(item);
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid Item ID.");
    }
}




void PlaceFoodOrder(List<FoodStall> allStalls)
{
    Console.WriteLine("=== Place Food Order ===");

    // 1. Show stalls
    for (int i = 0; i < allStalls.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {allStalls[i].StallName} - {allStalls[i].StallLocation} ({allStalls[i].Status})");
    }

    Console.Write("Select stall number (or 0 to cancel): ");
    int stallChoice;
    try
    {
        stallChoice = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Invalid input. Returning to menu.");
        return;
    }

    if (stallChoice == 0) return;
    if (stallChoice < 1 || stallChoice > allStalls.Count)
    {
        Console.WriteLine("Invalid stall number.");
        return;
    }

    FoodStall selectedStall = allStalls[stallChoice - 1];

    // 1.3 enterOrderDetails(menuSelection, quantity)
    Console.WriteLine($"\nMenu for {selectedStall.StallName}:");
    DisplayMenuItems(selectedStall);

    Console.Write("Enter the Item ID you want to order (or 0 to cancel): ");
    int itemId;
    try
    {
        itemId = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Invalid Item ID.");
        return;
    }

    if (itemId == 0) return;

    MenuItem menuItem = selectedStall.GetMenuItemById(itemId);
    if (menuItem == null)
    {
        Console.WriteLine("Item not found.");
        return;
    }

    Console.Write($"Enter quantity for '{menuItem.ItemName}': ");
    int qty;
    try
    {
        qty = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    // 1.2 checkItemQuantity
    if (!menuItem.CheckItemQuantity(qty))
    {
        // 3.2 displayStockError
        Console.WriteLine($"Sorry, only {menuItem.ItemQuantity} unit(s) available. Order not placed.");
        return;
    }

    // 1.3 calculateItemPrices
    float totalPrice = menuItem.ItemPrice * qty;

    // 1.4 displayConfirmScreen
    Console.WriteLine("\n--- Confirm Order ---");
    Console.WriteLine($"Item: {menuItem.ItemName}");
    Console.WriteLine($"Quantity: {qty}");
    Console.WriteLine($"Total Price: ${totalPrice:F2}");
    Console.Write("Confirm order? (y/n): ");
    string confirm = Console.ReadLine().Trim().ToLower();
    if (confirm != "y") return;

    List<TimeSlot> allSlots = new List<TimeSlot>
    {
        new TimeSlot(1, selectedStall.StallID, DateTime.Today.AddHours(10), DateTime.Today.AddHours(11), true, false, 5),
        new TimeSlot(2, selectedStall.StallID, DateTime.Today.AddHours(11), DateTime.Today.AddHours(12), true, false, 5),
        new TimeSlot(3, selectedStall.StallID, DateTime.Today.AddHours(12), DateTime.Today.AddHours(13), true, false, 5),
        new TimeSlot(4, selectedStall.StallID, DateTime.Today.AddHours(13), DateTime.Today.AddHours(14), true, false, 5)
    };


    // 3.1 choosePickupTimeslot
    List<TimeSlot> availableSlots = selectedStall.GetAvailableTimeSlots(allSlots, "student");

    if (availableSlots.Count == 0)
    {
        Console.WriteLine("No pickup slots available. Order cannot be placed.");
        return;
    }

    Console.Write("Select a pickup slot: \n");
    for (int i = 0; i < availableSlots.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availableSlots[i].StartTime:HH:mm} - {availableSlots[i].EndTime:HH:mm}");
    }

    int timeChoice;
    try
    {
        timeChoice = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    if (timeChoice < 1 || timeChoice > availableSlots.Count)
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    TimeSlot chosenSlot = availableSlots[timeChoice - 1];
    DateTime pickupTime = chosenSlot.StartTime;

    Order newOrder = new Order(
        orderID: new Random().Next(1000, 9999),
        studentID: 1, 
        stall: selectedStall,
        totalAmount: Convert.ToDecimal(totalPrice),
        orderTime: DateTime.Now,
        timeSlotID: 1,
        pickupTime: pickupTime
    );

    OrderItem orderItem = new OrderItem
    {
        OrderItemID = 1,
        MenuItemID = itemId,
        Quantity = qty
    };
    newOrder.AddOrderItem(orderItem);

    // 3.2 displayOrderScreen
    newOrder.DisplayOrderSummary();
    Payment(true); // Simulate successful payment
    Console.WriteLine("\nGenerating QR Code for order collection...");
    GenerateQRCode(newOrder.OrderID);
}



void Payment(bool paymentSuccess)
{
    Console.WriteLine("=== Payment Process ===");
    Console.WriteLine();

    int orderID = 1234;
    decimal amount = 15.50m;
    string orderDetails = "Chicken Rice";
    string paymentMethod = "Credit/Debit Card";

    Console.WriteLine($"Processing payment for Order #{orderID}");
    Console.WriteLine($"Item: {orderDetails}");
    Console.WriteLine($"Amount: ${amount:F2}");
    Console.WriteLine($"Payment Method: {paymentMethod}");

    Console.WriteLine("\nProcessing payment...");
    System.Threading.Thread.Sleep(1000);

    if (paymentSuccess)
    {
        Console.WriteLine("Payment processed successfully!");

        Console.WriteLine($"Order #{orderID} status updated to 'Paid'");

        Console.WriteLine("\n--- RECEIPT ---");
        Console.WriteLine($"Order ID: #{orderID}");
        Console.WriteLine($"Student ID: 12345");
        Console.WriteLine($"Item: {orderDetails}");
        Console.WriteLine($"Amount: ${amount:F2}");
        Console.WriteLine($"Payment Method: {paymentMethod}");
        Console.WriteLine($"Transaction Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Transaction ID: TXN123456");
        Console.WriteLine("Status: PAID");
        Console.WriteLine("--- END RECEIPT ---");

        Console.WriteLine("\nPayment confirmation sent to student email");

        Console.WriteLine("\nPayment completed successfully!");
        Console.WriteLine("You will receive an email confirmation shortly.");
        Console.WriteLine($"Your order #{orderID} is now confirmed and being prepared.");
    }
    else
    {
        string[] failureReasons = {
            "Insufficient funds",
            "Card declined by bank",
            "Network connection error",
            "Payment gateway timeout",
            "Invalid card details"
        };

        string failureReason = failureReasons[0];

        Console.WriteLine("Payment failed!");
        Console.WriteLine($"Reason: {failureReason}");

        Console.WriteLine($"Error logged for Order #{orderID}");

        Console.WriteLine("\nPayment Error");
        Console.WriteLine($"Failed to process payment for Order #{orderID}");
        Console.WriteLine($"Error: {failureReason}");
        Console.WriteLine("Please try again with a different payment method or contact support.");
    }
}

void GenerateQRCode(int orderID)
{
    Console.WriteLine("=== QR Code ===");
    QRCode qrCode = new QRCode();
    qrCode.QRCodeID = 1001;
    qrCode.OrderID = orderID;
    qrCode.GeneratedTime = DateTime.Now;
    qrCode.PickupTime = DateTime.Now.AddHours(2);
    qrCode.CollectionStatus = CollectionStatus.NotCollected;

    bool emailSuccess = true;

    if (emailSuccess)
    {
        qrCode.sendQRCodeEmail();
        Console.WriteLine($"QR Code {qrCode.QRCodeID} generated for Order #{orderID}");
        Console.WriteLine($"Valid until: {qrCode.ExpiryTime:HH:mm}");
    }
    else
    {
        Console.WriteLine("Email delivery failed. Please try again.");
    }
}