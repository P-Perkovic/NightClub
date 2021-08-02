using System;
using static NightClub.Domain.Constants;

namespace NightClub.Domain.Models
{
    public class Reservation : Entity
    {
        public int TableId { get; set; }

        public string UserStringId { get; set; }

        public DateTime DateOfReservation { get; set; }

        public int NumberOfGuests { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsCanceled { get; set; }

        public bool? IsCanceledByAdmin { get; set; }

        public string ReservedFor { get; set; }

        public string Note { get; set; }

        public int Status { get; set; }

        /* EF */
        public Table Table { get; set; }

        public User User { get; set; }


        public bool SetReservationStatus()
        {
            if (this.IsActive == true && this.DateOfReservation < DateTime.Now)
            {
                this.Status = (int)ReservationStatus.Past;
                this.IsActive = false;
                return true;
            }

            else if (this.IsCanceled == true && this.Status != (int)ReservationStatus.Canceled)
            {
                this.Status = (int)ReservationStatus.Canceled;
                this.IsActive = false;
                return true;
            }

            else if (this.IsCanceledByAdmin == true && this.Status != (int)ReservationStatus.CanceledByAdmin)
            {

                this.Status = (int)ReservationStatus.CanceledByAdmin;
                this.IsActive = false;
                this.IsCanceled = true;
                return true;
            }

            return false;
        }

        public void SetReservedFor()
        {
            if(string.IsNullOrEmpty(this.ReservedFor) || string.IsNullOrWhiteSpace(this.ReservedFor))
                this.ReservedFor = this.User.Name;
        }
    }
}
