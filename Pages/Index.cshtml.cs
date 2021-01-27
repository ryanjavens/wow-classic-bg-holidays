using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WowClassicBgCalendar.Models;

namespace WowClassicBgCalendar.Pages.Calendar {
    public class IndexModel : PageModel
    {
        public Battleground currentWeek;
        public Battleground previousWeek;
        public Battleground nextWeek;

        // Initialize BG objects
        static DateTime startDate = new DateTime(2020, 3, 13);
        static Battleground alteracValley = new Battleground("Alterac Valley", "~/img/alterac-valley.jpg");
        static Battleground arathiBasin = new Battleground("Arathi Basin", "~/img/arathi-basin.jpg");
        static Battleground warsongGulch = new Battleground("Warsong Gulch", "~/img/warsong-gulch.jpg");
        static Battleground weekOff = new Battleground("Week off", "~/img/thousand-needles.jpg");

        // Warsong Gulch: March 13, April 10, May 8, June 5, etc.
        // Arathi Basin: March 20, April 17, May 15, June 12, etc.
        // Alterac Valley: April 3, May 1, May 29, June 26, etc.

        // BG Holiday Order: Warsong, Arathi, off, Alterac
        public Battleground[] BgRotation = {
            warsongGulch,
            arathiBasin,
            alteracValley,
            weekOff
        };

        public void OnGet() {
            int weeks;
            DateTime nextWeekDate = new DateTime(2021, 2, 9);

            weeks = Convert.ToInt32(Math.Truncate(((DateTime.Today.Date - startDate.Date).TotalDays / 7) % 4));

            currentWeek = BgRotation[weeks];
            if(weeks > 0) {
                // Check to ensure not first week
                previousWeek = BgRotation[weeks - 1];
            }
            else {
                // If first week, need to show previous as last element of list
                previousWeek = BgRotation[BgRotation.Length];
            }
            if(weeks == BgRotation.Length - 1) {
                nextWeek = BgRotation[0];
            }
            else {
                nextWeek = BgRotation[weeks + 1];
            }
        }
    }
}
