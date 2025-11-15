using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GoVisit.Domain;

public class AppointmentsForUser
{
    [Key]
    public long UserId { get; set; }

    [BsonElement("appointments")]
    public List<Appointments> Appointments { get; set; } = new List<Appointments>();
}

public class Appointments
{
    [BsonElement("office_id")]
    public int OfficeId { get; set; }

    [BsonElement("appointment_date")]
    public DateTime AppointmentDate { get; set; }

}
