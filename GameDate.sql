DROP DATABASE IF EXISTS Info;
CREATE DATABASE Info;
USE Info;

CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(255),
	UserPassword VARCHAR(255)
);

INSERT INTO Userinfo (Username, UserPassword)
	VALUES ('Vincent', '1111'),
		   ('Baiyu', '2222'),
           ('Connor', '3333');

CREATE TABLE Inventory(	
	Username VARCHAR(255),
	Userinventory VARCHAR(1023)
);

INSERT INTO Inventory (Username, Userinventory)
	VALUES ('Vincent', 'aaaaaa'),
		   ('Baiyu', 'bbbbbb'),
           ('Connor', 'cccccc');

CREATE TABLE Market(
	MonsterID INT(11) AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(255),
	Monstername VARCHAR(255),
	Ask VARCHAR(255),
	HP INT(11),
	Attack INT(11)
);

INSERT INTO Market (Username, Monstername, Ask, HP, Attack)
	VALUES ('Vincent', 'Mewtwo', 'Mew', 100, 20),
		   ('Baiyu', 'Caterpie', 'Charizard', 5, 1),
           ('Connor', 'Weedle', 'Blastoise', 5, 1);

