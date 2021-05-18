using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task.Classes
{
    class Repository
    {
        public Repository(Queue<Subscriber> subscribers)
        {
            this.subscribers = subscribers;
        }

        public Queue<Subscriber> subscribers { get; }


        public Subscriber getBySurname(string surname) => GetSubscriberByPredicate(new Predicate<Subscriber>(x => x.surname == surname));

        public Subscriber GetByPhoneNumber(string phoneNumber) => GetSubscriberByPredicate(new Predicate<Subscriber>(x => x.phoneNumber == phoneNumber));

        public Subscriber GetSubscriberByPredicate(Predicate<Subscriber> predicate)
        {
            Subscriber need_subscriber = null;

            var new_Queue = new Queue<Subscriber>();

            while (subscribers.Count > 0)
            {
                var subscriber = subscribers.Dequeue();
                if (predicate(subscriber)) need_subscriber = subscriber;

                new_Queue.Enqueue(subscriber);
            }

            while (new_Queue.Count > 0)
            {
                var subscriber = new_Queue.Dequeue();
                subscribers.Enqueue(subscriber);
            }

            return need_subscriber;
        }


        public string getString()
        {
            var str = "Surname\tPhone Number\n";

            while (subscribers.Count > 0)
            {
                var subscriber = subscribers.Dequeue();

                str += $"{subscriber.surname}\t{subscriber.phoneNumber}\n";
            }

            return str;
        }

    }
}
