IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_mt_customer_cat_AC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[mt_customer_cat] DROP CONSTRAINT [DF_mt_customer_cat_AC]
END

GO

/****** Object:  Table [dbo].[mt_customer_cat]    Script Date: 03/13/2017 16:25:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mt_customer_cat]') AND type in (N'U'))
DROP TABLE [dbo].[mt_customer_cat]
GO


/****** Object:  Table [dbo].[mt_customer_cat]    Script Date: 03/13/2017 16:25:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mt_customer_cat](
	[customer_cat_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_cat_code] [nvarchar](50) NOT NULL,
	[customer_cat_name] [nvarchar](50) NOT NULL,
	[AC] [bit] NOT NULL,
	[CO] [smalldatetime] NOT NULL,
	[CB] [nvarchar](50) NOT NULL,
	[MO] [smalldatetime] NOT NULL,
	[MB] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_mt_customer_cat_1] PRIMARY KEY CLUSTERED 
(
	[customer_cat_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[mt_customer_cat] ADD  CONSTRAINT [DF_mt_customer_cat_AC]  DEFAULT ((0)) FOR [AC]
GO


