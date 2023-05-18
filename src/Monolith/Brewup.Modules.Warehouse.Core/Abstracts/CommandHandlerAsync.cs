﻿using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;

namespace Brewup.Modules.Warehouse.Core.Abstracts;

public abstract class CommandHandlerAsync<TCommand> : ICommandHandlerAsync<TCommand> where TCommand : class, ICommand
{
	protected readonly IRepository Repository;
	protected readonly ILogger Logger;

	protected CommandHandlerAsync(IRepository repository,
		ILoggerFactory loggerFactory)
	{
		Repository = repository ?? throw new ArgumentNullException(nameof(repository));
		Logger = loggerFactory.CreateLogger(GetType());
	}

	public abstract Task HandleAsync(TCommand command,
		CancellationToken cancellationToken = new());

	#region Dispose
	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~CommandHandlerAsync()
	{
		Dispose(false);
	}
	#endregion
}