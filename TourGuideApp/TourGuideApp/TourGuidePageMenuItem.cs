using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourGuideApp
{

    public class TourGuidePageMenuItem
    {
        public TourGuidePageMenuItem()
        {
            TargetType = typeof(TourGuidePageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}