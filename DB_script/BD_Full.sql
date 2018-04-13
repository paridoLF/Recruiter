USE [Recruit_DB]
GO
/****** Object:  User [Recruit_Admin]    Script Date: 13/4/2018 17:03:41 ******/
CREATE USER [Recruit_Admin] FOR LOGIN [Recruit_Admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Recruit_Recluter]    Script Date: 13/4/2018 17:03:41 ******/
CREATE USER [Recruit_Recluter] FOR LOGIN [Recruit_Recluter] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Recruit_Admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Recruit_Recluter]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Recruit_Recluter]
GO
/****** Object:  Table [dbo].[t_adm_empresa]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_adm_empresa](
	[PKEMPRESA] [int] NOT NULL,
	[NOMBREEMPRESA] [nvarchar](50) NOT NULL,
	[DIRECCIONEMPRESA] [nvarchar](50) NULL,
	[TELEFONOEMPRESA] [nvarchar](15) NULL,
	[EMAILEMPRESA] [nvarchar](50) NULL,
	[CONTACTOEMPRESA] [nvarchar](50) NULL,
	[ESTADOEMPRESA] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_OFERTA_RECLUTADOR]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_OFERTA_RECLUTADOR](
	[PKOFERTATRABAJO] [int] NOT NULL,
	[PKRECLUTADOR] [int] NOT NULL,
 CONSTRAINT [PK_T_OFERTA_RECLUTADOR] PRIMARY KEY CLUSTERED 
(
	[PKOFERTATRABAJO] ASC,
	[PKRECLUTADOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_candidatos]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_candidatos](
	[PKCANDIDATO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](50) NOT NULL,
	[ESTADO] [int] NOT NULL,
	[TELEFONO] [nvarchar](10) NOT NULL,
	[CORREO] [nvarchar](50) NOT NULL,
	[BLACKLIST] [bit] NOT NULL,
	[DIRECCION] [nvarchar](50) NOT NULL,
	[AÑOSEXPERIENCIA] [int] NOT NULL,
	[ESTADOCIVIL] [int] NOT NULL,
 CONSTRAINT [PK_t_rec_candidatos] PRIMARY KEY CLUSTERED 
(
	[PKCANDIDATO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_candmail]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_candmail](
	[PKCANDMAIL] [int] IDENTITY(1,1) NOT NULL,
	[CORREO] [nvarchar](50) NOT NULL,
	[FILENAME] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_t_rec_candmail] PRIMARY KEY CLUSTERED 
(
	[PKCANDMAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_detmailkword]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_detmailkword](
	[PKDETMAILKWORD] [int] IDENTITY(1,1) NOT NULL,
	[FKCANDMAIL] [int] NOT NULL,
	[FKKWORD] [int] NOT NULL,
 CONSTRAINT [PK_t_rec_detmailkword] PRIMARY KEY CLUSTERED 
(
	[PKDETMAILKWORD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_entrevista]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_entrevista](
	[PKENTREVISTA] [int] IDENTITY(1,1) NOT NULL,
	[EXPERIENCIAENTREVITA] [varchar](500) NOT NULL,
	[TRABAJOANTENTREVISTA] [varchar](500) NOT NULL,
	[REFERENCIASENTREVISTA] [varchar](500) NOT NULL,
	[EXPECTSALENTREVISTA] [numeric](18, 0) NOT NULL,
	[FKCANDIDATO] [int] NOT NULL,
	[FKESTADO] [int] NOT NULL,
	[FKIDIOMA] [int] NOT NULL,
	[FKPROBABILIDAD] [int] NOT NULL,
 CONSTRAINT [PK_t_rec_entrevista] PRIMARY KEY CLUSTERED 
(
	[PKENTREVISTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_estado]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_estado](
	[PKESTADO] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCIONESTADO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_rec_estado] PRIMARY KEY CLUSTERED 
(
	[PKESTADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_idioma]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_idioma](
	[PKIDIOMA] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCIONIDIOMA] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_t_rec_idioma] PRIMARY KEY CLUSTERED 
(
	[PKIDIOMA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_keyword]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_keyword](
	[PKKWORD] [int] IDENTITY(1,1) NOT NULL,
	[KEYWORD] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_t_rec_keyword] PRIMARY KEY CLUSTERED 
(
	[PKKWORD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_REC_OFERTA_TRABAJO]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_REC_OFERTA_TRABAJO](
	[PKOFERTATRABAJO] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[LABORES] [varchar](200) NULL,
	[IDIOMA] [varchar](20) NULL,
	[NIVEL_IDIOMA] [int] NULL,
	[CONOCIMIENTOS_REQ] [varchar](200) NULL,
	[CONOCIMIENTOS_DES] [varchar](200) NULL,
	[BENEFICIOS_LAB] [varchar](200) NOT NULL,
	[SALARIO] [numeric](13, 2) NULL,
	[EMPRESA] [int] NULL,
 CONSTRAINT [PK_T_REC_OFERTAS_TRABAJO] PRIMARY KEY CLUSTERED 
(
	[PKOFERTATRABAJO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_rec_probabilidad]    Script Date: 13/4/2018 17:03:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_rec_probabilidad](
	[PKPROBABILIDAD] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCIONPROBABILIDAD] [varchar](100) NULL,
 CONSTRAINT [PK_t_rec_probabilidad] PRIMARY KEY CLUSTERED 
(
	[PKPROBABILIDAD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_RECLUTADOR]    Script Date: 13/4/2018 17:03:41 ******/
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
/****** Object:  Table [dbo].[t_seg_bitacora]    Script Date: 13/4/2018 17:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_seg_bitacora](
	[PKBITACORA] [int] NOT NULL,
	[ACCIONBITACORA] [nvarchar](50) NOT NULL,
	[TABLABITACORA] [nvarchar](50) NOT NULL,
	[FECHABITACORA] [datetime] NOT NULL,
	[REGISTROBITACORA] [text] NOT NULL,
	[PAGINABITACORA] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_SEG_BITACORA] PRIMARY KEY CLUSTERED 
(
	[PKBITACORA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_seg_menu]    Script Date: 13/4/2018 17:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_seg_menu](
	[PKMENU] [int] NOT NULL,
	[ETIQUETAMENU] [nvarchar](150) NOT NULL,
	[URLMENU] [nvarchar](500) NOT NULL,
	[STATUREGISTER] [bit] NOT NULL,
	[FKROL] [int] NOT NULL,
 CONSTRAINT [PK_T_SEG_MENU] PRIMARY KEY CLUSTERED 
(
	[PKMENU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_seg_rol]    Script Date: 13/4/2018 17:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_seg_rol](
	[PKROL] [int] NOT NULL,
	[NOMBREROL] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_T_SEG_ROL] PRIMARY KEY CLUSTERED 
(
	[PKROL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_seg_usuario]    Script Date: 13/4/2018 17:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_seg_usuario](
	[PKUSUARIO] [int] NOT NULL,
	[NOMBREUSUARIO] [nvarchar](500) NOT NULL,
	[LOGINUSUARIO] [nvarchar](50) NOT NULL,
	[PASSWORDUSUARIO] [nvarchar](500) NOT NULL,
	[CEDULAUSUARIO] [nvarchar](50) NOT NULL,
	[ACTIVOUSUARIO] [bit] NOT NULL,
	[STATUSREGISTER] [bit] NOT NULL,
	[FKROL] [int] NOT NULL,
 CONSTRAINT [PK_T_SEG_USUARIO] PRIMARY KEY CLUSTERED 
(
	[PKUSUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_adm_empresa] ADD  CONSTRAINT [DF_t_adm_empresa_DIRECCIONEMPRESA]  DEFAULT (N'Sin Información') FOR [DIRECCIONEMPRESA]
GO
ALTER TABLE [dbo].[t_adm_empresa] ADD  CONSTRAINT [DF_t_adm_empresa_TELEFONOEMPRESA]  DEFAULT (N'Sin Información') FOR [TELEFONOEMPRESA]
GO
ALTER TABLE [dbo].[t_adm_empresa] ADD  CONSTRAINT [DF_t_adm_empresa_EMAILEMPRESA]  DEFAULT (N'Sin Información') FOR [EMAILEMPRESA]
GO
ALTER TABLE [dbo].[t_adm_empresa] ADD  CONSTRAINT [DF_t_adm_empresa_CONTACTOEMPRESA]  DEFAULT (N'Sin Información') FOR [CONTACTOEMPRESA]
GO
ALTER TABLE [dbo].[t_adm_empresa] ADD  CONSTRAINT [DF_t_adm_empresa_ESTADOEMPRESA]  DEFAULT ((1)) FOR [ESTADOEMPRESA]
GO
ALTER TABLE [dbo].[t_seg_menu] ADD  CONSTRAINT [DF_T_SEG_MENU_STATUREGISTER]  DEFAULT ((1)) FOR [STATUREGISTER]
GO
ALTER TABLE [dbo].[t_seg_usuario] ADD  CONSTRAINT [DF_T_SEG_USUARIO_ACTIVOUSUARIO]  DEFAULT ((1)) FOR [ACTIVOUSUARIO]
GO
ALTER TABLE [dbo].[t_seg_usuario] ADD  CONSTRAINT [DF_T_SEG_USUARIO_STATUSREGISTER]  DEFAULT ((1)) FOR [STATUSREGISTER]
GO
ALTER TABLE [dbo].[t_rec_detmailkword]  WITH CHECK ADD  CONSTRAINT [FK_t_rec_detmailkword_t_rec_candmail] FOREIGN KEY([FKCANDMAIL])
REFERENCES [dbo].[t_rec_candmail] ([PKCANDMAIL])
GO
ALTER TABLE [dbo].[t_rec_detmailkword] CHECK CONSTRAINT [FK_t_rec_detmailkword_t_rec_candmail]
GO
ALTER TABLE [dbo].[t_rec_detmailkword]  WITH CHECK ADD  CONSTRAINT [FK_t_rec_detmailkword_t_rec_keyword] FOREIGN KEY([FKKWORD])
REFERENCES [dbo].[t_rec_keyword] ([PKKWORD])
GO
ALTER TABLE [dbo].[t_rec_detmailkword] CHECK CONSTRAINT [FK_t_rec_detmailkword_t_rec_keyword]
GO
ALTER TABLE [dbo].[t_rec_entrevista]  WITH CHECK ADD  CONSTRAINT [FK_t_rec_entrevista_t_rec_estado] FOREIGN KEY([FKESTADO])
REFERENCES [dbo].[t_rec_estado] ([PKESTADO])
GO
ALTER TABLE [dbo].[t_rec_entrevista] CHECK CONSTRAINT [FK_t_rec_entrevista_t_rec_estado]
GO
ALTER TABLE [dbo].[t_rec_entrevista]  WITH CHECK ADD  CONSTRAINT [FK_t_rec_entrevista_t_rec_idioma] FOREIGN KEY([FKIDIOMA])
REFERENCES [dbo].[t_rec_idioma] ([PKIDIOMA])
GO
ALTER TABLE [dbo].[t_rec_entrevista] CHECK CONSTRAINT [FK_t_rec_entrevista_t_rec_idioma]
GO
ALTER TABLE [dbo].[t_rec_entrevista]  WITH CHECK ADD  CONSTRAINT [FK_t_rec_entrevista_t_rec_probabilidad] FOREIGN KEY([FKPROBABILIDAD])
REFERENCES [dbo].[t_rec_probabilidad] ([PKPROBABILIDAD])
GO
ALTER TABLE [dbo].[t_rec_entrevista] CHECK CONSTRAINT [FK_t_rec_entrevista_t_rec_probabilidad]
GO
ALTER TABLE [dbo].[t_seg_menu]  WITH CHECK ADD  CONSTRAINT [FK_T_SEG_MENU_T_SEG_ROL] FOREIGN KEY([FKROL])
REFERENCES [dbo].[t_seg_rol] ([PKROL])
GO
ALTER TABLE [dbo].[t_seg_menu] CHECK CONSTRAINT [FK_T_SEG_MENU_T_SEG_ROL]
GO
ALTER TABLE [dbo].[t_seg_usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_SEG_USUARIO_T_SEG_ROL] FOREIGN KEY([FKROL])
REFERENCES [dbo].[t_seg_rol] ([PKROL])
GO
ALTER TABLE [dbo].[t_seg_usuario] CHECK CONSTRAINT [FK_T_SEG_USUARIO_T_SEG_ROL]
GO
