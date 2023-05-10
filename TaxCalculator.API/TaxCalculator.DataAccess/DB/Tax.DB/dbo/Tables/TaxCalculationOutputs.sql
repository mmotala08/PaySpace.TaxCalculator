CREATE TABLE [dbo].[TaxCalculationOutputs] (
    [TaxCalculationOutputId] INT             IDENTITY (1, 1) NOT NULL,
    [PostalCode]             NVARCHAR (10)   NOT NULL,
    [AnnualIncome]           DECIMAL (18, 6) NOT NULL,
    [TaxValue]               DECIMAL (18, 6) NOT NULL,
    [CreatedDate]            DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_TaxCalculationOutputs] PRIMARY KEY CLUSTERED ([TaxCalculationOutputId] ASC)
);

