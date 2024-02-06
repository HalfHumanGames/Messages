﻿using System;
using System.Threading.Tasks;

namespace HHG.Messages
{
    public partial class Message
    {
        internal partial class DefaultAsync : IMessageAsync
        {
            private Default message = new Default();

            #region Publish

            public Task PublishAsync(object message)
            {
                this.message.Publish(message);
                return Task.CompletedTask;
            }

            public Task PublishAsync(object id, object message, PublishMode mode = PublishMode.Broadcast)
            {
                this.message.Publish(id, message, mode);
                return Task.CompletedTask;
            }

            public Task PublishToAsync(object id, object message)
            {
                this.message.PublishTo(id, message);
                return Task.CompletedTask;
            }

            #endregion

            #region Publish

            public Task<R[]> PublishAsync<R>(object message)
            {
                return Task.FromResult(this.message.Publish<R>(message));
            }

            public Task<R[]> PublishAsync<R>(object id, object message, PublishMode mode = PublishMode.Broadcast)
            {
                return Task.FromResult(this.message.Publish<R>(id, message, mode));
            }

            public Task<R[]> PublishToAsync<R>(object id, object message)
            {
                return Task.FromResult(this.message.PublishTo<R>(id, message));
            }

            #endregion

            #region Request

            public Task<R> PublishAsync<R>(IRequest<R> request)
            {
                return Task.FromResult(message.Publish(request));
            }

            public Task<R> PublishAsync<R>(object id, IRequest<R> request, PublishMode mode = PublishMode.Broadcast)
            {
                return Task.FromResult(message.Publish(id, request, mode));
            }

            public Task<R> PublishToAsync<R>(object id, IRequest<R> request)
            {
                return Task.FromResult(message.PublishTo(id, request));
            }

            #endregion

            #region Subscribe (Publishes)

            public Task SubscribeAsync<T>(Action<T> callback)
            {
                message.Subscribe(callback);
                return Task.CompletedTask;
            }

            public Task SubscribeAsync<T>(object id, Action<T> callback)
            {
                message.Subscribe(id, callback);
                return Task.CompletedTask;
            }

            public Task UnsubscribeAsync<T>(Action<T> callback)
            {
                message.Unsubscribe(callback);
                return Task.CompletedTask;
            }

            public Task UnsubscribeAsync<T>(object id, Action<T> callback)
            {
                message.Unsubscribe(id, callback);
                return Task.CompletedTask;
            }

            #endregion

            #region Subscribe (Publishs)

            public Task SubscribeAsync<T, R>(Func<T, R> callback)
            {
                message.Subscribe(callback);
                return Task.CompletedTask;
            }

            public Task SubscribeAsync<T, R>(object id, Func<T, R> callback)
            {
                message.Subscribe(id, callback);
                return Task.CompletedTask;
            }

            public Task UnsubscribeAsync<T, R>(Func<T, R> callback)
            {
                message.Unsubscribe(callback);
                return Task.CompletedTask;
            }

            public Task UnsubscribeAsync<T, R>(object id, Func<T, R> callback)
            {
                message.Unsubscribe(id, callback);
                return Task.CompletedTask;
            }

            #endregion
        }
    }
}