using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Rhizome;
using UnityEngine;

namespace Rhizome.Unity
{
	public static class TwirpResultExtensions
	{
		public static async void HandleResult<T>(this Task<ApiResult<T>> task, Action<T> onSuccess, Action<ApiError> onError)
			where T: class, IMessage<T>
		{
			try
			{
				var result = await task;
				result.HandleResult(onSuccess, onError);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}
	}
}
