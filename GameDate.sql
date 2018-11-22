DROP DATABASE IF EXISTS Info;
CREATE DATABASE Info;
USE Info;

CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(255),
	UserPassword VARCHAR(255)
);

INSERT INTO Userinfo (Username, UserPassword)
	VALUES ('vincent', '1111'),
		   ('baiyu', '2222'),
           ('connor', '3333');

CREATE TABLE Inventory(	
	Username VARCHAR(255),
	Userinventory VARCHAR(1023),
    Login BOOLEAN NOT NULL,
    InThread BOOLEAN NOT NULL
);

INSERT INTO Inventory (Username, Userinventory, Login, InThread)
	VALUES ('vincent', '{"InventoryList":[0]}', false, false),
		   ('baiyu', '{"InventoryList":[0]}', false, false),
           ('connor', '{"InventoryList":[0,2]}', false, false);

CREATE TABLE Market(
	MonsterID INT(11) AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(255),
	Monstername VARCHAR(255),
	Ask VARCHAR(255),
	HP INT(11),
	Attack INT(11)
);

INSERT INTO Market (Username, Monstername, Ask, HP, Attack)
	VALUES ('vincent', 'BLOB', 'Long', 100, 20),
		   ('baiyu', 'Long', 'BLOB', 5, 1),
           ('connor', 'Char_Star', 'BLOB', 5, 1);
