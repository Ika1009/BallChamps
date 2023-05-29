using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Common
{
    public class Options
    {
        /// <summary>
        /// Plan OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> PlanOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Free Plan", Value = "Free Plan" });
            selectList.Add(new SelectListItem() { Text = "Full Access Plan", Value = "Full Access Plan" });

            return selectList;
        }

        /// <summary>
        /// Cateogry Type OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> CateogryTypeOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Clothing", Value = "Clothing" });
            selectList.Add(new SelectListItem() { Text = "Shoes", Value = "Shoes" });
            selectList.Add(new SelectListItem() { Text = "Accessories", Value = "Accessories" });

            return selectList;
        }

        /// <summary>
        /// Product Type OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ProductTypeOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Event", Value = "Event" });
            selectList.Add(new SelectListItem() { Text = "Clothing", Value = "Clothing" });
            selectList.Add(new SelectListItem() { Text = "Shoes", Value = "Shoes" });
            selectList.Add(new SelectListItem() { Text = "Accessories", Value = "Accessories" });

            return selectList;
        }

        /// <summary>
        /// Access Level OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> AccessLevelOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Standard Player", Value = "Standard" });
            selectList.Add(new SelectListItem() { Text = "Admin (Staff)", Value = "Admin" });
            selectList.Add(new SelectListItem() { Text = "Super Admin", Value = "Super Admin" });

            return selectList;
        }

        /// <summary>
        /// Height OptionsListItems
        /// </summary>
        /// <returns></returns> 
        public static List<SelectListItem> HeightOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "5'0", Value = "5'0" });
            selectList.Add(new SelectListItem() { Text = "5'1", Value = "5'1" });
            selectList.Add(new SelectListItem() { Text = "5'2", Value = "5'2" });
            selectList.Add(new SelectListItem() { Text = "5'3", Value = "5'3" });
            selectList.Add(new SelectListItem() { Text = "5'4", Value = "5'4" });
            selectList.Add(new SelectListItem() { Text = "5'5", Value = "5'5" });
            selectList.Add(new SelectListItem() { Text = "5'6", Value = "5'6" });
            selectList.Add(new SelectListItem() { Text = "5'7", Value = "5'7" });
            selectList.Add(new SelectListItem() { Text = "5'8", Value = "5'8" });
            selectList.Add(new SelectListItem() { Text = "5'9", Value = "5'9" });
            selectList.Add(new SelectListItem() { Text = "5'10", Value = "5'10" });
            selectList.Add(new SelectListItem() { Text = "5'11", Value = "5'11" });
            selectList.Add(new SelectListItem() { Text = "6'0", Value = "6'0" });
            selectList.Add(new SelectListItem() { Text = "6'1", Value = "6'1" });
            selectList.Add(new SelectListItem() { Text = "6'2", Value = "6'2" });
            selectList.Add(new SelectListItem() { Text = "6'3", Value = "6'3" });
            selectList.Add(new SelectListItem() { Text = "6'4", Value = "6'4" });
            selectList.Add(new SelectListItem() { Text = "6'5", Value = "6'5" });
            selectList.Add(new SelectListItem() { Text = "6'6", Value = "6'6" });
            selectList.Add(new SelectListItem() { Text = "6'7", Value = "6'7" });
            selectList.Add(new SelectListItem() { Text = "6'8", Value = "6'8" });
            selectList.Add(new SelectListItem() { Text = "6'9", Value = "6'9" });
            selectList.Add(new SelectListItem() { Text = "6'10", Value = "6'10" });
            selectList.Add(new SelectListItem() { Text = "6'11", Value = "6'11" });
            selectList.Add(new SelectListItem() { Text = "7'0", Value = "7'0" });
            selectList.Add(new SelectListItem() { Text = "7'1", Value = "7'1" });
            selectList.Add(new SelectListItem() { Text = "7'2", Value = "7'2" });
            selectList.Add(new SelectListItem() { Text = "7'4", Value = "7'4" });
            selectList.Add(new SelectListItem() { Text = "7'5", Value = "7'5" });
            selectList.Add(new SelectListItem() { Text = "7'6", Value = "7'6" });
            selectList.Add(new SelectListItem() { Text = "7'7", Value = "7'7" });
            selectList.Add(new SelectListItem() { Text = "7'8", Value = "7'8" });
            selectList.Add(new SelectListItem() { Text = "7'9", Value = "7'9" });



            return selectList;
        }

        /// <summary>
        /// Position OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> PositionOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "PG", Value = "PG" });
            selectList.Add(new SelectListItem() { Text = "SG", Value = "SG" });
            selectList.Add(new SelectListItem() { Text = "SF", Value = "SF" });
            selectList.Add(new SelectListItem() { Text = "PF", Value = "PF" });
            selectList.Add(new SelectListItem() { Text = "C", Value = "C" });


            return selectList;
        }

        /// <summary>
        /// Yes Or No OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> YesOrNoOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Yes", Value = "Yes" });
            selectList.Add(new SelectListItem() { Text = "No", Value = "No" });


            return selectList;
        }

        /// <summary>
        /// Title OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> TitleOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Staff", Value = "Staff" });
            selectList.Add(new SelectListItem() { Text = "Manager", Value = "Manager" });
            selectList.Add(new SelectListItem() { Text = "Score Keeper", Value = "Score Keeper" });


            return selectList;
        }

        /// <summary>
        /// Gender OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GenderOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            selectList.Add(new SelectListItem() { Text = "Female", Value = "Female" });


            return selectList;
        }

        /// <summary>
        /// Court OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> CourtOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Open Run", Value = "Open Run" });
            selectList.Add(new SelectListItem() { Text = "Squads", Value = "Squads" });

            return selectList;
        }

        /// <summary>
        /// Open Closed OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> OpenClosedOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Open", Value = "Open" });
            selectList.Add(new SelectListItem() { Text = "Closed", Value = "Closed" });

            return selectList;
        }

        /// <summary>
        /// Skill OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> SkillOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Quick", Value = "Quick" });
            selectList.Add(new SelectListItem() { Text = "Big Man", Value = "Big Man" });
            selectList.Add(new SelectListItem() { Text = "Assist Man", Value = "Assist Man" });
            selectList.Add(new SelectListItem() { Text = "Fundamental", Value = "Fundamental" });
            selectList.Add(new SelectListItem() { Text = "Shooter", Value = "Shooter" });
            selectList.Add(new SelectListItem() { Text = "Hops", Value = "Hops" });
            selectList.Add(new SelectListItem() { Text = "Lock Defense", Value = "Lock Defense" });
            selectList.Add(new SelectListItem() { Text = "Shot Blocker", Value = "Shot Blocker" });
            selectList.Add(new SelectListItem() { Text = "Ball Handler", Value = "Ball Handler" });
            selectList.Add(new SelectListItem() { Text = "Explosive", Value = "Explosive" });


            return selectList;
        }

        /// <summary>
        /// Shop Options ListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ShopOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "All", Value = "All" });
            selectList.Add(new SelectListItem() { Text = "Shoes", Value = "Shoes" });
            selectList.Add(new SelectListItem() { Text = "Shirts", Value = "Shirts" });
            selectList.Add(new SelectListItem() { Text = "Shorts", Value = "Shorts" });
            selectList.Add(new SelectListItem() { Text = "Accessories", Value = "Accessories" });
            selectList.Add(new SelectListItem() { Text = "Events", Value = "Events" });           

            return selectList;
        }

        /// <summary>
        /// Court Status OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> CourtStatusOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Active", Value = "Active" });
            selectList.Add(new SelectListItem() { Text = "InActive", Value = "InActive" });
       
            return selectList;
        }

        /// <summary>
        /// Player Quick Comment OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> PlayerQuickCommentOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Very Skilled", Value = "Very Skilled" });
            selectList.Add(new SelectListItem() { Text = "High IQ", Value = "High IQ" });
            selectList.Add(new SelectListItem() { Text = "1st Round Draft Pick", Value = "1st Round Draft Pick" });
            selectList.Add(new SelectListItem() { Text = "Hustler", Value = "Hustler" });
            selectList.Add(new SelectListItem() { Text = "Shooter", Value = "Shooter" });
            selectList.Add(new SelectListItem() { Text = "Good, But Needs Work", Value = "Good, But Needs Work" });
            selectList.Add(new SelectListItem() { Text = "Not Good", Value = "Not Good" });
            selectList.Add(new SelectListItem() { Text = "Trash", Value = "Trash" });
            selectList.Add(new SelectListItem() { Text = "Old Timer", Value = "Old Timer" });
            selectList.Add(new SelectListItem() { Text = "Baby Shaq", Value = "Baby Shaq" });
            selectList.Add(new SelectListItem() { Text = "Hops", Value = "Hops" });
            selectList.Add(new SelectListItem() { Text = "Assassin", Value = "Assassin" });
            selectList.Add(new SelectListItem() { Text = "Finesse Player", Value = "Finesse Player" });
            selectList.Add(new SelectListItem() { Text = "Crazy Crossover", Value = "Crazy Crossover" });
            selectList.Add(new SelectListItem() { Text = "Old School", Value = "Old School" });
            selectList.Add(new SelectListItem() { Text = "Guaranteed Bucket", Value = "Guaranteed Bucket" });
            selectList.Add(new SelectListItem() { Text = "Sorry as Hell", Value = "Sorry as Hell" });
            selectList.Add(new SelectListItem() { Text = "Butter Fingers", Value = "Butter Fingers" });
            selectList.Add(new SelectListItem() { Text = "Strong", Value = "Strong" });
            selectList.Add(new SelectListItem() { Text = "Lock Defense", Value = "Lock Defense" });
            selectList.Add(new SelectListItem() { Text = "Play Maker", Value = "Play Maker" });
            selectList.Add(new SelectListItem() { Text = "Sees the Court", Value = "Sees the Court" });
            selectList.Add(new SelectListItem() { Text = "Dropping Dimes", Value = "Dropping Dimes" });
            selectList.Add(new SelectListItem() { Text = "Fundamental", Value = "Fundamental" });


            return selectList;
        }

        /// <summary>
        /// Style Of Play OptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> StyleOfPlayOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "M. Jordan", Value = "M. Jordan" });
            selectList.Add(new SelectListItem() { Text = "K. Bryant", Value = "K. Bryant" });
            selectList.Add(new SelectListItem() { Text = "D. Rose", Value = "D. Rose" });
            selectList.Add(new SelectListItem() { Text = "A. Davis", Value = "A. Davis" });
            selectList.Add(new SelectListItem() { Text = "K. Leonard", Value = "K. Leonard" });
            selectList.Add(new SelectListItem() { Text = "D. Lillard", Value = "D. Lillard" });
            selectList.Add(new SelectListItem() { Text = "K. Thompson", Value = "K. Thompson" });
            selectList.Add(new SelectListItem() { Text = "R. Westbrook", Value = "R. Westbrook" });
            selectList.Add(new SelectListItem() { Text = "S. Curry", Value = "S. Curry" });
            selectList.Add(new SelectListItem() { Text = "K. Morant", Value = "K. Morant" });
            selectList.Add(new SelectListItem() { Text = "T. Young", Value = "T. Young" });
            selectList.Add(new SelectListItem() { Text = "B. Simmons", Value = "B. Simmons" });
            selectList.Add(new SelectListItem() { Text = "D. Booker", Value = "D. Booker" });


            return selectList;
        }

        /// <summary>
        /// TypeOfRunOptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> TypeOfRunOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Open", Value = "Open" });
            selectList.Add(new SelectListItem() { Text = "Private", Value = "Private" });
            

            return selectList;
        }

        /// <summary>
        /// ProfileInviteOptionsListItems
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> ProfileInviteOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Confirmed", Value = "Confirmed" });
            selectList.Add(new SelectListItem() { Text = "Denied", Value = "Denied" });
            selectList.Add(new SelectListItem() { Text = "Waiting For Response", Value = "Waiting For Response " });

            return selectList;
        }

        /// <summary>
        /// Search For Player OptionsListItems
        /// </summary>
        /// <param name="productOptionsList"></param>
        /// <returns></returns>
        public static List<SelectListItem> SearchForPlayerOptionsListItems(List<UserProfileDTO> userNameOptionsList)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in userNameOptionsList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.UserProfileId,
                    Text = element.UserName
                });
            }

            return selectList;
        }

        /// <summary>
        /// Court PrivateRunAvailabilityOptions ListItems
        /// </summary>
        /// <param name="productOptionsList"></param>
        /// <returns></returns>
        public static List<SelectListItem> CourtPrivateRunAvailabilityOptionsListItems(List<CourtPrivateRunAvailability> courtPrivateRunAvailabilityList)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in courtPrivateRunAvailabilityList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToDateTime(element.StartTime).ToString() + " - " + Convert.ToDateTime(element.EndTime).ToString(),
                    Text = Convert.ToDateTime(element.StartTime).ToString() + " - " + Convert.ToDateTime(element.EndTime).ToString()
                }); ;
            }

            return selectList;
        }


        /// <summary>
        /// Available Times Options List Items
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> AvailableTimesOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "9 AM - 12 PM", Value = "9 AM - 12 PM" });
            selectList.Add(new SelectListItem() { Text = "12 PM - 3 PM", Value = "12 PM - 3 PM" });
            selectList.Add(new SelectListItem() { Text = "3 PM - 6 PM", Value = "3 PM - 6 PM" });

            return selectList;
        }

        /// <summary>
        /// Available Day Options List Items
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> AvailableDaysOptionsListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem() { Text = "Monday", Value = "Monday" });
            selectList.Add(new SelectListItem() { Text = "Tuesday", Value = "Tuesday" });
            selectList.Add(new SelectListItem() { Text = "Wednesday", Value = "Wednesday" });
            selectList.Add(new SelectListItem() { Text = "Thursday", Value = "Thursday" });
            selectList.Add(new SelectListItem() { Text = "Friday", Value = "Friday" });
            selectList.Add(new SelectListItem() { Text = "Saturday", Value = "Saturday" });
            selectList.Add(new SelectListItem() { Text = "Sunday", Value = "Sunday" });

            return selectList;
        }

    }
}