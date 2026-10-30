using MedicalSystem.Users;

namespace MedicalSystem.Notifications
{
    internal interface INotifier
    {
        void Send(Patient patient, string message);
    }

    internal class SmsNotifier : INotifier
    {
        public void Send(Patient patient, string message)
        {
            Console.WriteLine($"SMS на номер {patient.PhoneNumber}: {message}");
        }
    }

    internal class EmailNotifier : INotifier
    {
        public void Send(Patient patient, string message)
        {
            Console.WriteLine($"Email на адрес {patient.Email}: {message}");
        }
    }
}
