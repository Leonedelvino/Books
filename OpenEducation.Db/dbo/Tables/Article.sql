CREATE TABLE [dbo].[Article]
(
    [Id]                  INT            NOT NULL PRIMARY KEY,
	[Title]               NVARCHAR       NULL,
	[Description]         NVARCHAR       NOT NULL,
	[DatePosted]          DATETIME       NOT NULL,
	[DateLastModified]    DATETIME       NULL,
	[Author]              NVARCHAR       NOT NULL,
	[Redactor]            NVARCHAR       NULL,
	[Language]            INT            NOT NULL,
	[Cover]               VARBINARY(MAX) NOT NULL,
	[ArticleSection]      VARCHAR(MAX)   NOT NULL,
	[BookId]              INT            NOT NULL,
    CONSTRAINT [FK_Article_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
)
