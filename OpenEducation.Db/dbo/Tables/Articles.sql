CREATE TABLE [dbo].[Articles]
(
    [Id]                  INT               NOT NULL PRIMARY KEY,
	[Title]               NVARCHAR          NULL,
	[Description]         NVARCHAR          NOT NULL,
	[DatePosted]          DATETIME          NOT NULL,
	[DateLastModified]    DATETIME          NULL,
	[Author]              NVARCHAR          NOT NULL,
	[Redactor]            NVARCHAR          NULL,
	[Language]            INT               NOT NULL,
	[ArticleSection]      VARCHAR(MAX)      NOT NULL,
	[CoverPath]           VARCHAR           NOT NULL,
	[BookId]              INT               NOT NULL,
    CONSTRAINT [FK_Articles_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id]),
)
