using System.Collections.Generic;

namespace WaterskiBaan
{
    public class InstructieAfgelopenArgs
    {
        public List<Sporter> sporters { get; set; }

        public WachtrijStarten target { get; set; }

        public InstructieAfgelopenArgs (List<Sporter> sporters, WachtrijStarten target)
        {
            this.sporters = sporters;
            this.target = target;
        }

    }
}