using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcessionMediator mediator = new ConcessionMediator();

            NorthConcessionStand leftKitchen = new NorthConcessionStand(mediator);
            SouthConcessionStand rightKitchen = new SouthConcessionStand(mediator);

            mediator.NorthConcessions = leftKitchen;
            mediator.SouthConcessions = rightKitchen;

            leftKitchen.Send("Can you send some popcorn?");
            rightKitchen.Send("Sure thing ,Kenny's on his way .");
            leftKitchen.Send("Do you have any extra hot dogs? we 've had a rush on them over here.");
            rightKitchen.Send("Just a couple,we'll send Kenny back with them.");

            Console.ReadKey();
        }
    }

    interface Mediator
    {
        void SendMessage(string message, ConcessionStand concessionStand);
    }

    abstract class ConcessionStand
    {
        protected Mediator mediator;
        
        public ConcessionStand(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class NorthConcessionStand : ConcessionStand
    {
        public NorthConcessionStand(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            Console.WriteLine("North Concession stand send message : " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("North Concession stand gets message: " + message);
        }
    }
    class SouthConcessionStand : ConcessionStand
    {
        public SouthConcessionStand(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            Console.WriteLine("South Concession stand send message : " + message);
            mediator.SendMessage(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("South Concession stand gets message: " + message);
        }
    }

    class ConcessionMediator:Mediator
    {
        private NorthConcessionStand _northConcessions;
        private SouthConcessionStand _southConcessions;

        public NorthConcessionStand NorthConcessions
        {
            set { _northConcessions = value; }
        }
        public SouthConcessionStand SouthConcessions
        {
            set { _southConcessions = value; }
        }

        public void SendMessage(string message,ConcessionStand colleague)
        {
            if(colleague == _northConcessions)
            {
                _southConcessions.Notify(message);
            }
            else
            {
                _northConcessions.Notify(message);
            }
        }

    }

}
