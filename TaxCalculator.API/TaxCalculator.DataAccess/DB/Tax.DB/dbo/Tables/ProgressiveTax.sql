CREATE TABLE [dbo].[ProgressiveTax] (
    [ProgressiveTaxId] INT             IDENTITY (1, 1) NOT NULL,
    [Rate]             DECIMAL (18, 6) NOT NULL,
    [LowerBound]       DECIMAL (18, 6) NOT NULL,
    [UpperBound]       DECIMAL (18, 6) NULL,
    CONSTRAINT [PK_ProgressiveTax] PRIMARY KEY CLUSTERED ([ProgressiveTaxId] ASC)
);

