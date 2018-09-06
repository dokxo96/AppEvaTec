using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvaTec.Views.Menu1
{

    public class FicMasterPageMenuItem
    {
        public FicMasterPageMenuItem()
        {
            TargetType = typeof(FicMasterPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }

        public string FicPageName { get; set; }
    }
}