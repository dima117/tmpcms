namespace tmpcms.Core.Infrastructure
{
	interface IContentType
	{
		object Execute(ItemContext context);
	}
}
