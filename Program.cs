using FakturaMaker.src;

internal class Program
{
    private static void Main(string[] args)
    { 
        Address sAddress = new Address("Kladno", "Sasova", 52, "58963");
        Address rAddress = new Address("Brno", "Zemedelska", 18, "25639");
        Address address = new Address("Brno", "Technicka", 18, "25639");

        Subject sender = new Subject("Alex Vedarnikov", 256301, "CZ52634", sAddress);
        Subject receiver = new Subject("Edgard Kovbljuk", 256385, "CZ52685", rAddress);
        Subject subject = new Subject("Ondrej Mandik", 254385, "CZ52685", address);

        BankPayment payment = new BankPayment("6666 6666 6666 6666", "0300", "13");
        BankPayment payment1 = new BankPayment("9999 6666 6666 6666", "0300", "15");
        BankPayment payment2 = new BankPayment("9999 9999 6666 6666", "0300", "17");

        DateOnly dueDate = new DateOnly(2024, 10, 2);
        DateOnly dateOfIssue = new DateOnly(2024, 8, 2);

        Item item1 = new Item("Pen", 1.5, 5, "pcs", 20);
        Item item2 = new Item("Notebook", 3.75, 2, "pcs", 15);
        Item item3 = new Item("Laptop", 899.99, 1, "unit", 10);
        Item item4 = new Item("Printer", 299.99, 1, "unit", 20);
        Item item5 = new Item("Headphones", 49.99, 1, "pair", 15);
        Item item6 = new Item("T-shirt", 19.99, 1, "unit", 10);
        Item item7 = new Item("Backpack", 39.99, 2, "unit", 20);
        Item item8 = new Item("Smartphone", 699.99, 1, "unit", 20);
        Item item9 = new Item("Charger", 14.99, 5, "unit", 15);

        List<Item> items1 = [item1, item2, item3];
        List<Item> items2 = [item4, item5, item6];
        List<Item> items3 = [item7, item8, item9];


        Bill bill1 = new Bill(payment, sender, receiver, items1, dueDate, dateOfIssue);
        Bill bill2 = new Bill(payment2, receiver, sender, items2, dueDate, dateOfIssue);
        Bill bill3 = new Bill(receiver, subject, items3, dueDate, dateOfIssue);

        List<Bill> bills = [bill1, bill2, bill3];


        Console.WriteLine("Bill count that has item count more than 7: " + bills.Where(bill => bill.Items.Sum(item => item.Count) > 7).Count());

        Console.WriteLine("Bill count that has receiver address city 'Brno': " + bills.Where(bill => bill.Receiver.Address.City == "Brno").Count());

        Console.WriteLine("Bill item count that has total price more than 30 (Total price is meant as count * price): " + bill2.Items.Where(item => item.GetTotal() > 20).Count());

    }
}