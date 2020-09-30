CREATE TABLE [dbo].[tblLote] (
    [idlote]    INT           IDENTITY (1, 1) NOT NULL,
    [norte]     VARCHAR (50)  NOT NULL,
    [sur]       VARCHAR (50)  NULL,
    [este]      VARCHAR (50)  NULL,
    [oeste]     VARCHAR (50)  NULL,
    [medidas]   VARCHAR (50)  NULL,
    [ubicacion] VARCHAR (300) NOT NULL,
    [imagen]    IMAGE         NULL,
    [idParcela] VARCHAR (10)  NOT NULL,
    [estatus]   VARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_tblLote] PRIMARY KEY CLUSTERED ([idlote] ASC),
    CONSTRAINT [FK_tblLote_Parcela] FOREIGN KEY ([idParcela]) REFERENCES [dbo].[tblParcela] ([IdParcela])
);

