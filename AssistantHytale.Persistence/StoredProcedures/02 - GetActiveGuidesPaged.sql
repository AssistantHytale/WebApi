IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[guide].[GetActiveGuidesPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [import].[ImportPeopleManagement]
GO

CREATE PROCEDURE [guide].[GetActiveGuidesPaged]
    @page int,   
    @pageSize int  
AS
BEGIN
	IF(@page < 1) SET @page = 1;

	SELECT * 
	INTO #pagedActiveGuide
	FROM [dbo].[GuideDetails] AS gd
	WHERE gd.[Status] = 3
	ORDER BY gd.DateCreated
	OFFSET (@page - 1 * @pageSize) ROWS 
	FETCH NEXT @pageSize ROWS ONLY

	SELECT gd.*, u.Username, ut.Username AS Translator
	FROM #pagedActiveGuide AS gd
	INNER JOIN [dbo].[Users] AS u ON gd.UserGuid = u.Guid
	INNER JOIN [dbo].[Users] AS ut ON gd.TranslatorGuid = ut.Guid

	DROP TABLE #pagedActiveGuide;     
END