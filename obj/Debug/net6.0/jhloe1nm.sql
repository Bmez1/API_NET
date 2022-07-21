IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categorias] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [CreateBy] nvarchar(max) NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cursos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [DescripcionCorta] nvarchar(280) NOT NULL,
    [DescripcionLarga] nvarchar(max) NOT NULL,
    [Nivel] int NOT NULL,
    [CreateBy] nvarchar(max) NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Estudiantes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellidos] nvarchar(max) NOT NULL,
    [CreateBy] nvarchar(max) NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Estudiantes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [CreateBy] nvarchar(max) NOT NULL,
    [UpdateBy] nvarchar(max) NOT NULL,
    [DeleteBy] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [CategoriaCurso] (
    [CategoriasId] int NOT NULL,
    [CursosId] int NOT NULL,
    CONSTRAINT [PK_CategoriaCurso] PRIMARY KEY ([CategoriasId], [CursosId]),
    CONSTRAINT [FK_CategoriaCurso_Categorias_CategoriasId] FOREIGN KEY ([CategoriasId]) REFERENCES [Categorias] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CategoriaCurso_Cursos_CursosId] FOREIGN KEY ([CursosId]) REFERENCES [Cursos] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [CursoEstudiante] (
    [CursosId] int NOT NULL,
    [EstudiantesId] int NOT NULL,
    CONSTRAINT [PK_CursoEstudiante] PRIMARY KEY ([CursosId], [EstudiantesId]),
    CONSTRAINT [FK_CursoEstudiante_Cursos_CursosId] FOREIGN KEY ([CursosId]) REFERENCES [Cursos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CursoEstudiante_Estudiantes_EstudiantesId] FOREIGN KEY ([EstudiantesId]) REFERENCES [Estudiantes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_CategoriaCurso_CursosId] ON [CategoriaCurso] ([CursosId]);
GO

CREATE INDEX [IX_CursoEstudiante_EstudiantesId] ON [CursoEstudiante] ([EstudiantesId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220721184127_Iniciando el esquema de la base de datos', N'6.0.7');
GO

COMMIT;
GO

