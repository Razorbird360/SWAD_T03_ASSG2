// See https://aka.ms/new-console-template for more information
using SWAD_ASSG;
using System.Reflection.Metadata.Ecma335;

// Create Chicken Rice Stall
FoodStall chickenRiceStall = new FoodStall("Chicken Rice Stall", "Serving authentic chicken rice and related dishes.", "9876-5432", "Food Court, Stall #5", "chicken_rice.jpg", StallStatus.Active);
Console.WriteLine(chickenRiceStall.StallID);
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
chickenRiceStall.Feedbacks.Add(new Feedback(1, "Great Taste", "The food tastes amazing but takes a bit too long.", "104", "Clara Lee", DateTime.Now.AddDays(-3)));
chickenRiceStall.Feedbacks.Add(new Feedback(1, "Staff", "I HATE YOUR STAFF", "105", "John Doe", DateTime.Now.AddDays(-4)));

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

Console.WriteLine(order1.ToString());

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
    userID: "99",
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
    Console.WriteLine("  4. Response to feedback");
    Console.WriteLine("  5. Cancel orders & manage no-shows");
    Console.WriteLine("  6. Track sales performance");
    string? option = Console.ReadLine();
    if (option == "1")
    {

    }
    else if (option == "2")
    {
        ViewIncomingOrders();
    }
    else if (option == "3")
    {
        ManageMenuItems();
    }else if(option == "4")
    {
        RespondToFeedback();
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
                AddNewMenuItem();
            }
            else
            {
                Console.WriteLine("Invalid option! Please try again.");
            }
            Console.WriteLine("Final Menu Items:");
            DisplayMenuItems(chickenRiceStall);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

void EditMenuItems()
{
    bool continueUpdate = true;
    while (continueUpdate)
    {
        DisplayMenuItems(chickenRiceStall);
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
        MenuItem? item = chickenRiceStall.GetMenuItemById(itemId);
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
                UpdateMenuItem(item);
            }
            else if (editOption == "2")
            {
                DeleteMenuItem(item);
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
            if (!chickenRiceStall.validateFieldValue("name", newName, item))
            {
                Console.WriteLine("Invalid name. Please try again. The name must be unique and not empty.");
                break;
            }
            chickenRiceStall.UpdateField(item, "name", newName);
            Console.WriteLine($"Item name updated to: {newName}");
        }
        else if (fieldChoice == "2")
        {
            Console.WriteLine("Enter new description for the item: ");
            string? newDescription = Console.ReadLine();
            if (!chickenRiceStall.validateFieldValue("description", newDescription, item))
            {
                Console.WriteLine("Invalid description. Please try again. The description cannot be empty.");
                break;
            }
            chickenRiceStall.UpdateField(item, "description", newDescription);
            Console.WriteLine($"Item description updated to: {newDescription}");
        }
        else if (fieldChoice == "3")
        {
            Console.Write("Enter new price for the item: $");
            float priceInput = float.Parse(Console.ReadLine());
            if (!chickenRiceStall.validateFieldValue("price", priceInput, item))
            {
                Console.WriteLine("Invalid price. Please try again. The price cannot be negative.");
                break;
            }
            chickenRiceStall.UpdateField(item, "price", priceInput);
            Console.WriteLine($"Item price updated to: ${priceInput:F2}");
        }
        else if (fieldChoice == "4")
        {
            Console.Write("Enter new quantity for the item: ");
            int quantityInput = Convert.ToInt32(Console.ReadLine());
            if (!chickenRiceStall.validateFieldValue("quantity", quantityInput, item))
            {
                Console.WriteLine("Invalid quantity. Please try again. The quantity cannot be negative.");
                break;
            }
            chickenRiceStall.UpdateField(item, "quantity", quantityInput);
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

void DeleteMenuItem(MenuItem item)
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
            chickenRiceStall.RemoveMenuItemById(item.ItemID);
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

void AddNewMenuItem()
{
    Console.WriteLine("Adding a new menu item:");
    Console.Write("Enter item name: ");
    string? newItemName = Console.ReadLine();
    if (!chickenRiceStall.validateFieldValue("name", newItemName))
    {
        Console.WriteLine("Invalid item name. Please try again. The name must be unique and not empty.");
        return;
    }

    Console.Write("Enter item description: ");
    string? newItemDescription = Console.ReadLine();
    if (!chickenRiceStall.validateFieldValue("description", newItemDescription))
    {
        Console.WriteLine("Invalid item description. Please try again. The description cannot be empty.");
        return;
    }

    Console.Write("Enter item price: $");
    float newItemPrice = float.Parse(Console.ReadLine());
    if (!chickenRiceStall.validateFieldValue("price", newItemPrice))
    {
        Console.WriteLine("Invalid item price. Please try again. The price cannot be negative.");
        return;
    }

    Console.Write("Enter item quantity: ");
    int newItemQuantity = Convert.ToInt32(Console.ReadLine());
    if (!chickenRiceStall.validateFieldValue("quantity", newItemQuantity))
    {
        Console.WriteLine("Invalid item quantity. Please try again. The quantity cannot be negative.");
        return;
    }

    MenuItem newItem = chickenRiceStall.AddMenuItem(newItemName, newItemDescription, newItemPrice, newItemQuantity);
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


void RespondToFeedback()
{
    while (true)
    {
        var (unreplied, replied, reported) = chickenRiceStall.getListOfFeedback();
        // Unreplied Feedback Section
        Console.WriteLine("=== Unreplied Feedback ===");
        if (unreplied.Count == 0)
        {
            Console.WriteLine("No feedback available to respond to.");
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

            Feedback feedbackToReply = chickenRiceStall.getFeedbackByID(feedbackID);
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
            Console.WriteLine("1. Reply to Feedback");
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
                    Console.WriteLine($"Details for Order ID: {selectedOrder.OrderID}");
                    Console.WriteLine($"Student ID: {selectedOrder.StudentID}");
                    Console.WriteLine($"Total Amount: {selectedOrder.TotalAmount:C}");
                    Console.WriteLine($"Order Time: {selectedOrder.OrderTime}");
                    Console.WriteLine($"Pickup Time: {selectedOrder.PickupTime}");
                    Console.WriteLine($"Order Status: {selectedOrder.OrderStatus}");
                    Console.WriteLine();
                    Console.WriteLine("Items in this order:");
                    foreach (var item in selectedOrder.Items)
                    {
                        Console.WriteLine($"- {item.MenuItem.ItemName} (Quantity: {item.Quantity})");
                    }

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
