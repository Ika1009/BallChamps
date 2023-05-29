

using BallChamps.Domain;

namespace DataLayer.DTO
{
    public class PlayerInviteDTO
    {

        //Court
        public string CourtId { get; set; }
        public string CourtName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ImagePath { get; set; }


        //ReserveCourt
        public string ReserveCourtId { get; set; }
        public string HostUserProfileId { get; set; }
        public string AvailableTimes { get; set; }
        public string ReserveDay { get; set; }
        public string ReserveCourtNumber { get; set; }
        public string Status { get; set; }
        
        public DateTime ReserveDate { get; set; }
        public int PlayerLimit { get; set; }
        public int PerPlayerCost { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }




        //PlayerInvite
        public string PlayerInviteId { get; set; }
        public string PrivateRunId { get; set; }
        public string UserProfileId { get; set; }

        public string PlayerInviteNumber { get; set; }
        public string PlayerInviteStatus { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SignUpDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
