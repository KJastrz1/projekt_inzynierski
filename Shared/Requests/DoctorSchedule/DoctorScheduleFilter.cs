using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.DoctorSchedule;
public class DoctorScheduleFilter
{
    [Required(ErrorMessage = "DoctorId is required.")]
    public Guid DoctorId { get; set; }
    public DayOfWeek? Day { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }    
}

