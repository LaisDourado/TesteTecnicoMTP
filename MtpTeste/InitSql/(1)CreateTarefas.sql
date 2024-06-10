CREATE DATABASE ListaDeTarefas
GO

USE ListaDeTarefas

CREATE TABLE Tarefas(
	TarefaId bigint IDENTITY(1,1) Primary Key,
	Titulo VARCHAR(50) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	Concluido bit NOT NULL 
);
GO

INSERT INTO Tarefas (Titulo, Descricao, Concluido) VALUES ('Primeira tarefa do dia.', 'Teste 1', 0), ('Segunda tarefa do dia.', 'Teste 2', 0), ('Terceira tarefa do dia.', 'Teste 3', 0), ('Quarta tarefa do dia.', 'Teste 4', 1), ('Quinta tarefa do dia.', 'Teste 5', 0);

SELECT * FROM Tarefas;
