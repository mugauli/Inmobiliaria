CREATE TABLE [dbo].[proveedor] (
    [idproveedor]      INT           IDENTITY (1, 1) NOT NULL,
    [razon_social]     VARCHAR (150) NOT NULL,
    [sector_comercial] VARCHAR (50)  NOT NULL,
    [tipo_documento]   VARCHAR (20)  NOT NULL,
    [num_documento]    VARCHAR (11)  NOT NULL,
    [direccion]        VARCHAR (100) NULL,
    [telefono]         VARCHAR (10)  NULL,
    [email]            VARCHAR (50)  NULL,
    [url]              VARCHAR (100) NULL,
    CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED ([idproveedor] ASC)
);

