namespace WaterskiBaan
{
    public class VerschuifLijnenArgs
    {

        public WaterskiBaan baan { get; set; }
        public Kabel kabel { get; set; }
 
        public VerschuifLijnenArgs (WaterskiBaan baan, Kabel kabel)
        {
            this.baan = baan;
            this.kabel = kabel;
        }

    }
}