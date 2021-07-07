using System.Collections.Generic;
using _1811060740_NguyenDucThinh_BigSchool.Models;

namespace _1811060740_NguyenDucThinh_BigSchool.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser> Followings { get; set; }
        public bool ShowAction { get; set; }
    }
}