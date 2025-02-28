using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Rhizome.Client;
using Rhizome.Client.Twirp;
using UnityEngine;

namespace Rhizome.Unity
{
	public static class TwirpResultExtensions
	{
		public static async void Then<T>(this Task<TwirpResult<T>> task, Action<T> onSuccess, Action<TwirpError> onError)
			where T: class, IMessage<T>
		{
			try
			{
				var result = await task;
				result.Then(onSuccess, onError);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}

		public static void Then<T>(this TwirpResult<T> result, Action<T> onSuccess, Action<TwirpError> onError)
			where T: class, IMessage<T>
		{
			if (result.IsOk)
			{
				onSuccess(result.Response);
			}
			else
			{
				onError(result.Error);
			}
		}
	}
}
