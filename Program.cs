using FakturaMaker.src;

internal class Program
{
    private static void Main(string[] args)
    {
        Address sAdress = new Address("Kladno", "Sasova", 52, "58963");
        Address rAdress = new Address("Radotin", "Terezky", 18, "25639");

        Subject sender = new Subject("Alex Vedarnikov", 256301, "CZ52634", sAdress);
        Subject receiver = new Subject("Terezka Svobodova", 256385, "CZ52685", rAdress);

        CardPayment payment = new CardPayment("6666 6666 6666 6666", "0300", "13");

        DateOnly dueDate = new DateOnly(2024, 5, 2);
        DateOnly dateOfIssue = new DateOnly(2024, 5, 2);


        Item item1 = new Item("Apple", 200, 5, "kg", 10);
        Item item2 = new Item("Banana", 300, 10, "units", 5);
        Item item3 = new Item("Orange", 550, 8, "kg", 8);

        List<Item> items = [item1, item2, item3];

        Bill bill = new Bill(payment, sender, receiver, items, dueDate, dateOfIssue);

        Console.WriteLine(bill.selectItemsWithValuesMoreThan(200));
    }
}