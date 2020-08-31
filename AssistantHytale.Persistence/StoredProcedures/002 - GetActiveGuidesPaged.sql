IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[guide].[GetActiveGuidesPaged]') AND type in (N'P', N'PC'))
DROP PROCEDURE [import].[ImportPeopleManagement]
GO

CREATE PROCEDURE [guide].[GetActiveGuidesPaged]
    @page int,   
    @pageSize int,
	@langCode varchar(10) = ''
AS
BEGIN
	DECLARE @HasLangCodeSpecified BIT = NULL;

/*=================== System Parameter Clean up ======================== */
	IF(@page < 1) SET @page = 1;

	IF(@PageSize IS NULL OR @PageSize <= 0)
		SET @PageSize = 20;

/*=================== Parameter Clean up ======================== */
	IF(@langCode IS NOT NULL AND RTRIM(LTRIM(@langCode)) <> '')
		BEGIN
			SET @HasLangCodeSpecified = 1;
		END

/*========================= Base Query ======================== */
		
	SELECT * 
	INTO #tmpData
	FROM [dbo].[GuideDetails] AS gd
	WHERE gd.[Status] = 3
	ORDER BY gd.DateCreated

/*========================= Filter data Set ======================== */
	DECLARE @tmpFilteredIds TABLE([Guid] UNIQUEIDENTIFIER);/*used for filtering data rows*/
	DECLARE @tmpfilter TABLE([Guid] UNIQUEIDENTIFIER);/*temp filter to update @tmpFilteredIds*/
	
	INSERT INTO @tmpFilteredIds
	SELECT DISTINCT TD.[Guid]
	FROM #tmpData AS TD
			
	--Filter - @langCode
	IF(@HasLangCodeSpecified = 1)
	BEGIN
		INSERT INTO
			@tmpfilter		
		SELECT DISTINCT
			TD.[Guid]
		FROM 
			#tmpData TD
			INNER JOIN @tmpFilteredIds tmp on tmp.[Guid] = TD.[Guid]
		WHERE
			TD.LanguageCode = @langCode
			
		--Empty @tmpFilteredIds for new values
		DELETE FROM
			@tmpFilteredIds;		
		--Add new filter values to @tmpFilteredIds
		INSERT INTO 
			@tmpFilteredIds
		SELECT [Guid] FROM @tmpfilter;
		DELETE FROM @tmpfilter;
	END

	SELECT dat.* 
	INTO #tmpOut
	FROM #tmpData dat
		INNER JOIN @tmpFilteredIds filteredIds ON filteredIds.[Guid] = dat.[Guid]

	SELECT @page AS 'CurrentPage', CEILING(COUNT(0) / @pageSize) AS 'TotalPages', COUNT(0) as 'TotalRows'
	FROM #tmpOut;

	SELECT * 
	INTO #paged
	FROM #tmpOut AS gd
	ORDER BY gd.DateCreated
	OFFSET ((@page - 1) * @pageSize) ROWS 
	FETCH NEXT @pageSize ROWS ONLY

	SELECT gd.*, u.Username, ut.Username AS Translator
	FROM #paged AS gd
	INNER JOIN [dbo].[Users] AS u ON gd.UserGuid = u.Guid
	INNER JOIN [dbo].[Users] AS ut ON gd.TranslatorGuid = ut.Guid
	
	DROP TABLE #tmpData; 
	DROP TABLE #tmpOut;     
	DROP TABLE #paged;     
END

