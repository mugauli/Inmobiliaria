CREATE TABLE [dbo].[Pagos] (
    [idpagos]      INT             NOT NULL,
    [idventa]      INT             NOT NULL,
    [monto]        DECIMAL (18, 2) NOT NULL,
    [fecha]        DATE            NOT NULL,
    [nmensualidad] INT             NOT NULL,
    [morosidad]    BIT             NOT NULL,
    CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED ([idpagos] ASC),
    CONSTRAINT [FK_Pagos_venta] FOREIGN KEY ([idventa]) REFERENCES [dbo].[venta] ([idventa])
);

