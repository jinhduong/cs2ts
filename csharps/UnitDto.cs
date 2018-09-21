using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RentGuard.ApplicationService.Helpers;

namespace RentGuard.ApplicationService.DTOs
{
    public class UnitDto
    {
        public long RowId { get; set; }
        public DateTime? Created { get; set; }
        [JsonIgnore]
        public long? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        [JsonIgnore]
        public long? LastUpdatedBy { get; set; }
        public string DisplayName { get; set; }
        [JsonIgnore]
        public string ScehemeName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Building { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string FloorLevel { get; set; }
        public string UnitNumber { get; set; }
        public string UnitStatus { get; set; }
        [JsonIgnore]
        public bool? HighriseFlg { get; set; }
        public string DisplayFormat { get; set; }
        [JsonIgnore]
        public long? OwnerId { get; set; }
        [JsonIgnore]
        public long? AgentId { get; set; }
        public string HomeType { get; set; }
        public string RoomType { get; set; }
        public decimal? NoRoom { get; set; }
        public decimal? NoBathroom { get; set; }
        [JsonIgnore]
        public string Facility { get; set; }
        public long? Sqft { get; set; }
        public string Remarks { get; set; }
        public long? Width { get; set; }
        public long? Length { get; set; }
        public int? UnitLetterStatus { get; set; }

        // Extend
        public string HomeTypeName
        {
            get
            {
                if (string.IsNullOrEmpty(HomeType)) return "";

                var rentalHouseTypes = new List<string>();
                var houseTypes = HomeType.Split(',');
                foreach (var homeType in houseTypes)
                {
                    switch (homeType)
                    {
                        case "1": rentalHouseTypes.Add("Landed House"); break;
                        case "2": rentalHouseTypes.Add("Apartment"); break;
                        case "3": rentalHouseTypes.Add("Commercial"); break;
                    }
                }
                return string.Join(",", rentalHouseTypes);
            }
        }

        public string RoomTypeName
        {
            get
            {
                if (string.IsNullOrEmpty(RoomType)) return "";

                var rentalRoomTypes = new List<string>();
                var roomTypes = RoomType.Split(',');
                foreach (var roomType in roomTypes)
                {
                    switch (roomType)
                    {
                        case "1": rentalRoomTypes.Add("Room type 1"); break;
                        case "2": rentalRoomTypes.Add("Room type 2"); break;
                    }
                }
                return string.Join(",", rentalRoomTypes);
            }
        }

        public string AgentName { get; set; }
        public string HashId => StringUtils.Encode(RowId.ToString());
        public long PropertyId { get; set; }

        //public string PremiseAddress => HomeType.Equals("1")
        //    ? $"{UnitNumber}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}."
        //    : string.IsNullOrEmpty(Block)
        //        ? $"Block -, {FloorLevel}-{UnitNumber} {Building}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}."
        //        : $"Block {Block}-{FloorLevel}-{UnitNumber} {Building}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}.";

        public string PremiseAddress
        {
            get
            {
                if (HomeType.Equals("1"))
                    return $"{UnitNumber}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}.";
                else
                {
                    if (string.IsNullOrEmpty(Block))
                        return $"Block -, {FloorLevel}-{UnitNumber} {Building}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}.";
                    else
                        return $"Block {Block}-{FloorLevel}-{UnitNumber} {Building}. {Street}, {Area}, {City}, {Postcode}, {State}, {Country}.";
                }
            }
        }

        public string LoAStatus
        {
            get
            {
                switch (UnitLetterStatus)
                {
                    case (int)Constants.UnitLetterStatus.SentToLandlord:
                        return "Pending";
                    case (int)Constants.UnitLetterStatus.AcceptedByLandlord:
                        return "Accepted";
                    case (int)Constants.UnitLetterStatus.RejectedByLandlord:
                        return "Rejected";
                }

                return "";
            }
        }

        public UnitLoADto LoA { get; set; }
    }
}
