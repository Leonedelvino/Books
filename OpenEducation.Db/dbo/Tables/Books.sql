CREATE TABLE [dbo].[Books] (
    [Id]          INT              IDENTITY(1,1) NOT NULL,
    [Name]        NVARCHAR (200)                 NOT NULL,
    [Author]      NVARCHAR (150)                 NOT NULL,
    [Description] NVARCHAR (MAX)                 NULL,
    [Date]        DATE                           NOT NULL,
    [Language]    INT                            NOT NULL,
    [CoverPath]       NVARCHAR (2048)                NULL,
    [Type]        INT                            NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC), 
);