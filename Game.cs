using System;
namespace WaterskiBaan
{
    public class Game
    {
        private InstructieGroep instructieGroep;

        private WachtrijStarten wachtrijStarten;

        private WachtrijInstructie wachtrijInstructie;

        private WaterskiBaan waterskiBaan;

        public Game()
        {
        }

        public void Initialize ()
        {
            //initialize our similation
            instructieGroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();
            wachtrijInstructie = new WachtrijInstructie();
            waterskiBaan = new WaterskiBaan();


        }
    }
}
