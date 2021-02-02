CREATE TABLE [dbo].[Fundos]
(
    [CodigoDoSistema] INT NOT NULL, 
    [CNPJ] BIGINT NOT NULL, 
    [RazaoSocial] VARCHAR(255) NOT NULL, 
    [NomeFantasia] VARCHAR(140) NOT NULL, 
    [Gestor] VARCHAR(255) NOT NULL, 
    [Custodiante] VARCHAR(255) NOT NULL, 
    [Administrador] VARCHAR(255) NOT NULL, 
    [TaxaDeAdministracao] FLOAT NOT NULL, 
    [DiasParaLiquidacao] BIGINT NOT NULL, 
    [ResgateAutomatico] BIT NOT NULL,

	CONSTRAINT PK_CodigoDoSistema PRIMARY KEY ([CodigoDoSistema]),
	SysStartTime datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
	SysEndTime datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
	PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeeHistory, DATA_CONSISTENCY_CHECK = ON)
)
