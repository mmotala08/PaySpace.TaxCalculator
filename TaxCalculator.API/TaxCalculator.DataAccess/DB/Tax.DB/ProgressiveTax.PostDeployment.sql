SET IDENTITY_INSERT [dbo].[ProgressiveTax] ON 

GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (1, CAST(10.000000 AS Decimal(18, 6)), CAST(0.000000 AS Decimal(18, 6)), CAST(8350.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (2, CAST(15.000000 AS Decimal(18, 6)), CAST(8350.000000 AS Decimal(18, 6)), CAST(33950.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (3, CAST(25.000000 AS Decimal(18, 6)), CAST(33950.000000 AS Decimal(18, 6)), CAST(82250.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (4, CAST(28.000000 AS Decimal(18, 6)), CAST(82250.000000 AS Decimal(18, 6)), CAST(171550.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (5, CAST(33.000000 AS Decimal(18, 6)), CAST(171550.000000 AS Decimal(18, 6)), CAST(372950.000000 AS Decimal(18, 6)))
GO
INSERT [dbo].[ProgressiveTax] ([ProgressiveTaxId], [Rate], [LowerBound], [UpperBound]) VALUES (7, CAST(35.000000 AS Decimal(18, 6)), CAST(372950.000000 AS Decimal(18, 6)), NULL)
GO
SET IDENTITY_INSERT [dbo].[ProgressiveTax] OFF
GO