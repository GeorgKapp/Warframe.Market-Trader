using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warframe.Market_Api.Clients.Implementation
{
	/// <summary>
	/// Locks the amount of requests per unit of time
	/// Usage: useful for http requests to mitigate statuscode 429, also helps with stopping the amount of concurrent tasks to help balance load on the computer
	/// </summary>
	public class RequestLocker
	{
		public TimeUnit UnitOfTime { get; private set; }
		public int RequestLimit { get; private set; }

		private Queue<DateTime> _lockQueue;


		public RequestLocker(TimeUnit unitOfTime, int requestLimit)
		{
			UnitOfTime = unitOfTime;
			RequestLimit = requestLimit;
			_lockQueue = new Queue<DateTime>(requestLimit);
		}


		public async Task ReleaseAsync()
		{
			var requestTime = DateTime.Now;

			QueueAndDequeueExcess(requestTime);
			if (RequestLimit > _lockQueue.Count)
				return;

			var stackTime = _lockQueue.ElementAt(0);
			var difference = requestTime - stackTime;
			var timetoWait = TimeSpan.FromSeconds(0);

			switch (UnitOfTime)
			{
				case TimeUnit.Second:
					timetoWait = difference.TotalSeconds < 1 ? TimeSpan.FromSeconds(1).Subtract(difference) : TimeSpan.FromSeconds(0);
					break;
				case TimeUnit.Minute:
					timetoWait = difference.TotalMinutes < 1 ? TimeSpan.FromMinutes(1).Subtract(difference) : TimeSpan.FromSeconds(0);
					break;
				default:
					throw new NotImplementedException("Unit of time was not implemented");
			}

			await Task.Delay(timetoWait);
		}

		private void QueueAndDequeueExcess(DateTime date)
		{
			if (_lockQueue.Count == RequestLimit)
				_lockQueue.Dequeue();

			_lockQueue.Enqueue(date);
		}

		public enum TimeUnit
		{
			Minute,
			Second
		}
	}
}