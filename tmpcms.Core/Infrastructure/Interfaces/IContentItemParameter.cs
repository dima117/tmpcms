using System;

namespace tmpcms.Core.Infrastructure.Interfaces
{
	interface IContentItemParameter
	{
		Guid Id { get; set; }

		Guid ItemId { get; set; }

		string Name { get; set; }
	}
}