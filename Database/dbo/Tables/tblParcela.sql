CREATE TABLE [dbo].[tblParcela] (
    [IdParcela]     VARCHAR (10)  NOT NULL,
    [Nombre]        VARCHAR (50)  NOT NULL,
    [Cp]            VARCHAR (13)  NULL,
    [Colonia]       VARCHAR (10)  NULL,
    [DelMunc]       VARCHAR (10)  NULL,
    [Observaciones] VARCHAR (200) NULL,
    CONSTRAINT [PK_tblParcela] PRIMARY KEY CLUSTERED ([IdParcela] ASC)
);

