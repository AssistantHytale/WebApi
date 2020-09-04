CREATE PROCEDURE [guide].[GetGuideContentWithSections]
    @guideContent uniqueidentifier   
AS
BEGIN
	SELECT * 
	FROM [dbo].[GuideContents] as guideC
	WHERE guideC.[Guid] = @guideContent;
	
	SELECT * 
	INTO #guideSections
	FROM [dbo].[GuideSections] as guideS
	WHERE guideS.[GuideContentGuid] = @guideContent
	ORDER BY guideS.SortOrder ASC;

	SELECT * FROM #guideSections;
	
	DECLARE @guideSectionCount INT = 0;
	select @guideSectionCount = COUNT(0) from #guideSections;
	
	DECLARE @guideSectionGuid uniqueidentifier;
	DECLARE @guideSectionIndx INT = 0;
	DECLARE FirstCursor CURSOR FOR SELECT [Guid] from #guideSections
	OPEN FirstCursor 
	WHILE @guideSectionIndx < @guideSectionCount
	BEGIN
		fetch FirstCursor into @guideSectionGuid;
		SELECT * 
		FROM [dbo].[GuideSectionItems] as guideI
		WHERE guideI.[GuideSectionGuid] = @guideSectionGuid
		ORDER BY guideI.SortOrder ASC;
	   SET @guideSectionIndx = @guideSectionIndx + 1;
	END;
   CLOSE FirstCursor 
   DEALLOCATE FirstCursor 
END
GO
