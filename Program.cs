using System;

namespace HMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string guestName = "";
            string guestPhone = "";
            int roomNumber = 0;
            string roomType = "";
            double nightlyRate = 0.0;

            string checkInDate = "";
            string checkOutDate = "";
            int numberOfNights = 0;

            string roomNotes = "";
            double discountPercent = 0.0;
            double loyaltyPoints = 0.0;

            bool isRegistered = false;
            bool isCheckedIn = false;

            Random rng = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("GRAND PALACE HOTEL FRONT DESK");
                Console.WriteLine("0)Register New Guest");
                Console.WriteLine("1)View Guest Information");
                Console.WriteLine("2)Check In Guest");
                Console.WriteLine("3)Check Out & Bill");
                Console.WriteLine("4)Apply Discount");
                Console.WriteLine("5)Upgrade Room");
                Console.WriteLine("6)Add Room Service Note");
                Console.WriteLine("7)Search Guest by Name");
                Console.WriteLine("8)Calculate Loyalty Points");
                Console.WriteLine("9)Print Receipt");
                Console.WriteLine("10)Edit Guest Name");
                Console.WriteLine("11)Exit");

                if (isRegistered)
                    Console.WriteLine("Guest: " + guestName + "Room: " + roomNumber + "Status: " + (isCheckedIn ? "Checked In" : "Not Checked In"));
                else
                    Console.WriteLine("No guest registered");

                Console.WriteLine();
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                
                    case 0:
                        Console.WriteLine("── Register New Guest ──");

                        if (isRegistered)
                        {
                            Console.WriteLine("A guest is already registered. Check-out first.");
                            break;
                        }

                        Console.Write("Enter guest name: ");
                        guestName = Console.ReadLine().Trim();

                        if (guestName == "")
                        {
                            Console.WriteLine("Error: Name cannot be empty");
                            break;
                        }

                        Console.Write("Enter guest phone: ");
                        guestPhone = Console.ReadLine().Trim();

                        Console.Write("Enter room type (Standard / Deluxe / Suite): ");
                        roomType = Console.ReadLine().Trim();

                        Console.Write("Enter nightly rate (OMR): ");
                        nightlyRate = Convert.ToDouble(Console.ReadLine());

                        if (nightlyRate <= 0)
                        {
                            Console.WriteLine("Error: Rate must be greater than zero");
                            break;
                        }

                        roomNumber = rng.Next(100, 1000);
                        isRegistered = true;
                        discountPercent = 0.0;
                        roomNotes = "";

                        Console.WriteLine("Guest registered successfully!");
                        Console.WriteLine("Auto-generated Room Number: " + roomNumber);
                        break;

                    case 1:
                        Console.WriteLine("── Guest Information ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered yet");
                            break;
                        }

                        Console.WriteLine("Name: " + guestName.ToUpper());
                        Console.WriteLine("Phone: " + guestPhone);
                        Console.WriteLine("Room Number: " + Convert.ToString(roomNumber));
                        Console.WriteLine("Room Type: " + roomType);
                        Console.WriteLine("Nightly Rate: " + Math.Round(nightlyRate, 2) + " OMR");
                        Console.WriteLine("Discount: " + Convert.ToString(discountPercent) + " %");
                        Console.WriteLine("Loyalty Pts: " + Convert.ToString(loyaltyPoints));
                        Console.WriteLine("Checked In: " + Convert.ToString(isCheckedIn));

                        if (isCheckedIn)
                        {
                            Console.WriteLine("Check In: " + checkInDate);
                            Console.WriteLine("Check Out: " + checkOutDate);
                            Console.WriteLine("Nights: " + Convert.ToString(numberOfNights));
                        }

                        if (roomNotes != "")
                            Console.WriteLine("Notes: " + roomNotes);
                        break;
                    case 2:
                        Console.WriteLine("── Check-In Guest ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered. Register first.");
                            break;
                        }
                        if (isCheckedIn)
                        {
                            Console.WriteLine("Guest is already checked in");
                            break;
                        }

                        Console.Write("Enter number of nights: ");
                        numberOfNights = Convert.ToInt32(Console.ReadLine());

                        if (numberOfNights < 1)
                        {
                            Console.WriteLine("Error: Number of nights must be at least 1");
                            break;
                        }

                        DateTime checkInDateTime = DateTime.Today;
                        DateTime checkOutDateTime = checkInDateTime.AddDays(numberOfNights);

                        checkInDate = checkInDateTime.ToString("dd/MM/yyyy");
                        checkOutDate = checkOutDateTime.ToString("dd/MM/yyyy");
                        isCheckedIn = true;

                        Console.WriteLine("Check-in successful!");
                        Console.WriteLine("Check-In Date: " + checkInDate);
                        Console.WriteLine("Check-Out Date: " + checkOutDate);
                        Console.WriteLine("Number of Nights: " + numberOfNights);
                        Console.WriteLine("Checked-In at: " + DateTime.Now.ToString("hh:mm tt"));
                        break;

                    case 3:
                        Console.WriteLine("── Check-Out & Final Bill ──");

                        if (!isCheckedIn)
                        {
                            Console.WriteLine("Guest is not currently checked in");
                            break;
                        }

                        double subtotal = nightlyRate * numberOfNights;
                        double discountAmt = subtotal * (discountPercent / 100.0);
                        double totalBill = subtotal - discountAmt;

                        subtotal = Math.Round(subtotal, 2);
                        discountAmt = Math.Round(discountAmt, 2);
                        totalBill = Math.Round(totalBill, 2);

                        Console.WriteLine("Guest: " + guestName);
                        Console.WriteLine("Room: " + roomNumber + " (" + roomType + ")");
                        Console.WriteLine("Nights: " + numberOfNights);
                        Console.WriteLine("Rate/Night: " + nightlyRate + "OMR");
                        Console.WriteLine("Subtotal: " + subtotal + "OMR");
                        Console.WriteLine("Discount: " + discountPercent + "% = " + discountAmt + "OMR");
                        Console.WriteLine("TOTAL BILL: " + totalBill + "OMR");
                        Console.WriteLine("Thank you for staying at Grand Palace Hotel!");

                        isCheckedIn = false;
                        checkInDate = "";
                        checkOutDate = "";
                        numberOfNights = 0;
                        discountPercent = 0.0;
                        roomNotes = "";
                        isRegistered = false;
                        guestName = "";
                        guestPhone = "";
                        roomNumber = 0;
                        roomType = "";
                        nightlyRate = 0.0;

                        Console.WriteLine("Room has been reset and is ready for new guests");
                        break;

                    case 4:
                        Console.WriteLine("── Apply Discount ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered");
                            break;
                        }
                        if (!isCheckedIn)
                        {
                            Console.WriteLine("Guest must be checked in first");
                            break;
                        }

                        Console.Write("Enter discount percentage (e.g. 10 for 10%): ");
                        double newDiscount = Convert.ToDouble(Console.ReadLine());

                        newDiscount = Math.Abs(newDiscount);

                        if (newDiscount > 100)
                        {
                            Console.WriteLine("Error: Discount cannot exceed 100%.");
                            break;
                        }

                        double originalTotal = Math.Round(nightlyRate * numberOfNights, 2);
                        discountPercent = newDiscount;
                        double discountedTotal = Math.Round(originalTotal - (originalTotal * (discountPercent / 100.0)), 2);
                        double amountSaved = Math.Abs(Math.Round(originalTotal - discountedTotal, 2));

                        Console.WriteLine("Discount Applied");
                        Console.WriteLine("Original Total: " + originalTotal + "OMR");
                        Console.WriteLine("Discount: " + discountPercent + "%");
                        Console.WriteLine("Discounted Total: " + discountedTotal + "OMR");
                        Console.WriteLine("You Saved: " + amountSaved + "OMR");
                        break;

                    case 5:
                        Console.WriteLine("── Upgrade Room ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered.");
                            break;
                        }

                        Console.WriteLine("Current Room Type: " + roomType);
                        Console.WriteLine("Current Rate: " + nightlyRate + "OMR/night");

                        Console.Write("Enter new room type: ");
                        string newRoomType = Console.ReadLine().Trim();

                        Console.Write("Enter new nightly rate (OMR): ");
                        double newRate = Convert.ToDouble(Console.ReadLine());

                        if (newRate <= 0)
                        {
                            Console.WriteLine("Error: Rate must be greater than zero");
                            break;
                        }

                        double oldRate = nightlyRate;
                        double higherRate = Math.Max(oldRate, newRate);
                        double lowerRate = Math.Min(oldRate, newRate);
                        double difference = Math.Abs(newRate - oldRate);

                        Console.WriteLine("  Higher Rate: " + higherRate + "OMR");
                        Console.WriteLine("  Lower Rate: " + lowerRate + "OMR");
                        Console.WriteLine("  Difference: " + Math.Round(difference, 2) + "OMR per night");

                        roomType = newRoomType;
                        nightlyRate = newRate;

                        Console.WriteLine("Room upgraded successfully!");
                        Console.WriteLine("New Room Type: " + roomType);
                        Console.WriteLine("New Rate: " + nightlyRate + " OMR/night");
                        break;

                    case 6:
                        Console.WriteLine("── Add Room Service Note ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered.");
                            break;
                        }

                        Console.Write("Enter service note: ");
                        string newNote = Console.ReadLine().Trim();

                        if (newNote == "")
                        {
                            Console.WriteLine("Error: Note cannot be blank.");
                            break;
                        }

                        newNote = newNote.Replace("", "");

                        if (roomNotes == "")
                            roomNotes = newNote;
                        else
                            roomNotes = roomNotes + "" + newNote;

                        Console.WriteLine("Note added successfully!");
                        Console.WriteLine("All Notes: " + roomNotes);
                        Console.WriteLine("Total Length: " + roomNotes.Length + " characters");
                        break;

                    case 7:
                        Console.WriteLine("── Search Guest by Name ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered.");
                            break;
                        }

                        Console.Write("Enter search keyword: ");
                        string keyword = Console.ReadLine().Trim();

                        if (keyword == "")
                        {
                            Console.WriteLine("Error: Keyword cannot be empty.");
                            break;
                        }

                        bool found = guestName.ToLower().Contains(keyword.ToLower());

                        if (found)
                        {
                            Console.WriteLine("Guest FOUND!");
                            Console.WriteLine("  Name  : " + guestName);
                            Console.WriteLine("  Phone : " + guestPhone);
                            Console.WriteLine("  Room  : " + roomNumber + " (" + roomType + ")");
                        }
                        else
                        {
                            Console.WriteLine("No guest found matching keyword: " + keyword + "");
                        }
                        break;

                    case 8:
                        Console.WriteLine("── Calculate Loyalty Points ──");

                        if (!isCheckedIn)
                        {
                            Console.WriteLine("Guest must be checked-in to earn points.");
                            break;
                        }

                        double earnedPoints = Math.Round(Math.Pow(numberOfNights, 2), 0);
                        loyaltyPoints = loyaltyPoints + earnedPoints;

                        Console.WriteLine("Loyalty Points Calculated!");
                        Console.WriteLine("  Nights Stayed : " + numberOfNights);
                        Console.WriteLine("  Formula       : " + numberOfNights + "^2 = " + earnedPoints + " pts");
                        Console.WriteLine("  Points Earned : " + earnedPoints);
                        Console.WriteLine("  Total Points  : " + loyaltyPoints);
                        break;

                    case 9:
                        Console.WriteLine("── Print Receipt ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered.");
                            break;
                        }

                        string separator = "";
                        int dashCount = 0;
                        while (dashCount < 50)
                        {
                            separator = separator + "-";
                            dashCount++;
                        }

                        double receiptSubtotal = Math.Round(nightlyRate * numberOfNights, 2);
                        double receiptDiscount = Math.Round(receiptSubtotal * (discountPercent / 100.0), 2);
                        double receiptTotal = Math.Round(receiptSubtotal - receiptDiscount, 2);

                        string receiptTemplate =
                            "HOTEL  : Grand Palace Hotel" +
                            "GUEST  : [GUESTNAME]" +
                            "PHONE  : [PHONE]" +
                            "ROOM   : [ROOMNUM] ([ROOMTYPE])" +
                            "DATES  : [CHECKIN] to [CHECKOUT]" +
                            "NIGHTS : [NIGHTS]" +
                            "RATE   : [RATE] OMR/night" +
                            "SUB    : [SUBTOTAL] OMR" +
                            "DISC   : [DISCOUNT]%" +
                            "TOTAL  : [TOTAL] OMR" +
                            "POINTS : [POINTS]" +
                            "PRINTED: [DATETIME]";

                        string receipt = receiptTemplate;
                        receipt = receipt.Replace("[GUESTNAME]", guestName);
                        receipt = receipt.Replace("[PHONE]", guestPhone);
                        receipt = receipt.Replace("[ROOMNUM]", Convert.ToString(roomNumber));
                        receipt = receipt.Replace("[ROOMTYPE]", roomType);
                        receipt = receipt.Replace("[CHECKIN]", checkInDate == "" ? "N/A" : checkInDate);
                        receipt = receipt.Replace("[CHECKOUT]", checkOutDate == "" ? "N/A" : checkOutDate);
                        receipt = receipt.Replace("[NIGHTS]", Convert.ToString(numberOfNights));
                        receipt = receipt.Replace("[RATE]", Convert.ToString(nightlyRate));
                        receipt = receipt.Replace("[SUBTOTAL]", Convert.ToString(receiptSubtotal));
                        receipt = receipt.Replace("[DISCOUNT]", Convert.ToString(discountPercent));
                        receipt = receipt.Replace("[TOTAL]", Convert.ToString(receiptTotal));
                        receipt = receipt.Replace("[POINTS]", Convert.ToString(loyaltyPoints));
                        receipt = receipt.Replace("[DATETIME]", DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));

                        Console.WriteLine(separator);
                        Console.WriteLine(receipt);
                        Console.WriteLine(separator);
                        break;

                    case 10:
                        Console.WriteLine("── Edit Guest Name ──");

                        if (!isRegistered)
                        {
                            Console.WriteLine("No guest registered.");
                            break;
                        }

                        Console.WriteLine("Current Name: " + guestName);
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine().Trim();

                        if (newName.Length < 3)
                        {
                            Console.WriteLine("Error: Name must be at least 3 characters.");
                            break;
                        }

                        Console.WriteLine("── Name Preview ──");
                        Console.WriteLine("  UPPERCASE : " + newName.ToUpper());
                        Console.WriteLine("  lowercase : " + newName.ToLower());
                        Console.WriteLine("  Length    : " + newName.Length + " characters");

                        Console.Write("Confirm update? (yes / no): ");
                        string confirm = Console.ReadLine().Trim().ToLower();

                        if (confirm == "yes")
                        {
                            guestName = newName;
                            Console.WriteLine("Name updated to: " + guestName);
                        }
                        else
                        {
                            Console.WriteLine("Name update cancelled.");
                        }
                        break;

                    case 11:
                        string exitTime = DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt");
                        Console.WriteLine("  Thank you for using Grand Palace Hotel");
                        Console.WriteLine("  Front Desk System.");
                        Console.WriteLine("  Session ended on: " + exitTime);
                        Console.WriteLine("  Goodbye!");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 11.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
