public class Program
{
    enum TicketType
    {
        Standart,
        Vip
    }

    enum DayType
    {
        Weekday,
        Weekend
    }

    static  (decimal price, int age, Boolean studentStatus, TicketType ticketType, DayType dayType) ReadInput()
    {
        decimal price;
        Console.WriteLine("Price:");
        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
        {
            Console.WriteLine("Invalid input. Enter the decimal number.");
        }
        int age;
        Console.WriteLine("Age:");
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Invalid input. Enter the integer number.");
        }
        Boolean studentStatus;
        Console.WriteLine("Student Status (true/false):");
        while (!bool.TryParse(Console.ReadLine(), out studentStatus))
        {
            Console.WriteLine("Invalid boolean. Enter the boolean.");

        }
        TicketType ticketType = ReadTicketType();
        DayType dayType = ReadDyaType();

        return (price, age, studentStatus, ticketType, dayType);
    }

    static TicketType ReadTicketType()
    {
        TicketType ticketType = default;
        string ticketTypeInput;
        bool isTicketTypeValid;
        do
        {
            Console.WriteLine("Ticket Type (Standart/Vip):");
            ticketTypeInput = Console.ReadLine();
            bool isNumeric = int.TryParse(ticketTypeInput, out _);
            isTicketTypeValid = !isNumeric && Enum.TryParse<TicketType>(ticketTypeInput, true, out ticketType) && Enum.IsDefined(typeof(TicketType), ticketType);
            if (!isTicketTypeValid)
            {
                Console.WriteLine("Invalid input. Enter the correct ticket type.");
            }
        } while (!isTicketTypeValid);
        return ticketType;
    }

    static DayType ReadDyaType()
    {
        DayType dayType = default;
        string dayTypeInput;
        bool isDayTypeValid;

        do
        {
            Console.WriteLine("Day Type (Weekday/Weekend):");
            dayTypeInput = Console.ReadLine();
            bool isNumeric = int.TryParse(dayTypeInput, out _);
            isDayTypeValid = !isNumeric && Enum.TryParse<DayType>(dayTypeInput, true, out dayType) && Enum.IsDefined(typeof(DayType), dayType);
            if (!isDayTypeValid)
            {
                Console.WriteLine("Invalid input. Enter the correct day type.");
            }
        } while (!isDayTypeValid);
        return dayType;
    }

    static decimal ApplyPricingRule(decimal price, Func<decimal, decimal> rule) => rule(price);

    static decimal AgeOrStudentDiscount(int Age, Boolean studentStatus)
    {
        if (Age <= 6)
        {
            return 0m;
        }
        else
        {
            if (Age > 6 && Age <= 12)
            {
                return 0.5m;

            }
            else if (studentStatus)
            {
                return 0.85m;
            }
            else if (Age > 60)
            {
                return 0.75m;
            }
            else
            {
                return 1m;
            }
        }
    }
    static decimal CalculateFinalPrice(decimal price, int Age, Boolean studentStatus, TicketType ticketT, DayType dayType)
    {
        decimal result;
        result = ApplyPricingRule(price, p => p * AgeOrStudentDiscount(Age, studentStatus));
        result = ApplyPricingRule(result, p => p * (ticketT == TicketType.Vip ? 1.25m : 1m));
        result = ApplyPricingRule(result, p => p * (dayType == DayType.Weekend ? 1.1m : 1m));
        result = Math.Round(Math.Max(result, 0), 3);
        return result;
    }

    public static void Main()
    {
        var input = ReadInput();
        Console.WriteLine(CalculateFinalPrice(input.price, input.age, input.studentStatus, input.ticketType, input.dayType));

    }
}


