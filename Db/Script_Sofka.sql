CREATE DATABASE sofka_juego
GO
USE sofka_juego
GO
CREATE TABLE category
(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre NVARCHAR(20) NOT NULL
)
GO
CREATE TABLE question
(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	texto NVARCHAR(225) NOT NULL,
	category_id INT REFERENCES category(id) NOT NULL
)
GO
CREATE TABLE answer
(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	texto NVARCHAR(125) NOT NULL,
	points SMALLINT NOT NULL DEFAULT 0,
	question_id INT NOT NULL REFERENCES question(id) ON UPDATE CASCADE
)
GO
CREATE TABLE usuario
(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	user_text NVARCHAR(15) NOT NULL UNIQUE,
	password_name NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE player
(
	id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nombre NVARCHAR(125) NOT NULL,
	usuario_id INT REFERENCES usuario(id) NOT NULL,
	fecha_nacimiento DATE NOT NULL,
	max_points INT NOT NULL DEFAULT 0

)
GO
INSERT INTO category(nombre) 
VALUES
('Geografia'),
('Programacion'),
('Matematica'),
('Historia'),
('Entretenimiento')
GO
INSERT INTO usuario(user_text,password_name) 
VALUES('mary','12345')
GO
INSERT INTO player
(nombre,fecha_nacimiento,usuario_id)
VALUES('Mary Luz Giraldo','1992-05-9',1)
GO
SELECT pl.id,pl.nombre,pl.fecha_nacimiento, pl.max_points FROM usuario AS us 
                        INNER JOIN player AS pl 
                        ON pl.usuario_id = us.id 
                        WHERE us.user_text = 'mary' AND us.password_name='12345'