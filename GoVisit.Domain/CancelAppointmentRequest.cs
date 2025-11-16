namespace GoVisit.Domain;

public class CancelAppointmentRequest
{
    public long UserId { get; set; }
    public int OfficeId { get; set; }
}
