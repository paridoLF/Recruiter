USE [Recruit_DB]
GO

/****** Object:  Table [dbo].[T_RECLUTADOR]    Script Date: 13/4/2018 14:32:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_RECLUTADOR](
	[PKRECLUTADOR] [int] NOT NULL,
	[NOMBRERECLUTADOR] [varchar](50) NULL,
	[TELEFONORECLUTADOR] [varchar](20) NULL,
	[CORREORECLUTADOR] [varchar](50) NULL,
	[ESTADORECLUTADOR] [int] NULL,
 CONSTRAINT [PK_T_ADM_RECLUTADORES] PRIMARY KEY CLUSTERED 
(
	[PKRECLUTADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


