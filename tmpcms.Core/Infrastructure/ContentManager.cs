using System;
using System.Collections.Generic;
using tmpcms.Core.Infrastructure.Interfaces;

namespace tmpcms.Core.Infrastructure
{
	public class ContentManager
	{
		private readonly Dictionary<string, Type> contentTypes;

		public ContentManager(Dictionary<string, Type> contentTypes)
		{
			this.contentTypes = contentTypes;
		}

		public IContentItem LoadContentItem(Guid itemId)
		{
			// todo: загрузить из БД данные об элементе
			// todo: создать экземпляр нужного типа
			// todo: загрузить данные о его параметрах (смотреть на свойства) и заполнить свойства
			// todo: вернуть наружу

			throw new NotImplementedException();
		}
	}
}