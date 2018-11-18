DROP DATABASE IF EXISTS Info;
CREATE DATABASE Info;
USE Info;

CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY KEY,
	Username VARCHAR(255),
	UserPassword VARCHAR(255)
);

CREATE TABLE Inventory(	
	Username VARCHAR(255),
    Userinventory VARCHAR(1023)
);

CREATE TABLE Market(
    Username VARCHAR(255),
	Monstername VARCHAR(255),
    Ask VARCHAR(255),
	HP INT(11),
	Attack INT(11)
);

