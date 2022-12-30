namespace Microservice.Smart.Services.Common.Constants
{
	public class SqlConstants
	{
		public const string MicroserviceTypeFilterQuery = " AND t.Title = '{0}'";

		public const string MicroserviceCategoryFilterQuery = " AND c.Title = '{0}'";

		public const string GetSmartMicroservicesSql = @"SELECT 
	sm.Id,
	Name,
	TypeId,
	t.Title TypeTitle,
	CategoryId,
	c.Title CategoryTitle
FROM tblSmartMicroservice sm 
INNER JOIN tblType t ON t.Id = sm.TypeId
INNER JOIN tblCategory c ON c.Id = sm.CategoryId
WHERE (sm.Id = @Id OR ISNULL(@Id,'')='') AND (sm.Name = @Name OR ISNULL(@Name,'') = '') ";

	}
}
