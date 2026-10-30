using MedicalSystem.Users;
using MedicalSystem.Spravki;
using MedicalSystem.Interfaces;
using MedicalSystem.Buhgalteria;
using MedicalSystem.Notifications;

Patient patient = new Patient("Aktan", "Asanov", "+996 555 123 456", "II+")
{
    Email = "aktan@mail.com"
};
patient.DisplayInfo();

Spravka83 spravka83 = new Spravka83
{
    SpravkaName = "Spravka 83",
    Patient = patient,
    Price = 500
};

SpravkaSanknijka spravkaSanknijka = new SpravkaSanknijka
{
    SpravkaName = "Spravka Sanknijka",
    Patient = patient,
    Price = 1000,
    AnalysisCount = 3
};

SpravkaBassein spravkaBassein = new SpravkaBassein("Spravka Bassein", patient, 200, 6);

List<ISpravka> spravkiList =
    new List<ISpravka> { spravka83, spravkaSanknijka, spravkaBassein };

foreach (var spravka in spravkiList)
{
    spravka.DisplayInfo();
    Console.WriteLine($"Total Price: {spravka.CalculatePrice()}");
    Console.WriteLine();
}

Console.WriteLine("Short info:");
foreach (var spravka in spravkiList)
{
    Console.WriteLine(spravka.GetShortInfo());
}
Console.WriteLine();

Kassa kassa = new Kassa();

decimal totalAmount = kassa.Total(spravkiList);

Console.WriteLine($"Total Amount in Kassa: {totalAmount}");
Console.WriteLine();

kassa.PrintCheck(spravkiList);
Console.WriteLine();

Console.WriteLine("Выберите способ уведомления: 1 - SMS, 2 - Email, 3 - Telegram");
string? choice = Console.ReadLine();

INotifier notifier;
if (choice == "1")
{
    notifier = new SmsNotifier();
}
else if (choice == "2")
{
    notifier = new EmailNotifier();
}
else
{
    notifier = new TelegramNotifier();
}

notifier.Send(patient, "Ваша справка готова");

