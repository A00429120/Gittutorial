USE [PROJECT]
GO

/****** Object:  Table [dbo].[CARD]    Script Date: 28-11-2018 02:20:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CARD](
	[CREDIT_CARD_NO] [nvarchar] (50) NOT NULL,
	[CARD_TYPE] [nvarchar] (50) NOT NULL,
	[NAME_ON_CARD] [nvarchar](max) NOT NULL,
	[EXP_DATE] [nvarchar](10) NOT NULL,
	[CID] [bigint] NOT NULL,
 CONSTRAINT [PK_CARD] PRIMARY KEY CLUSTERED 
(
	[CREDIT_CARD_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CARD]  WITH CHECK ADD  CONSTRAINT [FK_CID_CUS_CARD] FOREIGN KEY([CID])
REFERENCES [dbo].[CUSTOMER] ([CID])
GO

ALTER TABLE [dbo].[CARD] CHECK CONSTRAINT [FK_CID_CUS_CARD]
GO

