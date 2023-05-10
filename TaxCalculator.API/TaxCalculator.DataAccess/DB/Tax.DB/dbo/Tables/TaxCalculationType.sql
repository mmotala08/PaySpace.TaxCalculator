CREATE TABLE [dbo].[TaxCalculationType] (
    [TaxTypeId]       INT           IDENTITY (1, 1) NOT NULL,
    [PostalCode]      NVARCHAR (10) NOT NULL,
    [CalculationType] INT           NOT NULL,
    CONSTRAINT [PK_TaxCalculationType] PRIMARY KEY CLUSTERED ([TaxTypeId] ASC)
);

