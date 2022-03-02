﻿using System;
using System.Threading.Tasks;

namespace Framework.CircuitBreakers.States
{
    internal interface ICircuitBreakerState
    {
        void Enter();
        void InvocationFails();
        void InvocationSucceeds();
        void Invoke(Action action);
        T Invoke<T>(Func<T> func);
        Task<T> InvokeAsync<T>(Func<Task<T>> func);
    }
}