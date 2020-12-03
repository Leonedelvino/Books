CREATE TABLE [dbo].[Article]
(
    [Id]                  INT            NOT NULL PRIMARY KEY,
	[FullTitle]           NVARCHAR       NOT NULL,
	[ShortTitle]          NVARCHAR       NULL,
	[DetailedDescription] NVARCHAR       NOT NULL,
	[ShortDescription]    NVARCHAR       NULL,
	[DatePosted]          DATETIME       NOT NULL,
	[DateLastModified]    DATETIME       NULL,
	[Author]              NVARCHAR       NOT NULL,
	[Redactor]            NVARCHAR       NULL,
	[Language]            NVARCHAR       NOT NULL,
	[Cover]               VARBINARY(MAX) NOT NULL,
	[CoversMimeType]      NVARCHAR       NULL,
	[ArticleSection]      VARCHAR(MAX)   NOT NULL,
	[BookId]              INT            NOT NULL,
    CONSTRAINT [FK_Article_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
)
