using LoanApp.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace LoanApp.Infrastructure.Services
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Action<object>>> _handlers;

        public InMemoryEventBus()
        {
            _handlers = new Dictionary<Type, List<Action<object>>>();
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : class
        {
            var eventType = typeof(TEvent);
            if (_handlers.ContainsKey(eventType))
            {
                foreach (var handler in _handlers[eventType])
                {
                    handler(@event);
                }
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : class
        {
            var eventType = typeof(TEvent);
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Action<object>>();
            }

            _handlers[eventType].Add(x => handler((TEvent)x));
        }
    }
}