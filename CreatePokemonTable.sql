CREATE TABLE [dbo].[pokemon](
	[id] [int] NOT NULL,
	[nombre] [nvarchar](200) NOT NULL,
	[altura] [int] NOT NULL,
	[peso] [int] NOT NULL,
	[tipos] [nvarchar](200) NOT NULL,
	[ImagenUrl] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

