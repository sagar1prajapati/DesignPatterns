// Complex subsystem classes
class PatientRepository
{
    public void AddPatient(string name, string address)
    {
        // Logic to add a new patient to the repository
        Console.WriteLine($"Adding patient {name} with address {address} to the repository");
    }
}

class AppointmentScheduler
{
    public void ScheduleAppointment(string patientId, DateTime dateTime)
    {
        // Logic to schedule an appointment for a patient
        Console.WriteLine($"Scheduling an appointment for patient {patientId} on {dateTime}");
    }
}

class MedicalRecordManager
{
    public void CreateMedicalRecord(string patientId)
    {
        // Logic to create a new medical record for a patient
        Console.WriteLine($"Creating a medical record for patient {patientId}");
    }
}

// Facade class
class PatientManagementFacade
{
    private PatientRepository patientRepository;
    private AppointmentScheduler appointmentScheduler;
    private MedicalRecordManager medicalRecordManager;

    public PatientManagementFacade()
    {
        patientRepository = new PatientRepository();
        appointmentScheduler = new AppointmentScheduler();
        medicalRecordManager = new MedicalRecordManager();
    }

    public void RegisterPatient(string name, string address)
    {
        // Add patient to the repository
        patientRepository.AddPatient(name, address);

        Console.WriteLine($"Patient {name} registered successfully.");
    }

    public void ScheduleAppointment(string patientId, DateTime dateTime)
    {
        // Schedule an appointment for the patient
        appointmentScheduler.ScheduleAppointment(patientId, dateTime);

        Console.WriteLine($"Appointment scheduled for patient {patientId} on {dateTime}.");
    }

    public void CreateMedicalRecord(string patientId)
    {
        // Create a medical record for the patient
        medicalRecordManager.CreateMedicalRecord(patientId);

        Console.WriteLine($"Medical record created for patient {patientId}.");
    }
}

// Client code
class Client
{
    static void Main(string[] args)
    {
        PatientManagementFacade patientManagement = new PatientManagementFacade();

        // Register a new patient
        patientManagement.RegisterPatient("John Doe", "123 Main St");

        // Schedule an appointment for the patient
        patientManagement.ScheduleAppointment("P12345", DateTime.Now.AddDays(3));

        // Create a medical record for the patient
        patientManagement.CreateMedicalRecord("P12345");
    }
}
