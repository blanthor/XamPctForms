﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamPctForms.DAL
{
    // original source: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases#create-a-database-access-class
    public static class TaskExtensions
    {
        // NOTE: Async void is intentional here. This provides a way
        // to call an async method from the constructor while
        // communicating intent to fire and forget, and allow
        // handling of exceptions
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }

            // if the provided action is not null, catch and
            // pass the thrown exception
            catch (Exception ex) when (onException != null) //TODO: Is an Action appropriate?
            {
                onException(ex);
            }
        }
    }
}
