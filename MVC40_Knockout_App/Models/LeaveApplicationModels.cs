using MVC40_Knockout_App.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC40_Knockout_App.Models
{
    /// <summary>
    /// The LeaveApplication model is used to create and update the leave application. 
    /// </summary>
    public class LeaveApplication
    {
        // INTERVIEW_TODO: 6. Leave Applications must have a StartDate and EndDate
        // Details:
        // Please modify this model to ensure that startDate and endDate are required fields.
        // Question: How would we ensure that the startDate is always before the endDate? 
        // Suggest a re-usable approach to validate business logic suitable for a production application - Implemented Custom Validator that can be extended to client side as well.
        public int EmpNo { get; set; }

        [Required]
        [DataType(DataType.DateTime))]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime))]
        [MyDateValidator("StartDate")]
        public DateTime EndDate { get; set; }

        public bool IsApproved { get; set; }
    }

    /// <summary>
    /// The LeaveApplicationView model is used to present leave applications to the user.
    /// </summary>
    public class LeaveApplicationView
    {
        // INTERVIEW_TODO: 7. Calculate duration of the leave application (leaveDays)
        // Details:
        // The LeaveDays property needs to be modified so it has the following characteristics:
        // It must be readonly
        // It must return the difference in days between the StartDate and EndDate
        // e.g. If (StartDate == EndDate) then LeaveDays = 1
        // if (StartDate == EndDate + 1) then LeaveDays = 2
        // Please add tests in EmployeeUnitTests.cs to validate your logic
        public int EmpNo { get; set; }

        public string EmployeeName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LeaveDays { get
            {
                var days = EndDate.Subtract(StartDate).Days;
                if (days >= default(int))
                    return days + 1;

                return default(int);
            }
        }
    }
}