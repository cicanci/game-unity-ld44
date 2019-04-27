using System;
using System.Collections.Generic;

namespace Asteroids.Message
{
    public class MessageManager
    {
        private readonly Dictionary<Type, List<Delegate>> _listeners;
        
        private static MessageManager _instance;

        public static MessageManager Instance
        {
            get { return _instance ?? (_instance = new MessageManager()); }
        }

        private MessageManager()
        {
            _listeners = new Dictionary<Type, List<Delegate>>();
        }

        public void SendMessage(object message)
        {
            List<Delegate> messages = null;
            if(_listeners.TryGetValue(message.GetType(), out messages))
            {
                for(int i = 0; i < messages.Count; i++)
                {
                    messages[i].DynamicInvoke(message);
                }
            }
        }

        public void AddListener<T>(Action<T> message)
        {
            List<Delegate> messages = null;
            if(_listeners.TryGetValue(typeof(T), out messages))
            {
                messages.Add(message);
            }
            else
            {
                messages = new List<Delegate> { message };
                _listeners.Add(typeof(T), messages);
            }
        }

        public void RemoveListener<T>(Action<T> message)
        {
            List<Delegate> messages = null;
            if(_listeners.TryGetValue(typeof(T), out messages))
            {
                messages.Remove(message);
            }
        }
    }
}