using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyApp.Entity;

public class AppointmentsForUser
{
    [BsonId]
    public ObjectId _id { get; set; }

    [BsonElement("user_id")]
    public long UserId { get; set; }

    [BsonElement("office_id")]
    public int OfficeId { get; set; }

    [BsonElement("appointment_date")]
    public DateTime AppointmentDate { get; set; }
}
